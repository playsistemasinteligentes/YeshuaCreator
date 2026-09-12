# Build E Teste Com Saida Curta

Estes scripts reduzem o ruido de compilacao e teste para uso local e para o Codex.
O log completo continua sendo salvo em `artifacts/build-logs`.

## Build De Um Projeto

```powershell
.\tools\build\build-project.ps1 .\src\CQRS\Infrastructure\Yeshua.Clinica.CQRS.Infrastructure.Api\Yeshua.Clinica.CQRS.Infrastructure.Api.csproj
```

Por padrao o script usa `--no-restore`, `ErrorsOnly` e imprime apenas resumo e erros relevantes.

Para ver warnings:

```powershell
.\tools\build\build-project.ps1 .\src\CQRS\Infrastructure\Yeshua.Clinica.CQRS.Infrastructure.Api\Yeshua.Clinica.CQRS.Infrastructure.Api.csproj -ShowWarnings
```

Para permitir restore:

```powershell
.\tools\build\build-project.ps1 .\src\CQRS\Infrastructure\Yeshua.Clinica.CQRS.Infrastructure.Api\Yeshua.Clinica.CQRS.Infrastructure.Api.csproj -Restore
```

## Teste De Um Projeto

```powershell
.\tools\build\test-project.ps1 .\tests\CQRS\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.csproj
```

Por padrao o teste roda com `--no-build` e timeout de 120 segundos.

Com filtro:

```powershell
.\tools\build\test-project.ps1 .\tests\CQRS\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.csproj -Filter "FullyQualifiedName~NomeDoTeste"
```

Com build antes do teste:

```powershell
.\tools\build\test-project.ps1 .\tests\CQRS\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.csproj -Build
```
