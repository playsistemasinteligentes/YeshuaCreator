# CT-e - Modularizacao E Desacoplamento

Pesquisa reorganizada em 2026-08-28.

Este documento reorganiza o modulo Fiscal.CTe a partir das funcoes oficiais do
CT-e e da estrategia Yeshua: motor gera bordas, IA/dev implementa miolos, e o
modulo fiscal precisa ser vendavel, publicavel e independente.

Documentos complementares:

- [CTE_DOSSIE_ASSUNTOS.md](CTE_DOSSIE_ASSUNTOS.md)
- [CTE_BACKLOG_IMPLEMENTACAO.md](CTE_BACKLOG_IMPLEMENTACAO.md)
- [CTE_INTERFACE_ENTRADA.md](CTE_INTERFACE_ENTRADA.md)
- [CTE_FLUXO_ENTRADA_SEFAZ_MDFE.md](CTE_FLUXO_ENTRADA_SEFAZ_MDFE.md)

## Tese Atual

O CT-e deve nascer como aplicativo fiscal independente:

- `Yeshua.Fiscal.CTe.CQRS.Domain`
- `Yeshua.Fiscal.CTe.CQRS.Application.Command`
- `Yeshua.Fiscal.CTe.CQRS.Application.RepositoryInterfaces`
- `Yeshua.Fiscal.CTe.CQRS.Infrastructure.Api`
- `Yeshua.Fiscal.CTe.CQRS.Infrastructure.RepositoryRead`
- `Yeshua.Fiscal.CTe.CQRS.Infrastructure.RepositoryWrite`
- `Yeshua.Fiscal.CTe.CQRS.Infrastructure.Shared`
- `Yeshua.Fiscal.CTe.CQRS.Infrastructure.Worker`
- `Yeshua.Fiscal.CTe.CQRS.Infrastructure.Front`, se houver UI propria.

`Yeshua.Fiscal` pode existir depois como pacote comercial, menu agregado ou
deploy coordenado, mas nao deve ser usado como desculpa para misturar CT-e,
MDF-e e NF-e no mesmo miolo tecnico.

## O Que A Pesquisa Oficial Mostrou

O CT-e 4.00 tem familias oficiais diferentes:

- CT-e de transporte de carga, modelo 57.
- CT-e OS, modelo 67.
- GTV-e, modelo 64.
- CT-e Simplificado.
- Consulta de situacao.
- Consulta de status do servico.
- Eventos.
- Distribuicao DF-e.
- DACTE e QR Code.
- Contingencia por EPEC, FS-DA e SVC.
- Alteracoes fiscais por notas tecnicas, incluindo RTC, pagamento vinculado,
  CNPJ alfanumerico, PAA e tabelas oficiais.

Conclusao de arquitetura:

- Servico SEFAZ nao deve virar modulo interno sozinho.
- Evento oficial nao deve virar `switch` gigante.
- Cada familia oficial deve ser mapeada para uma capacidade interna pequena.
- O primeiro produto nao precisa implementar todas as familias.

## Produtos Internos Do CT-e

O aplicativo Fiscal.CTe pode conter varios produtos internos. Eles compartilham
infra fiscal, mas devem manter fronteiras claras.

### CT-e Carga Modelo 57

Produto principal.

Primeira entrega:

- emissao normal;
- status do servico;
- consulta de situacao;
- cancelamento;
- carta de correcao;
- persistencia de XML/protocolo/retorno.

Nao deve depender de CT-e OS, GTV-e ou CT-e Simplificado.

### CT-e Simplificado

Produto relacionado ao CT-e modelo 57, mas com leiaute e regras proprias.

Deve ficar em namespace/pasta propria:

- `CteSimplificado`
- `EmissaoSimplificada`
- `XmlSimplificado`

Nao deve nascer como flag escondida em `EmitirCTe`.

### CT-e OS Modelo 67

Produto separado.

Pode reutilizar infraestrutura fiscal, certificado, endpoints, parser de
retorno e cliente SEFAZ, mas nao deve compartilhar composicao de documento com
CT-e carga.

### GTV-e Modelo 64

Produto separado.

Deve ser isolado ate existir caso real.

### Eventos CT-e

Familia propria.

O webservice oficial e unico, mas internamente cada evento relevante deve ter
command/receiver proprio:

- `CancelarCTe`
- `RegistrarCartaCorrecaoCTe`
- `RegistrarPrestacaoDesacordoCTe`
- `CancelarPrestacaoDesacordoCTe`
- `RegistrarComprovanteEntregaCTe`
- `CancelarComprovanteEntregaCTe`
- `RegistrarInsucessoEntregaCTe`
- `CancelarInsucessoEntregaCTe`
- `RegistrarEpecCTe`
- `RegistrarMultimodalCTe`
- `RegistrarVinculacaoPagamentoCTe`
- `CancelarVinculacaoPagamentoCTe`

Alguns eventos sao P1; outros ficam apenas mapeados ate haver demanda real.

### Consulta E Reconciliacao

Familia propria.

Responsavel por:

- status do servico;
- consulta de situacao por chave;
- reconciliar divergencia entre banco interno e SEFAZ;
- enriquecer diagnostico operacional.

Nao deve montar CT-e nem cancelar documento.

### Distribuicao DF-e

Familia propria.

Responsavel por buscar documentos do Ambiente Nacional para atores
interessados. Nao entra no primeiro recorte de emissao, mas deve ficar isolada
desde o desenho para nao contaminar emissao normal.

### DACTE E QR Code

Familia propria.

Responsavel por:

- gerar documento auxiliar;
- montar QR Code conforme ambiente/autorizador;
- expor PDF/HTML/arquivo;
- acompanhar variacoes por modal/produto.

Nao deve autorizar documento nem recalcular regra fiscal.

### Contingencia

Familia propria.

Responsavel por:

- EPEC;
- SVC-RS/SVC-SP;
- FS-DA;
- transmissao posterior;
- recuperacao de documentos emitidos em contingencia.

Nao entra no primeiro recorte, mas deve existir como fronteira conceitual para
emissao normal nao virar um emaranhado.

## Fronteiras Com Outros Modulos

O CT-e consome insumos. Ele nao domina os outros modulos.

### Planejamento De Transporte

Responsavel por pedidos, cargas, rotas, veiculos, motoristas, volumes e
previsao de entrega.

Pode gerar `CTeEmissionRequest`, mas nao chama SEFAZ.

### Pedidos

Responsavel pela demanda comercial e dados de entrega.

Fornece snapshot quando precisar alimentar transporte ou CT-e.

### Faturamento / NF-e

Responsavel por notas fiscais e cobranca comercial.

Fornece documentos originarios para CT-e, mas nao controla emissao de CT-e.

### MDF-e

Responsavel por manifestar viagem.

Consome CT-es autorizados por snapshot/evento entregue via outbox/inbox e
processado por Worker proprio, nao acessando tabela interna do CT-e nem
endpoint SOAP/REST interno como caminho normal.

### Adapters Externos Posteriores

Responsaveis por receber SOAP, REST, planilha, arquivo ou outros formatos de
terceiros.

Eles ficam antes dos modulos fiscais, em modulos de recepcao, carga ou
integracao. Esses adapters convertem payload externo para a mensagem oficial
Yeshua. Nao devem embarcar regra fiscal do CT-e nem conhecer XML SEFAZ.

Conectores externos nao sao barramento interno entre modulos Yeshua. Eles
servem principalmente para compatibilidade com legados, fabricantes e
contingencia, mas ficam fora do modulo Fiscal.CTe.

## Modelo De Entrada

Entrada deve ser pensada em dois niveis. O contrato consolidado esta em
[CTE_INTERFACE_ENTRADA.md](CTE_INTERFACE_ENTRADA.md); esta secao mantem apenas
o resumo arquitetural.

### Mensagem Oficial Recebida

O dado que chega ao Fiscal.CTe deve vir como mensagem oficial:

- romaneio consolidado;
- solicitacao fiscal normalizada;
- snapshots de documentos originarios;
- snapshots de participantes, rota, carga e preferencias fiscais.

Quando a origem for SOAP, REST de compatibilidade, planilha ou arquivo, a
traducao acontece antes, no modulo adapter. O Fiscal.CTe recebe o contrato
oficial ja normalizado, podendo preservar hash/storage para replay quando isso
for necessario.

### Pedido Interno De Emissao

Contrato estavel do modulo CT-e:

- `CTeEmissionRequest`
- `CTeParticipanteSnapshot`
- `CTeCargaSnapshot`
- `CTeDocumentoOriginarioSnapshot`
- `CTeFreteRequest`
- `CTeConfiguracaoFiscalRequest`

Esse contrato deve ser independente do fornecedor legado.

## Pipeline Interno De Emissao

O fluxo de emissao normal deve ser uma sequencia pequena e observavel:

1. Receber solicitacao.
2. Normalizar dados.
3. Validar pre-condicoes operacionais.
4. Reservar numeracao.
5. Compor documento fiscal interno.
6. Calcular valores/rateio, quando aplicavel.
7. Calcular tributacao.
8. Gerar XML oficial.
9. Assinar XML.
10. Validar XSD.
11. Transmitir para SEFAZ.
12. Interpretar retorno.
13. Persistir resultado fiscal.
14. Publicar evento interno de autorizado, rejeitado ou falha tecnica.
15. Liberar DACTE/QR Code quando autorizado.

Cada etapa deve poder ser diagnosticada separadamente.

## Componentes Internos

### Entrada Fiscal

Recebe requests por API nativa, conector, arquivo ou worker.

Nao monta XML.

### Normalizacao

Converte payload externo para contrato interno estavel.

Nao chama SEFAZ.

### Validacao Operacional

Valida se a solicitacao tem o minimo para seguir.

Exemplos:

- emitente configurado;
- certificado disponivel;
- UF/municipio conhecidos;
- tomador/remetente/destinatario presentes quando exigidos;
- documento originario informado quando o tipo de servico exigir.

Nao substitui validacao XSD nem regra SEFAZ.

### Numeracao E Chave

Controla serie, numero, codigo numerico, chave e digito verificador.

Deve ser concorrente e transacional.

### Composicao Fiscal

Monta o documento fiscal interno completo, sem XML.

Responsavel por:

- tipo de CT-e;
- CFOP/natureza quando ja definidos;
- participantes;
- carga;
- documentos;
- modal;
- valores;
- impostos;
- informacoes suplementares.

### Rateio De Frete

Distribui valores de frete por NF, pedido, peso, volume, valor de mercadoria,
rota ou regra comercial.

Nao conhece SOAP, certificado ou cStat.

### Tributacao

Calcula ICMS e campos fiscais aplicaveis, incluindo impacto de NTs vigentes
quando o recorte exigir.

Nao monta DACTE nem transmite documento.

### XML Oficial

Converte o documento fiscal interno para XML oficial.

Responsavel por:

- `CTe`;
- `consSitCTe`;
- `consStatServCTe`;
- `eventoCTe`;
- `procCTe`;
- XMLs especificos de CT-e Simplificado, CT-e OS e GTV-e quando existirem.

### Assinatura Digital

Assina os grupos exigidos pelo schema oficial.

Nao carrega regra de transporte.

### Validacao XSD

Valida XML contra pacote de schemas versionado.

Erro de XSD deve ser salvo como falha tecnica/pre-SEFAZ, nao como rejeicao
autorizadora.

### Cliente SEFAZ

Executa transporte HTTP/SOAP, certificado de cliente, timeout e retorno bruto.

Nao conhece pedido, carga, estoque, imposto ou rateio.

### Interpretacao De Retorno

Transforma retorno oficial em estado fiscal interno.

Deve separar:

- autorizado;
- rejeitado;
- cancelado;
- evento homologado;
- consumo indevido;
- servico paralisado;
- falha tecnica local;
- falha de comunicacao;
- erro de certificado;
- erro de schema.

### Eventos

Cada evento oficial relevante possui fluxo proprio.

Eventos nao devem ser implementados como extensao lateral de emissao normal.

### DACTE

Gera e disponibiliza documento auxiliar.

DACTE depende do CT-e autorizado ou de regra oficial de contingencia, mas nao
autoriza nada.

### Observabilidade Fiscal

Registra a tentativa fiscal de ponta a ponta.

Minimo por tentativa:

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
- versao de leiaute;
- versao de schema;
- hash do XML;
- duracao por etapa;
- cStat;
- xMotivo;
- protocolo;
- erro tecnico separado de rejeicao fiscal.

## Commands Candidatos

### P0

- `ReceberSolicitacaoEmissaoCTe`
- `EmitirCTe`
- `ConsultarStatusServicoCTe`
- `ConsultarSituacaoCTe`

### P1

- `CancelarCTe`
- `RegistrarCartaCorrecaoCTe`
- `GerarDacteCTe`
- `ReprocessarTentativaCTe`

### P2

- `RegistrarComprovanteEntregaCTe`
- `CancelarComprovanteEntregaCTe`
- `RegistrarInsucessoEntregaCTe`
- `CancelarInsucessoEntregaCTe`
- `RegistrarPrestacaoDesacordoCTe`
- `CancelarPrestacaoDesacordoCTe`
- `DistribuirDFeCTe`
- `RegistrarEpecCTe`
- `TransmitirCTeEmContingencia`

### P3

- `EmitirCTeSimplificado`
- `EmitirCTeOS`
- `EmitirGTVe`
- `RegistrarMultimodalCTe`
- `RegistrarVinculacaoPagamentoCTe`
- `CancelarVinculacaoPagamentoCTe`

## Entidades Operacionais Candidatas

O banco do modulo deve guardar a verdade fiscal e operacional do CT-e, nao uma
copia cega de todas as tags.

Entidades iniciais:

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

Entidades futuras:

- `CTeDacte`
- `CTeDistribuicaoDFe`
- `CTeContingencia`
- `CTeComprovanteEntrega`
- `CTeInsucessoEntrega`
- `CTePagamentoVinculado`

## Estrutura De Pastas Candidata

```text
Fiscal.CTe
  Domain
    Entitys
      Migration
      Custon
    Behaviors
    ValueObjects
      Emissao
      Eventos
      Snapshots
      Tributacao
      Sefaz

  Application.Command
    Commands
      Emissao
      Consulta
      Eventos
      Dacte
      Contingencia
      Distribuicao
    Receivers
      Migration
      Custon
        Emissao
        Consulta
        Eventos
        Dacte
        Contingencia

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
      Dacte
      Certificados
      Observabilidade

  Infrastructure.Api
    Endpoints
      Official
        Entrada
        Emissao
        Consulta
    Migration

  Infrastructure.Worker
    Emissao
    Eventos
    Inbox
    Reprocessamento
```

## O Que Vai Para A DSL

A DSL deve declarar o desenho operacional, nao o mundo fiscal inteiro.

Vai para DSL:

- aplicativo Fiscal.CTe;
- modulos internos;
- entidades operacionais;
- commands/use cases;
- mensagens oficiais consumidas;
- mensagens oficiais publicadas;
- policy sincronas/assincronas;
- inbox/outbox quando necessario;
- permissoes;
- telas administrativas basicas;
- marcadores de codigo gerado/custom.

Exemplo conceitual:

```csharp
AddModule("FCTE", "Fiscal CT-e");

AddUsecaseGroup("FiscalCTe")
    .AddUseCaseSubGrup("Entrada")
    .AddCommand("ReceberRomaneioConsolidadoParaCTe", new ReceberRomaneioConsolidadoParaCTeInput(), new ReceberRomaneioConsolidadoParaCTeOutput())
    .Authorization(Authorization.User)
    .AddScope("cte.romaneio.receber");

AddUsecaseGroup("FiscalCTe")
    .AddUseCaseSubGrup("IntegracaoMDFe")
    .AddCommand("PublicarCTeAutorizadoParaMDFe", new PublicarCTeAutorizadoParaMDFeInput(), new PublicarCTeAutorizadoParaMDFeOutput())
    .Authorization(Authorization.User)
    .AddScope("cte.mdfe.publicar");
```

## O Que Nao Vai Para A DSL

Nao vai para DSL:

- todas as tags do XML;
- todos os codigos de rejeicao;
- SOAP envelope detalhado;
- XSD completo;
- pixel de DACTE;
- regra tributaria inteira;
- implementacao de biblioteca fiscal;
- endpoint fixo de producao dentro de regra de negocio;
- regra especifica de fabricante legado.

Regras fiscais e integracoes SEFAZ pertencem ao aplicativo Fiscal.CTe,
preferencialmente em `Custon` ou em infraestrutura especifica fiscal. Regras
de fabricante legado pertencem aos adapters anteriores.

## Responsabilidade Da Engine

A Engine deve gerar:

- projetos do aplicativo;
- commands e receivers;
- endpoints REST;
- contratos de entrada/saida quando fizer sentido;
- repositories;
- migrations;
- workers quando houver fila/inbox/outbox/polling;
- arquivos `Migration`;
- partials e pontos `Custon` protegidos.

A Engine nao deve conhecer:

- regras fiscais especificas do CT-e;
- cStat detalhado;
- schemas oficiais por dentro;
- XML tag por tag;
- bibliotecas fiscais concretas;
- certificado de cliente;
- endpoint de UF fixado no template.

## Responsabilidade Do Aplicativo Fiscal.CTe

O aplicativo deve implementar:

- composicao fiscal;
- calculo/rateio;
- tributacao;
- builder XML;
- assinatura;
- validacao XSD;
- cliente SEFAZ;
- interpretacao de retorno;
- DACTE;
- regras de eventos;
- configuracao por UF/ambiente;
- integracoes fiscais especificas com SEFAZ.

## Regras De Desacoplamento

- CT-e recebe snapshots, nao entidades vivas de outros modulos.
- Pedido, carga, estoque e faturamento nao chamam SEFAZ.
- Rateio nao chama SEFAZ.
- Tributacao nao monta SOAP.
- XML builder nao calcula frete.
- Cliente SEFAZ nao conhece pedido, carga ou estoque.
- DACTE nao autoriza documento.
- Evento nao deve ficar dentro de emissao normal.
- Contingencia nao deve poluir o caminho feliz.
- Retorno SEFAZ sempre vira resultado fiscal persistido antes de disparar novo
  fluxo.
- Adapter externo so traduz contrato e chama command/receiver oficial, fora do
  Fiscal.CTe.

## Ordem De Implementacao Recomendada

### Etapa 1 - Base Oficial E Playground

- Baixar schemas vigentes.
- Validar status do servico em homologacao.
- Validar consulta de situacao em homologacao.
- Validar assinatura e XSD isoladamente.

### Etapa 2 - Aplicativo Fiscal.CTe

- Criar Studio Fiscal.CTe ou recorte equivalente.
- Declarar entidades operacionais minimas.
- Declarar commands P0.
- Gerar projetos e bordas.

### Etapa 3 - Emissao Normal Modelo 57

- Implementar `CTeEmissionRequest`.
- Implementar numeracao/chave.
- Implementar XML/assinatura/XSD.
- Transmitir para `CTeRecepcaoSincV4`.
- Persistir protocolo e retorno.

### Etapa 4 - Operacao Basica

- Cancelamento.
- Carta de correcao.
- DACTE/QR Code basico.
- Reprocessamento controlado.

### Etapa 5 - Integracao Oficial CT-e -> MDF-e

- Publicar snapshot de CT-e autorizado em `yOutbox`.
- Consumir no Fiscal.MDFe por `yInbox`/Worker.
- Persistir `CTeSaidaMDFe` com correlation id, chave e protocolo.
- Evitar acesso direto entre bancos ou tabelas internas dos modulos.

### Etapa 6 - Adapter Externo Posterior

- Criar conector fora do Fiscal.CTe quando houver necessidade comercial.
- Copiar contrato SOAP/REST/arquivo necessario.
- Receber payload bruto no modulo de recepcao/carga/integracao.
- Converter para mensagem oficial Yeshua.
- Entregar ao Fiscal.CTe por API oficial ou inbox.

### Etapa 7 - Robustez

- Distribuicao DF-e.
- Contingencia.
- Comprovante/insucesso de entrega.
- RTC/pagamento vinculado conforme prioridade real.

## Pendencias

- Baixar o ZIP de schemas vigente e confirmar nomes/codigos por XSD.
- Escolher biblioteca C# de apoio para XML, assinatura, SOAP e DACTE.
- Criar playground de `CTeStatusServicoV4`.
- Desenhar `CTeEmissionRequest` minimo.
- Definir storage fisico de XMLs fiscais.
- Definir politica inicial de certificado por ambiente.
