# CT-e - Interface De Entrada Canonica

Consolidado em 2026-08-28.

Este documento define a entrada canonica do modulo Fiscal.CTe antes de ligar
modulos anteriores, adapters externos ou qualquer origem de dados. A ideia e
ter uma regua limpa: primeiro definimos o que o modulo CT-e precisa receber
para trabalhar bem; depois mapeamos qualquer origem externa para essa entrada.

Documento complementar de fluxo:

- [CTE_FLUXO_ENTRADA_SEFAZ_MDFE.md](CTE_FLUXO_ENTRADA_SEFAZ_MDFE.md)

## Objetivo

A entrada canonica deve permitir que o modulo Fiscal.CTe:

- receba solicitacoes de CT-e vindas de API nativa, fila, tela ou mensagem
  interna de outro modulo;
- preserve o payload bruto para auditoria, replay e diagnostico;
- normalize dados externos para um contrato interno estavel;
- classifique a solicitacao fiscal sem acoplar o conector ao XML da SEFAZ;
- decida se o processamento sera sincrono ou assincrono;
- gere CT-e modelo 57 no primeiro recorte;
- evolua depois para eventos, CT-e Simplificado, CT-e OS, GTV-e,
  contingencia, distribuicao e DACTE.

## Regra Principal

O modulo CT-e nao deve receber entidades vivas de APS, Pedido, Carga,
Faturamento, NF-e, MDF-e ou legado.

Ele deve receber snapshots/requests.

Isso protege o modulo de duas formas:

- outros modulos podem mudar seu banco, entidade e fluxo interno sem quebrar
  CT-e;
- CT-e pode ser vendido e implantado sozinho, recebendo dados pela API oficial.

## Dois Niveis De Entrada

Existem dois niveis e eles nao devem ser confundidos.

### 1. Entrada Bruta

Representa o que chegou pelo canal externo.

Exemplos:

- REST nativo `POST /cte/solicitacoes`;
- planilha importada;
- arquivo TXT/EDI;
- mensagem de fila;
- mensagem interna vinda de outbox/inbox.

A entrada bruta existe para:

- auditoria;
- idempotencia;
- replay;
- diagnostico de suporte;
- rastreio do contrato original;
- correlacao entre token, tenant, payload e tentativa fiscal.

Ela nao deve conter regra fiscal.

### Fronteira Externa E Integracao Interna

SOAP legado, REST de compatibilidade, planilha e arquivo sao portas de entrada
externa. Eles existem para clientes, fabricantes, sistemas legados e cenarios
de contingencia em que o consumidor final precisa trocar apenas o endereco ou
contrato de integracao.

No recorte atual, esses adapters ficam antes do Fiscal.CTe, normalmente em
modulos de recepcao de pedido, montagem/execucao de carga ou integracao. O
Fiscal.CTe recebe somente a mensagem oficial ja convertida para a linguagem
Yeshua.

Entre modulos Yeshua, a integracao normal nao deve usar SOAP nem REST interno.
O produtor publica evento/snapshot em outbox; o consumidor recebe em inbox e
processa por Worker/Receiver proprio. Assim o CT-e pode ser vendido sozinho, e
o MDF-e pode consumir documentos originarios sem acoplar ao banco, tela,
endpoint ou classe interna do CT-e.

### 2. Solicitacao Fiscal Canonica

Representa o pedido interno estavel para o CT-e.

Tudo que chega por canal externo deve ser convertido para ela antes de entrar
no miolo fiscal.

A solicitacao canonica deve ser independente de fabricante, APS, nome de tela,
nome de tabela legada ou estrutura SOAP especifica.

## Contratos Candidatos

Os nomes abaixo sao candidatos iniciais. Podem mudar quando virarem DSL/codigo,
mas a responsabilidade de cada um deve permanecer.

```csharp
public sealed class ReceberRomaneioConsolidadoParaCTeCommand
{
    public CTeEntradaOficial Entrada { get; init; }
    public RomaneioConsolidadoParaCTeSnapshot Romaneio { get; init; }
    public CTePoliticaProcessamento Processamento { get; init; }
}

public sealed class SolicitarEmissaoCTeCommand
{
    public CTeSolicitacaoFiscal Solicitacao { get; init; }
    public CTePoliticaProcessamento Processamento { get; init; }
}
```

`ReceberRomaneioConsolidadoParaCTeCommand` e a primeira borda oficial de
recepcao do CT-e.

`SolicitarEmissaoCTeCommand` e a entrada fiscal ja normalizada.

## CTeEntradaOficial

Representa o envelope oficial interno recebido pelo modulo CT-e.

| Campo | Obrigatorio | Origem | Observacao |
| --- | --- | --- | --- |
| `TenantId` | Sim | Token/contexto | Pode vir resolvido pelo produtor ou pela API oficial. |
| `SourceApplication` | Sim | Origem oficial | Ex.: `ExecucaoCarga`, `Integracao`, `Fiscal.CTe.Api`. |
| `SourceModule` | Desejavel | Origem oficial | Modulo que produziu o snapshot. |
| `SourceMessageId` | Sim | Origem oficial | Idempotencia entre modulos. |
| `MessageType` | Sim | Contrato interno | Ex.: `RomaneioConsolidadoParaCTe`. |
| `MessageVersion` | Sim | Contrato interno | Versao do contrato interno. |
| `CorrelationId` | Sim | Borda | Criado se nao vier da origem. |
| `ReceivedAtUtc` | Sim | Borda | Momento de entrada. |
| `PayloadHash` | Sim | Borda oficial | SHA-256 para idempotencia e diagnostico. |
| `PayloadStorageKey` | Desejavel | Storage | Ponte para snapshot completo quando ele for grande. |

### Onde Persistir

Primeira opcao:

- usar `yInbox` quando o payload for tratado como mensagem operacional generica.

Opcao especifica:

- criar `CTeEntradaOficial` quando precisarmos de consultas fiscais, replay
  seletivo, status de normalizacao e historico detalhado.

Decisao provisoria:

- usar tabela especifica `CTeEntradaOficial` para o modulo CT-e no primeiro
  recorte oficial;
- manter `yInbox` como mecanismo generico de fila/processamento quando a Engine
  ja estiver madura para esse fluxo.

Pendencia:

- decidir se `yInbox` sera suficiente para payload bruto fiscal sem empobrecer
  suporte e auditoria.

## CTeSolicitacaoFiscal

Contrato interno principal. Ele representa a intencao fiscal normalizada.

```csharp
public sealed class CTeSolicitacaoFiscal
{
    public CTeIdentificacaoEntrada Entrada { get; init; }
    public CTeContextoFiscal ContextoFiscal { get; init; }
    public CTeClassificacao Classificacao { get; init; }
    public CTeParticipantes Participantes { get; init; }
    public CTeServicoTransporte Servico { get; init; }
    public CTeCargaEntrada Carga { get; init; }
    public IReadOnlyList<CTeDocumentoOriginarioEntrada> Documentos { get; init; }
    public CTeValoresEntrada Valores { get; init; }
    public CTeTributacaoEntrada Tributacao { get; init; }
    public CTeModalEntrada Modal { get; init; }
    public CTeInformacoesAdicionais InformacoesAdicionais { get; init; }
}
```

O contrato deve ser grande o suficiente para representar o CT-e, mas nao deve
virar uma copia literal do XML oficial. XML e uma projecao fiscal posterior.

## Bloco: Identificacao Da Entrada

Responsavel por manter rastreabilidade.

| Campo | Obrigatorio | Observacao |
| --- | --- | --- |
| `SolicitacaoId` | Sim | Id interno gerado na entrada. |
| `EntradaOficialId` | Desejavel | Ponte para mensagem oficial recebida. |
| `SourceApplication` | Sim | Aplicativo/modulo produtor. |
| `SourceMessageId` | Sim | Idempotencia com origem. |
| `MessageType` | Sim | Tipo da mensagem oficial. |
| `IdempotencyKey` | Sim | Pode nascer de tenant + tipo + versao + id origem + hash. |
| `CorrelationId` | Sim | Rastreio operacional ponta a ponta. |
| `ReceivedAtUtc` | Sim | Entrada no Yeshua. |
| `RequestedAtUtc` | Opcional | Data da solicitacao de negocio. |

## Bloco: Contexto Fiscal

Responsavel por dados que normalmente virao do token, tenant ou configuracao.

| Campo | Obrigatorio | Observacao |
| --- | --- | --- |
| `TenantId` | Sim | Resolvido pelo token. |
| `ClienteId` | Desejavel | Cliente operacional quando diferente do tenant. |
| `Ambiente` | Sim | Homologacao ou Producao. |
| `UFEmitente` | Sim | Define autorizador/endpoints. |
| `MunicipioEmitenteCodigoIbge` | Sim | Necessario no XML. |
| `EmitenteDocumento` | Sim | CNPJ/CPF do emissor. |
| `InscricaoEstadualEmitente` | Sim | Conforme cadastro fiscal. |
| `CertificadoReferenciaId` | Sim | Nunca embutir certificado no command. |
| `VersaoLeiaute` | Sim | Primeiro recorte: `4.00`. |
| `Autorizador` | Derivado | Ex.: SVSP, SVRS, MG etc. |
| `SeriePreferencial` | Opcional | Pode ser resolvida por numeracao. |

Regra:

- conector externo nao escolhe certificado diretamente;
- conector informa token/contexto;
- modulo resolve configuracao fiscal do tenant.

## Bloco: Classificacao

Responsavel por declarar ou permitir derivar qual fluxo fiscal sera executado.

| Campo | Obrigatorio | Valores candidatos |
| --- | --- | --- |
| `ProdutoFiscal` | Sim | `CTeCargaModelo57`, `CTeSimplificado`, `CTeOS`, `GTVe`. |
| `TipoCTe` | Sim | `Normal`, `Complemento`, `Substituicao`. |
| `TipoServico` | Sim | `Normal`, `Subcontratacao`, `Redespacho`, `RedespachoIntermediario`, `Multimodal`. |
| `Modal` | Sim | `Rodoviario`, `Aereo`, `Aquaviario`, `Ferroviario`, `Dutoviario`, `Multimodal`. |
| `Globalizado` | Sim | `true`/`false`. |
| `Contingencia` | Sim | `Normal`, `EPEC`, `SVC`, `FSDA`. |
| `ProcessoEmissao` | Sim | Aplicativo contribuinte, contingencia etc. |

Primeiro recorte:

- `ProdutoFiscal = CTeCargaModelo57`;
- `TipoCTe = Normal`;
- `TipoServico = Normal`;
- `Modal = Rodoviario`;
- `Globalizado = false`;
- `Contingencia = Normal`.

Mas o contrato ja deixa espaco para redespacho, complemento e outras variantes
sem transformar `EmitirCTe` em um `switch` gigante.

## Bloco: Participantes

Responsavel por pessoas fiscais envolvidas.

Participantes candidatos:

- emitente;
- remetente;
- destinatario;
- expedidor;
- recebedor;
- tomador;
- outros quando o leiaute exigir.

Cada participante deve ser snapshot:

```csharp
public sealed class CTeParticipanteEntrada
{
    public TipoParticipanteCTe Tipo { get; init; }
    public string Documento { get; init; }
    public string Nome { get; init; }
    public string InscricaoEstadual { get; init; }
    public EnderecoFiscalEntrada Endereco { get; init; }
    public string Telefone { get; init; }
    public string Email { get; init; }
}
```

Regra:

- participante e snapshot fiscal, nao FK viva para cadastro de pessoa;
- o modulo pode guardar uma referencia externa, mas a emissao deve preservar o
  dado fiscal usado naquele momento.

## Bloco: Servico De Transporte

Representa a prestacao que o CT-e documenta.

Campos candidatos:

| Campo | Obrigatorio | Observacao |
| --- | --- | --- |
| `NaturezaOperacao` | Sim | Texto fiscal. |
| `CFOP` | Sim | Pode ser informado ou derivado por policy. |
| `MunicipioInicioCodigoIbge` | Sim | Inicio da prestacao. |
| `UFInicio` | Sim | Inicio da prestacao. |
| `MunicipioFimCodigoIbge` | Sim | Fim da prestacao. |
| `UFFim` | Sim | Fim da prestacao. |
| `Retira` | Opcional | Indicador conforme leiaute. |
| `DetalheRetira` | Opcional | Texto quando aplicavel. |
| `PrevisaoEntrega` | Opcional | Pode vir da logistica, nao e nucleo fiscal P0. |
| `CaracteristicaTransporte` | Opcional | Texto operacional/fiscal. |
| `CaracteristicaServico` | Opcional | Texto operacional/fiscal. |

Redespacho/subcontratacao devem ser tratados aqui por tipo de servico e
documentos anteriores, nao como conector separado.

## Bloco: Carga

Representa o objeto transportado.

Campos candidatos:

| Campo | Obrigatorio | Observacao |
| --- | --- | --- |
| `ValorCarga` | Sim | Valor total declarado. |
| `ProdutoPredominante` | Sim | Produto predominante transportado. |
| `OutrasCaracteristicas` | Opcional | Livre conforme necessidade. |
| `QuantidadeVolumes` | Opcional | Quando conhecido. |
| `PesoBruto` | Desejavel | Importante para rateio e transporte. |
| `PesoLiquido` | Opcional | Conforme origem. |
| `Cubagem` | Opcional | Logistica. |
| `Medidas` | Opcional | Lista de unidades/pesos/volumes. |

Regra:

- carga aqui e snapshot da carga fiscal para CT-e;
- planejamento logistico pode ter uma carga muito mais rica fora do modulo.

## Bloco: Documentos Originarios

Representa NF-e, NF, outros CT-es, documentos anteriores e referencias.

```csharp
public sealed class CTeDocumentoOriginarioEntrada
{
    public TipoDocumentoOriginarioCTe Tipo { get; init; }
    public string ChaveAcesso { get; init; }
    public string Numero { get; init; }
    public string Serie { get; init; }
    public DateTime? EmitidoEm { get; init; }
    public decimal? ValorDocumento { get; init; }
    public string DocumentoEmitente { get; init; }
    public string UfEmitente { get; init; }
    public string ReferenciaExterna { get; init; }
}
```

Tipos candidatos:

- `NFe`;
- `NF`;
- `Outro`;
- `CTeAnterior`;
- `DocumentoAnteriorRedespacho`;
- `Declaracao`;
- outros conforme schema.

Regra:

- documento originario nao e entidade NF-e viva;
- e snapshot do documento usado para compor o CT-e.

## Bloco: Valores E Rateio

Representa valores recebidos e politica para calcular/distribuir.

Campos candidatos:

| Campo | Obrigatorio | Observacao |
| --- | --- | --- |
| `ValorTotalServico` | Sim | Valor da prestacao. |
| `ValorAReceber` | Sim | Valor cobrado/recebido. |
| `Componentes` | Opcional | Frete peso, valor, pedagio, seguro, outros. |
| `RegraRateio` | Opcional | Peso, valor NF, volume, pedido, fixo, custom. |
| `RateiosInformados` | Opcional | Quando origem ja enviar rateio. |
| `Moeda` | Opcional | Normalmente BRL. |

Rateio e capacidade propria. Ele nao pode conhecer SOAP, XML SEFAZ ou
certificado.

## Bloco: Tributacao

Representa dados fiscais que podem vir informados ou ser calculados.

Campos candidatos:

- regime tributario do emitente;
- CST/CSOSN quando aplicavel;
- base ICMS;
- aliquota ICMS;
- valor ICMS;
- reducao;
- beneficio fiscal;
- partilha/diferimento quando aplicavel;
- dados RTC quando o recorte exigir.

Decisao:

- P0 pode aceitar tributacao informada para romper emissao;
- depois criamos `CTeTributacaoPolicy` para derivar/calcular por UF, regime,
  tomador, CFOP e regra vigente.

## Bloco: Modal

Representa dados especificos do modal.

Para P0, o foco e rodoviario.

Campos candidatos para rodoviario:

- RNTRC;
- CIOT, se aplicavel;
- dados de lotacao, se aplicavel;
- dados especificos que o schema exigir no recorte real.

Regra:

- modal tem pasta/objeto proprio;
- nao espalhar campo rodoviario em todos os contratos genericos.

## Bloco: Informacoes Adicionais

Representa textos e referencias complementares.

Campos candidatos:

- informacoes ao fisco;
- informacoes complementares;
- observacoes do contribuinte;
- observacoes internas;
- referencias externas de pedido/carga;
- tags auxiliares para suporte.

Observacao:

- informacao interna nao deve vazar para XML se nao for explicitamente mapeada.

## Bloco: Politica De Processamento

Controla como a entrada sera processada.

```csharp
public sealed class CTePoliticaProcessamento
{
    public ModoProcessamentoCTe Modo { get; init; }
    public bool AguardarAutorizacao { get; init; }
    public bool PersistirPayloadBruto { get; init; }
    public bool PermitirReplay { get; init; }
    public int Prioridade { get; init; }
}
```

Valores candidatos:

- `ReceberSomente`: grava entrada e devolve protocolo.
- `Assincrono`: grava entrada e agenda processamento.
- `SincronoAteValidacao`: normaliza, valida e devolve pendencia/erro sem SEFAZ.
- `SincronoAteAutorizacao`: processa ate retorno SEFAZ.

Regra:

- a borda pode aceitar qualquer modo permitido;
- a decisao final pertence ao miolo/receiver, considerando conector, tenant,
  SLA e caracteristica da operacao.

## Matriz Minima Por Cenario

### Emissao Normal P0

Minimo esperado:

- contexto fiscal completo;
- classificacao como CT-e modelo 57 normal;
- emitente, remetente, destinatario e tomador;
- municipio/UF inicio e fim;
- pelo menos um documento originario quando exigido pelo cenario;
- valor do servico;
- valor da carga;
- dados rodoviarios minimos;
- tributacao informada ou policy capaz de calcular;
- politica de processamento.

### Redespacho

Acrescenta:

- tipo de servico redespacho ou redespacho intermediario;
- documento anterior;
- transportador anterior/contratante quando exigido;
- trecho executado;
- tomador coerente com o contrato.

Pendencia:

- confirmar no schema vigente todos os campos obrigatorios por redespacho antes
  de codificar validacoes finais.

### Complemento

Acrescenta:

- CT-e original referenciado;
- motivo/justificativa;
- valores complementares;
- regra para nao duplicar carga/documentos quando o leiaute nao exigir.

### Substituicao

Acrescenta:

- CT-e substituido;
- evento de prestacao em desacordo quando aplicavel;
- motivo fiscal;
- regra oficial de autorizacao.

### Globalizado

Acrescenta:

- indicador de globalizado;
- documentos/pedidos agrupados conforme regra;
- politica de consolidacao;
- criterios de rateio e rastreabilidade por documento.

Pendencia:

- pesquisar o recorte oficial vigente de globalizado antes da primeira
  implementacao real.

## Fluxo De Implementacao Do Modulo

### Etapa 1 - Recepcao

Commands:

- `ReceberRomaneioConsolidadoParaCTeCommand`

Responsabilidades:

- identificar origem, tipo e versao da mensagem;
- gerar correlation id;
- calcular hash;
- persistir entrada oficial;
- aplicar idempotencia;
- devolver protocolo de recebimento ou seguir para normalizacao.

Gerado pela Engine:

- command;
- receiver base;
- endpoint/rota;
- DI;
- repository para tabela de entrada;
- ponto `Custon`.

Miolo IA/dev:

- validacao minima do snapshot oficial;
- decisao de modo sincrono/assincrono quando for especifica.

### Etapa 2 - Normalizacao

Commands:

- `NormalizarEntradaCTeCommand`

Responsabilidades:

- converter snapshot oficial para `CTeSolicitacaoFiscal`;
- resolver dados por token/tenant;
- mapear participantes, documentos, carga, valores e classificacao;
- registrar inconsistencias de normalizacao.

Gerado pela Engine:

- command/receiver/pastas;
- contrato de saida;
- repository de status.

Miolo IA/dev:

- mapper de `RomaneioConsolidadoParaCTe` para entrada canonica;
- regras de compatibilidade com origem oficial;
- defaults seguros do tenant.

### Etapa 3 - Pre-Validacao

Commands:

- `ValidarSolicitacaoCTeCommand`

Responsabilidades:

- validar campos minimos;
- validar coerencia de participantes;
- validar municipio/UF;
- validar tipo de servico;
- validar documentos originarios;
- bloquear cenarios fora do recorte implementado.

Gerado pela Engine:

- borda do command/receiver;
- retorno padronizado.

Miolo IA/dev:

- policies fiscais;
- mensagens de erro uteis;
- regras por cenario.

### Etapa 4 - Composicao Fiscal

Commands:

- `PrepararDocumentoCTeCommand`

Responsabilidades:

- reservar numeracao;
- gerar chave;
- compor documento fiscal interno;
- calcular rateio;
- calcular ou validar tributacao;
- preparar tentativa de emissao.

Miolo IA/dev:

- numeracao/chave;
- rateio;
- tributacao;
- composicao por tipo de CT-e/servico/modal.

### Etapa 5 - Autorizacao

Commands:

- `AutorizarCTeCommand`

Responsabilidades:

- gerar XML oficial;
- assinar;
- validar XSD;
- resolver endpoint;
- enviar para SEFAZ;
- interpretar retorno;
- persistir protocolo/XML/retorno;
- publicar resultado interno.

Gerado pela Engine:

- command/receiver;
- persistencias basicas;
- endpoint administrativo quando exposto.

Miolo IA/dev:

- XML;
- assinatura;
- validacao XSD;
- cliente SEFAZ;
- parser e cStat.

## Entidades Minimas Para Suportar A Entrada

Entidades candidatas para a DSL inicial:

- `CTeEntradaOficial`
- `CTeRomaneioConsolidado`
- `CTeSolicitacaoFiscal`
- `CTeParticipanteSnapshot`
- `CTeDocumentoOriginario`
- `CTeTentativaEmissao`
- `CTeSaidaMDFe`

Nao precisamos criar todas no primeiro minuto. Mas a entrada canonica deve
apontar para esse desenho para evitar remendo depois.

## Pastas Sugeridas

```text
Yeshua.Fiscal.CTe.CQRS.Application.Command
  Commands
    Entrada
    Emissao
    Consulta
    Eventos
  Receivers
    Migration
    Custon
      Entrada
      Normalizacao
      Emissao

Yeshua.Fiscal.CTe.CQRS.Domain
  Entitys
  ValueObjects
    Entrada
    Classificacao
    Participantes
    Carga
    Documentos
    Valores
    Tributacao
    Modal
  Policies
    Classificacao
    Rateio
    Tributacao

Yeshua.Fiscal.CTe.CQRS.Infrastructure.Api
  Endpoints
    Official
      Romaneio
      Emissao
      Consulta

Yeshua.Fiscal.CTe.CQRS.Infrastructure.Shared
  Fiscal
    Sefaz
    Xml
    Assinatura
    Schemas
    Certificados
```

## Onde A DSL Entra

DSL deve declarar a casca:

- modulo Fiscal.CTe;
- entidades operacionais;
- commands/use cases;
- mensagens oficiais consumidas;
- mensagens oficiais publicadas;
- politica inicial de processamento;
- se a entrada oficial deve ser persistida;
- se ha worker/inbox;
- permissoes.

DSL nao deve declarar:

- XML inteiro;
- XSD inteiro;
- todos os cStat;
- regras fiscais linha por linha;
- contrato completo de fabricante quando for grande;
- algoritmo de rateio;
- assinatura digital;
- SOAP envelope especifico.

## Exemplo Conceitual De DSL

```csharp
AddModule("FCTE", "Fiscal CT-e");

AddEntity<CTeEntradaOficial>();
AddEntity<CTeRomaneioConsolidado>();
AddEntity<CTeSolicitacaoFiscal>();
AddEntity<CTeParticipanteSnapshot>();
AddEntity<CTeDocumentoOriginario>();
AddEntity<CTeTentativaEmissao>();
AddEntity<CTeSaidaMDFe>();

AddUsecaseGroup("FiscalCTe")
    .AddUseCaseSubGrup("Entrada")
    .AddCommand("ReceberRomaneioConsolidadoParaCTe", new ReceberRomaneioConsolidadoParaCTeInput(), new ReceberRomaneioConsolidadoParaCTeOutput())
    .ExecutionPolicy(ExecutionPolicy.AsyncCapable);

AddUsecaseGroup("FiscalCTe")
    .AddUseCaseSubGrup("IntegracaoMDFe")
    .AddCommand("PublicarCTeAutorizadoParaMDFe", new PublicarCTeAutorizadoParaMDFeInput(), new PublicarCTeAutorizadoParaMDFeOutput())
    .ExecutionPolicy(ExecutionPolicy.AsyncCapable);
```

Esse exemplo e direcao, nao contrato final.

## Regras Anti-Acoplamento

- Conector nao monta XML SEFAZ.
- Conector nao calcula imposto.
- Conector nao reserva numero fiscal.
- Conector nao decide sozinho certificado.
- Normalizador nao transmite para SEFAZ.
- Rateio nao conhece SOAP.
- Tributacao nao conhece WSDL.
- XML builder nao consulta APS.
- Cliente SEFAZ nao conhece pedido/carga/estoque.
- Documento fiscal nao guarda ponte obrigatoria para entidade viva de outro
  modulo.
- Payload bruto nao substitui a solicitacao canonica.

## Decisoes Para O Primeiro Recorte

Para iniciar pequeno:

- produto: CT-e carga modelo 57;
- versao: 4.00;
- emissao: normal;
- servico: normal;
- modal: rodoviario;
- ambiente inicial: homologacao;
- entrada inicial: `RomaneioConsolidadoParaCTe` por API oficial e/ou inbox;
- processamento: aceitar assincrono, mas permitir sincrono ate autorizacao para
  teste guiado;
- persistencia: guardar entrada oficial, solicitacao, tentativa, XML e retorno.

## Perguntas Para Integracao Com Modulos Anteriores

Quando formos ligar o modulo de execucao/montagem de carga ao CT-e, a pergunta
nao sera "como copiar um contrato externo?".

A pergunta sera:

- qual fato de negocio alimenta `CTeEntradaOficial`?
- qual token/contexto identifica tenant e cliente?
- quais campos do snapshot viram participantes?
- quais campos viram documentos originarios?
- quais campos viram carga?
- quais campos viram valores/rateio?
- como a execucao de carga decide tipo de CT-e e tipo de servico?
- quais campos sao defaults de configuracao e nao devem vir no snapshot?
- quais operacoes precisam ser sincronas de verdade?

## Pendencias

- Confirmar se a primeira entrada real sera API oficial, inbox, ou ambas.
- Definir o detalhe final entre persistir `CTeEntradaOficial` e tambem usar
  `yInbox` como fila operacional.
- Definir nomes finais dos commands antes de gerar codigo.
- Baixar ZIP de schemas vigente e fechar campos obrigatorios por cenario.
- Pesquisar regras especificas de redespacho, complemento, substituicao e
  globalizado antes de implementar validacao fiscal definitiva.
- Documentar adapters legados nos modulos anteriores de recepcao/carga quando
  esse assunto voltar.
