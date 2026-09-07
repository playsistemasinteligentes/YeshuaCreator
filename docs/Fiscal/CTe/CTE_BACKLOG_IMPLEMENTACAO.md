# CT-e - Backlog De Implementacao

Consolidado em 2026-08-28.

Este backlog transforma o dossie de assuntos em uma ordem de execucao. Ele foi
organizado para evoluir o modulo Fiscal.CTe sem criar um monstro de DSL e sem
misturar emissao fiscal, conectores, transporte, pedidos, MDF-e ou legado.

## Regra De Execucao

- Implementar sempre o menor recorte que prove uma capacidade real.
- Quando a informacao oficial ou decisao de negocio faltar, registrar
  `pendencia` e seguir para o proximo item.
- A Engine gera bordas e pontos de extensao.
- O aplicativo Fiscal.CTe guarda miolos fiscais, bibliotecas, schemas, WSDLs,
  XML, assinatura, cliente SEFAZ e DACTE.
- Nenhum item deve depender de MDF-e, APS ou outro modulo como caminho quente.

## Fase A - Pesquisa Operavel

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| A01 | CT-P00 | Fechar fontes oficiais locais. | PDFs e links oficiais catalogados. |
| A02 | CT-P00, CT-P01 | Baixar schemas vigentes. | ZIP do schema versionado e referenciado. |
| A03 | CT-P01 | Fechar endpoint resolver inicial. | PE/SVSP prod/homolog e SVC-RS documentados. |
| A04 | CT-P15 | Catalogar referencias C#. | DFe.NET e Unimake.DFe baixados e indexados como referencias nao oficiais. |
| A05 | CT-P15 | Decidir biblioteca ou implementacao propria para prova. | Comparativo minimo e decisao provisoria. |

Pendencias atuais:

- pendencia: baixar ZIP de schemas CT-e vigente.
- pendencia: pesquisar Hercules-NET/ZeusFiscal antes da decisao final.
- pendencia: confirmar se a primeira prova usa biblioteca pronta ou cliente
  proprio enxuto.

## Fase B - Playground Fiscal

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev | Pronto quando |
| --- | --- | --- | --- | --- | --- |
| B01 | CT-P03 | Status do servico em homologacao. | Nada ou comando futuro. | Cliente CT-e status. | Retorno com `cStat` e `xMotivo`. |
| B02 | CT-P03 | Consulta por chave em homologacao. | Nada ou comando futuro. | Cliente CT-e consulta. | Retorno bruto salvo localmente. |
| B03 | CT-P02 | Assinatura XML isolada. | Ponto custom futuro. | Signer com certificado real/homolog. | XML assinado validavel. |
| B04 | CT-P02 | Validacao XSD isolada. | Ponto custom futuro. | Validator com schema versionado. | Erro XSD separado de erro SEFAZ. |
| B05 | CT-P04 | Autorizacao modelo 57 em homologacao. | Nada ainda. | XML minimo + cliente recepcao. | CT-e autorizado ou rejeicao fiscal interpretada. |

Evidencia atual:

- 2026-09-05: `tools/Yeshua.Engine.Playground` possui `--cte-status` para
  `CTeStatusServicoV4` em homologacao SVSP. A chamada retornou `cStat=107`
  (`Servico em Operacao`), provando TLS, certificado, SOAP 1.2 e endpoint.
- 2026-09-05: `tools/Yeshua.Engine.Playground` possui `--cte-recepcao` para
  `CTeRecepcaoSincV4`. A chamada com XML CT-e propositalmente incompleto
  retornou HTTP `200 OK` e `cStat=215`, rejeicao de schema. Isso prova a
  comunicacao de recepcao, compactacao GZip/Base64 em `cteDadosMsg` e retorno
  `retCTe`; nao prova autorizacao fiscal completa.
- 2026-09-05: o mesmo Playground autorizou CT-e modelo 57 versao 4.00 em
  homologacao SVSP/PE com XML gerado e assinado localmente. A SEFAZ retornou
  `cStat=100` (`Autorizado o uso do CT-e`), chave
  `26260963249950000174570018377596831037056271` e protocolo
  `526260000515491`. Isso prova o ciclo tecnico minimo de certificado A1,
  assinatura, XML CT-e, IBS/CBS, GZip/Base64, SOAP 1.2, envio sincrono e
  interpretacao de retorno.

Regra:

- Playground pode ser fora da Engine.
- Depois de provado, o conhecimento vira miolo do aplicativo Fiscal.CTe.

## Fase C - Studio E Bordas Do App Fiscal.CTe

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev | Pronto quando |
| --- | --- | --- | --- | --- | --- |
| C01 | CT-P18 | Criar Studio Fiscal.CTe. | Gera projetos por aplicativo. | DSL inicial. | Projetos Fiscal.CTe aparecem e compilam. |
| C02 | CT-P04, CT-P05 | Declarar entidades operacionais. | Domain, repositories, API, worker/testes. | Ajustes de miolo. | Entidades geradas sem acoplar outros modulos. |
| C03 | CT-P04 | Declarar use cases P0. | Commands, receivers, endpoints. | Miolo fiscal. | `EmitirCTe`, `ConsultarStatus`, `ConsultarSituacao`. |
| C04 | CT-P17 | Declarar trilha fiscal minima. | Repositorios e endpoints de consulta. | Registro das etapas fiscais. | Tentativas consultaveis por chave. |

Entidades candidatas:

- `CTe`
- `CTeParticipante`
- `CTeDocumentoOriginario`
- `CTeCarga`
- `CTeValor`
- `CTeImposto`
- `CTeModalRodoviario`
- `CTeTentativaEmissao`
- `CTeXml`
- `CTeProtocolo`
- `CTeEvento`
- `CTeEventoXml`
- `CTeConfiguracaoSefaz`
- `CTeCertificadoReferencia`
- `CTeNumeracao`
- `CTeRetornoSefaz`

Pendencias:

- pendencia: fechar contrato `CTeEmissionRequest` antes de declarar todos os
  campos na DSL.
- pendencia: decidir se configuracao SEFAZ nasce como entidade DSL ou arquivo
  operacional inicialmente.

## Fase D - Emissao Normal P0

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| D01 | CT-P05 | Receber snapshot completo. | Dados minimos chegam sem consultar outro modulo. |
| D02 | CT-P04 | Validar pre-condicoes. | Falhas locais param antes do SEFAZ. |
| D03 | CT-P04 | Reservar numeracao/chave. | Serie/numero/chave transacionais. |
| D04 | CT-P07 | Calculo fiscal minimo. | Cenario real P0 calculado ou bloqueado com mensagem clara. |
| D05 | CT-P04 | Gerar XML oficial. | XML pronto antes de assinatura. |
| D06 | CT-P02 | Assinar e validar XSD. | Erro tecnico separado de rejeicao. |
| D07 | CT-P01, CT-P04 | Enviar para `CTeRecepcaoSincV4`. | Retorno bruto persistido. |
| D08 | CT-P08 | Interpretar retorno. | Estado interno correto. |
| D09 | CT-P17 | Expor diagnostico. | Suporte ve tentativa completa. |

Decisao de sincronismo:

- A borda HTTP pode ser async tecnicamente.
- O miolo decide se espera conclusao da SEFAZ ou grava para processamento
  posterior.
- Para emissao fiscal, o padrao inicial deve privilegiar trilha e seguranca:
  receber, salvar tentativa e executar transmissao com estado claro.

## Fase E - Eventos P1

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev |
| --- | --- | --- | --- | --- |
| E01 | CT-P09 | Cancelamento. | Command/receiver/endpoint. | XML evento, prazo, parser. |
| E02 | CT-P09 | Carta de correcao. | Command/receiver/endpoint. | Campos vedados e texto de correcao. |
| E03 | CT-P08 | Historico de eventos. | Repositories/queries. | Vincular retorno ao CT-e. |
| E04 | CT-P17 | Diagnostico por evento. | Campos/trilha. | Hash XML, cStat, protocolo. |

Pendencias:

- pendencia: confirmar regras de prazo e campos vedados por manual/NT antes de
  validar no dominio.

## Fase F - Integracao Oficial Entre Modulos

| Entrega | Assuntos | Objetivo | Engine | App/IA-dev |
| --- | --- | --- | --- | --- |
| F01 | CT-P18 | Receber romaneio consolidado. | Command/receiver/endpoint. | Validar snapshot oficial. |
| F02 | CT-P18, CT-P04 | Criar solicitacao fiscal. | Repositories e ponto custom. | Normalizar para solicitacao CT-e. |
| F03 | CT-P18, CT-P17 | Persistir entrada oficial. | Entidades e consultas. | Decidir payload bruto, hash e replay. |
| F04 | CT-P18 | Publicar CT-e autorizado para MDF-e. | Command/receiver/outbox quando declarado. | Montar snapshot oficial para MDF-e. |
| F05 | CT-P17 | Diagnosticar fluxo entre modulos. | Telemetria base. | Correlacao romaneio, tentativa e saida MDF-e. |

Decisao atual:

- Fiscal.CTe nao contem contrato legado.
- Integracao normal entre modulos Yeshua usa mensagem oficial, outbox/inbox e
  Worker quando houver processamento posterior.
- REST pode existir como porta oficial para clientes que comprarem somente o
  modulo CT-e, mas nao substitui o barramento interno entre modulos.

Pendencias:

- pendencia: definir gatilho gerado para publicar `CTeAutorizado` em `yOutbox`.
- pendencia: definir tabela ou `yInbox` para persistir payload bruto da entrada
  oficial quando houver necessidade de replay.
- pendencia: conectores SOAP/REST/arquivo de legado ficam para modulos de
  recepcao/carga/integracao, nao para Fiscal.CTe.

## Fase G - Operacao P1

| Entrega | Assuntos | Objetivo | Pronto quando |
| --- | --- | --- | --- |
| G01 | CT-P10 | DACTE basico. | Documento gerado para CT-e autorizado. |
| G02 | CT-P10 | QR Code. | URL correta por ambiente/autorizador. |
| G03 | CT-P03, CT-P08 | Reconciliacao por chave. | Estado local corrigivel por consulta oficial. |
| G04 | CT-P06 | Rateio inicial. | Valor de frete rastreavel por regra. |
| G05 | CT-P17 | Painel/consulta de suporte. | Tentativas, eventos e falhas pesquisaveis. |

## Fase H - Robustez P2

| Entrega | Assuntos | Objetivo |
| --- | --- | --- |
| H01 | CT-P11 | Contingencia SVC/EPEC. |
| H02 | CT-P12 | Distribuicao DF-e. |
| H03 | CT-P09 | Comprovante de entrega. |
| H04 | CT-P09 | Insucesso na entrega. |
| H05 | CT-P09 | Prestacao em desacordo. |
| H06 | CT-P08, CT-P17 | Reprocessamento e replay controlado. |

Pendencias:

- pendencia: nao iniciar H antes de D/E estarem estaveis em homologacao.

## Fase I - Produtos Fiscais Adicionais P3

| Entrega | Assuntos | Produto |
| --- | --- | --- |
| I01 | CT-P13 | CT-e Simplificado |
| I02 | CT-P14 | CT-e OS |
| I03 | CT-P14 | GTV-e |
| I04 | CT-P09 | Registro multimodal |
| I05 | CT-P09 | Vinculacao de pagamento |

Regra:

- Cada produto nasce isolado, com commands e miolos proprios.
- Reutilizar somente infraestrutura fiscal comprovadamente comum.

## Primeiro Recorte Recomendado

O menor ciclo util e:

1. Baixar schema vigente.
2. Provar status e consulta em homologacao.
3. Provar assinatura e XSD.
4. Provar autorizacao de CT-e modelo 57.
5. Criar Studio Fiscal.CTe.
6. Declarar entidades e use cases P0.
7. Gerar bordas.
8. Migrar conhecimento do playground para miolos customizados.
9. Implementar cancelamento.
10. Implementar integracao oficial CT-e -> MDF-e por outbox/inbox.

Esse recorte ja serve para evoluir o Yeshua por demanda real e ao mesmo tempo
mantem CT-e como produto fiscal separado.
