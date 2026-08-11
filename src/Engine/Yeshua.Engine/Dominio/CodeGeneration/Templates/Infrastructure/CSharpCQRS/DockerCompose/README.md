# Template Docker Compose Do CSharpCQRS

Este diretorio contem a infraestrutura inicial padrao de um aplicativo gerado
pelo schema `CSharpCQRS`.

O template e usado apenas para iniciar a infraestrutura de um aplicativo. Apos
a copia, os arquivos pertencem ao aplicativo e nao devem ser sobrescritos pela
Engine.

Tokens esperados durante a inicializacao:

- `{{APPLICATION_NAME}}`: nome do aplicativo.
- `{{DATABASE_NAME}}`: catalogo SQL do aplicativo.
- `{{PUBLIC_BASE_URL}}`: endereco publico usado pelo storage.
- `{{SA_PASSWORD}}`: senha inicial do SQL Server.
- `{{RABBITMQ_USER}}`: usuario inicial do RabbitMQ.
- `{{RABBITMQ_PASSWORD}}`: senha inicial do RabbitMQ.
- `{{API_PROJECT_PATH}}`: caminho do projeto da API.
- `{{API_ASSEMBLY}}`: assembly executavel da API.
- `{{FRONT_PROJECT_PATH}}`: caminho do projeto do Front.
- `{{FRONT_ASSEMBLY}}`: assembly executavel do Front.
- `{{WORKER_PROJECT_PATH}}`: caminho do projeto do Worker.
- `{{WORKER_ASSEMBLY}}`: assembly executavel do Worker.
- `{{STUDIO_PROJECT_PATH}}`: caminho do projeto de Studio usado nas migrations.
- `{{STUDIO_ASSEMBLY}}`: assembly executavel do Studio.

Particularidades como workers externos, imagens de IA, portas publicas,
credenciais e recursos exclusivos devem ser editadas diretamente na copia do
aplicativo.
