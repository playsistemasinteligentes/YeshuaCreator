# MDF-e - Referencias De Codigo Aberto

Criado em 2026-08-28.

Este arquivo cataloga projetos open-source usados como referencia tecnica para
o modulo Fiscal.MDFe. Essas referencias nao sao fonte fiscal oficial. Antes de
copiar qualquer decisao para o Yeshua, validar contra MOC, Anexo I, Anexo II,
notas tecnicas, schemas XML e WSDLs oficiais vigentes.

## Regra De Uso

- Usar para comparar sequencia tecnica, organizacao de codigo e exemplos de
  chamada.
- Nao usar como fonte final para regra fiscal, `cStat`, schema, endpoint,
  prazo, obrigatoriedade de campo ou vigencia.
- Nao copiar arquitetura inteira para dentro do Yeshua.
- Nao colocar dependencia de biblioteca fiscal dentro da Engine.
- Se uma biblioteca for adotada, ela pertence ao aplicativo Fiscal.MDFe ou a
  uma biblioteca fiscal especifica do aplicativo.
- Verificar licenca antes de empacotar, distribuir ou modificar codigo.
- Quando o snapshot local estiver incompleto, registrar a limitacao em vez de
  assumir que o projeto possui o codigo necessario no disco.

## DFe.NET / ZeusAutomacao

Repositorio:

- https://github.com/ZeusAutomacao/DFe.NET

Referencia local:

- `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\DFe.NET`

Snapshot baixado:

- Branch: `master`
- Commit: `f07f6cf`
- Modo: clone raso com sparse-checkout das pastas CT-e/DFe comuns.

Licenca declarada:

- LGPL 2.1, conforme `LICENSE` e README.

Escopo declarado pelo README:

- Biblioteca C# para NFe, NFCe, MDF-e e CT-e.
- Suporte declarado para MDF-e 3.0.
- NuGet `Zeus.Net.MDFe`.
- Projetos demo declarados para MDF-e e DAMDFE.

Alerta importante:

- O README informa que adequacoes da Reforma Tributaria do Consumo para CT-e e
  MDF-e ainda serao tratadas futuramente. Portanto, esta referencia nao deve ser
  usada como base definitiva para RTC em MDF-e.
- O snapshot local atual nao contem as pastas `MDFe.Classes`, `MDFe.Servicos`,
  `MDFe.Utils`, `MDFe.Wsdl` ou `MDFe.Damdfe.*`, apesar de a solucao declarar
  esses projetos. Para estudo profundo de emissao MDF-e nessa biblioteca,
  precisamos baixar as pastas MDFe completas.

## Pastas Baixadas No Snapshot Atual

- `CTe.AppTeste`
- `CTe.AppTeste.NetCore`
- `CTe.Classes`
- `CTe.Dacte.Base`
- `CTe.Dacte.OpenFast`
- `CTe.Servicos`
- `CTe.Utils`
- `CTe.Wsdl`
- `DFe.Classes`
- `DFe.Utils`
- `DFe.Wsdl`
- `Shared.NFe`

## Pontos Uteis Para MDF-e Mesmo Sem As Pastas MDFe

### Tipos De Servico MDF-e

Arquivo:

- `DFe.Wsdl\Common\TipoEvento.cs`

Ponto de estudo:

- O enum inclui `MDFeStatusServico`, `MDFeRecepcao`, `MDFeRecepcaoSinc`,
  `MDFeRetRecepcao`, `MDFeNaoEncerrado`, `MDFeConsulta` e `MDFeEvento`.

Uso no Yeshua:

- Confirmar a familia minima P0/P1 do modulo: status, consulta, nao
  encerrados, recepcao de evento, recepcao sincrona e retorno.
- Reforca que servico web oficial e capacidade interna nao sao a mesma coisa.

### SOAPAction / URNs MDF-e

Arquivo:

- `DFe.Wsdl\Common\SoapUrls.cs`

Pontos de estudo:

- `MDFeStatusServico` aponta para namespace de status.
- `MDFeRecepcaoSinc` aponta para namespace de recepcao sincrona.
- `MDFeNaoEncerrado` aponta para `MDFeConsNaoEnc`.
- `MDFeConsulta` aponta para `MDFeConsulta`.
- `MDFeEvento` aponta para `MDFeRecepcaoEvento`.

Uso no Yeshua:

- Comparar com o WSDL oficial antes de codificar.
- Manter `IMDFeSefazClient` com `soapAction`/URN configuravel por servico.
- Evitar `SOAPAction` hardcoded dentro do receiver.

### Cabecalho MDF-e

Arquivos:

- `DFe.Wsdl\Common\mdfeCabecMsg.cs`
- `DFe.Wsdl\Common\mdfeCabMsg.cs`

Ponto de estudo:

- Representam cabecalho com `cUF` e `versaoDados`.

Uso no Yeshua:

- Confirma o padrao ja usado no playground de encerramento.
- O cabecalho continua detalhe do cliente SEFAZ, nao da DSL de dominio.

### Envelope SOAP 1.2

Arquivo:

- `DFe.Wsdl\Common\CommonSOAPEnvelope.cs`

Ponto de estudo:

- Usa namespace SOAP 1.2 `http://www.w3.org/2003/05/soap-envelope`.

Uso no Yeshua:

- Bate com o caminho do playground atual.
- O envelope deve ficar em componente fiscal de transporte, nao no receiver.

### Envio HTTP/SOAP

Arquivo:

- `DFe.Wsdl\Common\RequestSefazHttpClientHandler.cs`

Sequencia observada:

1. Serializa envelope com `XmlSerializer`.
2. Remove BOM UTF-8.
3. Usa `InnerXml` sem formatacao.
4. Configura TLS.
5. Adiciona certificado cliente.
6. Usa `application/soap+xml`.
7. Envia header `SOAPAction`.
8. Le resposta bruta.

Uso no Yeshua:

- Reforca a necessidade de separar `IMDFeSoapEnvelopeBuilder`,
  `IMDFeSefazTransport` e `IMDFeReturnParser`.
- Reforca o cuidado com BOM, declaracao XML, espacos de formatacao e charset.
- Ajuda a explicar por que o erro 599 anterior foi de formato da mensagem.

Alertas:

- Nao copiar callback que aceita qualquer certificado de servidor.
- Evitar chamadas bloqueantes `.Result` no caminho definitivo.
- Validar timeout e tratamento de erro sem perder corpo da resposta.

### Assinatura Digital Comum

Arquivo:

- `DFe.Utils\Assinatura\AssinaturaDigital.cs`

Uso no Yeshua:

- Referencia para `IMDFeXmlSigner`.
- Confirmar algoritmos e transformacoes contra schemas oficiais vigentes antes
  de adotar.

## O Que Precisa Ser Baixado Do DFe.NET Para MDF-e

Baixar no proximo refinamento:

- `MDFe.AppTeste`
- `MDFe.Classes`
- `MDFe.Utils`
- `MDFe.Servicos`
- `MDFe.Wsdl`
- `MDFe.Damdfe.Base`
- `MDFe.Damdfe.Fast`
- `MDFe.Damdfe.OpenFast`
- `MDFe.Damdfe.AppTeste`

Perguntas para responder depois de baixar:

- Como a biblioteca implementa `MDFeRecepcaoEvento`?
- Como implementa `MDFeConsNaoEnc`?
- Como implementa `MDFeConsulta` e `MDFeStatusServico`?
- Como monta `evEncMDFe`?
- Como organiza DAMDFE?
- Como trata retorno `retEventoMDFe`, `retConsSitMDFe` e `retConsMDFeNaoEnc`?

## Unimake.DFe

Repositorio:

- https://github.com/Unimake/DFe

Referencia local:

- `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\Unimake.DFe`

Snapshot baixado:

- Branch: `main`
- Commit: `25ff3f0`
- Modo: clone raso com sparse-checkout das pastas comuns, CT-e e testes CT-e.

Licenca declarada:

- MIT, conforme `LICENSE`.

Escopo declarado pelo README:

- Biblioteca open-source para documentos fiscais eletronicos.
- Suporte declarado para NFe, NFCe, MDFe, CTe, NFSe, GNRE, EFDReinf e outros.
- Suporte multiplataforma e multilanguage.
- NuGet `Unimake.DFe`.
- Referencia ao Unidanfe para impressao de DANFE, DACTE, DAMDFE e outros.

Alerta importante:

- O snapshot local atual nao contem
  `source\.NET Standard\Unimake.Business.DFe\Servicos\MDFe`.
- Mesmo incompleto para MDF-e, o snapshot contem camadas comuns muito uteis para
  SOAP, normalizacao, assinatura e parser de resposta.

## Pastas Baixadas No Snapshot Atual

- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\CTe`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\CTeOS`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\CTe`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\CTeOS`
- `source\Unimake.DFe.Test\CTe`
- `source\Unimake.DFe.Test\CTeOS`
- `source\Unimake.DFe.Test\CTeSimp`
- `source\Unimake.DFe.Test\Utility\Validacao\XMLteste\CTe`

## Pontos Uteis Para MDF-e Mesmo Sem A Pasta MDFe

### Montagem De Envelope SOAP

Arquivo:

- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico\Builders\SoapEnvelopeBuilder.cs`

Pontos de estudo:

- Remove declaracao XML do corpo antes de inserir no envelope.
- Permite compressao GZip quando o servico exigir.
- Trata CDATA, escape de XML e templates de envelope.
- Separa regra de montagem do transporte.

Uso no Yeshua:

- Bom desenho para `IMDFeSoapEnvelopeBuilder`.
- O receiver fiscal nao deve montar envelope manualmente.
- A retirada da declaracao XML do corpo e relevante para evitar rejeicoes de
  formato.

### Transporte SOAP

Arquivo:

- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico\Transport\SoapTransportExecutor.cs`

Pontos de estudo:

- Separa request de transporte em objeto proprio.
- Configura certificado cliente.
- Retorna status HTTP, conteudo e excecao de rede.
- Preserva corpo de erro quando existe resposta HTTP.
- Possui preparacao de conexao TLS antes do envio real.

Uso no Yeshua:

- Reforca `IMDFeSefazTransport` separado de XML, assinatura e parser.
- A resposta HTTP/SOAP deve ser persistida como evidencia tecnica.
- Falha de TLS/certificado deve ser separada de rejeicao SEFAZ.

Alertas:

- O codigo usa `HttpWebRequest`; no Yeshua novo, preferir `HttpClient` se
  mantiver comportamento equivalente.
- Nao copiar validacao permissiva de certificado de servidor.
- Preparacao TLS deve ser configuravel; nao pode dobrar custo em todo envio sem
  necessidade.

### Parser De Resposta SOAP

Arquivo:

- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico\Parsers\SoapResponseParser.cs`

Pontos de estudo:

- Valida retorno vazio.
- Valida retorno nao XML.
- Guarda XML bruto.
- Resolve tag de retorno.
- Trata `soap:Fault`.
- Normaliza retorno antes de carregar XML do servico.

Uso no Yeshua:

- Bom desenho para `IMDFeReturnParser`.
- Separar erro HTTP/SOAP de `retEventoMDFe` com rejeicao fiscal.
- Sempre preservar retorno bruto para suporte.

### Normalizacao XML

Arquivo:

- `source\Unimake.DFe.Test\Utility\Validacao\NormalizacaoXMLTest.cs`

Ponto de estudo:

- Inclui `TipoDFe.MDFe` com raiz `consMDFeNaoEnc` como caso de normalizacao.

Uso no Yeshua:

- Confirma que `consMDFeNaoEnc` merece atencao especial de normalizacao.
- Ajuda na Fase B03 do backlog MDF-e.

### Assinatura E Whitespace

Arquivo:

- `source\Unimake.DFe.Test\Utility\Validacao\AssinaturaDigitalWhitespaceTest.cs`

Pontos de estudo:

- Testa assinatura de documentos fiscais com tag de assinatura e tag com
  atributo `Id` distintas.
- Inclui caso `MDFe` assinando `infMDFe`.
- Testa preservacao de whitespace/comentarios na localizacao do elemento
  assinavel.

Uso no Yeshua:

- Reforca que assinatura deve localizar corretamente `infMDFe`/`infEvento`.
- Nao significa que devemos enviar XML SOAP formatado. Para MDF-e, o teste real
  anterior mostrou rejeicao quando havia caracteres de edicao indevidos.

## O Que Precisa Ser Baixado Do Unimake Para MDF-e

Baixar no proximo refinamento:

- `source\.NET Standard\Unimake.Business.DFe\Servicos\MDFe`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\MDFe`
- `source\Unimake.DFe.Test\MDFe`
- `source\Unimake.DFe.Test\Utility\Validacao\XMLteste\MDFe`
- Exemplos C# de MDFe, se existirem no snapshot completo.

Perguntas para responder depois de baixar:

- Como a Unimake implementa encerramento MDF-e?
- Como implementa consulta de nao encerrados?
- Como organiza endpoint/configuracao por ambiente?
- Como representa eventos MDF-e?
- Como valida XML e assinatura de `eventoMDFe`?
- Como usa Unidanfe/DAMDFE?

## Comparacao Inicial

| Tema | DFe.NET | Unimake.DFe | Impacto no Yeshua |
| --- | --- | --- | --- |
| Licenca | LGPL 2.1 | MIT | Unimake tende a ser mais simples para empacotamento; validar juridicamente antes de distribuir. |
| MDF-e declarado | Sim, MDF-e 3.0 e Zeus.Net.MDFe. | Sim, MDFe no README e NuGet unico. | Ambas merecem estudo completo. |
| Snapshot local MDF-e | Incompleto: sem pastas `MDFe.*`. | Incompleto: sem pasta `Servicos\\MDFe`. | Baixar pastas MDF-e antes de decisao definitiva. |
| SOAP | Camada comum com SOAP 1.2, `SOAPAction`, certificado e `application/soap+xml`. | Builder, transport e parser separados. | Yeshua deve preferir componentes pequenos e separados. |
| Header MDF-e | Possui `mdfeCabecMsg`/`mdfeCabMsg`. | Nao observado no snapshot atual. | Confirmar pelo WSDL/schema oficial. |
| Nao encerrados | Tipo/URN em `SoapUrls`. | Normalizacao testa `consMDFeNaoEnc`. | Prioridade P0/P1 para operacao. |
| Assinatura | `AssinaturaDigital.cs` comum. | Testes validam `MDFe`/`infMDFe`. | Criar signer fiscal no app, nao na Engine. |
| DAMDFE | README e solucao citam projetos DAMDFE. | README aponta Unidanfe para DAMDFE. | Avaliar quando entrar na Fase G. |
| RTC MDF-e | README alerta suporte futuro. | Snapshot local nao permite concluir. | Confirmar tudo em NT/schema oficial. |

## Decisao Tecnica Provisoria

- Usar DFe.NET para estudar SOAPAction/URN, cabecalho MDF-e, envelope SOAP 1.2
  e detalhes comuns de envio com certificado.
- Usar Unimake para estudar separacao de builder de envelope, transporte,
  parser, normalizacao e testes de assinatura.
- Nao escolher dependencia definitiva ainda.
- Baixar as pastas MDF-e completas dos dois projetos antes de decidir entre
  biblioteca pronta e implementacao propria enxuta.
- Manter a primeira implementacao do Yeshua baseada no encerramento ja provado
  no playground, mas reorganizada em componentes pequenos no aplicativo
  Fiscal.MDFe.

## Impacto No Desenho Do Fiscal.MDFe

Componentes candidatos reforcados pelas referencias:

- `IMDFeSoapEnvelopeBuilder`
- `IMDFeSefazTransport`
- `IMDFeSefazClient`
- `IMDFeReturnParser`
- `IMDFeXmlSigner`
- `IMDFeSchemaValidator`
- `IMDFeEndpointResolver`
- `IMDFeXmlNormalizer`
- `IDAMDFERenderer`

Regra:

- Esses contratos pertencem ao aplicativo fiscal ou a uma biblioteca fiscal do
  aplicativo, nao ao Shared generico e nao a Engine.

## Pendencias

- pendencia: ampliar o sparse-checkout do DFe.NET para incluir pastas `MDFe.*`.
- pendencia: ampliar o sparse-checkout do Unimake.DFe para incluir servicos,
  configs, testes e exemplos MDF-e.
- pendencia: validar licenca/empacotamento antes de distribuir biblioteca em
  produto.
- pendencia: comparar `MDFeRecepcaoEvento`, `MDFeConsulta`,
  `MDFeStatusServico` e `MDFeConsNaoEnc` nas duas bibliotecas contra o WSDL
  oficial.
- pendencia: executar prova local de status/consulta/nao encerrados usando
  cliente proprio comparado com as referencias.
- pendencia: decidir se DAMDFE inicial usa Unidanfe, FastReport/OpenFastReport
  ou renderer proprio.
