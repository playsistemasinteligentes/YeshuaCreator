# CT-e - Dossie De Assuntos

Consolidado em 2026-08-28.

Este arquivo e o dossie de trabalho para o modulo Fiscal.CTe. Ele nao substitui
MOC, Anexo I, Anexo II, notas tecnicas ou schemas XML oficiais. A funcao dele e
separar os assuntos, evitar mistura de responsabilidades e orientar a criacao
do modulo de CT-e dentro do conceito Yeshua.

Regra central:

- Fonte oficial define regra fiscal, leiaute, evento, endpoint e validacao.
- Engine gera bordas previsiveis.
- Aplicativo Fiscal.CTe implementa miolos fiscais e integracoes SEFAZ.
- Adapters externos ficam em modulos anteriores de recepcao/carga/integracao e
  normalizam para contratos internos.
- Outros modulos fornecem snapshots; CT-e nao invade o dominio deles.

## Mapa Geral

| Familia | Assunto | Prioridade | Produto interno |
| --- | --- | --- | --- |
| CT-P00 | Inventario oficial | P0 | Conhecimento fiscal |
| CT-P01 | Webservices 4.00 | P0 | Infra fiscal SEFAZ |
| CT-P02 | Certificado e assinatura | P0 | Infra fiscal SEFAZ |
| CT-P03 | Status e consulta | P0 | Consulta e reconciliacao |
| CT-P04 | Emissao modelo 57 | P0 | CT-e carga |
| CT-P05 | Participantes e documentos | P0 | CT-e carga |
| CT-P06 | Valores e rateio | P1 | Frete e composicao comercial |
| CT-P07 | Impostos e RTC | P1 | Tributacao |
| CT-P08 | Retornos SEFAZ | P0/P1 | Estado fiscal |
| CT-P09 | Eventos essenciais | P1/P2 | Eventos CT-e |
| CT-P10 | DACTE e QR Code | P1/P2 | Documento auxiliar |
| CT-P11 | Contingencia | P2 | Recuperacao fiscal |
| CT-P12 | Distribuicao DF-e | P2 | Distribuicao e reconciliacao |
| CT-P13 | CT-e Simplificado | P2/P3 | Produto separado |
| CT-P14 | CT-e OS e GTV-e | P3 | Produto separado |
| CT-P15 | Bibliotecas C# | P0/P1 | Decisao tecnica |
| CT-P16 | Adapters externos posteriores | P1 | Fora do Fiscal.CTe |
| CT-P17 | Observabilidade fiscal | P1 | Suporte operacional |
| CT-P18 | Modularizacao interna | P0 | Arquitetura do app |

## CT-P00 - Inventario Oficial

### Objetivo

Manter uma base versionada de manuais, notas tecnicas, schemas, tabelas e
enderecos oficiais usados para implementar CT-e.

### Fontes

- Portal CT-e - Manuais.
- Portal CT-e - Schemas XML.
- Portal CT-e - Notas Tecnicas.
- Portal CT-e - Servicos Web.
- PDFs baixados em `docs/Fiscal/CTe/oficial`.

### O Que Implementar

- Dossie local com data da pesquisa.
- Registro do pacote de schema usado em cada emissao.
- Registro da versao de leiaute e notas tecnicas consideradas.
- Processo manual inicial para atualizar fonte oficial antes de mudanca fiscal.

### O Que A Engine Gera

- Nada fiscal especifico neste ponto.
- Pode gerar campos genericos de rastreabilidade fiscal se a DSL declarar a
  entidade/tentativa.

### O Que O Aplicativo Faz

- Guarda artefatos oficiais.
- Versiona schemas XML no repositorio ou pacote do aplicativo fiscal.
- Usa essas versoes para validar XML e registrar evidencias.

### Entrega

- `FONTES_OFICIAIS.md` atualizado.
- Schemas vigentes baixados antes de implementar assinatura/XSD.

### Pendencias

- pendencia: baixar e versionar o ZIP de schemas CT-e exato que sera usado no
  primeiro playground de validacao XSD.
- pendencia: definir politica de atualizacao de schemas e tabelas oficiais sem
  travar deploy de aplicacao.

## CT-P01 - Webservices CT-e 4.00

### Objetivo

Mapear como chamar os servicos oficiais CT-e 4.00 por UF, ambiente,
autorizador e tipo de documento.

### Servicos Relevantes

- `CTeRecepcaoSincV4`: autorizacao sincrona do CT-e modelo 57.
- `CTeStatusServicoV4`: status do autorizador.
- `CTeConsultaV4`: consulta de situacao por chave.
- `CTeRecepcaoEventoV4`: eventos.
- `CTeRecepcaoSimpV4`: CT-e Simplificado.
- `CTeRecepcaoOSV4`: CT-e OS.
- `CTeRecepcaoGTVeV4`: GTV-e.
- `CTeDistribuicaoDFe`: distribuicao pelo Ambiente Nacional.

### Decisoes Atuais

- CT-e 4.00 deve usar recepcao sincrona.
- CT-e 4.00 nao deve copiar o modelo antigo com SOAP Header.
- Endpoint e configuracao por UF/ambiente/autorizador, nao regra de negocio.
- Para Pernambuco, o autorizador atual mapeado e SVSP.
- A relacao oficial de servicos organiza endpoints por autorizadores como MG,
  MS, MT, PR, SVSP e SVRS.
- O WSDL deve ser obtido adicionando `?wsdl` a URL oficial do servico.

### O Que A Engine Gera

- Commands e receivers para chamadas de status, consulta, emissao e eventos.
- Contratos de configuracao operacional quando declarados.
- Endpoints internos da API do aplicativo.

### O Que O Aplicativo Faz

- Resolve endpoint por UF/ambiente.
- Executa transporte HTTP/SOAP conforme contrato oficial.
- Guarda timeout, retries e retorno bruto.

### Entrega

- `ICTeEndpointResolver`.
- `ICTeSefazClient`.
- Playground de status e consulta antes da emissao.

### Pendencias

- pendencia: confirmar por WSDL oficial o formato exato de cada envelope CT-e
  4.00 antes de codificar cliente definitivo.
- pendencia: montar matriz completa UF x autorizador x contingencia.
- pendencia: confirmar se algum estado possui regra operacional adicional alem
  do autorizador publicado.

## CT-P02 - Certificado E Assinatura

### Objetivo

Assinar XML oficial e autenticar chamada SEFAZ com certificado ICP-Brasil.

### Responsabilidades

- Carregar certificado A1/A3 conforme ambiente.
- Validar validade, cadeia e permissao de uso.
- Assinar os grupos exigidos pelo schema.
- Usar certificado cliente no transporte.
- Separar erro de certificado, erro de assinatura e rejeicao SEFAZ.

### O Que A Engine Gera

- Bordas de comando para configurar referencia de certificado.
- Entidade de referencia como `CTeCertificadoReferencia`, se declarada na DSL.
- Pontos `Custon` para implementacao real.

### O Que O Aplicativo Faz

- Implementa `ICTeXmlSigner`.
- Implementa carga segura do certificado.
- Decide armazenamento de senha/chave em dev, homologacao e producao.

### Entrega

- Assinatura de XML local validada por XSD.
- Falha tecnica clara quando certificado estiver ausente ou invalido.

### Pendencias

- pendencia: decidir armazenamento de segredo do certificado para producao.
- pendencia: avaliar PAA como recurso futuro sem contaminar a primeira entrega.

## CT-P03 - Status E Consulta

### Objetivo

Ter chamadas simples que provem comunicacao com autorizador e reconciliam estado
do CT-e pela chave.

### Fluxos

- Consultar status do servico antes de uma rodada de emissao.
- Consultar situacao por chave quando houver duvida local.
- Salvar retorno bruto e interpretacao.

### O Que A Engine Gera

- `ConsultarStatusServicoCTeCommand`.
- `ConsultarSituacaoCTeCommand`.
- Receivers e endpoints internos.
- Repositorios para salvar tentativa/retorno quando entidades existirem.

### O Que O Aplicativo Faz

- Implementa parser dos retornos oficiais.
- Controla regra para nao consultar em excesso.
- Define quando consulta corrige o estado interno.

### Entrega

- Playground P0 chamando homologacao.
- Resultado com `cStat`, `xMotivo`, autorizador, UF, ambiente e duracao.

### Pendencias

- pendencia: definir limites de consulta para evitar consumo indevido.
- pendencia: registrar codigos de indisponibilidade e manutencao relevantes.

## CT-P04 - Emissao CT-e Modelo 57

### Objetivo

Romper a primeira emissao de CT-e normal modelo 57, inicialmente em
homologacao.

### Pipeline Minimo

1. Receber intencao de emissao.
2. Normalizar entrada para contrato interno.
3. Validar pre-condicoes.
4. Reservar serie/numero/codigo numerico.
5. Montar documento fiscal interno.
6. Gerar XML oficial.
7. Assinar XML.
8. Validar XSD.
9. Transmitir por `CTeRecepcaoSincV4`.
10. Interpretar retorno.
11. Persistir XML, protocolo, status e trilha.
12. Publicar resultado interno.

### O Que A Engine Gera

- `ReceberSolicitacaoEmissaoCTe`.
- `EmitirCTe`.
- Entities operacionais de CT-e e tentativa.
- Repositories, endpoints, receivers e workers se a DSL declarar assincrono.

### O Que O Aplicativo Faz

- Implementa composicao fiscal.
- Implementa XML/assinatura/XSD/cliente SEFAZ/parser.
- Decide se o fluxo responde sincrono ou apenas enfileira.

### Entrega

- CT-e homologado em ambiente de teste.
- Retorno salvo com chave, protocolo, status e XML.

### Pendencias

- pendencia: definir primeiro conjunto minimo de campos do
  `CTeEmissionRequest`.
- pendencia: confirmar modal inicial. A pre-decisao e rodoviario.

## CT-P05 - Participantes E Documentos Originarios

### Objetivo

Organizar os dados necessarios para emitir CT-e sem acoplar CT-e a pedido,
carga, NF-e ou sistema legado.

### Assuntos

- Emitente.
- Tomador.
- Remetente.
- Destinatario.
- Expedidor.
- Recebedor.
- Motorista e veiculo quando modal exigir.
- Documentos originarios, especialmente NF-e.
- Carga, volumes, peso, valor de mercadoria e localidade.

### O Que A Engine Gera

- Entidades e DTOs de snapshots.
- Commands para receber/atualizar dados operacionais.
- Repositorios e consultas.

### O Que O Aplicativo Faz

- Valida combinacoes obrigatorias por tipo de servico.
- Normaliza dados vindos de mensagens oficiais ou adapters anteriores.
- Mantem snapshots independentes do banco original de pedido/carga/NF-e.

### Entrega

- Modelo interno capaz de emitir CT-e sem consultar modulo externo durante a
  emissao.

### Pendencias

- pendencia: confirmar quais participantes entram no primeiro cliente real.
- pendencia: mapear todos os documentos originarios exigidos pelo recorte
  rodoviario inicial.

## CT-P06 - Valores E Rateio

### Objetivo

Separar regra comercial de rateio do transporte tecnico SEFAZ.

### Assuntos

- Valor total do frete.
- Componentes do frete.
- Pedagio, seguro, carga/descarga e outras taxas.
- Rateio por peso, valor, volume, nota, pedido, rota ou regra customizada.
- Consolidacao por CT-e unico ou multiplos CT-es.

### O Que A Engine Gera

- Bordas para comandos de calculo/rateio quando declaradas.
- Entidades de valor e historico se a DSL pedir.

### O Que O Aplicativo Faz

- Implementa politica de rateio.
- Decide arredondamento, divergencias e rastreabilidade.
- Garante que regra comercial nao misture XML SEFAZ.

### Entrega

- `ICTeFreteRateioPolicy` ou miolo equivalente.
- Evidencia do rateio usado em cada emissao.

### Pendencias

- pendencia: levantar modelos reais de cobranca dos modulos anteriores antes
  de fixar contrato definitivo.

## CT-P07 - Impostos, ICMS E RTC

### Objetivo

Isolar calculo fiscal para nao misturar tributacao com emissao, XML, DACTE ou
adapter externo.

### Assuntos

- ICMS do CT-e.
- CST, CFOP e natureza.
- Regras por UF, tipo de servico e tomador.
- Reforma Tributaria do Consumo.
- IBS, CBS, cashback, credito presumido, classificacao tributaria e pagamento
  vinculado quando aplicavel.
- Tabelas oficiais de dominios fiscais.

### O Que A Engine Gera

- Entidades/DTOs de imposto se declaradas.
- Bordas para policies de calculo.
- Campos de trilha que indiquem versao de regra fiscal usada.

### O Que O Aplicativo Faz

- Implementa calculo fiscal.
- Versiona regras fiscais.
- Interpreta notas tecnicas por data de entrada em vigor.

### Entrega

- Motor fiscal inicial para cenarios reais P1.
- Falha clara quando uma regra fiscal ainda nao estiver suportada.

### Pendencias

- pendencia: nao codificar RTC completo antes de identificar impacto real no
  primeiro recorte.
- pendencia: confirmar tabelas oficiais vigentes antes de gerar enums ou
  constantes.

## CT-P08 - Retornos SEFAZ E Estado Fiscal

### Objetivo

Transformar resposta oficial em estado interno sem esconder a evidencia bruta.

### Estados Internos Candidatos

- Recebido.
- Em processamento local.
- Assinatura invalida.
- Schema invalido.
- Enviado.
- Autorizado.
- Rejeitado.
- Denegado, se aplicavel ao CT-e em regra vigente.
- Cancelado.
- Evento registrado.
- Falha tecnica.
- Reprocessamento requerido.

### O Que A Engine Gera

- Entidades de tentativa, retorno e protocolo.
- Repositorios e consultas.
- Commands de reprocessamento se declarados.

### O Que O Aplicativo Faz

- Implementa parser de `cStat`, `xMotivo`, protocolo e XML de retorno.
- Decide transicao de estado.
- Diferencia rejeicao fiscal de falha tecnica.

### Entrega

- Tabela de `cStat` mapeada conforme schema/manual vigente.
- Persistencia de retorno bruto e retorno interpretado.

### Pendencias

- pendencia: extrair matriz de `cStat` do schema/manual vigente antes de
  transformar em constantes.

## CT-P09 - Eventos CT-e

### Objetivo

Implementar eventos como fluxos de negocio independentes, apesar de a SEFAZ
usar um webservice oficial comum.

### Eventos Mapeados

- `110110` - Carta de Correcao.
- `110111` - Cancelamento.
- `110113` - EPEC.
- `110160` - Registro Multimodal.
- `110170` - Informacoes da GTV.
- `110180` - Comprovante de Entrega.
- `110181` - Cancelamento do Comprovante de Entrega.
- `110190` - Insucesso na Entrega.
- `110191` - Cancelamento do Insucesso na Entrega.
- `110300` - Vinculacao de Pagamento.
- `110301` - Cancelamento da Vinculacao de Pagamento.
- `610110` - Prestacao em Desacordo.
- `610111` - Cancelamento da Prestacao em Desacordo.

### O Que A Engine Gera

- Commands e receivers por evento declarado.
- Repositories de evento e XML.
- Endpoint interno por capacidade, nao por detalhe SEFAZ.

### O Que O Aplicativo Faz

- Monta XML de evento.
- Valida regra de negocio e prazo.
- Transmite por `CTeRecepcaoEventoV4`.
- Interpreta retorno e vincula ao CT-e.

### Entrega

- P1: cancelamento e carta de correcao.
- P2: comprovante, insucesso, desacordo, contingencia.
- P3: eventos muito especificos.

### Pendencias

- pendencia: confirmar codigos e schemas de evento no ZIP vigente antes de
  codificar constantes.

## CT-P10 - DACTE E QR Code

### Objetivo

Disponibilizar documento auxiliar e consulta publica depois da autorizacao ou
conforme regra de contingencia.

### Assuntos

- DACTE PDF/HTML.
- QR Code por ambiente/autorizador.
- Layout por modal e tipo de CT-e.
- Armazenamento e reemissao.
- Impressao ou download.

### O Que A Engine Gera

- Borda `GerarDacteCTe`.
- Entidade de documento gerado se declarada.
- Endpoints para baixar/consultar documento.

### O Que O Aplicativo Faz

- Implementa renderer.
- Monta QR Code conforme manual.
- Decide cache e invalidacao.

### Entrega

- DACTE basico para CT-e modelo 57 autorizado.

### Pendencias

- pendencia: definir biblioteca ou renderer proprio para DACTE.
- pendencia: confirmar exigencias do DACTE por modal antes do layout completo.

## CT-P11 - Contingencia

### Objetivo

Isolar emissao em contingencia para nao contaminar fluxo normal.

### Modalidades Candidatas

- SVC-RS/SVC-SP conforme autorizador.
- EPEC.
- FS-DA.
- Transmissao posterior.
- Reconciliacao apos retorno do autorizador principal.

### O Que A Engine Gera

- Commands de contingencia quando declarados.
- Workers de reprocessamento quando a DSL declarar fila/polling.
- Persistencia de tentativa/estado.

### O Que O Aplicativo Faz

- Decide quando contingencia e permitida.
- Monta XML/evento especifico.
- Gerencia retorno ao fluxo normal.

### Entrega

- Nao entra na primeira emissao.
- Deve estar desenhada como fronteira.

### Pendencias

- pendencia: pesquisar regras atuais de SVC e EPEC para CT-e 4.00 antes de
  implementar.

## CT-P12 - Distribuicao DF-e

### Objetivo

Buscar documentos fiscais de interesse pelo Ambiente Nacional sem misturar com
emissao propria.

### Assuntos

- NSU.
- `ultNSU`.
- `maxNSU`.
- CNPJ/CPF interessado.
- Persistencia de lotes recebidos.
- Manifestacao/visibilidade quando aplicavel.
- Reconciliacao com documentos emitidos internamente.

### O Que A Engine Gera

- Bordas de consulta/distribuicao.
- Repositories para lotes/documentos.
- Workers se a DSL declarar rotina.

### O Que O Aplicativo Faz

- Implementa cliente AN.
- Controla NSU e janela de consumo.
- Interpreta documentos recebidos.

### Entrega

- P2, depois da emissao e eventos basicos.

### Pendencias

- pendencia: revisar NT 2015.002 e schemas atuais antes de definir entidade
  final.

## CT-P13 - CT-e Simplificado

### Objetivo

Tratar CT-e Simplificado como produto relacionado, mas separado da emissao
normal.

### Decisao Atual

- Nao nascer como flag dentro de `EmitirCTe`.
- Criar pasta/namespace e comandos proprios quando chegar a hora.

### O Que A Engine Gera

- Bordas especificas quando a DSL declarar o produto.

### O Que O Aplicativo Faz

- Implementa XML, regra fiscal e retorno do CT-e Simplificado.

### Entrega

- P2/P3.

### Pendencias

- pendencia: estudar NT 2024.002 e schemas especificos antes de implementar.

## CT-P14 - CT-e OS E GTV-e

### Objetivo

Preservar espaco para produtos fiscais proximos sem acoplar ao CT-e de carga.

### Decisao Atual

- CT-e OS e GTV-e ficam fora do primeiro recorte.
- Podem reutilizar certificado, endpoint resolver, cliente SEFAZ, parser e
  observabilidade fiscal.
- Nao compartilham composicao de documento nem regra de emissao com CT-e carga.

### O Que A Engine Gera

- Projetos/bordas quando declarados.

### O Que O Aplicativo Faz

- Miolos fiscais especificos.

### Pendencias

- pendencia: somente abrir esses produtos depois de demanda real.

## CT-P15 - Bibliotecas C#

### Objetivo

Avaliar se vale usar biblioteca pronta para XML, assinatura, XSD, SOAP,
DACTE ou regras fiscais.

### Principio

Biblioteca e detalhe de implementacao, nao arquitetura do modulo.

### Criterios De Avaliacao

- Suporte CT-e 4.00.
- Atualizacao ativa de schemas/NTs.
- Controle sobre XML e assinatura.
- Licenca.
- Compatibilidade com Linux/Docker.
- Compatibilidade futura com trimming/AOT, quando possivel.
- Capacidade de retornar XML bruto e evidencias.

### O Que A Engine Gera

- Interfaces e pontos customizados.
- Nunca dependencia direta em biblioteca fiscal especifica.

### O Que O Aplicativo Faz

- Escolhe implementacao concreta.
- Pode trocar biblioteca sem alterar DSL.

### Entrega

- Comparativo tecnico antes do miolo definitivo.

### Pendencias

- pendencia: DFe.NET foi baixado como primeira referencia C# em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\DFe.NET`;
  Unimake.DFe foi baixado como segunda referencia C# em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\Unimake.DFe`.
- pendencia: pesquisar Hercules-NET/ZeusFiscal, fork/sucessor do DFe.NET, antes
  da decisao final.
- pendencia: testar pelo menos status, assinatura/XSD e autorizacao em
  homologacao antes de escolher dependencia ou implementacao propria.

## CT-P16 - Adapters Externos Posteriores

### Objetivo

Permitir que clientes troquem apenas a URL quando ja integram com contrato
externo legado, sem colocar esse contrato dentro do modulo Fiscal.CTe.

### Decisao Atual

- O adapter fica fora do Fiscal.CTe, em modulo de recepcao, carga ou
  integracao, organizado por mnemonico neutro.
- Nome real de fabricante nao deve aparecer quando houver risco comercial.
- Exemplo de mnemonico: `FabricaSoftware01`.
- Adapter SOAP deve entregar `.svc` e `.svc?wsdl` quando a compatibilidade
  exigir.
- Token deve vir no formato esperado pelo contrato externo; no primeiro adapter
  APS o legado usa SOAP Header `Token`.
- O payload bruto pode ser guardado antes de qualquer regra, ainda no adapter.
- O adapter converte para mensagem oficial e entrega ao Fiscal.CTe por API
  oficial ou inbox/outbox.

### O Que A Engine Gera

- Casca da rota no modulo adapter.
- Extracao de token no adapter.
- Encaminhamento para receiver oficial do modulo fiscal.
- Alias previsivel como `/SGT.WebService/{Service}.svc`, se declarado.

### O Que O Aplicativo Faz

- Guarda WSDL e XSD real no modulo adapter.
- Normaliza payload para mensagem oficial.
- Implementa receiver que cria entrada, carga, pedido ou solicitacao oficial.

### Entrega

- Primeiro adapter externo provado fora do Fiscal.CTe, salvando payload bruto e
  gerando mensagem oficial.

### Pendencias

- pendencia: decidir se payload bruto fica em `yInbox` ou tabela especifica de
  integracao.
- pendencia: resolver token em `yToken` para obter tenant, cliente e permissoes.

## CT-P17 - Observabilidade Fiscal

### Objetivo

Permitir suporte operacional real em emissao fiscal sem depender de adivinhacao.

### Minimo Por Tentativa

- Aplicacao.
- Ambiente.
- UF.
- Autorizador.
- Servico.
- Endpoint.
- Chave de acesso.
- Serie e numero.
- Emitente.
- Versao de leiaute.
- Versao de schema.
- Hash do XML.
- Duracao por etapa.
- `cStat`.
- `xMotivo`.
- Protocolo.
- XML enviado.
- Retorno bruto.
- Erro tecnico separado de rejeicao fiscal.

### O Que A Engine Gera

- Bordas e entidades de tentativa se declaradas.
- Telemetria padrao de commands/repositories ja alinhada ao Yeshua.

### O Que O Aplicativo Faz

- Registra etapas fiscais especificas.
- Fornece dados suficientes para replay controlado.
- Expõe diagnostico para suporte.

### Entrega

- Consulta operacional por chave, tentativa, status e protocolo.

### Pendencias

- pendencia: definir ate onde replay pode usar payload real sem violar
  seguranca/privacidade.
- pendencia: correlacionar logs de adapter, emissao e retorno SEFAZ.

## CT-P18 - Modularizacao Interna

### Objetivo

Garantir que o modulo CT-e seja vendavel, implantavel e manutenivel sem virar
um bloco unico.

### Modulos Externos Que O CT-e Nao Deve Invadir

- Pedido.
- Carga.
- Planejamento de transporte.
- Estoque.
- Producao.
- Faturamento/NF-e.
- MDF-e.
- Financeiro.

### Fronteiras Internas Do CT-e

- Entrada oficial.
- Normalizacao.
- Validacao operacional.
- Numeracao/chave.
- Composicao fiscal.
- Rateio.
- Tributacao.
- XML oficial.
- Assinatura.
- XSD.
- Cliente SEFAZ.
- Retorno.
- Eventos.
- DACTE.
- Contingencia.
- Distribuicao.
- Observabilidade fiscal.

### O Que A Engine Gera

- Projeto/app Fiscal.CTe independente.
- Bordas por use case/capacidade.
- Pastas `Migration` e `Custon`.
- Pontos de extensao protegidos.

### O Que O Aplicativo Faz

- Mantem miolos pequenos e substituiveis.
- Evita classe central de CT-e.
- Mantem contratos internos estaveis.

### Entrega

- Primeiro app Fiscal.CTe com P0 implementado sem depender de MDF-e ou APS.

### Pendencias

- pendencia: decidir se `Yeshua.Fiscal` sera apenas agregador comercial ou
  tambem projeto tecnico em algum ponto futuro.

## Regras De Corte

- Se o assunto e tag XML, schema, assinatura, cStat, DACTE ou regra oficial,
  pertence ao aplicativo Fiscal.CTe.
- Se o assunto e borda repetivel de command, receiver, endpoint, repository,
  worker, smoke test ou ownership, pertence a Engine.
- Se o assunto e contrato generico de CQRS, logging, cache, unit of work ou
  telemetria nao fiscal, pertence ao Shared.
- Se o assunto e contrato de fabricante, arquivo legado, SOAP externo ou layout
  de terceiro, pertence a adapters fora do Fiscal.CTe/MDF-e.
- Se o assunto e pedido, estoque, producao, transporte ou faturamento, CT-e
  recebe snapshot e nao assume propriedade.

## Sequencia De Conhecimento

1. Confirmar e versionar schemas.
2. Provar status/consulta em homologacao.
3. Provar assinatura e XSD local.
4. Provar autorizacao modelo 57 em homologacao.
5. Modelar persistencia operacional.
6. Gerar app Fiscal.CTe.
7. Implementar emissao normal.
8. Implementar cancelamento e carta de correcao.
9. Implementar integracao oficial CT-e -> MDF-e por outbox/inbox.
10. Implementar DACTE basico.
11. Tratar contingencia, distribuicao e produtos fiscais adicionais por demanda.
