# Conexao YouTube do Memorias

## Configuracao inicial do aplicativo

1. No Google Cloud, crie ou selecione o projeto do aplicativo e habilite YouTube Data API v3.
2. Na Google Auth Platform, configure Branding e Audience como External. Em Testing, adicione as contas autorizadas em Test users.
3. Em Data Access, solicite somente `youtube.upload` (envio de videos) e `youtube.readonly` (identificar o canal autorizado).
4. Em Clients, crie um OAuth client do tipo Web application. Cadastre exatamente este Authorized redirect URI:
   `https://playsis.com.br/spa/youtube-callback.html`
5. No servidor, execute `sudo bash /root/YeshuaCreator/infra/Memorias/DockerCompose/configure-youtube.sh`. Informe Client ID e Client Secret pelos prompts. Nunca versione o segredo, a chave de criptografia ou os tokens.
6. Execute o deploy padrao: `sudo bash /root/YeshuaCreator/infra/docker/deploy.sh`. API/Worker e Front Central precisam conter esta versao.

Cada usuario entao abre um Album no Memorias e usa Conectar YouTube. O login e o consentimento acontecem no Google, em navegador normal. O retorno confirma o canal; nenhuma senha Google e recebida pelo Memorias. Um usuario pode adicionar N conexoes e lista-las por Consultar conexoes. Escolhe o canal de destino antes de Publicar album.

Consultar conexoes, Reconectar canal e Desconectar sao comandos manuais. Uma publicacao existente no estado 45 pode ser aberta em Publicacoes e retomada pelo botao Retomar envio. Conectar um canal nao dispara uploads existentes.

Publicacoes novas registram ConexaoYouTubeId, CanalYouTubeId e YouTubeCredentialUserId. O destino e imutavel durante o processamento. Publicacoes antigas sem esses campos exigem escolha explicita na primeira retomada; depois o destino tambem fica fixo. Reconectar uma conexao exige autorizar o mesmo canal. Para trocar de canal, crie outra publicacao. O CRUD de PublicacaoAlbum e bloqueado pelo DomainBehavior para preservar o fluxo e o destino.

## Seguranca e operacao

- Commands autenticados gerados pela DSL recebem a identidade do contexto; nao aceitam tenant/user no corpo.
- PKCE S256 e state aleatorio valido por dez minutos protegem a autorizacao. O state e consumido uma vez e vinculado ao tenant, usuario, escopo de processamento, client ID e redirect URI.
- Tokens e verificadores sao cifrados com AES-256-GCM e AAD especifico por dono/finalidade/escopo. Persistem em `/root/YeshuaMemoriasSecrets`, volume montado somente na API e Worker .NET. O renderer Python e o gateway nao recebem esse volume nem a chave.
- Escrita atomica e lock de arquivo por usuario coordenam API e Worker. Cada conexao tem arquivo e AAD proprios. Renovacao preserva o refresh token quando o Google nao envia outro. As respostas HTTP nunca devolvem tokens/verificadores.
- Upload resumable persiste a sessao cifrada antes de enviar o video. Cada publicacao tem lock proprio; retomadas consultam os bytes confirmados pelo Google, mantem destino/arquivo/hash e nunca abrem outra sessao automaticamente. O recibo cifrado com o ID do video sobrevive a falhas ao atualizar o banco. Preserve tambem esses arquivos no backup restrito.
- Desconectar apaga os segredos locais, revoga o acesso no Google e cancela autorizacoes pendentes daquela conexao. Preserva o ID/canal para as publicacoes existentes. A revogacao Google pode afetar outras conexoes da mesma conta Google; nenhuma conexao e substituida por outra nesse caso.
- Configuracao e chave ficam em `/root/YeshuaDB/persistent/config/memorias-youtube.env`, fora do repositorio. O loader do deploy padrao le esse arquivo. Preserve a chave em backup restrito junto das credenciais; troca-la exige reconectar as contas.
- Sem configuracao, a API continua saudavel e informa a pendencia. Sem conta autorizada, a saga para no envio YouTube e exige retomada manual.
- O callback limpa code/state da barra de enderecos, nao carrega terceiros e usa politica de referrer restrita. O gateway tambem desliga access logs e cache nessa rota.
- O primeiro teste real deve usar album privado. Testes locais usam Google simulado: nunca concedem consentimento nem publicam no canal de uma pessoa.
- Tokens podem expirar ou ser revogados. Projetos em Testing podem exigir nova autorizacao apos sete dias; antes do uso amplo, revise verificacao OAuth e politicas/quota do YouTube.
- `invalid_grant` na renovacao marca a conexao como desconectada e remove seus tokens locais. Falhas transitorias nao removem a credencial.
- Sessao de upload expirada ou resposta final sem ID confiavel exige revisao humana no canal. Essa situacao para a saga; reconectar nao autoriza um reenvio cego.

## Fontes oficiais

- https://developers.google.com/youtube/v3/guides/auth/server-side-web-apps
- https://developers.google.com/workspace/guides/configure-oauth-consent
- https://developers.google.com/identity/protocols/oauth2#expiration
- https://developers.google.com/youtube/v3/guides/using_resumable_upload_protocol

## Fluxo do prototipo

Usuario autenticado + tenant -> Album -> upload padrao de fotos -> selecionar conexao/canal -> SolicitarPublicacaoAlbum -> PublicacaoAlbum com destino imutavel + Saga -> manifesto -> Outbox/RabbitMQ -> FFmpeg Python -> RabbitMQ/Inbox -> Saga -> upload resumable .NET -> recibo + ID/link YouTube -> finalizar publicacao.

Se faltar autorizacao, a publicacao fica no estado 45. Reconectar o mesmo canal -> abrir a publicacao -> Retomar envio -> Worker continua a mesma saga/sessao. Consultar conexoes/status e atualizar a publicacao sao acoes manuais, sem polling no Front.

## Validacao

Os testes BusinessSmoke usam repositorio cifrado real em diretorio temporario, Google/HTTP simulados, ownership por tenant/usuario, N canais, PKCE/state, replay, refresh/revogacao, destino imutavel, retomada e falhas ambiguas. Os testes Playwright cobrem desktop e celular, callback, negacao/expiracao e ausencia de polling.

A suite CRUD gerada permite `CustomizeExecution` em Custon. PublicacaoAlbum verifica leitura e rejeicao da criacao CRUD, sem fabricar uma publicacao nem furar o DomainBehavior. A seed tambem respeita esse controle. Testes HTTP reais exigem ambiente explicitamente configurado; testes locais simulados nao comprovam consentimento ou publicacao real no Google.

## Revisao futura

Modalidade simplificada: cliente com identidade limitada em tenant gerenciado, fotos/pagamento e recebimento do link, usando uma conexao do servico sem expor OAuth ao cliente. Reutilizar os mesmos commands/saga/storage; separar solicitante de responsavel pela credencial. A primeira implementacao aceita somente conexoes particulares do proprio usuario; compartilhamento e canais de servico exigem politica explicita e confirmacao de pagamento no servidor.

Consentimento/publicacao real no YouTube depende de Client ID/Secret do aplicativo e autorizacao humana do canal. Nenhum teste automatizado deve substituir esse consentimento por credenciais falsas em producao.
