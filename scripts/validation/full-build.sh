#!/usr/bin/env bash
# Mesma validacao local e no CI; nenhuma whitelist de projetos nem tolerancia a erro.
set -euo pipefail
validation_root=$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")/../.." && pwd)
cd "$validation_root"
validation_logs=${1:-"$validation_root/.artifacts/pr-validation"}
mkdir -p "$validation_logs"
validation_logs=$(cd "$validation_logs" && pwd)
dotnet --info | tee "$validation_logs/dotnet-info.log"
dotnet restore YeshuaCreator.sln --disable-parallel --verbosity minimal 2>&1 | tee "$validation_logs/restore.log"
dotnet build YeshuaCreator.sln --no-restore --configuration Release --verbosity minimal -m:2 -nr:false 2>&1 | tee "$validation_logs/build.log"
