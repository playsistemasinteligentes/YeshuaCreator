# MDF-e - Contexto Inicial

Pesquisa inicial: 2026-08-28.

Este documento consolida o entendimento tecnico para evoluir o modulo
Fiscal.MDFe no Yeshua. Diferente do CT-e, o primeiro recorte real ja provado no
repositorio e o encerramento de MDF-e autorizado, usando evento oficial
`110112` pelo webservice `MDFeRecepcaoEvento`.

Documentos complementares:

- [MDFE_MODULARIZACAO.md](MDFE_MODULARIZACAO.md)
- [MDFE_FUNCOES_OFICIAIS.md](MDFE_FUNCOES_OFICIAIS.md)
- [MDFE_PLANO_DE_PESQUISA.md](MDFE_PLANO_DE_PESQUISA.md)
- [MDFE_DOSSIE_ASSUNTOS.md](MDFE_DOSSIE_ASSUNTOS.md)
- [MDFE_BACKLOG_IMPLEMENTACAO.md](MDFE_BACKLOG_IMPLEMENTACAO.md)

## Ideia Oficial Do MDF-e

O MDF-e e um documento fiscal eletronico nacional para manifestar documentos
fiscais em transito. Ele identifica carga, percurso, unidade de transporte,
condutores, documentos originarios e caracteristicas do transporte.

O Portal MDF-e informa que o documento deve ser emitido por:

- empresas prestadoras de servico de transporte para prestacoes com mais de um
  conhecimento de transporte;
- demais empresas quando o transporte for realizado com veiculo proprio,
  arrendado ou por transportador autonomo, com mais de uma nota fiscal.

Consequencia arquitetural:

- MDF-e depende de documentos originarios, mas nao deve conhecer o miolo de
  CT-e, NF-e, pedido, estoque ou carga.
- MDF-e recebe snapshots ou requests.
- CT-e/NF-e podem alimentar MDF-e, mas MDF-e nao vira dono desses modulos.

## Escopo Inicial Do Yeshua

Primeiro recorte:

- MDF-e versao 3.00.
- Encerramento de MDF-e ja autorizado.
- Consulta de situacao.
- Consulta de MDF-e nao encerrados.
- Consulta de status do servico.
- Persistencia de tentativa, XML enviado, XML retornado, protocolo, `cStat`,
  `xMotivo`, data/hora e trilha operacional.

Segundo recorte:

- Cancelamento.
- Inclusao de condutor.
- DAMDFE e QR Code.
- Emissao completa de MDF-e rodoviario.

Fora do primeiro recorte:

- MDF-e completo para todos os modais.
- MDF-e Integrado completo.
- Pagamento/alteracao/confirmacao de servico.
- Distribuicao automatica.
- InfraSA/DTe automatizado.
- PAA/NFF.
- CIOT obrigatorio como bloqueio total antes de confirmar o primeiro caso real.

## Pontos Oficiais Ja Confirmados

- A versao atual de referencia dos manuais e MOC MDFe 3.00b.
- O Portal MDF-e/SVRS lista servicos oficiais de producao e homologacao.
- Para obter WSDL, usar a URL oficial do servico concatenada com `?wsdl`.
- O autorizador MDF-e atual aparece como SVRS Ambiente Nacional.
- A URL de QR Code do MDF-e e `https://dfe-portal.svrs.rs.gov.br/mdfe/qrCode`.
- O Portal MDF-e lista janela de manutencao programada dos ambientes DFe aos
  domingos das 07h00 as 09h00.

## Endpoints Oficiais Confirmados

Producao SVRS:

- Recepcao de evento: `https://mdfe.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx`
- Consulta: `https://mdfe.svrs.rs.gov.br/ws/MDFeConsulta/MDFeConsulta.asmx`
- Status: `https://mdfe.svrs.rs.gov.br/ws/MDFeStatusServico/MDFeStatusServico.asmx`
- Nao encerrados: `https://mdfe.svrs.rs.gov.br/ws/MDFeConsNaoEnc/MDFeConsNaoEnc.asmx`
- Distribuicao DF-e: `https://mdfe.svrs.rs.gov.br/ws/MDFeDistribuicaoDFe/MDFeDistribuicaoDFe.asmx`
- Recepcao sincrona: `https://mdfe.svrs.rs.gov.br/ws/MDFeRecepcaoSinc/MDFeRecepcaoSinc.asmx`
- QR Code: `https://dfe-portal.svrs.rs.gov.br/mdfe/qrCode`

Homologacao SVRS:

- Recepcao de evento: `https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx`
- Consulta: `https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeConsulta/MDFeConsulta.asmx`
- Status: `https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeStatusServico/MDFeStatusServico.asmx`
- Nao encerrados: `https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeConsNaoEnc/MDFeConsNaoEnc.asmx`
- Distribuicao DF-e: `https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeDistribuicaoDFe/MDFeDistribuicaoDFe.asmx`
- Recepcao sincrona: `https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeRecepcaoSinc/MDFeRecepcaoSinc.asmx`
- QR Code: `https://dfe-portal.svrs.rs.gov.br/mdfe/qrCode`

## Prova Local Existente

O arquivo [Program.cs](../../../tools/Yeshua.Engine.Playground/Program.cs)
mantem um playground isolado de encerramento:

- monta `eventoMDFe` versao 3.00;
- usa `tpEvento` `110112`;
- assina `infEvento`;
- valida ausencia de espacos/quebras de formatacao no XML SOAP;
- envia SOAP 1.2 para `MDFeRecepcaoEvento`;
- usa `mdfeCabecMsg` e `mdfeDadosMsg`;
- recebeu retorno real `135 - Evento registrado e vinculado ao MDF-e` durante
  a prova anterior.

Esse playground nao deve virar arquitetura definitiva, mas ele provou o caminho
minimo do encerramento.

## Fluxo Tecnico Do Encerramento

Fluxo minimo:

1. Receber chave do MDF-e.
2. Receber protocolo de autorizacao.
3. Identificar CNPJ do emitente pela chave e/ou certificado.
4. Informar UF e municipio de encerramento.
5. Gerar `eventoMDFe`.
6. Preencher `evEncMDFe`.
7. Assinar XML.
8. Validar XSD do evento.
9. Enviar para `MDFeRecepcaoEvento`.
10. Interpretar retorno.
11. Persistir tentativa, XML, retorno bruto, protocolo do evento e estado.
12. Atualizar MDF-e para encerrado quando `cStat` indicar evento homologado.

## Modelo De Dominio Inicial

Entidades existentes no Studio:

- `MDFe`.
- `MDFeEncerramento`.

Entidades candidatas para evolucao:

- `MDFeDocumentoOriginario`.
- `MDFePercurso`.
- `MDFeMunicipioCarregamento`.
- `MDFeMunicipioDescarregamento`.
- `MDFeVeiculo`.
- `MDFeCondutor`.
- `MDFeContratante`.
- `MDFeSeguro`.
- `MDFeValePedagio`.
- `MDFeCIOT`.
- `MDFePagamento`.
- `MDFeTentativaEvento`.
- `MDFeTentativaEmissao`.
- `MDFeEvento`.
- `MDFeEventoXml`.
- `MDFeXml`.
- `MDFeProtocolo`.
- `MDFeRetornoSefaz`.
- `MDFeConfiguracaoSefaz`.
- `MDFeCertificadoReferencia`.
- `MDFeNumeracao`.
- `MDFeDAMDFE`.

## Contratos Tecnicos Candidatos

Esses contratos pertencem ao aplicativo fiscal ou a uma biblioteca fiscal
especifica. Nao devem ir para Shared generico enquanto forem MDF-e-specific.

- `IMDFeXmlBuilder`
- `IMDFeEventoXmlBuilder`
- `IMDFeXmlSigner`
- `IMDFeSchemaValidator`
- `IMDFeSefazClient`
- `IMDFeEndpointResolver`
- `IMDFeQrCodeBuilder`
- `IDAMDFERenderer`
- `IMDFeReturnParser`
- `IMDFeNaoEncerradoService`
- `IMDFeDocumentoOriginarioNormalizer`

## Divisao Yeshua

Engine:

- Gera bordas CQRS, commands, receivers, endpoints, repositorios, workers e
  pontos de extensao.
- Pode gerar trilha padrao de tentativas, eventos e retornos.
- Nao deve conhecer regra oficial de MDF-e, XML SEFAZ, codigos de rejeicao ou
  endpoint concreto.

Studio/DSL:

- Declara modulo Fiscal.MDFe, entidades operacionais, use cases, conectores e
  policies de execucao.
- Mantem a DSL pequena: declarar intencoes, nao cada tag XML.

Aplicativo Fiscal.MDFe:

- Implementa miolos de encerramento, emissao, eventos, assinatura, XSD, cliente
  SEFAZ, retorno e DAMDFE.
- Guarda schemas, WSDLs, templates fiscais e configuracoes especificas.
- Decide quando processar sincrono, assincrono ou via inbox.

## Operacao E Observabilidade

Cada tentativa fiscal deve registrar:

- Aplicacao, ambiente, servico e endpoint.
- Chave de acesso, UF, CNPJ, serie e numero.
- Tipo de evento, sequencia, protocolo original e protocolo do evento.
- UF e municipio de encerramento quando aplicavel.
- Versao de schema e versao de leiaute.
- Hash do XML enviado.
- Duracao por etapa.
- `cStat`, `xMotivo`, retorno bruto e erro tecnico.
- Situacao interna antes/depois.

## Plano Curto

1. Baixar schemas XML MDF-e vigentes.
2. Confirmar WSDL de `MDFeRecepcaoEvento`, `MDFeConsulta`,
   `MDFeStatusServico` e `MDFeConsNaoEnc`.
3. Migrar o encerramento provado no playground para miolo customizado do app.
4. Persistir tentativa/evento/retorno com trilha operacional.
5. Implementar consulta situacao e nao encerrados.
6. Implementar cancelamento e inclusao de condutor.
7. So entao iniciar emissao completa.

