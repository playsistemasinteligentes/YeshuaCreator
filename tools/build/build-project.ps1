[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string]$Project,

    [string]$Configuration = "Debug",

    [switch]$Restore,

    [switch]$ShowWarnings,

    [int]$TimeoutSeconds = 0,

    [string]$LogDirectory = "artifacts/build-logs",

    [string[]]$ExtraArgs = @()
)

$ErrorActionPreference = "Stop"

function Get-RepoRoot {
    return (Resolve-Path -LiteralPath (Join-Path $PSScriptRoot "..\..")).Path
}

function Invoke-LoggedDotnet {
    param(
        [string[]]$Arguments,
        [string]$LogFile,
        [int]$TimeoutSeconds
    )

    $tempBase = Join-Path ([System.IO.Path]::GetTempPath()) ("yeshua-dotnet-" + [guid]::NewGuid().ToString("N"))
    $stdoutFile = "$tempBase.out"
    $stderrFile = "$tempBase.err"
    $timedOut = $false

    try {
        $process = Start-Process -FilePath "dotnet" `
            -ArgumentList $Arguments `
            -NoNewWindow `
            -RedirectStandardOutput $stdoutFile `
            -RedirectStandardError $stderrFile `
            -PassThru

        if ($TimeoutSeconds -gt 0) {
            $completed = $process.WaitForExit($TimeoutSeconds * 1000)
            if (-not $completed) {
                $timedOut = $true
                $process.Kill()
                $process.WaitForExit()
            }
        }
        else {
            $process.WaitForExit()
        }

        $output = if (Test-Path -LiteralPath $stdoutFile) { Get-Content -LiteralPath $stdoutFile -Raw } else { "" }
        $errors = if (Test-Path -LiteralPath $stderrFile) { Get-Content -LiteralPath $stderrFile -Raw } else { "" }
        if ($null -eq $output) { $output = "" }
        if ($null -eq $errors) { $errors = "" }
        $combined = (@($output.TrimEnd(), $errors.TrimEnd()) |
            Where-Object { -not [string]::IsNullOrWhiteSpace($_) }) -join [Environment]::NewLine

        if ($timedOut) {
            $combined = (@($combined.TrimEnd(), "TIMEOUT: comando encerrado apos $TimeoutSeconds segundos.") |
                Where-Object { -not [string]::IsNullOrWhiteSpace($_) }) -join [Environment]::NewLine
        }

        Set-Content -LiteralPath $LogFile -Value $combined -Encoding UTF8

        if ($timedOut) {
            return [pscustomobject]@{ ExitCode = 124; TimedOut = $true }
        }

        return [pscustomobject]@{ ExitCode = $process.ExitCode; TimedOut = $false }
    }
    finally {
        Remove-Item -LiteralPath $stdoutFile, $stderrFile -Force -ErrorAction SilentlyContinue
    }
}

$repoRoot = Get-RepoRoot
Set-Location -LiteralPath $repoRoot

$projectPath = (Resolve-Path -LiteralPath $Project).Path
$logDirectoryPath = if ([System.IO.Path]::IsPathRooted($LogDirectory)) {
    $LogDirectory
}
else {
    Join-Path $repoRoot $LogDirectory
}

New-Item -ItemType Directory -Force -Path $logDirectoryPath | Out-Null

$timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
$projectName = [System.IO.Path]::GetFileNameWithoutExtension($projectPath) -replace "[^\w\.-]", "_"
$logFile = Join-Path $logDirectoryPath "$timestamp-build-$projectName.log"

$dotnetArgs = @(
    "build",
    $projectPath,
    "-c",
    $Configuration,
    "-m:1",
    "-nr:false",
    "-v:minimal",
    "-p:UseAppHost=false"
)

if (-not $Restore) {
    $dotnetArgs += "--no-restore"
}

if ($ShowWarnings) {
    $dotnetArgs += "-clp:Summary"
}
else {
    $dotnetArgs += "-clp:ErrorsOnly"
}

$dotnetArgs += $ExtraArgs

$result = Invoke-LoggedDotnet -Arguments $dotnetArgs -LogFile $logFile -TimeoutSeconds $TimeoutSeconds
$lines = if (Test-Path -LiteralPath $logFile) { @(Get-Content -LiteralPath $logFile) } else { @() }
$errorLines = @($lines | Where-Object { $_ -match "(: error [A-Z]+[0-9]+:| error [A-Z]+[0-9]+ |Build FAILED|Unhandled exception|Exception)" })
$warningLines = @($lines | Where-Object { $_ -match ":\s*warning\s+[A-Z]+[0-9]+:" })

Write-Host "Build: $projectPath"
Write-Host "Log:   $logFile"

if ($result.TimedOut) {
    Write-Host "Status: TIMEOUT apos $TimeoutSeconds segundos"
}
elseif ($result.ExitCode -eq 0) {
    Write-Host "Status: OK"
}
else {
    Write-Host "Status: FALHOU com exit code $($result.ExitCode)"
}

if ($errorLines.Count -gt 0) {
    Write-Host ""
    Write-Host "Erros relevantes:"
    $errorLines | Select-Object -First 120 | ForEach-Object { Write-Host $_ }
    if ($errorLines.Count -gt 120) {
        Write-Host "... mais $($errorLines.Count - 120) linhas no log completo."
    }
}

if ($ShowWarnings -and $warningLines.Count -gt 0) {
    Write-Host ""
    Write-Host "Warnings encontrados: $($warningLines.Count)"
    $warningLines | Select-Object -First 60 | ForEach-Object { Write-Host $_ }
    if ($warningLines.Count -gt 60) {
        Write-Host "... mais $($warningLines.Count - 60) warnings no log completo."
    }
}

exit $result.ExitCode
