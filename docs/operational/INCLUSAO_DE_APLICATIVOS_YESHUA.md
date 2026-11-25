# Inclusão de aplicativos no Yeshua

Um aplicativo novo precisa percorrer especificação, geração, preparação de
infraestrutura, configuração privada, implantação e primeiro acesso. A migration
participa dessa esteira preparando o banco e as definições de autorização. O
deploy existente coordena a implantação. Hoje essas peças existem, mas sua
integração ainda exige um checklist; não há um comando que cadastre todos os
pontos automaticamente.

Este roteiro trata de um aplicativo com Studio, API, Worker e banco próprios.
Adicionar um módulo de domínio com `AddModule` dentro de um aplicativo existente
não exige outro banco, outro Compose ou outro alias SQL.

## O que cada etapa já faz

| Etapa | Caminho existente | Resultado e limite |
| --- | --- | --- |
| Especificação e geração | Studio, `MigrationBuilder`, `CSharpCQRS` | Consolida a DSL e gera as bordas, preservando as customizações. Não configura o servidor. |
| Banco do aplicativo | Studio `--database-only`, `UnitOfWork(connection, true)` e `SqlServerSchema` | Cria o catálogo configurado quando ausente e aplica as migrations pelo histórico. Requer conexão explícita e privilégio suficiente para essa operação. |
| Definições de autorização | `CentralAuthorizationSchema`, quando registrado pelo Studio | Projeta módulos, scopes e direitos declarados na DSL, com histórico por aplicativo e migration. Não concede acesso a usuários ou tenants. |
| Infraestrutura inicial | Templates Docker Compose da Engine | São uma base para cópia explícita. A infraestrutura copiada pertence ao aplicativo; a geração normal não a mantém sincronizada. |
| Configuração privada | `infra/private/credentials.py` e `infra/docker/load-deploy-env.sh` | Validam e exportam a configuração existente. Não geram credenciais nem descobrem novos aplicativos sozinhos. |
| Implantação | `infra/docker/deploy.sh` e Compose de cada aplicativo | Atualizam o Git, constroem as imagens, executam a migration, sobem os serviços e reconciliam o gateway. Os destinos estão registrados explicitamente. |
| Primeiro acesso | Catálogo e concessões da Central, login e `getMenu` | Habilitam a entrada do tenant e o provisionamento local pelo caminho existente. Ter um banco criado não basta para autorizar o usuário. |
| Inicialização particular | Command de bootstrap do próprio aplicativo, quando houver | Cria os dados iniciais específicos mediante escolha explícita do operador. Não deve ser confundida com migration nem repetida em todo deploy. |

O `MigrationBuilder` só executa os schemas que o Studio registra. A existência
de `CentralAuthorizationSchema` na Engine não faz todos os Studios usá-lo.

## Sequência para incluir um aplicativo

1. **Definir a identidade.** Registrar nome do aplicativo, Studio, prefixo de
   rota, nome Compose e catálogo SQL. Conferir conflitos de nomes, portas e
   dependências. API e Worker devem usar o mesmo escopo de processamento.
2. **Declarar e gerar as bordas.** Usar a DSL e os geradores existentes; compilar
   os projetos e revisar as customizações. Geração de código acontece na
   preparação do produto, fora da migration executada no servidor.
3. **Preparar a migration de instalação.** O modo `--database-only` deve receber
   a conexão do aplicativo, aplicar seu histórico e registrar a projeção de
   autorização na Central quando o aplicativo declarar essas definições. A
   Central é pré-requisito da projeção; concessões a tenants permanecem separadas.
4. **Completar a infraestrutura do aplicativo.** Adaptar a cópia do template
   para API, Worker e Migration. No ambiente atual, a Central fornece o Front
   compartilhado. Templates que ainda incluem um Front individual precisam
   dessa adaptação; não publicar outro Front por aplicativo.
5. **Registrar os pontos compartilhados.** Atualizar o target do deploy, a
   inclusão no destino `all`, as dependências do gateway, as rotas Nginx, o
   catálogo `applications.json` e os assets do Front Central. Atualizar também
   as listas de destinos da ponte MCP quando o aplicativo puder ser implantado
   individualmente.
6. **Preparar a configuração privada.** Registrar `APPS`/`DB_KEYS`, o exemplo
   sem valores reais, `Apps.<Aplicativo>` e o alias explícito em
   `Shared.OperationalIntelligence.DatabaseQueries`. Conferir a referência
   correspondente no Compose operacional. Conexões, chaves e atores escolhidos
   pelo operador continuam no mesmo JSON privado, fora do Git.
7. **Validar antes de implantar.** Executar a leitura privada para os destinos
   afetados, a exportação consumida pelo shell, a interpretação do Compose, os
   testes dos aliases e do fluxo de deploy, além da compilação e sintaxe das
   rotas. Usar dados sintéticos nos testes de infraestrutura. Validar o JSON
   isoladamente não comprova que o Bash e o Compose aceitam sua exportação.
8. **Entregar o código no Git.** Commit, push e merge devem disponibilizar na
   main as correções necessárias ao comando oficial de deploy. Uma ordem de
   aguardar o deploy não impede essa entrega quando o Git estiver autorizado.
9. **Implantar quando autorizado.** Usar o orquestrador oficial, que executa a
   migration antes de subir os hosts. No primeiro deploy, a ordem deve respeitar
   SQL e Central, aplicativo e, por último, suas rotas. Não substituir o roteiro
   por cópia de fontes ou pela execução manual de pedaços desconexos.
10. **Validar acesso e operação.** Conferir saúde, versão, catálogo, login,
    autorização do tenant e `getMenu`. Executar o bootstrap particular somente
    quando necessário e autorizado. Depois conferir telemetria, consulta SQL,
    cobertura de backup e indexação de fontes para a Inteligência Operacional.

### Compatibilidade durante a preparação

A configuração ativa precisa ser compreendida pelo código que está instalado.
Novos campos podem passar na validação do JSON e ainda quebrar um carregador
antigo. Preparar uma alteração não autoriza ativar esse perfil antecipadamente.
O roteiro deve determinar a revisão mínima do carregador e o momento de
atualização do arquivo privado na janela autorizada de implantação.

Na tentativa de 25/11/2026, o perfil Presença já estava no arquivo privado, mas
o servidor ainda usava o carregador anterior. A primeira chave rejeitada foi
`Presenca__Enabled`; o filtro do Bash aceitava apenas nomes em maiúsculas. A
correção do PR #68 separa a exportação para shell da configuração de runtime do
aplicativo. Repetir o deploy antes de disponibilizar essa correção na main não
resolveria o problema.

## O que ainda precisa ser organizado

A menor evolução é reforçar os pontos existentes, nesta ordem:

1. **Uniformizar a instalação dos Studios.** Usar o mesmo caminho explícito para
   banco e projeção de autorização. Conferir a ligação no Studio, sem copiar
   SQL de cadastro para scripts de deploy nem criar usuários automaticamente.
2. **Completar o checklist do template.** Cada novo aplicativo deve sair da
   preparação com seus registros de deploy, configuração, rota, catálogo e
   diagnóstico identificados. O template atual já lista parte dos aliases;
   falta cobrir a esteira inteira e apontar para este roteiro.
3. **Ampliar as verificações existentes antes do build.** Conferir a coerência
   entre aplicativo registrado, configuração exportada, Compose, target, rota
   e catálogo. Aproveitar os testes e a validação privada atuais, sem criar um
   segundo instalador ou outro cadastro universal de aplicativos.
4. **Exercitar instalação inicial e repetição.** Após autorização, comprovar a
   criação em um banco exclusivo e um segundo deploy preservando dados,
   concessões e configurações. Bootstrap particular requer teste separado,
   porque nem todo bootstrap existente aceita repetição.

Esses itens são o plano de evolução. Este roteiro não adiciona um verificador
automático nem transfere responsabilidades de Docker, Nginx ou segredos para
a migration de domínio.

## Situação do Presença

- O PR #68 integrou o carregador corrigido, Compose, rotas e destinos de deploy.
  Isso disponibiliza a infraestrutura no Git; não comprova implantação no VPS.
- O Studio Presença registra `SqlServerSchema` e `CentralAuthorizationSchema`
  em `--database-only`. As conexões de escrita local e de autorização da Central
  são obrigatórias antes de abrir o banco. Sua DSL declara o módulo `PRESENCA`
  e o scope `presenca.editorial`, projetados com histórico pela Engine. As
  concessões de acesso ao tenant continuam sendo uma etapa explícita.
- O perfil privado já contém banco exclusivo, escopo, ator técnico e bootstrap
  escolhidos pelo operador. Essa configuração não representa uma concessão
  automática nem bootstrap executado.
- Coleta e distribuição externa permanecem desativadas. Seu funcionamento
  exige configuração e ativação próprias, além de API e Worker saudáveis.
- O [roteiro específico do Presença](../../infra/Presenca/DockerCompose/README.md)
  detalha o deploy e a sequência do primeiro acesso.

## Referências do caminho existente

- [MigrationBuilder](../../src/Engine/Yeshua.Engine/Dominio/Migration/MigrationBuilder.cs)
- [Criação do catálogo SQL](../../src/Engine/Yeshua.Engine/Infra/UnitOfWork.cs)
- [Projeção de autorização](../../src/Engine/Yeshua.Engine/Dominio/Schemas/CentralAuthorizationSchema.cs)
- [Studio Fiscal como referência da ligação dos schemas](../../src/Studio/Yeshua.Studio.Fiscal/Program.cs)
- [Studio Presença](../../src/Studio/Yeshua.Studio.Presenca/Program.cs)
- [Checklist atual do template Docker Compose](../../src/Engine/Yeshua.Engine/Dominio/CodeGeneration/Templates/Infrastructure/CSharpCQRS/DockerCompose/README.md)
- [Configuração privada](../../infra/private/README.md)
- [Orquestrador de deploy](../../infra/docker/deploy.sh)
- [Cobertura dos aliases SQL](../../tests/Infrastructure/PrivateConfig/test_compose_configuration.py)
