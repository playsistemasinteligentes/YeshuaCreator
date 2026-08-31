# CT-e - Referencias De Codigo Aberto

Criado em 2026-08-28.

Este arquivo cataloga projetos open-source usados como referencia tecnica para
o modulo Fiscal.CTe. Essas referencias nao sao fonte fiscal oficial. Antes de
copiar qualquer decisao para o Yeshua, validar contra MOC, Anexo I, Anexo II,
notas tecnicas e schemas XML vigentes.

## Regra De Uso

- Usar para comparar sequencia tecnica, organizacao de codigo e exemplos de
  chamada.
- Nao usar como fonte final para regra fiscal, cStat, schema, endpoint ou prazo.
- Nao copiar arquitetura inteira para dentro do Yeshua.
- Nao colocar dependencia de biblioteca fiscal dentro da Engine.
- Se uma biblioteca for adotada, ela pertence ao aplicativo Fiscal.CTe ou a uma
  biblioteca fiscal especifica do aplicativo.
- Verificar licenca antes de empacotar, distribuir ou modificar codigo.

## DFe.NET / ZeusAutomacao

Repositorio:

- https://github.com/ZeusAutomacao/DFe.NET

Referencia local:

- `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\DFe.NET`

Snapshot baixado:

- Branch: `master`
- Commit: `f07f6cf`
- Modo: clone raso com sparse-checkout das pastas CT-e/DFe relevantes.

Licenca declarada:

- LGPL, conforme `README.md` e cabecalhos dos arquivos.

Escopo declarado pelo README:

- Biblioteca C# para NFe, NFCe, MDF-e e CT-e.
- Suporte declarado para CT-e 3.0/4.0.
- Projetos demo para CT-e, incluindo console .NET.
- NuGet `Zeus.Net.CTe`.

Alerta importante:

- O README informa que adequacoes da Reforma Tributaria do Consumo para CT-e e
  MDF-e ainda serao tratadas futuramente. Portanto, esta referencia nao deve ser
  usada como base definitiva para RTC em CT-e.

## Pastas Baixadas

- `CTe.AppTeste.NetCore`
- `CTe.AppTeste`
- `CTe.Classes`
- `CTe.Servicos`
- `CTe.Utils`
- `CTe.Wsdl`
- `CTe.Dacte.Base`
- `CTe.Dacte.OpenFast`
- `DFe.Classes`
- `DFe.Utils`
- `DFe.Wsdl`
- `Shared.NFe`

## Pontos Uteis Para Estudo

### Recepcao Sincrona CT-e 4.00

Arquivo:

- `CTe.Servicos\Recepcao\ServicoCTeRecepcao.cs`

Ponto de estudo:

- Metodo `CTeRecepcaoSincronoV4`.

Sequencia observada:

1. Ajusta dados especiais de homologacao.
2. Define `tpEmis`.
3. Assina o CT-e.
4. Monta QR Code.
5. Salva XML antes da validacao.
6. Valida schema.
7. Cria WSDL de recepcao sincrona V4.
8. Chama `CTeRecepcaoSincV4`.
9. Carrega retorno em `retCTe`.
10. Salva XML de retorno.

Uso no Yeshua:

- Aproveitar como checklist da prova P0.
- Implementar a sequencia em miolos do aplicativo Fiscal.CTe.
- Manter cada etapa observavel e persistivel.

### Status Do Servico

Arquivo:

- `CTe.Servicos\ConsultaStatus\StatusServico.cs`

Ponto de estudo:

- Metodo `ConsultaStatusV4`.

Sequencia observada:

1. Cria XML `consStatServCTe`.
2. Valida schema se configurado.
3. Salva XML se configurado.
4. Cria WSDL de status.
5. Chama `cteStatusServicoCT`.
6. Converte retorno para `retConsStatServCTe`.

Uso no Yeshua:

- Base para playground de status antes da emissao.
- Separar disponibilidade SEFAZ de regra de negocio.

### Consulta De Situacao

Arquivo:

- `CTe.Servicos\ConsultaProtocolo\ConsultaProtcoloServico.cs`

Ponto de estudo:

- Metodo `ConsultaProtocoloV4`.

Uso no Yeshua:

- Base para reconciliacao por chave.
- Validar o envelope e o parser contra WSDL/schema oficial.

### Eventos CT-e

Arquivo:

- `CTe.Servicos\Eventos\ServicoController.cs`

Ponto de estudo:

- Metodos `Executar` e `ExecutarAsync`.

Sequencia observada:

1. Cria evento por tipo, sequencia, chave, CNPJ e container.
2. Assina o evento.
3. Valida schema se configurado.
4. Salva XML.
5. Resolve WSDL conforme versao.
6. Chama `cteRecepcaoEvento`.
7. Carrega retorno em `retEventoCTe`.

Uso no Yeshua:

- Confirmar que o webservice oficial e comum, mas internamente manter command e
  receiver por evento.

### WSDL E Configuracao De Chamada

Arquivo:

- `CTe.Servicos\Factory\WsdlFactory.cs`

Pontos de estudo:

- `CriaWsdlCteStatusServico`
- `CriaWsdlConsultaProtocoloV4`
- `CriaWsdlCteRecepcaoSincronoV4`
- `CriaWsdlCteEventoV4`
- `CriaWsdlCTeDistDFeInteresse`

Uso no Yeshua:

- Inspirar `ICTeEndpointResolver` e `ICTeSefazClient`.
- Nao acoplar resolucao de endpoint na regra fiscal.

### URLs Por Ambiente E Autorizador

Arquivo:

- `CTe.Servicos\Enderecos\Helpers\UrlHelper.cs`

Pontos de estudo:

- SVSP producao/homologacao.
- SVRS producao/homologacao.
- SVC-RS e SVC-SP.
- QR Code.

Uso no Yeshua:

- Comparar contra o Portal CT-e antes de adotar.
- Montar matriz propria UF -> autorizador -> URL.

### Assinatura Digital

Arquivo:

- `DFe.Utils\Assinatura\AssinaturaDigital.cs`

Ponto de estudo:

- XMLDSig com enveloped signature, canonicalizacao e certificado X509.

Uso no Yeshua:

- Servir como comparacao para `ICTeXmlSigner`.
- Confirmar algoritmos aceitos no schema/manual vigente antes da implementacao
  definitiva.

### Configuracao Do Servico

Arquivo:

- `CTe.Classes\ConfiguracaoServico.cs`

Pontos de estudo:

- Certificado.
- UF.
- Ambiente.
- Versao do layout.
- Diretorio de schemas.
- Diretorio de XMLs.
- Flag de validacao de schema.

Uso no Yeshua:

- Separar configuracao operacional do dominio.
- Evitar singleton global para regras fiscais no caminho quente do aplicativo.

### DACTE

Pastas:

- `CTe.Dacte.Base`
- `CTe.Dacte.OpenFast`

Uso no Yeshua:

- Referencia para decidir se DACTE inicial sera por biblioteca, template ou
  renderer proprio.
- Avaliar custo de CPU/memoria no Linux/Docker antes de usar em producao.

## Decisao Provisoria

DFe.NET fica como primeira referencia C# para:

- sequencia de emissao CT-e 4.00;
- chamadas de status e consulta;
- evento CT-e;
- assinatura XML;
- resolucao de endpoint;
- DACTE.

O modulo Yeshua nao deve depender dele automaticamente. A proxima decisao e
testar se vale usar a biblioteca diretamente no aplicativo Fiscal.CTe ou apenas
como referencia para uma implementacao propria enxuta.

## Unimake.DFe

Repositorio:

- https://github.com/Unimake/DFe

Referencia local:

- `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\Unimake.DFe`

Snapshot baixado:

- Branch: `main`
- Commit: `25ff3f0`
- Modo: clone raso com sparse-checkout das pastas CT-e, CT-e OS, configs,
  consumo de servico e testes CT-e.

Licenca declarada:

- MIT, conforme `README.md`.

Escopo declarado pelo README:

- Biblioteca open-source para documentos fiscais eletronicos.
- Suporte declarado para NFe, NFCe, MDFe, CTe, NFSe, GNRE, EFDReinf e outros.
- Suporte multiplataforma e multilanguage.
- NuGet `Unimake.DFe`.

Pastas baixadas:

- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\CTe`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\CTeOS`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\CTe`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\CTeOS`
- `source\Unimake.DFe.Test\CTe`
- `source\Unimake.DFe.Test\CTeOS`
- `source\Unimake.DFe.Test\CTeSimp`
- `source\Unimake.DFe.Test\Utility\Validacao\XMLteste\CTe`

### Autorizacao Sincrona

Arquivo:

- `source\.NET Standard\Unimake.Business.DFe\Servicos\CTe\AutorizacaoSinc.cs`

Pontos de estudo:

- Extrai `cUF`, `tpAmb`, `mod`, `tpEmis` e versao do proprio XML.
- Monta QR Code apos assinatura.
- Usa validacao XML centralizada.
- Mantem resultado `CteProc` quando o protocolo autoriza o documento.

Uso no Yeshua:

- Boa referencia para separar configuracao derivada do XML de configuracao
  operacional persistida.
- Boa referencia para retornar XML processado/protocolado.

### Transporte SOAP

Arquivos:

- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico\Builders\SoapEnvelopeBuilder.cs`
- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico\Transport\SoapTransportExecutor.cs`
- `source\.NET Standard\Unimake.Business.DFe\ConsumirServico\Parsers\SoapResponseParser.cs`

Pontos de estudo:

- Montagem de envelope SOAP separada do servico fiscal.
- Tratamento de compressao GZip quando o servico exige.
- Remocao de declaracao XML antes de inserir corpo no envelope.
- Parser separado para retorno SOAP.

Uso no Yeshua:

- Reforca criar `ICTeSefazClient` independente de `ICTeXmlBuilder`.
- Evitar que cada receiver monte envelope manualmente.
- Separar falha HTTP/SOAP de rejeicao fiscal retornada pela SEFAZ.

### Configuracoes Por UF/Autorizador

Pastas:

- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\CTe`
- `source\.NET Standard\Unimake.Business.DFe\Servicos\Config\CTeOS`

Pontos de estudo:

- Configuracao de servicos por documento fiscal, UF, ambiente e autorizador.
- Arquivos especificos para `SVSP` e `SVRS`.

Uso no Yeshua:

- Confirmar se vale usar arquivos de configuracao versionados no aplicativo
  Fiscal.CTe em vez de URLs fixas no codigo.
- Comparar sempre com o Portal CT-e antes de adotar.

### Testes E XMLs De Exemplo

Pastas:

- `source\Unimake.DFe.Test\CTe`
- `source\Unimake.DFe.Test\Utility\Validacao\XMLteste\CTe`

Pontos de estudo:

- XMLs por modal.
- XMLs de retorno de consulta.
- Eventos recentes como comprovante, insucesso e vinculacao de pagamento.
- Testes de autorizacao, status, consulta, distribuicao e eventos.

Uso no Yeshua:

- Excelente base para montar testes locais de serializacao, assinatura e XSD.
- Nao usar dados de teste como regra fiscal sem conferir no schema vigente.

## Comparacao Inicial

| Tema | DFe.NET | Unimake.DFe | Impacto no Yeshua |
| --- | --- | --- | --- |
| Licenca | LGPL | MIT | Unimake tende a ser mais simples para empacotamento; validar juridicamente antes de distribuir. |
| CT-e 4.00 | Declarado no README e possui servicos V4. | Declarado no README e possui servicos CT-e. | Ambas servem para referencia P0. |
| Transporte | WSDL factory por servico. | Transporte SOAP separado em camada propria. | Yeshua deve preferir cliente SEFAZ isolado. |
| URLs | `UrlHelper` em codigo. | XMLs de configuracao por UF/autorizador. | Yeshua deve evitar URL fixa no miolo fiscal. |
| Testes/XMLs | Apps teste e exemplos. | Muitos testes e XMLs por modal/evento. | Unimake parece forte para massa de testes. |
| RTC CT-e | README alerta suporte futuro. | Ha recursos/testes RTC no snapshot baixado. | Confirmar tudo em NT/schema oficial antes de implementar. |

Decisao tecnica provisoria:

- Usar DFe.NET para entender sequencia de servicos e WSDL.
- Usar Unimake para estudar separacao de transporte, configs por UF e massa de
  XMLs/testes.
- Ainda nao escolher dependencia definitiva.
- Primeiro implementar playground comparativo de status/consulta CT-e.

## Pendencias

- pendencia: pesquisar Hercules-NET/ZeusFiscal, fork/sucessor do DFe.NET, antes
  da decisao final de biblioteca.
- pendencia: verificar compatibilidade de runtime Linux/Docker e licenca antes
  de empacotar biblioteca em produto.
- pendencia: validar todos os endpoints e schemas observados no DFe.NET contra
  o Portal CT-e atual.
- pendencia: validar todos os endpoints e schemas observados no Unimake.DFe
  contra o Portal CT-e atual.
- pendencia: executar uma prova de status/consulta CT-e usando essa referencia
  ou usando cliente proprio comparado a ela.
