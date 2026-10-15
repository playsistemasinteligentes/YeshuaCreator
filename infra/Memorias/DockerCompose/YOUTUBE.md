# Conexao YouTube do Memorias

## Configuracao Pela Interface

O Estudio possui o botao Configuracao YouTube junto ao canal. A configuracao
OAuth do aplicativo e global por ProcessingScope; nao pertence a um canal,
usuario ou tenant. O dialogo pede Client ID e Client Secret, exibe o endereco
de retorno definido pela implantacao e consulta somente metadata segura.
Salvar nao concede consentimento Google nem publica videos. Cada usuario
continua autorizando seus proprios canais pelo botao Conectar canal.

Uma conexao autorizada pertence ao tenant/usuario e permanece disponivel nos
proximos logins, inclusive em outro dispositivo. O Estudio seleciona o unico
canal conectado quando nao ha destino escolhido; com varios canais, exige
escolha explicita. Uma publicacao em andamento sempre preserva seu destino,
mesmo se outro canal continuar conectado. Adicionar outro canal inicia OAuth;
Reconectar aparece somente para uma conexao marcada como desconectada. Entrar
no Estudio, consultar canais e publicar com uma conexao valida nao iniciam OAuth.
O campo Client Secret fica vazio; Segredo salvo confirma a persistencia e um
campo vazio na atualizacao preserva o valor existente.

A implantacao deve designar uma unica identidade administrativa confiavel:

```bash
YESHUA_MEMORIAS_CONFIG_ADMIN_TENANT_ID=<TenantId global do administrador>
YESHUA_MEMORIAS_CONFIG_ADMIN_USER_ID=<UserId global do administrador>
```

Esses valores entram no ambiente de deploy, nunca pelo navegador. Sem ambos,
o acesso administrativo fica fechado. O papel legado Admin nao e suficiente:
o login atual da Central ainda emite esse papel para todos os usuarios. O
receiver valida os dois identificadores do contexto autenticado antes de ler
metadata administrativa ou salvar qualquer segredo. O scope declarativo
memorias.youtube.configurar registra a intencao, mas nao substitui essa guarda.

O repositorio guarda configuracao cifrada e chave interna persistente em
`/root/YeshuaMemoriasSecrets/accounts/configuration/<hash-do-escopo>`. O arquivo
oauth.bin e cifrado por AES-256-GCM; key.bin nunca e devolvido pela API. A
chave existente do ambiente e preservada na primeira importacao. Depois,
perda da chave ou corrupcao exige revisao operacional, sem substituicao cega.
Preserve esses arquivos em backup privado junto dos tokens e recibos.

API e Worker leem um snapshot por escopo de DI somente ao resolver os servicos
YouTube, sem novo polling. Uma nova operacao usa a configuracao salva sem
reiniciar/deploy; operacoes ja em andamento mantem seu snapshot. O segredo
nao e persistido em localStorage/sessionStorage e e limpo do formulario e do
command apos o envio. Atualizacao do segredo preserva tokens, recibos e chave;
Client ID ja vinculado nao pode ser trocado pela tela nesta fase.

O configurador SSH abaixo permanece como caminho legado/bootstrap. A
configuracao cifrada salva pela interface tem precedencia sobre o ambiente;
nao use o script para tentar sobrescrever uma configuracao ja administrada
pela tela. Nao configure credenciais falsas em producao para homologacao.

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

Falha de envio registra estado 90 e mensagem segura na publicacao. A saga continua sendo dona da decisao de retry: falhas temporarias retomam a mesma sessao; recusa definitiva falha sem gastar tentativas iguais. Falhas de comunicacao OAuth tambem sao sanitizadas antes de chegar a tela/log operacional.

## Validacao

### Classes de qualidade

O seletor Qualidade do video possui IDs estaveis independentes da futura
politica comercial: 1 Economica (HD 720p, CRF 23), 2 Padrao (Full HD 1080p,
CRF 18) e 3 Alta (4K 2160p, CRF 18). Todos usam 30 fps. Ainda nao existem
precos, planos, pagamentos nem restricoes comerciais entre essas classes.

O Album grava a escolha e PublicacaoAlbum captura a classe ao solicitar.
Manifestos e retries usam a classe da publicacao, mesmo que o album seja
editado depois. NULL/zero em registros anteriores e tratado como Padrao,
nunca como classe invalida ou como a escolha atual do album. As novas colunas
permanecem nullable para permitir a migration de bases existentes.

O .NET define os parametros; o renderer somente aplica width/height/fps/crf
do manifesto. O CRF explicito prevalece sobre `FFMPEG_CRF`, mantido como
fallback para manifestos antigos. Testes geram videos reais em 720p, 1080p e
4K e validam dimensoes, giro e parametro de compressao. Nenhuma dessas
classes e arquivo de preservacao sem perdas nem garante recuperar originais.

### Orientacao das fotos

No Estudio, as fotos selecionadas oferecem giros de 90 graus para esquerda,
direita e 180 graus. O envio salva essa orientacao no vinculo AlbumFoto, sem
reescrever o arquivo. Nas fotos ja enviadas, o botao Girar foto abre a previa
privada e Salvar orientacao confirma a mudanca. Durante publicacao os controles
ficam bloqueados; a validacao tambem acontece no servidor.

O manifesto leva `rotationDegrees` por foto, com zero como padrao para
manifestos antigos. FFmpeg aplica primeiro a orientacao de metadados, depois
o giro manual e o ajuste sem corte ao quadro do video. Registros antigos de
AlbumFoto aceitam NULL na nova coluna; o DTO os representa como zero. O campo
imutavel no CRUD evita que a edicao de legenda/ordem apague a orientacao.

`tests/Media/Memorias/test_rotation.py` usa Python, Pillow e FFmpeg local para
validar pixels de todos os giros, retrato/paisagem, EXIF, video com orientacoes
mistas, manifesto legado e rejeicao de angulos invalidos. Execute
`python tests/Media/Memorias/test_rotation.py`; FFmpeg deve estar no PATH ou
em `FFMPEG_BINARY`. Os testes de tela usam API simulada e tamanhos desktop e
celular; nao substituem homologacao em iPhone fisico ou no servidor publicado.

Os testes BusinessSmoke usam repositorio cifrado real em diretorio temporario, Google/HTTP simulados, ownership por tenant/usuario, N canais, PKCE/state, replay, refresh/revogacao, destino imutavel, retomada e falhas ambiguas. Os testes Playwright cobrem desktop e celular, callback, negacao/expiracao e ausencia de polling.

A suite CRUD gerada permite `CustomizeExecution` em Custon. PublicacaoAlbum verifica leitura e rejeicao da criacao CRUD, sem fabricar uma publicacao nem furar o DomainBehavior. A seed tambem respeita esse controle. Testes HTTP reais exigem ambiente explicitamente configurado; testes locais simulados nao comprovam consentimento ou publicacao real no Google.

## Revisao futura

Modalidade simplificada: cliente com identidade limitada em tenant gerenciado, fotos/pagamento e recebimento do link, usando uma conexao do servico sem expor OAuth ao cliente. Reutilizar os mesmos commands/saga/storage; separar solicitante de responsavel pela credencial. A primeira implementacao aceita somente conexoes particulares do proprio usuario; compartilhamento e canais de servico exigem politica explicita e confirmacao de pagamento no servidor.

Consentimento/publicacao real no YouTube depende de Client ID/Secret do aplicativo e autorizacao humana do canal. Nenhum teste automatizado deve substituir esse consentimento por credenciais falsas em producao.

## Modelos E Musica

O Estudio salva modelo, trilha e volume no album. A solicitacao de publicacao
captura essas escolhas, como ja faz com qualidade e canal. Modelo Classico
mantem fotos estaticas; Romantico aproxima, Aventura desloca lateralmente e
Celebracao afasta. Modelos animados usam fades curtos pelo preto.

O catalogo inicial tem Air Prelude, Adventure Meme e Carefree, de Kevin MacLeod,
com CC BY 4.0 e atribuicao automatica na descricao do video. Consulte
`music/LICENSE.md` e `music/SHA256SUMS`. Sao faixas do catalogo do compositor,
nao uma listagem automatica da Biblioteca de Audio do YouTube; licenca nao e
garantia contra reivindicacoes de terceiros. O usuario pode escolher Sem musica.

O deploy padrao instala as trilhas versionadas em
`/root/YeshuaStorage/persistent/memorias/music`, verificando os hashes e sem
sobrescrever arquivos divergentes. API, Worker e renderer compartilham esse
storage. Para desenvolvimento local, copiar os mesmos arquivos para
`storage/persistent/memorias/music` do host; sem eles a tela indica indisponivel.
Nao precisa configurar credenciais Google para ouvir o catalogo.
