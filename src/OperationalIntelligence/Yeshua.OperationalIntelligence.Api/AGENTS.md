# Contexto Para Agentes Da Operational Intelligence API

Este projeto expoe o indice de engenharia reversa e os bundles de codigo-fonte
para aplicativos Yeshua e sistemas legados.

## Chamadas Diretas Pelo Agente

Quando o usuario solicitar uma investigacao, uma consulta de contexto ou a
geracao de um bundle, o agente deve realizar diretamente as chamadas HTTP desta
API. Nao orientar o usuario a operar o Swagger quando a chamada puder ser feita
pelo proprio agente.

Fluxo padrao:

1. Consultar GET /api/health.
2. Quando aplicativo ou versao precisarem ser confirmados, consultar
   GET /api/applications e GET /api/applications/{application}/builds.
3. Para diagnostico estruturado, usar POST /api/investigations.
4. Para contexto compacto, usar POST /api/investigations/context.
5. Para analisar os fontes completos, preferir
   POST /api/investigations/context/bundle.
6. Ler o resultado retornado e responder ao usuario; nao limitar o trabalho a
   informar a URL ou o comando HTTP.

O endereco local padrao e http://localhost:5728. Se ele nao responder,
verificar se ja existe outra porta configurada ou uma instancia em execucao
antes de iniciar outro processo. Informar ao usuario somente o bloqueio
concreto que impedir a chamada.

## Parametros E Evidencias

- Usar a pergunta do usuario como question.
- Usar BusinessRule para entendimento de regras, ChangeImplementation para
  planejar ou implementar mudancas, BugDiagnosis para erros,
  Architecture para estrutura e Full somente quando necessario.
- Informar field, class, function, file e line quando esses dados estiverem
  disponiveis.
- Se a versao nao for informada, confirmar a versao indexada apropriada em vez
  de inventar uma.
- O bundle representa um snapshot confirmado armazenado no banco. Nao confundir
  esse conteudo com a working tree atual.
- Respeitar ownership, editable e sourceOfTruth ao sugerir alteracoes.
- Evidencias TEXT_REFERENCE selecionam fontes candidatos, mas nao provam
  semanticamente leitura ou escrita.

O Swagger permanece disponivel para exploracao humana, mas nao e uma etapa
obrigatoria quando o agente foi solicitado a executar a consulta.
