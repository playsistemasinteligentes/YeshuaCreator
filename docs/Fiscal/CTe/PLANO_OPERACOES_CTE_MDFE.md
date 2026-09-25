# Plano De Operacoes CT-e E MDF-e

## Objetivo

Disponibilizar operacoes fiscais individuais, pequenas e homologaveis antes de
compo-las em processos por carga. CT-e e MDF-e permanecem separados. Cada
operacao recebe a chave do documento sempre que isso for suficiente.

## Regras Do Trabalho

- Nao criar motor generico de eventos fiscais.
- Declarar cada borda como Command na DSL do Fiscal.
- Manter miolos fiscais no aplicativo Fiscal.
- Reutilizar apenas infraestrutura inequivocamente comum: certificado A1,
  assinatura XML, transporte SOAP e storage.
- Homologar uma operacao individual antes de usa-la em saga por carga.
- A saga por `CargaId` apenas coordena operacoes individuais ja comprovadas.

## R01 - Inventario E Contratos

Mini escopo:

- Mapear as operacoes existentes na DSL e nos miolos customizados.
- Separar catalogos `CTeUtilitarios` e `MDFeUtilitarios`.
- Definir entrada e saida de cada operacao por chave.

Entrega:

- Catalogo sem duplicar XML, DACTE, DAMDFE e encerramento ja existentes.

## R02 - Consultas Individuais

Mini escopo:

- Consultar situacao do MDF-e no SEFAZ.
- Consultar situacao do CT-e no SEFAZ.
- Retornar `cStat`, `xMotivo`, protocolo, chave e status HTTP.

Entrega:

- Diagnostico individual do documento antes e depois de qualquer evento.

## R03 - Documentos Locais

Mini escopo:

- Consolidar obtencao do XML CT-e e MDF-e armazenado.
- Consolidar DACTE e DAMDFE.
- Diferenciar claramente XML local de distribuicao/recuperacao no SEFAZ.

Entrega:

- Quatro operacoes locais previsiveis e reutilizaveis pela contingencia e APS.

## R04 - Eventos MDF-e

Ordem:

1. Encerramento, ja comprovado isoladamente.
2. Inclusao de condutor.
3. Cancelamento.
4. Inclusao de documento fiscal, se confirmada no recorte oficial adotado.
5. Eventos de pagamento/contrato em rodada propria.

Cada operacao deve montar, assinar, transmitir, interpretar e persistir seu
proprio evento. Encerramento nunca sera fallback automatico de cancelamento.

## R05 - Eventos CT-e

Ordem:

1. Cancelamento.
2. Carta de correcao.
3. Comprovante de entrega e cancelamento do comprovante.
4. Insucesso na entrega e cancelamento do insucesso.
5. Prestacao em desacordo.

Cada evento tera Command, Receiver e contrato proprios.

## R06 - Composicao Por Carga

Mini escopo:

- Resolver os documentos ligados ao `CargaId` pelos dados fiscais existentes.
- Criar uma saga por operacao em lote, por exemplo cancelamento da carga.
- Criar um step por documento para retry e retomada independentes.
- Produzir resumo final com sucesso, rejeicao e pendencia por chave.

Entrega:

- APS e contingencia solicitam uma operacao por carga sem conhecer detalhes do
  SEFAZ, enquanto as operacoes individuais continuam disponiveis por chave.

## Estado Inicial

Ja implementado no Fiscal:

- CT-e: consultar situacao, obter XML local, gerar DACTE, cancelar CT-e e carta
  de correcao.
- MDF-e: consultar situacao, obter XML local, gerar DAMDFE, cancelar MDF-e,
  incluir condutor e encerrar MDF-e por chave.
- Tela de contingencia: painel simples para chamar as operacoes individuais por
  chave, sem criar mecanismo paralelo ao Command/Receiver gerado pela DSL.

Pendencias planejadas:

- Homologar individualmente cada evento em ambiente SEFAZ antes de compor por
  carga.
- Persistir historico de eventos fiscais por documento com XML de envio,
  retorno, protocolo e status.
- Evoluir composicao por carga somente depois das operacoes por chave estarem
  comprovadas.
- Mapear eventos oficiais restantes: comprovante de entrega, insucesso,
  prestacao em desacordo, inclusao de documento MDF-e se entrar no recorte, e
  eventos de pagamento/contrato em rodada propria.
