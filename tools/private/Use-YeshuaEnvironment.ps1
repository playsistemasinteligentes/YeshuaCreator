[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [ValidateSet('Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias')]
    [string]$Application,
    [string]$File = (Join-Path $env:USERPROFILE '.yeshua/private/development/credentials.json'),
    [string]$Python = $(if ($env:YESHUA_PYTHON) { $env:YESHUA_PYTHON } else { 'python' }),
    [ValidateSet('Smoke', 'Seed')]
    [string]$TestProfile,
    [string[]]$Command = @()
)
$ErrorActionPreference = 'Stop'
$repo = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../..'))
$target = if ($Application -eq 'APS.ADM') { 'aps-adm' } else { $Application.ToLowerInvariant() }
$suffix = if ($Application -eq 'APS.ADM') { 'APS_ADM' } else { $Application.ToUpperInvariant() }
$options = @()
if ($TestProfile) { $options = @('--test-profile', $TestProfile) }
$lines = & $Python (Join-Path $repo 'infra/private/credentials.py') export --file $File --target $target @options
if ($LASTEXITCODE -ne 0) { throw 'Configuracao privada nao carregada. Nenhum aplicativo foi iniciado.' }
$values = @{}
foreach ($line in $lines) {
    $parts = $line.Split("`t", 2)
    if ($parts.Count -ne 2 -or $parts[0] -notmatch '^[A-Z][A-Z0-9_]*$') { throw 'Saida de configuracao invalida.' }
    $values[$parts[0]] = [Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($parts[1]))
}
if (-not $TestProfile) {
    $values['MYCONFIG__READCONECTIONSTRING'] = $values["YESHUA_SQL_${suffix}_READ"]
    $values['MYCONFIG__WRITECONECTIONSTRING'] = $values["YESHUA_SQL_${suffix}_WRITE"]
    $values['MYCONFIG__CENTRALAUTHORIZATIONCONECTIONSTRING'] = $values['YESHUA_SQL_CENTRAL_AUTHORIZATION']
    $values['JwtSettings__SecretKey'] = $values['YESHUA_JWT_SECRET']
    $values['RabbitMq__UserName'] = $values['YESHUA_RABBITMQ_USERNAME']
    $values['RabbitMq__Password'] = $values['YESHUA_RABBITMQ_PASSWORD']
    $values['YeshuaModules__Authentication__SharedKey'] = $values['YESHUA_MODULE_SHARED_KEY']
    $values['UploadTokens__SigningKey'] = $values['YESHUA_CLINICA_UPLOAD_SIGNING_KEY']
    $values['MemoriasYouTube__ClientId'] = $values['YESHUA_MEMORIAS_YOUTUBE_CLIENT_ID']
    $values['MemoriasYouTube__ClientSecret'] = $values['YESHUA_MEMORIAS_YOUTUBE_CLIENT_SECRET']
    $values['MemoriasYouTube__EncryptionKey'] = $values['YESHUA_MEMORIAS_YOUTUBE_ENCRYPTION_KEY']
    $values['MemoriasYouTube__CredentialsDirectory'] = Join-Path $values['YESHUA_MEMORIAS_PRIVATE_ROOT'] 'accounts'
    $values['MemoriasYouTube__RedirectUri'] = if ($values['YESHUA_MEMORIAS_YOUTUBE_REDIRECT_URI']) { $values['YESHUA_MEMORIAS_YOUTUBE_REDIRECT_URI'] } else { $null }
    $values['MemoriasYouTube__ConfigurationAdminTenantId'] = if ($values['YESHUA_MEMORIAS_CONFIG_ADMIN_TENANT_ID']) { $values['YESHUA_MEMORIAS_CONFIG_ADMIN_TENANT_ID'] } else { $null }
    $values['MemoriasYouTube__ConfigurationAdminUserId'] = if ($values['YESHUA_MEMORIAS_CONFIG_ADMIN_USER_ID']) { $values['YESHUA_MEMORIAS_CONFIG_ADMIN_USER_ID'] } else { $null }
}
$previous = @{}
foreach ($key in $values.Keys) {
    $previous[$key] = [Environment]::GetEnvironmentVariable($key, 'Process')
    [Environment]::SetEnvironmentVariable($key, $values[$key], 'Process')
}
if ($Command.Count) {
    try {
        [string[]]$commandArguments = @()
        if ($Command.Count -gt 1) { $commandArguments = $Command[1..($Command.Count - 1)] }
        & $Command[0] @commandArguments
        if ($LASTEXITCODE -ne 0) { throw 'O processo iniciado retornou erro.' }
    } finally {
        foreach ($key in $previous.Keys) { [Environment]::SetEnvironmentVariable($key, $previous[$key], 'Process') }
    }
} else {
    Write-Host "Configuracao carregada na sessao para $Application. Valores omitidos."
}
