# Post-Build Gate

Executor dos gates tecnicos e da homologacao operacional R16. Ele nao roda
dentro da API Central e nao adiciona custo ao runtime dos aplicativos.

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

## Homologacao G1-G7

O relatorio sempre apresenta G1 a G7. Gates sem evidencia ficam como `Missing`;
evidencia obrigatoria que falhou ou foi ignorada deixa o gate como `Failed`.
Use `--require-gates` na homologacao final para permitir aprovacao somente
quando todos os gates estiverem `Passed`.

O manifesto pode relacionar arquivos de evidencia produzidos pelos testes de
sucesso, rejeicao, falha, propagacao, protecao de dados, consulta central e D2:

```json
{
  "gateEvidenceFiles": [
    "artifacts/operational/Fiscal-gates.json"
  ]
}
```

Formato do arquivo:

```json
{
  "evidence": [
    {
      "gate": "G6",
      "name": "DirectedD2",
      "status": "Passed",
      "evidence": "D2 atingiu somente a operacao autorizada e expirou no limite.",
      "required": true
    }
  ]
}
```

O runner nao deduz conformidade pela existencia de arquivos. Cada evidencia
deve declarar o gate e o resultado; arquivos ausentes, gate desconhecido e
status diferente de `Passed` permanecem visiveis no relatorio.
