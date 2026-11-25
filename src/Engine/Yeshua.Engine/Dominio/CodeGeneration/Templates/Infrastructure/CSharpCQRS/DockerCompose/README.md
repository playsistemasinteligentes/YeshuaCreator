# Template Docker Compose Do CSharpCQRS

Este diretorio contem a infraestrutura inicial padrao de um aplicativo gerado
pelo schema `CSharpCQRS`.

O template e usado apenas para iniciar a infraestrutura de um aplicativo. Apos
a copia, os arquivos pertencem ao aplicativo e nao devem ser sobrescritos pela
Engine.

Tokens esperados durante a inicializacao:

- `{{APPLICATION_NAME}}`: nome do aplicativo.
- `{{APPLICATION_SLUG}}`: prefixo dos servicos do aplicativo.
- `{{COMPOSE_PROJECT_NAME}}`: nome isolado do projeto Compose.
- `{{DATABASE_NAME}}`: catalogo SQL do aplicativo.
- `{{API_PROJECT_PATH}}`: caminho do projeto da API.
- `{{API_ASSEMBLY}}`: assembly executavel da API.
- `{{FRONT_PROJECT_PATH}}`: caminho do projeto do Front.
- `{{FRONT_ASSEMBLY}}`: assembly executavel do Front.
- `{{WORKER_PROJECT_PATH}}`: caminho do projeto do Worker.
- `{{WORKER_ASSEMBLY}}`: assembly executavel do Worker.
- `{{STUDIO_PROJECT_PATH}}`: caminho do projeto de Studio usado nas migrations.
- `{{STUDIO_ASSEMBLY}}`: assembly executavel do Studio.

O template contem apenas API, Front, Worker e Migration. SQL Server, Redis,
RabbitMQ, nginx, certificados e a rede pertencem ao Shared do servidor.

Particularidades como workers externos, imagens de IA, rotas, credenciais e
recursos exclusivos devem ser editadas diretamente na copia do aplicativo.

Senhas nao sao tokens de substituicao nem valores para copiar ao template.
Conexoes, JWT e RabbitMQ sao referencias obrigatorias de ambiente. Ao adotar
este template para um app novo, registrar explicitamente seu target/mapeamento
no leitor `infra/private/credentials.py` e configurar Apps.<App> no JSON privado.
Nao executar o template com placeholders nem adicionar fallback secreto.

O cadastro operacional e por aplicativo/banco, nao por cada `AddModule` de
dominio. Um modulo novo dentro de um aplicativo existente nao implica outro
catalogo ou alias. `CSharpCQRS`/Studio nao alteram o Compose Shared existente nem
o arquivo privado; a infraestrutura e inicializada explicitamente e sua copia
continua sob responsabilidade do aplicativo/operador.

Na inclusao de um aplicativo novo, conferir tambem:

- `DB_KEYS` e o target em `infra/private/credentials.py`;
- a referencia vazia em `Shared.OperationalIntelligence.DatabaseQueries` do
  exemplo privado, sem deduzir catalogo, credencial ou connection string;
- a referencia `Mcp__DatabaseQuery__Connections__<Alias>` no Compose operacional
  e sua correspondencia no importador/exportador;
- o teste de cobertura dos aliases em
  `tests/Infrastructure/PrivateConfig/test_compose_configuration.py`.

Proposta para evoluir o scaffolding: na primeira inicializacao explicita de
infraestrutura, emitir um checklist/fragmento de referencias para esse cadastro
e validar sua cobertura antes do deploy. Nao registrar aliases automaticamente
durante migrations de dominio nem sobrescrever Shared ou configuracao privada.
O teste de cobertura ja detecta aplicativo adicionado em DB_KEYS sem alias no
Compose; a emissao automatica desse checklist fica como evolucao futura.
