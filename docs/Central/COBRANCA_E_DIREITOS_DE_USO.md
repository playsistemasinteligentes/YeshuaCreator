# Cobranca e direitos de uso

## Decisao

A Central recebe pagamentos, mantem a carteira de creditos do tenant e registra
contratacoes. O aplicativo recebe direitos de uso: um periodo ou uma quantidade
de servico. Nao consulta saldo financeiro na Central durante cada utilizacao.

O prototipo atende a issue #16. A issue #22 podera utilizar a mesma carteira,
mas patrocinio, propriedade, participacao economica e execucao de agentes nao
fazem parte desta entrega.

## DSL e responsabilidades

Em `Yeshua.Studio.AppClinicas/Migrations/M000010.cs`:

```csharp
RequirePeriodAccess("PSI", "clinica.access", "Acesso a Clinica");
ChargeSagaStep("PsychologySessionInsight", "audioTranscriptRequested",
    "clinica.transcription", "Transcricao de audio",
    UsagePurchaseModel.Period | UsagePurchaseModel.Credits);
```

A DSL determina as modalidades permitidas e a borda cobrada. A contratacao
determina a modalidade adquirida. O catalogo de ofertas e precos demonstrativos
pertence ao codigo customizado da Central. A projecao de autorizacao existente
entrega as definicoes DSL para a Central como `UsageRight`; somente ofertas
compativeis com essas definicoes ficam disponiveis.

As tabelas financeiras e de utilizacao sao internas, declaradas na DSL, sem
CRUD, lookup, menu de entidade ou metadata publica. Commands normais expõem
consulta, adicao demonstrativa a carteira, alocacao e renovacao
do acesso. Mutacoes comerciais exigem o proprietario do tenant autenticado.

## Compra e acesso

1. O responsavel acessa Central > Carteira de creditos.
2. Em **Adicionar creditos a carteira**, escolhe a quantidade e confirma a adicao.
   Neste prototipo o saldo entra diretamente, sem cobranca ou confirmacao de Pix.
3. Na etapa abaixo, **Alocar creditos da carteira**, escolhe o servico e o periodo
   ou pacote. A Central desconta o saldo e ativa o direito na mesma transacao.
4. O token atualizado transporta os direitos para a entrada do aplicativo.

A DSL M000004 declara AdicionarCreditosCarteira e AlocarCreditosCarteira com os
mesmos conceitos da interface. Os contratos antigos de cobranca permanecem para
compatibilidade, fora do fluxo atual. O corpo Up de M000003 e suas definicoes de
autorizacao continuam iguais; somente seu DTO de movimento recebeu os campos
opcionais de apresentacao. Nao houve nova tabela ou mudanca de dados historicos.

O extrato separa entrada, saida, saldo anterior e saldo apos, identifica o servico
e permite filtrar a visualizacao. A identificacao de alocacoes novas e anteriores
usa a referencia ja persistida para ContratacaoUso; nao consulta uma vez por linha.
Direitos por periodo sem pacote de unidades aparecem como Por periodo.
Pagamento real por Pix e transferencia entre servicos nao estao implementados.

Sem periodo ativo, a entrada responde `403` com `USAGE_PERIOD_REQUIRED` antes
de abrir a sessao local. A tela explica a necessidade de contratar ou renovar e
oferece **Ir para a carteira de creditos**, direcionando para
`/spa/?app=Central#central-financeiro` com a identidade atual. O dashboard e suas
consultas nao sao carregados nesse caso. Falta de permissao continua sendo um
bloqueio distinto; sessao expirada pede novo login e falha tecnica permite tentar
novamente. Esse tratamento nao concede saldo nem direito automaticamente.

Pedidos de adicao e alocacao possuem identidade idempotente vinculada ao
tenant. Repetir o mesmo pedido nao repete seu efeito; alterar seus parametros
com a mesma identidade e rejeitado. A confirmacao repetida de uma cobranca nao
duplica creditos. Compras concorrentes travam a mesma carteira e nao geram divida.
O extrato financeiro e formado por insercoes, sem editar movimentos anteriores.

Periodos usam meses de calendario. Renovacao antecipada preserva o periodo ainda
vigente; um direito vencido recomeca na data da nova contratacao. A oferta e o
preco efetivamente pagos ficam registrados na contratacao.

## Token e quantidade local

O token leva identidade, catalogos, `usageRights` e claims diretas
`usageUntil.<recurso>`. A verificacao de acesso por periodo compara a claim
direta com o horario, sem JSON, banco ou HTTP no caminho da requisicao.
Trocar de aplicativo preserva os direitos e nao prolonga a expiracao da sessao.
Tokens comerciais duram no maximo 30 minutos; durante o uso, o Front renova pela
Central e reabre o escopo do aplicativo quando necessario.

O snapshot assinado inclui quantidade total contratada, nunca saldo restante.
Na entrada do aplicativo ele atualiza a concessao local de forma monotona.
Reapresentar um token antigo nao reduz o total nem zera consumos. A quantidade
disponivel e calculada a partir do total contratado menos reserva e consumo
persistidos no banco do aplicativo. Usuarios do mesmo tenant compartilham esse
controle; sessoes ou replicas nao criam carteiras independentes.

## Transcricao e saga

O executor compartilhado reserva o direito na borda declarada, antes de executar
o step que publica a solicitacao de transcricao. A identidade estavel do step
e a chave do consumo. Retentativas reaproveitam a reserva. Aplicar uma resposta
bem-sucedida confirma o consumo. Falha definitiva libera a reserva; falha
transitoria preserva a reserva para retry. Periodo valido tem prioridade sobre
unidades, preservando pacotes adquiridos. O custo inicial e uma unidade por
transcricao concluida, independentemente do provedor existente.

Sem direito suficiente, o step fica em `WaitingUsageRight` (estado persistido 7),
sem executar o provedor, contar retry ou gerar polling financeiro. A gravacao e o
upload continuam normais. A tela informa a espera e usa o command existente de
retomada depois da contratacao, renovando os direitos na entrada do aplicativo.
O mesmo step e o mesmo audio sao reutilizados. A localizacao temporaria do audio
e sua limpeza permanecem exatamente as existentes: nao ha copia persistente,
protecao contra limpeza nem extensao de prazo. Se o arquivo ja tiver sido limpo,
a retomada falha e libera a reserva sem consumir a unidade.

As transicoes financeiras locais sao idempotentes e persistentes, separadas da
tentativa de transporte. Elas nao fazem chamadas para a Central nem para o
provedor. OpenAI, Groq e Queue continuam usando os caminhos existentes.

## Configuracao e limites do prototipo

Adicoes demonstrativas ficam desabilitadas por padrao. Para o sandbox autorizado,
o arquivo privado pode conter `Apps.Central.Billing.SandboxEnabled` com a string
`"true"`. O loader existente exporta somente o sinalizador ao servico Central.
Rebuild usa o mesmo arquivo privado e os mesmos bancos. O frontend identifica
a adicao demonstrativa. Nao existe Pix real nesta entrega.

Esta primeira carteira usa creditos livres. Lotes restritos, conversao, cambio,
expiracao de creditos, devolucao bancaria, cobranca automatica, boleto,
pos-pago e patrocinio permanecem evolucoes. Cancelamentos nao revogam JWTs
instantaneamente; o limite e a validade do token. Os dados existentes nao sao
apagados e nenhum direito pago e concedido silenciosamente a tenants antigos.
Usuarios antigos da Clinica precisam contratar o acesso no sandbox antes de
usar as bordas protegidas.

## Validacao

- Engine: declaracoes invalidas, infraestrutura interna e geracao da borda.
- Shared: claims, expiracao e preservacao do vencimento entre aplicativos.
- Saga: bloqueio antes do provedor, espera, confirmacao e falha definitiva.
- Central: meses de calendario e ofertas independentes de transcricao.
- Front: compra, repeticao do pedido apos resposta perdida e desktop/celular.
- Configuracao: simulacao explicita e preservada pelo loader na reconstrucao.

Validacoes unitarias e de interface nao substituem o ensaio HTTP/SQL no sandbox
publicado, especialmente concorrencia, isolamento entre tenants e retomada.

Em 2026-11-18, o ensaio HTTP no sandbox publicado passou com duas contas
sinteticas: confirmacoes concorrentes nao duplicaram saldo; vinte compras de
pacotes esgotaram exatamente 400 creditos e cinco compras extras foram negadas.
O ensaio pelo navegador confirmou recarga, entrada na Clinica e contratacao de
transcricao por periodo e unidades em desktop e celular, sem chamar provedores.
Os testes da saga verificam espera sem credito, retomada com a mesma identidade
e liberacao da reserva quando o arquivo temporario ja nao existe.
