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
