param([string]$DashboardPath)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($DashboardPath))
{
    $dashboardPaths = Get-ChildItem -LiteralPath (Join-Path $PSScriptRoot 'grafana/dashboards') -Filter '*.json' -File |
        Select-Object -ExpandProperty FullName
}
else
{
    $dashboardPaths = @($DashboardPath)
}

if (-not $dashboardPaths -or $dashboardPaths.Count -eq 0)
{
    throw 'Nenhum dashboard versionado foi encontrado.'
}

foreach ($currentDashboardPath in $dashboardPaths)
{
if (-not (Test-Path -LiteralPath $currentDashboardPath -PathType Leaf))
{
    throw "Dashboard nao encontrado: $currentDashboardPath"
}

$dashboard = Get-Content -Raw -LiteralPath $currentDashboardPath | ConvertFrom-Json -Depth 100
$errors = [System.Collections.Generic.List[string]]::new()

if (-not $dashboard.panels -or $dashboard.panels.Count -eq 0)
{
    $errors.Add('O dashboard nao possui paineis.')
}

$duplicateIds = $dashboard.panels.id | Group-Object | Where-Object Count -gt 1
foreach ($duplicateId in $duplicateIds)
{
    $errors.Add("ID de painel duplicado: $($duplicateId.Name).")
}

foreach ($panel in $dashboard.panels)
{
    $prefix = "Painel $($panel.id) - $($panel.title)"

    if ([string]::IsNullOrWhiteSpace($panel.title))
    {
        $errors.Add("Painel $($panel.id) sem titulo.")
    }

    if ([string]::IsNullOrWhiteSpace($panel.description))
    {
        $errors.Add("$prefix sem descricao operacional.")
    }
    elseif ($panel.description -notmatch '\*\*O que mede:\*\*' -or
            $panel.description -notmatch '\*\*Como interpretar:\*\*')
    {
        $errors.Add("$prefix deve explicar 'O que mede' e 'Como interpretar'.")
    }

    if (-not $panel.targets -or $panel.targets.Count -eq 0)
    {
        $errors.Add("$prefix sem consulta.")
        continue
    }

    $duplicateRefs = $panel.targets.refId | Group-Object | Where-Object Count -gt 1
    foreach ($duplicateRef in $duplicateRefs)
    {
        $errors.Add("$prefix possui refId duplicado: $($duplicateRef.Name).")
    }

    foreach ($target in $panel.targets)
    {
        if ([string]::IsNullOrWhiteSpace($target.expr))
        {
            $errors.Add("$prefix possui consulta vazia em $($target.refId).")
        }

        if ($target.expr -match 'container_memory_percent' -and
            $target.expr -match '100\s*\*')
        {
            $errors.Add("$prefix multiplica container_memory_percent por 100, mas a metrica ja chega em percentual.")
        }
    }

    if ($null -eq $panel.gridPos -or
        $panel.gridPos.w -le 0 -or
        $panel.gridPos.h -le 0 -or
        $panel.gridPos.x -lt 0 -or
        ($panel.gridPos.x + $panel.gridPos.w) -gt 24)
    {
        $errors.Add("$prefix possui gridPos invalido.")
    }
}

for ($leftIndex = 0; $leftIndex -lt $dashboard.panels.Count; $leftIndex++)
{
    for ($rightIndex = $leftIndex + 1; $rightIndex -lt $dashboard.panels.Count; $rightIndex++)
    {
        $left = $dashboard.panels[$leftIndex]
        $right = $dashboard.panels[$rightIndex]
        $leftGrid = $left.gridPos
        $rightGrid = $right.gridPos

        $overlap =
            $leftGrid.x -lt ($rightGrid.x + $rightGrid.w) -and
            ($leftGrid.x + $leftGrid.w) -gt $rightGrid.x -and
            $leftGrid.y -lt ($rightGrid.y + $rightGrid.h) -and
            ($leftGrid.y + $leftGrid.h) -gt $rightGrid.y

        if ($overlap)
        {
            $errors.Add("Paineis sobrepostos: $($left.id) e $($right.id).")
        }
    }
}

if ($errors.Count -gt 0)
{
    throw "Dashboard invalido:`n- $($errors -join "`n- ")"
}

Write-Host "Dashboard valido: $([System.IO.Path]::GetFileName($currentDashboardPath)) - $($dashboard.panels.Count) paineis com contrato operacional e layout consistente."
}
