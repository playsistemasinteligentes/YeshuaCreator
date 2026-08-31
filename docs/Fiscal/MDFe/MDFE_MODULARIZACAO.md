# MDF-e - Modularizacao E Desacoplamento

Pesquisa reorganizada em 2026-08-28.

Este documento organiza o modulo Fiscal.MDFe a partir das funcoes oficiais do
MDF-e, do teste real ja feito no playground e da estrategia Yeshua: a Engine
gera bordas, o aplicativo fiscal implementa os miolos, e cada produto fiscal
precisa continuar vendavel e implantavel de forma isolada.

Documentos complementares:

- [MDFE_DOSSIE_ASSUNTOS.md](MDFE_DOSSIE_ASSUNTOS.md)
- [MDFE_BACKLOG_IMPLEMENTACAO.md](MDFE_BACKLOG_IMPLEMENTACAO.md)

## Tese Atual

O MDF-e deve continuar como aplicativo fiscal independente:

- `Yeshua.Fiscal.MDFe.CQRS.Domain`
- `Yeshua.Fiscal.MDFe.CQRS.Application.Command`
- `Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces`
- `Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api`
- `Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead`
- `Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite`
- `Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared`
- `Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Worker`
- `Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front`, se houver UI propria.

`Yeshua.Fiscal` pode existir como pacote comercial, menu agregado, deploy
coordenado ou composicao de modulos fiscais. Ele nao deve virar justificativa
para acoplar CT-e, MDF-e e NF-e no mesmo miolo tecnico.

## O Que A Pesquisa Oficial Mostrou

O MDF-e possui familias oficiais diferentes:

- emissao e autorizacao do manifesto;
- encerramento;
- cancelamento;
- inclusao de condutor;
- consulta de situacao;
- consulta de status do servico;
- consulta de MDF-e nao encerrados;
- distribuicao DF-e aos atores interessados;
- DAMDFE e QR Code;
- documentos originarios, municipios e percurso;
- CIOT, contrato, vale pedagio e pagamento;
- MDF-e Integrado;
- CT-e Simplificado referenciado no MDF-e;
- InfraSA/DTe;
- PAA, NFF e CNPJ Alfa;
- modais rodoviario, ferroviario, aquaviario e aereo.

Conclusao de arquitetura:

- Webservice oficial nao deve virar modulo interno sozinho.
- Evento oficial nao deve virar `switch` gigante.
- Cada familia oficial deve ser mapeada para uma capacidade interna pequena.
- O primeiro produto nao precisa implementar todo o universo MDF-e.
- Encerramento e consulta sao o menor recorte util para operacao real.

## Produtos Internos Do MDF-e

O aplicativo Fiscal.MDFe pode conter varios produtos internos. Eles compartilham
infraestrutura fiscal, mas precisam manter fronteiras claras.

### Encerramento MDF-e

Produto P0 atual.

Objetivo:

- encerrar MDF-e autorizado;
- consultar situacao;
- consultar documentos nao encerrados;
- salvar tentativa, XML, retorno bruto, protocolo e diagnostico.

Nao deve depender de emissao completa, DAMDFE, CIOT completo, pagamento ou
modais especiais.

### Emissao MDF-e Rodoviario

Produto P1/P2.

Objetivo:

- receber documentos originarios;
- compor manifesto;
- controlar municipios, percurso, veiculo, condutor, CIOT, vale pedagio,
  seguro, contratante e pagamento quando aplicavel;
- transmitir por `MDFeRecepcaoSinc`;
- persistir XML/protocolo/retorno.

Nao deve nascer como extensao lateral do encerramento.

### Eventos MDF-e

Familia propria.

O webservice oficial de evento e comum, mas internamente cada evento relevante
deve ter command/receiver proprio:

- `EncerrarMDFe`
- `CancelarMDFe`
- `IncluirCondutorMDFe`
- `IncluirDocumentoFiscalMDFe`
- `RegistrarPagamentoMDFe`
- `ConfirmarServicoTransporteMDFe`
- `AlterarPagamentoServicoMDFe`
- `EncerrarMDFePeloTransportador`

Eventos sem codigo confirmado no schema vigente permanecem como pendencia.

### Consulta E Reconciliacao

Familia propria.

Responsavel por:

- status do servico;
- consulta de situacao por chave;
- consulta de nao encerrados;
- reconciliar divergencia entre banco interno e SEFAZ;
- enriquecer diagnostico operacional.

Nao deve montar XML de emissao nem executar cancelamento.

### DAMDFE E QR Code

Familia propria.

Responsavel por:

- gerar documento auxiliar;
- montar QR Code conforme ambiente;
- disponibilizar PDF/HTML/arquivo;
- acompanhar variacoes de layout por modal e nota tecnica.

Nao deve autorizar, cancelar ou encerrar documento.

### Distribuicao DF-e

Familia propria.

Responsavel por buscar documentos de interesse para atores envolvidos. Nao deve
poluir emissao, encerramento ou conector legado.

### MDF-e Integrado, Contrato E Pagamento

Familia propria.

Responsavel por contrato, adiantamento, alteracao de pagamento, confirmacao de
servico e integracoes com participantes externos. Deve ficar isolada ate haver
demanda real.

### InfraSA/DTe

Familia propria.

Responsavel por persistir e expor dados retornados na consulta de situacao para
geracao de DTe/InfraSA quando o recorte exigir.

### Modais

Cada modal deve ficar separado:

- `Rodoviario`
- `Ferroviario`
- `Aquaviario`
- `Aereo`

O rodoviario deve ser o primeiro recorte. Os demais nao devem aparecer como
flags soltas em uma classe central.

## Fronteiras Com Outros Modulos

O MDF-e consome insumos. Ele nao deve dominar outros modulos.

### CT-e

Fornece documento originario autorizado por snapshot/evento. MDF-e nao deve
acessar tabela interna do CT-e como caminho normal.

### NF-e

Fornece nota fiscal autorizada ou snapshot do documento originario. MDF-e nao
deve virar emissor de NF-e.

### Planejamento De Transporte

Fornece carga, rota, veiculo, condutor e planejamento operacional. Nao chama
SEFAZ.

### Pedido

Fornece dados comerciais/logisticos quando necessario. Nao conhece XML MDF-e.

### Faturamento E Financeiro

Fornecem valores, contrato, pagamento e cobranca. Nao devem montar evento fiscal
MDF-e diretamente.

### Conectores Legados

Recebem SOAP, REST, planilha, TXT ou outro formato externo.

Eles devem:

- guardar payload bruto quando necessario;
- normalizar para comandos/snapshots internos;
- resolver token, tenant, cliente e permissao;
- chamar use cases internos.

Eles nao devem:

- implementar XML SEFAZ;
- acessar direto banco de CT-e/NF-e como contrato estavel;
- decidir regra fiscal profunda do MDF-e.

## Modelo De Entrada

Entrada deve existir em dois niveis.

### Payload Bruto

O dado original que chegou:

- SOAP legado;
- REST nativo;
- planilha;
- arquivo TXT;
- mensageria;
- importacao manual;
- integracao entre modulos internos.

Pode ser persistido em `yInbox` ou tabela especifica de integracao quando
precisarmos replay/auditoria.

### Pedido Interno MDF-e

Contratos internos estaveis do modulo:

- `MDFeEncerramentoRequest`
- `MDFeConsultaRequest`
- `MDFeNaoEncerradosRequest`
- `MDFeEmissionRequest`
- `MDFeDocumentoOriginarioSnapshot`
- `MDFeMunicipioSnapshot`
- `MDFeVeiculoSnapshot`
- `MDFeCondutorSnapshot`
- `MDFeContratoPagamentoSnapshot`
- `MDFeConfiguracaoSefazRequest`

Esses contratos devem ser independentes de fornecedor, legado ou tela.

## Pipeline Interno De Encerramento

O encerramento deve ser uma sequencia pequena e observavel:

1. Receber solicitacao.
2. Resolver token/tenant/emitente quando vier de conector.
3. Validar chave, protocolo e certificado disponivel.
4. Resolver UF, municipio, ambiente e endpoint.
5. Criar tentativa fiscal.
6. Gerar XML `eventoMDFe`.
7. Assinar XML.
8. Validar XSD.
9. Transmitir para `MDFeRecepcaoEvento`.
10. Interpretar retorno.
11. Persistir retorno bruto e retorno interpretado.
12. Atualizar estado interno quando o evento for homologado.
13. Publicar evento interno de encerrado, rejeitado ou falha tecnica.

Cada etapa deve poder ser diagnosticada separadamente.

## Pipeline Interno De Emissao

O fluxo de emissao rodoviaria deve ficar separado do encerramento:

1. Receber solicitacao ou snapshot operacional.
2. Normalizar origem.
3. Validar pre-condicoes.
4. Reservar serie, numero, codigo numerico e chave.
5. Compor manifesto interno.
6. Validar documentos originarios.
7. Validar municipios, percurso, veiculo e condutor.
8. Validar CIOT, vale pedagio, seguro, contrato e pagamento quando aplicavel.
9. Gerar XML oficial.
10. Assinar XML.
11. Validar XSD.
12. Transmitir por `MDFeRecepcaoSinc`.
13. Interpretar retorno.
14. Persistir XML, protocolo e status.
15. Liberar DAMDFE/QR Code quando autorizado.
16. Publicar evento interno.
17. Agendar reconciliacao quando necessario.

## Componentes Internos

### Entrada Fiscal

Recebe requests por API nativa, conector, arquivo ou worker.

Nao monta XML.

### Normalizacao

Converte payload externo para contrato interno estavel.

Nao chama SEFAZ.

### Validacao Operacional

Valida se a solicitacao tem o minimo para seguir:

- emitente configurado;
- certificado disponivel;
- ambiente definido;
- chave/protocolo presentes quando o evento exigir;
- UF e municipio existentes;
- veiculo, condutor e documentos presentes quando a emissao exigir.

Nao substitui validacao XSD nem regra SEFAZ.

### Numeracao E Chave

Controla serie, numero, codigo numerico, chave e digito verificador.

Deve ser concorrente e transacional.

### Documentos Originarios

Guarda snapshots de CT-e, NF-e ou outros documentos aceitos no recorte.

Nao acessa miolo de outro modulo no caminho quente.

### Modal Rodoviario

Concentra veiculo, condutor, percurso, carga, RNTRC, CIOT, vale pedagio,
seguro, contratante e pagamento rodoviario.

Nao deve conter regras de SOAP ou XML generico.

### XML Oficial

Converte contrato/documento interno para XML MDF-e ou XML de evento.

Responsavel por:

- `MDFe`;
- `eventoMDFe`;
- `consSitMDFe`;
- `consStatServMDFe`;
- `consMDFeNaoEnc`;
- XMLs de distribuicao quando o recorte chegar.

### Assinatura Digital

Assina os grupos exigidos pelo schema oficial.

Nao conhece pedido, carga ou financeiro.

### Validacao XSD

Valida XML contra pacote de schemas versionado.

Erro de XSD e falha tecnica local/pre-SEFAZ, nao rejeicao fiscal.

### Cliente SEFAZ

Executa transporte HTTP/SOAP, certificado de cliente, timeout e retorno bruto.

Nao conhece regra de negocio.

### Interpretacao De Retorno

Transforma resposta oficial em estado fiscal interno.

Deve separar:

- autorizado;
- encerrado;
- cancelado;
- evento homologado;
- rejeicao fiscal;
- consumo indevido;
- servico paralisado;
- falha tecnica local;
- falha de comunicacao;
- erro de certificado;
- erro de schema.

### DAMDFE

Gera documento auxiliar e QR Code.

Nao autoriza nem encerra documento.

### Observabilidade Fiscal

Registra tentativa fiscal de ponta a ponta.

Minimo:

- aplicacao;
- ambiente;
- UF;
- autorizador;
- servico;
- endpoint;
- chave;
- serie;
- numero;
- emitente;
- tipo de evento;
- sequencia;
- protocolo original;
- protocolo de evento;
- versao de leiaute;
- versao de schema;
- hash do XML;
- duracao por etapa;
- `cStat`;
- `xMotivo`;
- XML enviado;
- retorno bruto;
- erro tecnico separado de rejeicao fiscal.

## Commands Candidatos

### P0

- `EncerrarMDFe`
- `ConsultarSituacaoMDFe`
- `ConsultarStatusServicoMDFe`
- `ConsultarMDFeNaoEncerrados`
- `ReprocessarTentativaMDFe`

### P1

- `CancelarMDFe`
- `IncluirCondutorMDFe`
- `GerarDAMDFE`
- `ReceberSolicitacaoEmissaoMDFe`
- `EmitirMDFeRodoviario`

### P2

- `IncluirDocumentoFiscalMDFe`
- `DistribuirDFeMDFe`
- `RegistrarPagamentoMDFe`
- `ConfirmarServicoTransporteMDFe`
- `AlterarPagamentoServicoMDFe`
- `ReconciliarMDFe`

### P3

- `EmitirMDFeFerroviario`
- `EmitirMDFeAquaviario`
- `EmitirMDFeAereo`
- `RegistrarEventoSVBAMDFe`
- `ProcessarPaaMDFe`
- `ProcessarNffMDFe`

## Entidades Operacionais Candidatas

Entidades iniciais:

- `MDFe`
- `MDFeEncerramento`
- `MDFeTentativaEvento`
- `MDFeEvento`
- `MDFeEventoXml`
- `MDFeRetornoSefaz`
- `MDFeConfiguracaoSefaz`
- `MDFeCertificadoReferencia`

Entidades para emissao:

- `MDFeDocumentoOriginario`
- `MDFeMunicipioCarregamento`
- `MDFeMunicipioDescarregamento`
- `MDFePercurso`
- `MDFeVeiculo`
- `MDFeCondutor`
- `MDFeContratante`
- `MDFeSeguro`
- `MDFeValePedagio`
- `MDFeCIOT`
- `MDFePagamento`
- `MDFeNumeracao`
- `MDFeXml`
- `MDFeProtocolo`
- `MDFeDAMDFE`

Entidades futuras:

- `MDFeDistribuicaoDFe`
- `MDFeNaoEncerradoConsulta`
- `MDFeInfraSA`
- `MDFeDTe`
- `MDFePAA`
- `MDFeNFF`
- `MDFeCNPJAlfaCompatibilidade`

## Estrutura De Pastas Candidata

```text
Fiscal.MDFe
  Domain
    Entitys
      Migration
      Custon
    Behaviors
    ValueObjects
      Encerramento
      Emissao
      Eventos
      Consulta
      Snapshots
      Rodoviario
      Sefaz

  Application.Command
    Commands
      Encerramento
      Consulta
      Emissao
      Eventos
      Damdfe
      Distribuicao
    Receivers
      Migration
      Custon
        Encerramento
        Consulta
        Emissao
        Eventos
        Damdfe

  Application.RepositoryInterfaces
    Read
    Write
    Fiscal

  Infrastructure.Shared
    Fiscal
      Sefaz
        Endpoints
        Soap
        Retornos
      Xml
        Builders
        Schemas
        Assinatura
      Damdfe
      Certificados
      Observabilidade

  Infrastructure.Api
    Connectors
      Native
      FabricaSoftware01
        Soap
        Rest
        Arquivo
    Migration

  Infrastructure.Worker
    Encerramento
    Emissao
    Eventos
    Inbox
    Reprocessamento
```

## O Que Vai Para A DSL

Vai para DSL:

- aplicativo Fiscal.MDFe;
- modulos internos;
- entidades operacionais;
- commands/use cases;
- conectores e aliases de rota;
- policies sincronas/assincronas;
- inbox/outbox quando necessario;
- workers de reprocessamento quando houver fila/polling;
- permissoes;
- telas administrativas basicas;
- marcadores de codigo gerado/custom.

Exemplo conceitual:

```csharp
AddModule("FMDFE", "Fiscal MDF-e");

AddUsecaseGroup("FiscalMDFe")
    .AddUseCaseSubGrup("Encerramento")
    .AddCommand(
        "EncerrarMDFe",
        new EncerrarMDFeInput(),
        new EncerrarMDFeOutput())
    .Authorization(Authorization.User)
    .AddScope("mdfe.encerrar")
    .AddEntity("MDFe");

AddUsecaseGroup("FiscalMDFe")
    .AddUseCaseSubGrup("Consulta")
    .AddCommand(
        "ConsultarSituacaoMDFe",
        new ConsultarSituacaoMDFeInput(),
        new ConsultarSituacaoMDFeOutput())
    .Authorization(Authorization.User)
    .AddScope("mdfe.consultar")
    .AddEntity("MDFe");
```

## O Que Nao Vai Para A DSL

Nao vai para DSL:

- todas as tags do XML;
- SOAP envelope detalhado;
- XSD completo;
- todos os codigos de rejeicao;
- regra ANTT completa;
- regra de pagamento inteira;
- DAMDFE pixel a pixel;
- implementacao de biblioteca fiscal;
- endpoint fixo de producao dentro de regra de negocio;
- detalhe de certificado real;
- regra especifica de fornecedor legado.

Esses pontos pertencem ao aplicativo Fiscal.MDFe, preferencialmente em `Custon`
ou em infraestrutura fiscal especifica do proprio aplicativo.

## Responsabilidade Da Engine

A Engine deve gerar:

- projetos do aplicativo;
- commands e receivers;
- endpoints REST;
- casca tecnica de conectores;
- repositories;
- migrations;
- workers quando houver fila/inbox/outbox/polling;
- arquivos `Migration`;
- partials e pontos `Custon` protegidos;
- trilha padrao de tentativa se a DSL declarar entidades/commands.

A Engine nao deve conhecer:

- regras fiscais especificas do MDF-e;
- cStat detalhado;
- schemas oficiais por dentro;
- XML tag por tag;
- bibliotecas fiscais concretas;
- certificado de cliente;
- endpoint de producao fixado no template.

## Responsabilidade Do Aplicativo Fiscal.MDFe

O aplicativo deve implementar:

- composicao fiscal;
- documentos originarios;
- regras do modal;
- builder XML;
- assinatura;
- validacao XSD;
- cliente SEFAZ;
- interpretacao de retorno;
- DAMDFE;
- QR Code;
- regras de eventos;
- configuracao por UF/ambiente;
- conectores especificos.

## Regras De Desacoplamento

- MDF-e recebe snapshots, nao entidades vivas de outros modulos.
- CT-e/NF-e nao sao dependencias de runtime obrigatorias do MDF-e.
- Planejamento de transporte nao chama SEFAZ.
- XML builder nao decide rota comercial.
- Cliente SEFAZ nao conhece pedido, carga, estoque ou financeiro.
- DAMDFE nao autoriza documento.
- Evento nao deve ficar dentro de emissao normal.
- Encerramento nao deve depender de emissao completa.
- Retorno SEFAZ sempre vira resultado fiscal persistido antes de disparar novo
  fluxo.
- Conector externo so traduz contrato e chama command/receiver.

## Ordem De Implementacao Recomendada

### Etapa 1 - Base Oficial E Playground

- Baixar schemas vigentes.
- Validar status do servico.
- Validar consulta por chave.
- Validar consulta de nao encerrados.
- Revalidar encerramento em ambiente controlado.

### Etapa 2 - Aplicativo Fiscal.MDFe

- Evoluir `Yeshua.Studio.Fiscal.MDFe`.
- Declarar entidades operacionais minimas.
- Declarar commands P0.
- Gerar projetos e bordas.

### Etapa 3 - Encerramento P0

- Migrar conhecimento do playground para miolo customizado.
- Persistir tentativa, XML, retorno e protocolo.
- Consultar situacao antes/depois quando necessario.
- Reprocessar rejeicoes/falhas tecnicas com seguranca.

### Etapa 4 - Operacao Basica P1

- Cancelamento.
- Inclusao de condutor.
- DAMDFE/QR Code basico.
- Status/consulta/nao encerrados como ferramentas de suporte.

### Etapa 5 - Emissao Rodoviaria P1/P2

- Criar `MDFeEmissionRequest`.
- Modelar documentos originarios, municipios, veiculo e condutor.
- Implementar numeracao/chave.
- Implementar XML/assinatura/XSD.
- Transmitir por `MDFeRecepcaoSinc`.

### Etapa 6 - Integracao APS/Legado

- Receber carga/pedido/documentos por conector.
- Guardar payload bruto quando necessario.
- Normalizar para snapshots internos.
- Alimentar CT-e/MDF-e por comandos independentes.

### Etapa 7 - Robustez

- Distribuicao DF-e.
- MDF-e Integrado.
- CIOT/contrato/pagamento.
- InfraSA/DTe.
- PAA/NFF/CNPJ Alfa.
- Modais especiais por demanda real.

## Pendencias

- pendencia: baixar o ZIP de schemas MDF-e vigente e confirmar codigos por XSD.
- pendencia: confirmar todos os nomes de metodo no WSDL vigente.
- pendencia: decidir biblioteca C# fiscal ou implementacao propria para o
  miolo definitivo.
- pendencia: desenhar `MDFeEncerramentoRequest` definitivo.
- pendencia: desenhar `MDFeEmissionRequest` minimo.
- pendencia: definir storage fisico dos XMLs fiscais.
- pendencia: definir politica inicial de certificado por ambiente.
- pendencia: decidir se `Yeshua.Fiscal` sera apenas agregador comercial ou
  tambem projeto tecnico em algum ponto futuro.
