# MDF-e - Backlog De Implementacao

Consolidado em 2026-08-28.

Este backlog transforma o dossie de assuntos em uma ordem de execucao. Ele foi
organizado para evoluir o modulo Fiscal.MDFe sem criar um monstro de DSL e sem
misturar encerramento, emissao, conectores, transporte, CT-e, NF-e, APS ou
legado.

## Regra De Execucao

- Implementar sempre o menor recorte que prove uma capacidade real.
- Quando a informacao oficial ou decisao de negocio faltar, registrar
  `pendencia` e seguir para o proximo item.
- A Engine gera bordas e pontos de extensao.
- O aplicativo Fiscal.MDFe guarda miolos fiscais, bibliotecas, schemas, WSDLs,
  XML, assinatura, cliente SEFAZ e DAMDFE.
- Nenhum item deve depender de CT-e, NF-e, APS ou outro modulo como caminho
  quente.
- Encerramento vem antes de emissao completa porque ja existe prova real no
  playground.

## Fase A - Pesquisa Operavel

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| A01 | MDF-P00 | Fechar fontes oficiais locais. | Links oficiais e manuais catalogados. |
| A02 | MDF-P00, MDF-P01 | Baixar schemas vigentes. | ZIP do schema versionado e referenciado. |
| A03 | MDF-P01 | Fechar endpoint resolver inicial. | Producao/homologacao SVRS documentadas. |
| A04 | MDF-P18 | Decidir biblioteca ou implementacao propria para prova. | Catalogo open-source e decisao provisoria registrados. |
| A05 | MDF-P03, MDF-P04 | Confirmar WSDLs P0. | RecepcaoEvento, Consulta, Status e NaoEncerrados verificados. |
| A06 | MDF-P18 | Completar snapshots MDF-e das referencias. | Pastas MDF-e de DFe.NET e Unimake baixadas ou pendencia confirmada. |

Pendencias atuais:

- pendencia: baixar ZIP de schemas MDF-e vigente.
- pendencia: confirmar se a primeira prova definitiva usa biblioteca pronta ou
  cliente proprio enxuto.
- pendencia: registrar hash/versao do pacote de schemas usado.
- pendencia: ampliar referencias open-source para alem das camadas comuns ja
  catalogadas em [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md).

## Fase B - Playground Fiscal

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev | Pronto quando |
| --- | --- | --- | --- | --- | --- |
| B01 | MDF-P04 | Status do servico. | Nada ou comando futuro. | Cliente MDF-e status. | Retorno com `cStat` e `xMotivo`. |
| B02 | MDF-P04 | Consulta por chave. | Nada ou comando futuro. | Cliente MDF-e consulta. | Retorno bruto salvo localmente. |
| B03 | MDF-P04 | Consulta de nao encerrados. | Nada ou comando futuro. | Cliente MDF-e nao encerrados. | Lista interpretavel por emitente. |
| B04 | MDF-P02 | Assinatura XML isolada. | Ponto custom futuro. | Signer com certificado real/homolog. | XML assinado validavel. |
| B05 | MDF-P02 | Validacao XSD isolada. | Ponto custom futuro. | Validator com schema versionado. | Erro XSD separado de erro SEFAZ. |
| B06 | MDF-P03 | Encerramento controlado. | Nada ainda. | Evento `110112` + cliente evento. | Evento homologado ou rejeicao interpretada. |

Regra:

- Playground pode ser fora da Engine.
- Depois de provado, o conhecimento vira miolo do aplicativo Fiscal.MDFe.
- O playground nao deve conter arquitetura definitiva nem segredo permanente.

## Fase C - Studio E Bordas Do App Fiscal.MDFe

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev | Pronto quando |
| --- | --- | --- | --- | --- | --- |
| C01 | MDF-P21 | Evoluir Studio Fiscal.MDFe. | Gera projetos por aplicativo. | DSL inicial. | Projetos Fiscal.MDFe compilam. |
| C02 | MDF-P03, MDF-P05 | Declarar entidades de encerramento/tentativa. | Domain, repositorios, API, worker/testes. | Ajustes de miolo. | Estado fiscal persistivel. |
| C03 | MDF-P03, MDF-P04 | Declarar use cases P0. | Commands, receivers, endpoints. | Miolo fiscal. | `Encerrar`, `ConsultarSituacao`, `Status`, `NaoEncerrados`. |
| C04 | MDF-P20 | Declarar trilha fiscal minima. | Repositorios e endpoints de consulta. | Registro das etapas fiscais. | Tentativas consultaveis por chave. |

Entidades candidatas P0:

- `MDFe`
- `MDFeEncerramento`
- `MDFeTentativaEvento`
- `MDFeEvento`
- `MDFeEventoXml`
- `MDFeRetornoSefaz`
- `MDFeConfiguracaoSefaz`
- `MDFeCertificadoReferencia`

Pendencias:

- pendencia: decidir se `MDFeEncerramento` atual absorve tentativa ou se nasce
  `MDFeTentativaEvento`.
- pendencia: decidir se configuracao SEFAZ nasce como entidade DSL ou arquivo
  operacional inicialmente.

## Fase D - Encerramento P0

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| D01 | MDF-P03 | Receber solicitacao interna. | Chave/protocolo/municipio/ambiente chegam ao receiver. |
| D02 | MDF-P03 | Validar pre-condicoes. | Falhas locais param antes da SEFAZ. |
| D03 | MDF-P03, MDF-P02 | Gerar e assinar evento. | XML `eventoMDFe` assinado. |
| D04 | MDF-P02 | Validar XSD. | Erro XSD salvo como falha tecnica local. |
| D05 | MDF-P01, MDF-P03 | Enviar para `MDFeRecepcaoEvento`. | Retorno bruto persistido. |
| D06 | MDF-P05 | Interpretar retorno. | Estado interno correto. |
| D07 | MDF-P20 | Expor diagnostico. | Suporte ve tentativa completa. |
| D08 | MDF-P04 | Consulta pos-evento. | Estado conciliavel por chave. |

Decisao de sincronismo:

- A borda HTTP pode ser async tecnicamente.
- O miolo decide se espera conclusao da SEFAZ ou grava para processamento
  posterior.
- Para encerramento manual, o padrao inicial pode responder com retorno fiscal
  completo.
- Para integracao em massa, o padrao deve privilegiar salvar tentativa e
  processar por worker/inbox.

## Fase E - Consulta E Reconciliacao P0/P1

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| E01 | MDF-P04 | Status do servico. | Operador identifica disponibilidade SVRS. |
| E02 | MDF-P04 | Consulta situacao por chave. | Estado local pode ser conferido. |
| E03 | MDF-P04 | Nao encerrados. | Operador enxerga pendencias de encerramento. |
| E04 | MDF-P05 | Reconciliacao. | Divergencia local x SEFAZ gera acao clara. |
| E05 | MDF-P20 | Diagnostico por chave. | Suporte enxerga historico fiscal completo. |

Pendencias:

- pendencia: definir quais reconciliacoes podem atualizar estado interno sem
  intervencao humana.
- pendencia: definir limite de consultas para evitar consumo indevido.

## Fase F - Eventos P1

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev |
| --- | --- | --- | --- | --- |
| F01 | MDF-P06 | Cancelamento. | Command/receiver/endpoint. | XML evento, prazo, parser. |
| F02 | MDF-P07 | Inclusao de condutor. | Command/receiver/endpoint. | XML evento, validacao condutor, parser. |
| F03 | MDF-P05 | Historico de eventos. | Repositories/queries. | Vincular retorno ao MDF-e. |
| F04 | MDF-P20 | Diagnostico por evento. | Campos/trilha. | Hash XML, cStat, protocolo. |

Pendencias:

- pendencia: confirmar regras de prazo e campos por manual/schema vigente antes
  de validar no dominio.
- pendencia: confirmar codigos de todos os eventos por XSD vigente.

## Fase G - DAMDFE E Operacao P1

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| G01 | MDF-P08 | DAMDFE basico. | Documento gerado para MDF-e autorizado. |
| G02 | MDF-P08 | QR Code. | URL correta por ambiente. |
| G03 | MDF-P04, MDF-P05 | Reconciliacao por chave. | Estado local corrigivel por consulta oficial. |
| G04 | MDF-P20 | Painel/consulta de suporte. | Tentativas, eventos e falhas pesquisaveis. |
| G05 | MDF-P04 | Rotina de nao encerrados. | Pendencias aparecem com data/emitente. |

## Fase H - Emissao Rodoviaria P1/P2

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| H01 | MDF-P09 | `MDFeEmissionRequest`. | Contrato interno aprovado. |
| H02 | MDF-P10 | Documentos originarios. | Snapshots independentes de CT-e/NF-e. |
| H03 | MDF-P11 | Veiculo, condutor e percurso. | Dados minimos do modal rodoviario prontos. |
| H04 | MDF-P12 | CIOT/contrato/vale pedagio minimo. | Regras obrigatorias do recorte mapeadas. |
| H05 | MDF-P09 | Numeracao/chave. | Serie/numero/chave transacionais. |
| H06 | MDF-P09 | XML oficial. | XML pronto antes de assinatura. |
| H07 | MDF-P02 | Assinar e validar XSD. | Erro tecnico separado de rejeicao. |
| H08 | MDF-P01, MDF-P09 | Enviar para `MDFeRecepcaoSinc`. | Retorno bruto persistido. |
| H09 | MDF-P05 | Interpretar retorno. | Estado interno correto. |

Pendencias:

- pendencia: nao iniciar emissao completa sem primeiro fechar snapshots de
  documentos originarios.
- pendencia: decidir regra de numeracao em ambiente multi-tenant.

## Fase I - Conector Legado Inicial

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev |
| --- | --- | --- | --- | --- |
| I01 | MDF-P19 | Servir `.svc?wsdl` se necessario. | Casca/rota/alias. | WSDL/XSD customizado real. |
| I02 | MDF-P19 | Receber metodo legado. | Receiver e token extractor. | Normalizacao do payload. |
| I03 | MDF-P19 | Guardar payload bruto. | Opcao `yInbox` se declarada. | Decidir tabela ou inbox. |
| I04 | MDF-P10, MDF-P09 | Converter para snapshots/solicitacao. | Ponto custom. | Mapper do contrato externo. |
| I05 | MDF-P20 | Diagnosticar entrada externa. | Telemetria base. | Correlacao token, payload, tentativa MDF-e. |

Decisao atual:

- Conector pertence a API do aplicativo.
- Nome real do fabricante nao deve aparecer.
- Usar mnemonico neutro como `FabricaSoftware01`.

Pendencias:

- pendencia: obter WSDL/XSD final que o cliente usa hoje quando o conector MDF-e
  for necessario.
- pendencia: resolver token em `yToken` para tenant/cliente/permissao.

## Fase J - Robustez P2

| Entrega | Assuntos | Objetivo |
| --- | --- | --- |
| J01 | MDF-P14 | Distribuicao DF-e. |
| J02 | MDF-P13 | MDF-e Integrado/pagamento. |
| J03 | MDF-P12 | CIOT/contrato/ANTT completo. |
| J04 | MDF-P15 | InfraSA/DTe. |
| J05 | MDF-P16 | CT-e Simplificado como documento originario. |
| J06 | MDF-P05, MDF-P20 | Reprocessamento e replay controlado. |

Pendencias:

- pendencia: nao iniciar J antes de D/E/F estarem estaveis em homologacao ou
  producao controlada.

## Fase K - Produtos Especiais P3

| Entrega | Assuntos | Produto |
| --- | --- | --- |
| K01 | MDF-P17 | PAA |
| K02 | MDF-P17 | NFF |
| K03 | MDF-P17 | CNPJ Alfa |
| K04 | MDF-P11 | Modal ferroviario |
| K05 | MDF-P11 | Modal aquaviario |
| K06 | MDF-P11 | Modal aereo |
| K07 | MDF-P13 | Eventos especiais de pagamento/servico |

Regra:

- Cada produto nasce isolado, com commands e miolos proprios.
- Reutilizar somente infraestrutura fiscal comprovadamente comum.

## Primeiro Recorte Recomendado

O menor ciclo util para MDF-e e:

1. Baixar schema vigente.
2. Confirmar WSDL de `MDFeRecepcaoEvento`.
3. Confirmar WSDL de `MDFeConsulta`.
4. Confirmar WSDL de `MDFeStatusServico`.
5. Confirmar WSDL de `MDFeConsNaoEnc`.
6. Migrar encerramento do playground para app Fiscal.MDFe.
7. Persistir tentativa, XML, retorno e protocolo.
8. Implementar consulta por chave.
9. Implementar consulta de nao encerrados.
10. Implementar cancelamento.
11. Implementar inclusao de condutor.
12. Implementar DAMDFE/QR Code basico.
13. So entao iniciar emissao rodoviaria.

Esse recorte ja serve para operar MDF-e real, evoluir o Yeshua por demanda e
manter o modulo independente de CT-e, NF-e, APS e conectores legados.

## Backlog De Engine Relacionado

- Gerar pontos `Custon` fiscais sem expor regra fiscal na Engine.
- Gerar markers de ownership para diferenciar DSL, borda gerada e miolo custom.
- Gerar smoke tests de endpoints fiscais sem chamar SEFAZ por padrao.
- Gerar worker apenas quando a DSL declarar inbox/fila/polling.
- Gerar estrutura de conector SOAP/REST/arquivo quando declarada.
- Preservar performance no caminho quente: sem reflection, sem descoberta
  dinamica e sem serializacao quando a telemetria estiver desligada.

## Backlog De Aplicativo Relacionado

- Mover o cliente MDF-e do playground para `Custon` do app.
- Definir contratos fiscais internos.
- Baixar e versionar schemas.
- Completar referencias tecnicas de DFe.NET/Unimake antes de decidir
  dependencia definitiva.
- Implementar assinatura/XSD/cliente/parser.
- Persistir XMLs e retornos.
- Criar consultas operacionais.
- Implementar eventos P1.
- Definir politica de certificado.
- Definir estrategia de armazenamento seguro de XML e segredo.
