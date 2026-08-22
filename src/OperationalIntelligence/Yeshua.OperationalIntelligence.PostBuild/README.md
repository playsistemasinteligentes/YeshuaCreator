# Post-Build Gate

Executor transitorio do gate tecnico R05. Ele nao roda dentro da API Central e
nao adiciona custo ao runtime dos aplicativos.

Execute a partir da raiz do repositorio:

```powershell
dotnet run --project .\src\OperationalIntelligence\Yeshua.OperationalIntelligence.PostBuild\Yeshua.OperationalIntelligence.PostBuild.csproj -- `
  --manifest .\tests\CQRS\Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke\Migration\PostBuildManifest.json `
  --commit <commit-publicado>
```

O endereco base e lido do `appsettings.json` do projeto de smoke tests. Ele pode
ser substituido na execucao pela variavel `TESTSETTINGS__BASEURL`.

O comando retorna `0` somente quando todas as verificacoes obrigatorias passam.
O relatorio e o log integral do smoke CRUD ficam em
`artifacts/post-build/<Aplicativo>`.

`--skip-smoke` existe apenas para diagnostico parcial e sempre reprova o gate,
pois nao produz evidencia de CRUD nem das dependencias exercitadas por ele.
