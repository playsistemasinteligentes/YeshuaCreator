# Ajuda contextual do Front compartilhado

O botão Ajuda no cabeçalho copia o prompt; em telas pequenas a mesma ação fica
na área do usuário como Copiar prompt de ajuda. Funciona no Front Central que
serve os cinco aplicativos. Não faz chamadas de API nem envia o contexto à IA.

O texto identifica aplicação, página/cadastro, ação, identificador técnico do
registro quando disponível, tenant, usuário, URL sem parâmetros e horário. Não
copia credenciais, valores de formulário ou conteúdo dos registros. O módulo do
menu ainda não é um campo separado do contexto; aplicação e tela o delimitam.

Endereços incluídos no texto desde 28/10/2026:

- Serviço: https://playsis.com.br/operational/
- MCP: https://playsis.com.br/operational/mcp

Esses links identificam o serviço e não conectam o GPT automaticamente. O MCP
público anuncia apenas `yeshua_health`. Fontes e evidências exigem conexão
autorizada; não expor ferramentas privadas nem a porta interna para viabilizar
o prompt. O texto orienta o assistente a informar ferramentas ou conexão ausentes.

## Atualização do cabeçalho

Foi reproduzido o caso de cabeçalho antigo em cache coexistindo com painel novo.
A cadeia index/main/router/user-area e o fragmento dashboard agora usam a versão
`20261028-help02`. As entradas diretas do Clínica e Memórias usam o mesmo fragmento
e versão do user-area, preservando uma única definição do cabeçalho.

O host Front envia `Cache-Control: no-cache` para HTML, JavaScript, CSS e JSON.
Isso mantém ETag/304, exigindo revalidação em vez de cache heurístico após deploy;
não adiciona polling, recarga automática ou substituição do editor em uso.

Validação: teste com cabeçalho/user-area antigos em cache, recarga normal, botão
visível e cópia; política HTTP com revalidação 304; testes do prompt e navegador
nos cinco aplicativos, incluindo privacidade, foco/seleção e dispositivos móveis.
