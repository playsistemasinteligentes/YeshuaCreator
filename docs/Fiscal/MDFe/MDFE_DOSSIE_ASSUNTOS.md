# MDF-e - Dossie De Assuntos

Consolidado em 2026-08-28.

Este arquivo e o dossie de trabalho para o modulo Fiscal.MDFe. Ele nao substitui
MOC, Anexo I, Anexo II, notas tecnicas, schemas XML ou WSDLs oficiais. A funcao
dele e separar os assuntos, evitar mistura de responsabilidades e orientar a
criacao do modulo de MDF-e dentro do conceito Yeshua.

Regra central:

- Fonte oficial define regra fiscal, leiaute, evento, endpoint e validacao.
- Engine gera bordas previsiveis.
- Aplicativo Fiscal.MDFe implementa miolos fiscais e integracoes SEFAZ.
- Conectores recebem contratos externos e normalizam para contratos internos.
- Outros modulos fornecem snapshots; MDF-e nao invade o dominio deles.

## Mapa Geral

| Familia | Assunto | Prioridade | Produto interno |
| --- | --- | --- | --- |
| MDF-P00 | Inventario oficial | P0 | Conhecimento fiscal |
| MDF-P01 | Webservices 3.00 | P0 | Infra fiscal SEFAZ |
| MDF-P02 | Certificado e assinatura | P0 | Infra fiscal SEFAZ |
| MDF-P03 | Encerramento | P0 | Encerramento MDF-e |
| MDF-P04 | Consulta e nao encerrados | P0 | Consulta e reconciliacao |
| MDF-P05 | Retornos SEFAZ | P0/P1 | Estado fiscal |
| MDF-P06 | Cancelamento | P1 | Eventos MDF-e |
| MDF-P07 | Inclusao de condutor | P1 | Eventos MDF-e |
| MDF-P08 | DAMDFE e QR Code | P1 | Documento auxiliar |
| MDF-P09 | Emissao rodoviaria | P1/P2 | MDF-e rodoviario |
| MDF-P10 | Documentos originarios | P1/P2 | Composicao fiscal |
| MDF-P11 | Veiculos, condutores e percurso | P1 | Modal rodoviario |
| MDF-P12 | CIOT, contrato e vale pedagio | P1/P2 | Rodoviario/ANTT |
| MDF-P13 | Pagamento e MDF-e Integrado | P2 | Integrado/pagamento |
| MDF-P14 | Distribuicao DF-e | P2 | Distribuicao |
| MDF-P15 | InfraSA/DTe | P2 | Consulta e integracao federal |
| MDF-P16 | CT-e Simplificado no MDF-e | P2 | Documentos originarios |
| MDF-P17 | PAA, NFF e CNPJ Alfa | P3 | Compatibilidade futura |
| MDF-P18 | Bibliotecas C# | P0/P1 | Decisao tecnica |
| MDF-P19 | Conectores legados | P1 | Entrada externa |
| MDF-P20 | Observabilidade fiscal | P1 | Suporte operacional |
| MDF-P21 | Modularizacao interna | P0 | Arquitetura do app |

## MDF-P00 - Inventario Oficial

### Objetivo

Manter uma base versionada de manuais, notas tecnicas, schemas, tabelas e
enderecos oficiais usados para implementar MDF-e.

### Fontes

- Portal MDF-e - Manuais.
- Portal MDF-e - Schemas XML.
- Portal MDF-e - Notas Tecnicas.
- Portal MDF-e - Servicos Web.
- Portal MDF-e - Legislacao.
- Portal MDF-e - Tabelas e informes tecnicos.

### O Que Implementar

- Dossie local com data da pesquisa.
- Registro do pacote de schema usado em cada transmissao.
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
- Schemas vigentes baixados antes de implementar XSD definitivo.

### Pendencias

- pendencia: baixar e versionar o ZIP de schemas MDF-e exato que sera usado no
  primeiro cliente definitivo.
- pendencia: definir politica de atualizacao de schemas e tabelas oficiais sem
  travar deploy de aplicacao.

## MDF-P01 - Webservices MDF-e 3.00

### Objetivo

Mapear como chamar os servicos oficiais MDF-e por ambiente, autorizador,
servico, namespace, SOAPAction e XML de entrada/retorno.

### Servicos Relevantes

- `MDFeRecepcaoEvento`: eventos como encerramento, cancelamento e inclusoes.
- `MDFeConsulta`: consulta de situacao por chave.
- `MDFeStatusServico`: status do autorizador.
- `MDFeConsNaoEnc`: consulta de MDF-e nao encerrados.
- `MDFeDistribuicaoDFe`: distribuicao aos atores interessados.
- `MDFeRecepcaoSinc`: autorizacao sincrona do MDF-e.
- QR Code MDF-e: consulta publica usada pelo DAMDFE.

### Decisoes Atuais

- O primeiro recorte usa `MDFeRecepcaoEvento`.
- A SVRS aparece como Ambiente Nacional para producao e homologacao.
- WSDL deve ser obtido com `?wsdl` na URL oficial.
- Endpoint deve ser configuracao por ambiente/servico, nao constante no miolo.
- O playground provou SOAP 1.2 com `mdfeCabecMsg` e `mdfeDadosMsg` para
  encerramento.

### O Que A Engine Gera

- Commands e receivers para chamadas declaradas.
- Endpoints internos da API do aplicativo.
- Pontos `Custon` para cliente fiscal.

### O Que O Aplicativo Faz

- Resolve endpoint por ambiente.
- Executa transporte HTTP/SOAP conforme contrato oficial.
- Guarda timeout, retries e retorno bruto.

### Entrega

- `IMDFeEndpointResolver`.
- `IMDFeSefazClient`.
- Playground/miolo de status, consulta e encerramento.

### Pendencias

- pendencia: confirmar por WSDL oficial o formato exato de cada servico MDF-e
  antes de codificar cliente definitivo.
- pendencia: decidir se o SOAP Header sera mantido apenas por compatibilidade
  do MDF-e 3.00 ou se sera opcional conforme schemas/NTs vigentes.

## MDF-P02 - Certificado E Assinatura

### Objetivo

Assinar XML oficial e autenticar chamada SEFAZ com certificado ICP-Brasil.

### Responsabilidades

- Carregar certificado A1/A3 conforme ambiente.
- Validar validade, cadeia e permissao de uso.
- Assinar o grupo exigido pelo evento ou documento.
- Usar certificado cliente no transporte.
- Separar erro de certificado, erro de assinatura e rejeicao SEFAZ.

### O Que A Engine Gera

- Bordas de comando para configurar referencia de certificado, se a DSL pedir.
- Entidade de referencia como `MDFeCertificadoReferencia`, se declarada.
- Pontos `Custon` para implementacao real.

### O Que O Aplicativo Faz

- Implementa `IMDFeXmlSigner`.
- Implementa carga segura do certificado.
- Decide armazenamento de senha/chave em dev, homologacao e producao.

### Entrega

- XML de evento assinado localmente.
- Falha tecnica clara quando certificado estiver ausente ou invalido.

### Pendencias

- pendencia: decidir armazenamento de segredo do certificado para producao.
- pendencia: avaliar PAA como recurso futuro sem contaminar a primeira entrega.

## MDF-P03 - Encerramento

### Objetivo

Encerrar MDF-e autorizado com rastreabilidade suficiente para suporte e
reprocessamento controlado.

### Dados Minimos

- Chave do MDF-e.
- Protocolo de autorizacao do MDF-e.
- CNPJ do emitente.
- Ambiente.
- UF e municipio de encerramento.
- Data de encerramento.
- Certificado.
- Sequencia do evento.

### Pipeline

1. Receber intencao de encerramento.
2. Validar chave e protocolo.
3. Resolver emitente/certificado/ambiente.
4. Montar evento `110112`.
5. Assinar XML.
6. Validar XSD.
7. Transmitir por `MDFeRecepcaoEvento`.
8. Interpretar retorno.
9. Salvar XML enviado, retorno bruto, protocolo e estado interno.
10. Atualizar MDF-e quando evento for homologado.

### O Que A Engine Gera

- `EncerrarMDFeCommand`.
- Receiver de borda.
- Endpoint interno.
- Repositorios e entidades declaradas na DSL.
- Ponto custom para miolo fiscal.

### O Que O Aplicativo Faz

- Implementa XML do evento.
- Implementa assinatura/XSD/cliente SEFAZ/parser.
- Decide idempotencia e reprocessamento.

### Entrega

- Encerramento real ou homologado com retorno salvo.

### Pendencias

- pendencia: migrar o playground para o miolo customizado do app.
- pendencia: confirmar regra de data/municipio de encerramento no schema
  vigente.
- pendencia: decidir se tentativa fica em `MDFeEncerramento` ou entidade
  separada `MDFeTentativaEvento`.

## MDF-P04 - Consulta E Nao Encerrados

### Objetivo

Ter chamadas simples para diagnosticar estado fiscal e evitar MDF-e aberto
indevidamente.

### Fluxos

- Consultar status do servico antes de rodada fiscal.
- Consultar situacao por chave.
- Consultar MDF-e nao encerrados por emitente.
- Reconciliar divergencias entre estado interno e estado SEFAZ.

### O Que A Engine Gera

- `ConsultarStatusServicoMDFeCommand`.
- `ConsultarSituacaoMDFeCommand`.
- `ConsultarMDFeNaoEncerradosCommand`.
- Receivers, endpoints e repositorios quando declarados.

### O Que O Aplicativo Faz

- Implementa XML/cliente/parser.
- Controla consumo para evitar abuso/consumo indevido.
- Atualiza indicadores operacionais.

### Entrega

- Consulta por chave com `cStat`, `xMotivo`, protocolo e situacao.
- Lista de nao encerrados usavel para operacao.

### Pendencias

- pendencia: confirmar regras de consumo e limite para nao encerrados.
- pendencia: definir quais divergencias podem alterar o estado interno
  automaticamente.

## MDF-P05 - Retornos SEFAZ E Estado Fiscal

### Objetivo

Transformar resposta oficial em estado interno sem esconder a evidencia bruta.

### Estados Internos Candidatos

- Recebido.
- Em processamento local.
- Assinatura invalida.
- Schema invalido.
- Enviado.
- Autorizado.
- Em transporte.
- Encerrado.
- Cancelado.
- Evento registrado.
- Rejeitado.
- Falha tecnica.
- Reprocessamento requerido.

### O Que A Engine Gera

- Entidades de tentativa, retorno e protocolo quando declaradas.
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

## MDF-P06 - Cancelamento

### Objetivo

Cancelar MDF-e autorizado quando regra oficial permitir.

### Pipeline

1. Receber chave, protocolo e justificativa.
2. Validar situacao interna.
3. Montar evento de cancelamento.
4. Assinar e validar XSD.
5. Enviar por `MDFeRecepcaoEvento`.
6. Interpretar retorno.
7. Persistir evento e atualizar estado.

### O Que A Engine Gera

- `CancelarMDFeCommand`.
- Receiver/endpoint.
- Repositorios de evento.

### O Que O Aplicativo Faz

- Regra de prazo e justificativa.
- XML evento e parser.

### Entrega

- P1, depois do encerramento/consulta.

### Pendencias

- pendencia: confirmar prazo, codigo, schema e campos obrigatorios no pacote
  vigente.

## MDF-P07 - Inclusao De Condutor

### Objetivo

Permitir inclusao de condutor em MDF-e autorizado quando a operacao rodoviaria
exigir.

### O Que A Engine Gera

- `IncluirCondutorMDFeCommand`.
- Receiver/endpoint.
- Repositorios de evento.

### O Que O Aplicativo Faz

- Valida dados do condutor.
- Monta XML do evento.
- Interpreta retorno e vincula ao MDF-e.

### Entrega

- P1, junto com cancelamento ou logo apos.

### Pendencias

- pendencia: confirmar campos/codigo no XSD vigente.

## MDF-P08 - DAMDFE E QR Code

### Objetivo

Disponibilizar documento auxiliar e consulta publica depois da autorizacao.

### Assuntos

- DAMDFE PDF/HTML.
- QR Code por ambiente.
- Layout por modal.
- Armazenamento e reemissao.
- Impressao, download e envio.

### O Que A Engine Gera

- Borda `GerarDAMDFE`.
- Entidade de documento gerado se declarada.
- Endpoints para baixar/consultar documento.

### O Que O Aplicativo Faz

- Implementa renderer.
- Monta QR Code conforme manual.
- Decide cache e invalidacao.

### Entrega

- DAMDFE basico para MDF-e rodoviario autorizado.

### Pendencias

- pendencia: definir biblioteca ou renderer proprio.
- pendencia: confirmar exigencias do DAMDFE por modal.

## MDF-P09 - Emissao Rodoviaria

### Objetivo

Autorizar MDF-e rodoviario em fluxo sincrono quando o recorte estiver maduro.

### Pipeline Minimo

1. Receber `MDFeEmissionRequest`.
2. Normalizar documentos originarios.
3. Validar emitente/certificado/ambiente.
4. Reservar serie/numero/chave.
5. Validar modal rodoviario.
6. Montar XML oficial.
7. Assinar XML.
8. Validar XSD.
9. Transmitir por `MDFeRecepcaoSinc`.
10. Interpretar retorno.
11. Persistir XML, protocolo e status.
12. Liberar DAMDFE quando autorizado.

### O Que A Engine Gera

- `ReceberSolicitacaoEmissaoMDFe`.
- `EmitirMDFeRodoviario`.
- Entidades operacionais.
- Repositories, endpoints, receivers e workers se a DSL declarar assincrono.

### O Que O Aplicativo Faz

- Implementa composicao fiscal.
- Implementa XML/assinatura/XSD/cliente SEFAZ/parser.
- Decide processamento sincrono ou por inbox.

### Entrega

- MDF-e rodoviario homologado ou rejeitado com diagnostico claro.

### Pendencias

- pendencia: definir primeiro contrato `MDFeEmissionRequest`.
- pendencia: confirmar campos obrigatorios do modal rodoviario no schema
  vigente.

## MDF-P10 - Documentos Originarios

### Objetivo

Receber CT-e, NF-e e outros documentos aceitos sem acoplar MDF-e aos modulos de
origem.

### Assuntos

- CT-e autorizado.
- NF-e autorizada.
- CT-e Simplificado.
- BPe ou outros documentos quando a regra permitir.
- Municipio de descarregamento por documento.
- Limite de documentos por municipio conforme nota tecnica vigente.

### O Que A Engine Gera

- Entidades e DTOs de snapshots.
- Commands para receber/atualizar dados.
- Repositorios e consultas.

### O Que O Aplicativo Faz

- Valida combinacoes obrigatorias.
- Normaliza snapshots vindos de conectores ou modulos internos.
- Mantem independencia do banco original.

### Entrega

- Modelo interno capaz de emitir MDF-e sem consultar outro modulo durante a
  transmissao.

### Pendencias

- pendencia: confirmar documentos originarios do primeiro cliente real.

## MDF-P11 - Veiculos, Condutores E Percurso

### Objetivo

Organizar dados fisicos/logisticos do transporte rodoviario.

### Assuntos

- Veiculo de tracao.
- Reboques.
- Placa, RENAVAM, tara, capacidade e UF.
- Proprietario/arrendatario quando aplicavel.
- Condutores.
- Municipios de carregamento e descarregamento.
- Percurso por UFs.

### O Que A Engine Gera

- Entidades operacionais declaradas.
- Commands e consultas de apoio.

### O Que O Aplicativo Faz

- Valida regra do modal.
- Normaliza dados do planejamento de transporte.

### Entrega

- Snapshot rodoviario suficiente para emissao.

### Pendencias

- pendencia: levantar dados reais do APS/legado antes de fixar entidade final.

## MDF-P12 - CIOT, Contrato E Vale Pedagio

### Objetivo

Tratar exigencias rodoviarias sem misturar com XML, emissao ou encerramento.

### Assuntos

- CIOT obrigatorio em prestacoes por conta de terceiros e mediante remuneracao.
- RNTRC.
- Contratante.
- Proprietario do veiculo.
- Vale pedagio e fornecedores validos.
- Seguro e averbação.

### O Que A Engine Gera

- Bordas/entidades quando declaradas.
- Campos de trilha.

### O Que O Aplicativo Faz

- Implementa regras ANTT e notas tecnicas.
- Versiona validacoes por vigencia.

### Entrega

- Bloqueios claros antes de transmitir quando dado obrigatorio faltar.

### Pendencias

- pendencia: confirmar impacto da NT 2026.001 antes de bloquear todos os
  cenarios.
- pendencia: baixar tabela ANTT vigente de vale pedagio quando esse recorte
  entrar.

## MDF-P13 - Pagamento E MDF-e Integrado

### Objetivo

Isolar eventos e dados de contrato, adiantamento, pagamento e confirmacao do
servico.

### O Que A Engine Gera

- Commands/receivers quando o recorte for declarado.
- Repositorios e entidades de pagamento.

### O Que O Aplicativo Faz

- Implementa regras de pagamento.
- Monta eventos fiscais especificos.
- Interpreta retornos.

### Entrega

- P2, somente apos emissao/eventos basicos.

### Pendencias

- pendencia: estudar NT 2020.001, NT 2022.001 e schemas vigentes antes de
  definir contrato.

## MDF-P14 - Distribuicao DF-e

### Objetivo

Buscar documentos fiscais de interesse pelo Ambiente Nacional sem misturar com
emissao propria.

### Assuntos

- NSU.
- `ultNSU`.
- `maxNSU`.
- CNPJ/CPF interessado.
- Persistencia de lotes recebidos.
- Reconciliacao com documentos emitidos internamente.

### O Que A Engine Gera

- Bordas de consulta/distribuicao.
- Repositorios para lotes/documentos.
- Workers se a DSL declarar rotina.

### O Que O Aplicativo Faz

- Implementa cliente de distribuicao.
- Controla NSU e janela de consumo.
- Interpreta documentos recebidos.

### Entrega

- P2, depois da emissao e eventos basicos.

### Pendencias

- pendencia: revisar NT 2015.002 e schemas atuais antes de definir entidade
  final.

## MDF-P15 - InfraSA/DTe

### Objetivo

Guardar e expor dados retornados na consulta de situacao para uso de DTe/InfraSA
quando a operacao exigir.

### O Que A Engine Gera

- Nada especifico inicialmente.
- Pode gerar entidades/queries quando a DSL declarar.

### O Que O Aplicativo Faz

- Interpreta retorno de consulta situacao.
- Persiste protocolo/data de disponibilizacao quando existir.

### Entrega

- P2, apenas quando houver caso real.

### Pendencias

- pendencia: mapear campos alterados pela NT 2023.002.

## MDF-P16 - CT-e Simplificado No MDF-e

### Objetivo

Tratar referencia a CT-e Simplificado sem contaminar documento originario comum.

### Decisao Atual

- Nao codificar como flag solta.
- Criar subtipo/normalizador proprio quando houver demanda.

### O Que A Engine Gera

- Bordas e entidades quando declaradas.

### O Que O Aplicativo Faz

- Implementa normalizacao do documento originario.
- Valida regra vigente.

### Pendencias

- pendencia: estudar NT 2024.002 e schema antes de implementar.

## MDF-P17 - PAA, NFF E CNPJ Alfa

### Objetivo

Preservar compatibilidade futura sem atrasar o primeiro recorte.

### Decisao Atual

- PAA/NFF/CNPJ Alfa ficam fora do P0.
- O modelo deve evitar validar CNPJ apenas por suposicao fixa que inviabilize
  CNPJ Alfa no futuro.
- PAA deve ficar isolado da carga normal de certificado.

### Pendencias

- pendencia: revisar NT 2022.002, NT 2020.002 e NT DFe CNPJ Alfanumerico antes
  de criar constantes definitivas.

## MDF-P18 - Bibliotecas C#

### Objetivo

Avaliar se vale usar biblioteca pronta para XML, assinatura, XSD, SOAP, DAMDFE
ou regras fiscais.

### Principio

Biblioteca e detalhe de implementacao, nao arquitetura do modulo.

### Catalogo Atual

Referencia:

- [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md)

Snapshots locais avaliados:

- DFe.NET / ZeusAutomacao em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\DFe.NET`.
- Unimake.DFe em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\Unimake.DFe`.

Situacao:

- DFe.NET declara suporte a MDF-e e possui camadas comuns uteis de SOAP,
  cabecalho, URN, envio HTTP e assinatura, mas o snapshot local ainda nao
  contem as pastas `MDFe.*`.
- Unimake.DFe declara suporte a MDF-e e possui camadas comuns uteis de builder
  de envelope, transporte, parser, normalizacao e testes de assinatura, mas o
  snapshot local ainda nao contem `Servicos\MDFe`.

Decisao provisoria:

- estudar as duas como referencia tecnica;
- baixar as pastas MDF-e completas antes de decidir biblioteca definitiva;
- manter o primeiro desenho do Yeshua com componentes pequenos e trocaveis:
  envelope, transporte, cliente SEFAZ, parser, assinatura, XSD, endpoint e
  DAMDFE.

### Criterios De Avaliacao

- Suporte MDF-e 3.00/3.00b.
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

- pendencia: ampliar o sparse-checkout do DFe.NET para incluir as pastas
  `MDFe.*`.
- pendencia: ampliar o sparse-checkout do Unimake.DFe para incluir servicos,
  configs, testes e exemplos MDF-e.
- pendencia: testar pelo menos status, assinatura/XSD e encerramento em
  ambiente controlado.

## MDF-P19 - Conectores Legados

### Objetivo

Permitir que clientes troquem apenas a URL quando ja integram com contrato
externo legado.

### Decisao Atual

- O conector fica dentro da API do aplicativo, organizado por mnemonico neutro.
- Nome real de fabricante nao deve aparecer.
- Exemplo de mnemonico: `FabricaSoftware01`.
- Conector SOAP deve entregar `.svc` e `.svc?wsdl` quando a compatibilidade
  exigir.
- Token deve vir no formato esperado pelo contrato externo.
- O payload bruto pode ser guardado antes de qualquer regra.
- O miolo decide se processa sincrono ou manda para `yInbox`.

### O Que A Engine Gera

- Casca da rota.
- Extracao de token.
- Encaminhamento para receiver customizado.
- Alias previsivel quando declarado.

### O Que O Aplicativo Faz

- Guarda WSDL e XSD real em `Custon/ExternalConnectors`.
- Normaliza payload para contrato interno.
- Implementa receiver que cria carga, pedido, documento originario ou
  solicitacao fiscal.

### Entrega

- Primeiro metodo SOAP entrando com contrato legado e salvando payload bruto.

### Pendencias

- pendencia: decidir se payload bruto fica em `yInbox` ou tabela especifica de
  integracao.
- pendencia: resolver token em `yToken` para obter tenant, cliente e permissoes.

## MDF-P20 - Observabilidade Fiscal

### Objetivo

Permitir suporte operacional real em MDF-e sem depender de adivinhacao.

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
- Tipo de evento.
- Sequencia.
- Protocolo original.
- Protocolo do evento.
- Versao de leiaute.
- Versao de schema.
- Hash do XML.
- Duracao por etapa.
- `cStat`.
- `xMotivo`.
- XML enviado.
- Retorno bruto.
- Erro tecnico separado de rejeicao fiscal.

### O Que A Engine Gera

- Bordas e entidades de tentativa se declaradas.
- Telemetria padrao de commands/repositories ja alinhada ao Yeshua.

### O Que O Aplicativo Faz

- Registra etapas fiscais especificas.
- Fornece dados suficientes para replay controlado.
- Expoe diagnostico para suporte.

### Entrega

- Consulta operacional por chave, tentativa, evento, status e protocolo.

### Pendencias

- pendencia: definir ate onde replay pode usar payload real sem violar
  seguranca/privacidade.
- pendencia: correlacionar logs de conector, emissao, evento e retorno SEFAZ.

## MDF-P21 - Modularizacao Interna

### Objetivo

Garantir que o modulo MDF-e seja vendavel, implantavel e manutenivel sem virar
um bloco unico.

### Modulos Externos Que O MDF-e Nao Deve Invadir

- Pedido.
- Carga.
- Planejamento de transporte.
- CT-e.
- NF-e.
- Estoque.
- Producao.
- Faturamento.
- Financeiro.

### Fronteiras Internas Do MDF-e

- Entrada e conectores.
- Normalizacao.
- Validacao operacional.
- Numeracao/chave.
- Documentos originarios.
- Modal rodoviario.
- CIOT/contrato/pagamento.
- XML oficial.
- Assinatura.
- XSD.
- Cliente SEFAZ.
- Retorno.
- Eventos.
- DAMDFE.
- Consulta/nao encerrados.
- Distribuicao.
- Observabilidade fiscal.

### O Que A Engine Gera

- Projeto/app Fiscal.MDFe independente.
- Bordas por use case/capacidade.
- Pastas `Migration` e `Custon`.
- Pontos de extensao protegidos.

### O Que O Aplicativo Faz

- Mantem miolos pequenos e substituiveis.
- Evita classe central de MDF-e.
- Mantem contratos internos estaveis.

### Entrega

- Primeiro app Fiscal.MDFe com P0 implementado sem depender de CT-e, NF-e ou
  APS como caminho quente.

### Pendencias

- pendencia: decidir se `Yeshua.Fiscal` sera apenas agregador comercial ou
  tambem projeto tecnico em algum ponto futuro.

## Regras De Corte

- Se o assunto e tag XML, schema, assinatura, cStat, DAMDFE ou regra oficial,
  pertence ao aplicativo Fiscal.MDFe.
- Se o assunto e borda repetivel de command, receiver, endpoint, repository,
  worker, smoke test ou ownership, pertence a Engine.
- Se o assunto e contrato generico de CQRS, logging, cache, unit of work ou
  telemetria nao fiscal, pertence ao Shared.
- Se o assunto e contrato de fabricante, arquivo legado, SOAP externo ou layout
  de terceiro, pertence a Conectores dentro do aplicativo.
- Se o assunto e pedido, estoque, producao, transporte, CT-e, NF-e ou
  faturamento, MDF-e recebe snapshot e nao assume propriedade.

## Sequencia De Conhecimento

1. Confirmar e versionar schemas.
2. Provar status/consulta/nao encerrados.
3. Provar assinatura e XSD local.
4. Migrar encerramento real do playground para o app.
5. Modelar persistencia operacional de evento/tentativa.
6. Implementar cancelamento e inclusao de condutor.
7. Implementar DAMDFE/QR Code basico.
8. Implementar emissao rodoviaria.
9. Implementar conector legado inicial.
10. Tratar CIOT, pagamento, distribuicao e InfraSA por demanda.
