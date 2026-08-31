# CT-e - Contexto Inicial De Emissao

Este documento consolida o primeiro entendimento tecnico para criarmos um
modulo Yeshua de emissao de CT-e. O objetivo inicial e o CT-e de transporte de
carga, modelo 57, comunicando com SEFAZ por webservice oficial.

Pesquisa inicial: 2026-08-28.

Documento complementar de arquitetura:

- [CTE_MODULARIZACAO.md](CTE_MODULARIZACAO.md)
- [CTE_FUNCOES_OFICIAIS.md](CTE_FUNCOES_OFICIAIS.md)
- [CTE_PLANO_DE_PESQUISA.md](CTE_PLANO_DE_PESQUISA.md)
- [CTE_DOSSIE_ASSUNTOS.md](CTE_DOSSIE_ASSUNTOS.md)
- [CTE_BACKLOG_IMPLEMENTACAO.md](CTE_BACKLOG_IMPLEMENTACAO.md)
- [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md)

## Escopo Inicial

Primeiro recorte:

- CT-e modelo 57.
- Emissao normal.
- Autorizacao sincrona pela SEFAZ.
- Consulta de status do servico.
- Consulta de situacao do CT-e.
- Eventos basicos: cancelamento e carta de correcao.
- Armazenamento do XML enviado, XML retornado, protocolo, cStat, xMotivo e
  trilha operacional.

Fora do primeiro recorte:

- CT-e OS, GTV-e e CT-e Simplificado.
- EPEC e SVC como primeira entrega.
- DACTE completo com todos os modais.
- Distribuicao DF-e como rotina automatica.
- PAA/NFF.
- Vinculacao de pagamento, CT-e Simplificado, CT-e OS e GTV-e como primeira
  entrega.

## Pontos Oficiais Ja Confirmados

- O MOC CT-e 4.00 e a referencia base para a comunicacao, XML, certificado,
  assinatura, webservices, eventos, QR Code e contingencia.
- O Anexo I contem leiaute e regras de validacao.
- O Anexo II contem as especificacoes tecnicas do DACTE.
- CT-e 4.00 removeu o SOAP Header dos webservices e eliminou a autorizacao
  assincrona; o fluxo principal deve usar recepcao sincrona.
- A emissao em producao deve ser feita depois de validar em homologacao; testes
  em producao podem disparar controle de uso indevido.
- PE, AP e RR usam a SVSP como autorizador.
- Estados que autorizam na SVSP devem usar SVC-RS em contingencia.
- A lista oficial de servicos trabalha por autorizadores; o modulo deve mapear
  UF para autorizador e depois autorizador para URL.
- Para obter WSDL, usar a URL oficial do servico concatenada com `?wsdl`.

## Endpoints Confirmados

Para Pernambuco, usar SVSP.

Producao SVSP:

- Status: `https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeStatusServicoV4.asmx`
- Consulta: `https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx`
- Evento: `https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx`
- Recepcao CT-e modelo 57: `https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoSincV4.asmx`
- QR Code: `https://nfe.fazenda.sp.gov.br/CTeConsulta/qrCode`

Homologacao SVSP:

- Status: `https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeStatusServicoV4.asmx`
- Consulta: `https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx`
- Evento: `https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx`
- Recepcao CT-e modelo 57: `https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoSincV4.asmx`
- QR Code: `https://homologacao.nfe.fazenda.sp.gov.br/CTeConsulta/qrCode`

Distribuicao DF-e:

- Producao AN: `https://www1.cte.fazenda.gov.br/CTeDistribuicaoDFe/CTeDistribuicaoDFe.asmx`
- Homologacao AN: `https://hom1.cte.fazenda.gov.br/CTeDistribuicaoDFe/CTeDistribuicaoDFe.asmx`

## Fluxo Tecnico De Emissao

Fluxo minimo para autorizar um CT-e:

1. Receber uma intencao de emissao: pedido, carga, tomador, remetente,
   destinatario, origem, destino, valores, impostos e modal.
2. Validar dados estruturais no dominio do aplicativo.
3. Gerar numero, serie, cCT e chave de acesso com digito verificador.
4. Montar o XML `CTe` conforme schema vigente.
5. Assinar digitalmente o XML com certificado ICP-Brasil do emitente ou
   prestador autorizado.
6. Validar o XML assinado contra XSD.
7. Transmitir para `CTeRecepcaoSincV4` do autorizador da UF.
8. Interpretar retorno: `cStat`, `xMotivo`, protocolo, data de autorizacao e
   XML processado.
9. Persistir XML enviado, retorno bruto, XML autorizado/processado, protocolo,
   ambiente, endpoint, schema usado e status operacional.
10. Liberar DACTE/QR Code quando autorizado.

## Modelo De Dominio Inicial

Entidades candidatas para a primeira versao:

- `CTe`
- `CTeParticipante`
- `CTeCarga`
- `CTeDocumentoOriginario`
- `CTeValor`
- `CTeImposto`
- `CTeModalRodoviario`
- `CTeTentativaEmissao`
- `CTeEvento`
- `CTeEventoXml`
- `CTeProtocolo`
- `CTeXml`
- `CTeRetornoSefaz`
- `CTeConfiguracaoSefaz`
- `CTeCertificadoReferencia`
- `CTeNumeracao`

Nao transformar o leiaute inteiro do XML em DSL logo de inicio. A DSL deve
modelar o dominio operacional. O XML fiscal deve nascer de um builder/mapper
especializado do aplicativo Fiscal.CTe.

## Contratos Tecnicos Candidatos

Esses contratos pertencem ao aplicativo fiscal ou a uma biblioteca fiscal
especifica. Nao devem ir para Shared generico enquanto forem SEFAZ-specific.

- `ICTeXmlBuilder`
- `ICTeXmlSigner`
- `ICTeSchemaValidator`
- `ICTeSefazClient`
- `ICTeEndpointResolver`
- `ICTeQrCodeBuilder`
- `IDacteRenderer`
- `ICTeContingencyPolicy`
- `ICTeReturnParser`

## Divisao Yeshua

Engine:

- Gera bordas CQRS, commands, receivers, endpoints, repositorios, workers e
  pontos de extensao.
- Pode gerar tabelas operacionais e trilha padrao.
- Nao deve conhecer regras de CT-e, cStat, XML SEFAZ ou endpoints por UF.

Studio/DSL:

- Declara modulo fiscal, entidades operacionais, use cases e conectores.
- Deve ser pequena e pragmatica.
- Pode declarar que um use case e assincrono, que gera inbox/outbox ou que
  expõe uma borda externa.

Aplicativo Fiscal.CTe:

- Contem miolos de emissao, assinatura, validacao XSD, comunicacao SEFAZ,
  tratamento de retorno e DACTE.
- Guarda schemas, WSDLs, templates fiscais e configuracoes especificas.
- Decide quando processar sincronamente ou persistir para processamento
  posterior.

## Operacao E Observabilidade

Cada tentativa de emissao deve registrar:

- Aplicativo, ambiente, UF, autorizador, servico e endpoint.
- Chave de acesso, serie, numero e CNPJ do emitente.
- Versao de schema e versao de leiaute.
- Hash do XML enviado.
- Status interno, cStat, xMotivo, protocolo e data/hora do retorno.
- Tempo de montagem, assinatura, validacao XSD e transmissao.
- Erro tecnico separado de rejeicao fiscal.

O payload bruto recebido por conectores externos pode entrar em `yInbox`. A
emissao para SEFAZ pode usar command/receiver direto ou outbox, dependendo do
SLA e da necessidade de retry. A decisao fica no miolo do aplicativo.

## Proximas Perguntas Tecnicas

- Qual biblioteca C# usaremos como apoio para XML, assinatura, schema e SOAP:
  propria, ACBrLib, Zeus/NFe.NET, sped-nfe ou outra?
- O modulo Fiscal.CTe sera um novo Studio (`Yeshua.Studio.Fiscal.CTe`) ou sera
  agregado ao fiscal existente junto com MDF-e? A pre-decisao favorece projeto
  independente quando o modulo puder ser vendido, publicado e implantado sozinho.
- O primeiro caso real vira do conector APS ou de uma emissao nativa Yeshua?
- Como guardar certificado em desenvolvimento, homologacao e producao?
- Quais modais serao realmente necessarios no primeiro cliente?

## Plano Curto

1. Baixar schemas XML CT-e oficiais vigentes.
2. Criar um playground isolado para status/consulta/autorizacao CT-e em
   homologacao.
3. Validar SOAP 4.00 sem header legado.
4. Desenhar a DSL minima do modulo Fiscal.CTe.
5. Gerar bordas pelo motor.
6. Implementar o miolo customizado de emissao no aplicativo.
7. Persistir XMLs, protocolo e trilha operacional.
8. Integrar com conectores APS quando a emissao nativa estiver comprovada.
