# Ciclo De Producao APS -> CT-e -> MDF-e

Este documento define o ciclo de revisao para retirar mocagens e preparar o
fluxo fiscal para producao, partindo do APS ate MDF-e autorizado com sucesso.

O foco inicial e o aplicativo Fiscal unificado, usando a saga
`EmissaoFiscalCargaStandard`. Mudancas estruturais de DSL ficam fora deste ciclo
ate existir decisao arquitetural explicita.

## 1. Objetivo

Chegar em um fluxo operacional real:

1. APS consolida a carga.
2. APS publica `CargaProntaParaEmissaoFiscal.v1`.
3. Fiscal recebe a mensagem oficial em `yInbox`.
4. Fiscal normaliza documentos originarios e snapshots.
5. Fiscal monta solicitacoes de CT-e.
6. Fiscal prepara XML CT-e real.
7. Fiscal assina, valida e autoriza CT-e na SEFAZ.
8. Fiscal persiste XML, protocolo, chave, `cStat`, `xMotivo` e status.
9. Fiscal publica CT-e autorizado para MDF-e.
10. Fiscal monta solicitacao de MDF-e.
11. Fiscal prepara XML MDF-e real.
12. Fiscal assina, valida e autoriza MDF-e na SEFAZ.
13. Fiscal persiste XML, protocolo, chave, `cStat`, `xMotivo` e status.
14. Fiscal publica `DocumentosFiscaisDaCargaConcluidos.v1`.
15. APS recebe o retorno fiscal e libera a proxima etapa da carga.

## 2. Regra De Ouro

Nao existe producao enquanto o fluxo depender de:

- payload pequeno sem snapshot fiscal suficiente;
- chave de documento originario inventada;
- emitente fixo no fonte;
- certificado fixo no fonte;
- endpoint fixo no fonte;
- veiculo, condutor, RNTRC, seguro ou percurso fixo;
- ambiente fixo no persistence store;
- teste que inicia direto no Fiscal e ignora APS.

Mocks podem existir em testes isolados e playground, mas nao no caminho quente
da saga de producao.

## 3. Fluxo Declarado Hoje

### APS ADM

DSL em `Yeshua.Studio.APS.ADM`:

- saga `CargaStandard`;
- step `publicarCargaProntaParaEmissaoFiscal`;
- publica `CargaProntaParaEmissaoFiscal.v1`;
- entrega para o modulo `Fiscal` via Yeshua API.

### Fiscal

DSL em `Yeshua.Studio.Fiscal`:

- saga `EmissaoFiscalCargaStandard`;
- inicia por `CargaProntaParaEmissaoFiscal.v1`;
- steps atuais:
  - `receberCargaProntaParaEmissaoFiscal`;
  - `normalizarDocumentosOriginarios`;
  - `montarSolicitacoesCTe`;
  - `prepararCTe`;
  - `autorizarCTeNaSefaz`;
  - `publicarCTeAutorizadoParaMDFe`;
  - `montarSolicitacaoMDFe`;
  - `prepararMDFe`;
  - `autorizarMDFeNaSefaz`;
  - `publicarDocumentosFiscaisDaCargaConcluidos`.

Essa sequencia esta conceitualmente correta para o primeiro ciclo.

## 4. Mocks E Fixos Encontrados

### APS

Arquivo:
`src/CQRS/Application/Yeshua.APS.ADM.CQRS.Application.Command/Receivers/Custon/Saga/CargaStandard/preparacaoFiscal/publicarCargaProntaParaEmissaoFiscal/PublicarCargaProntaParaEmissaoFiscalHandler.cs`

Situacao atual:

- publica evento real de modulo Yeshua;
- porem o payload ainda contem basicamente `cargaId` e metadados;
- nao envia snapshot fiscal completo.

Acao:

- montar e enviar snapshot oficial da carga, documentos, rota, participantes,
  preferencias fiscais, veiculo, condutor e dados de manifesto.

### Fiscal - Entrada E Preparacao

Arquivos:

- `NormalizarDocumentosOriginariosHandler.cs`
- `MontarSolicitacoesCTeHandler.cs`
- `PrepararCTeHandler.cs`
- `PublicarCTeAutorizadoParaMDFeHandler.cs`
- `MontarSolicitacaoMDFeHandler.cs`
- `PrepararMDFeHandler.cs`

Situacao atual:

- registram eventos internos com `modo = "interno-prototipo"`;
- nao criam ainda a cadeia persistida real a partir do snapshot;
- nao alimentam plenamente as tabelas fiscais ja declaradas na DSL.

Acao:

- trocar eventos vazios por operacoes reais nos repositorios do Fiscal;
- persistir entrada oficial, romaneio, documentos originarios, solicitacoes,
  participantes, veiculo, condutor, percurso e tentativas.

### Fiscal - CT-e SEFAZ

Arquivo:
`src/CQRS/Application/Yeshua.Fiscal.CQRS.Application.Command/Receivers/Custon/Sefaz/CTe/CteRecepcaoSincV4HomologacaoClient.cs`

Situacao atual:

- cliente prova comunicacao CT-e 4.00 em homologacao;
- contem defaults/fixos de endpoint, emitente e certificado;
- monta XML de homologacao dentro do proprio client;
- usa documento originario mockado;
- usa dados de rota/participantes simplificados.

Acao:

- transformar em client parametrizado;
- separar montagem do XML em builder de CT-e;
- montar XML a partir de `CTeSolicitacaoFiscal`, `CTeDocumentoOriginario` e
  `CTeParticipanteSnapshot`;
- manter homologacao como ambiente configurado, nao como classe exclusiva.

### Fiscal - MDF-e SEFAZ

Arquivo:
`src/CQRS/Application/Yeshua.Fiscal.CQRS.Application.Command/Receivers/Custon/Sefaz/MDFe/MdfeRecepcaoSincHomologacaoClient.cs`

Situacao atual:

- cliente prova comunicacao MDF-e em homologacao;
- contem defaults/fixos de endpoint, emitente, CT-e, veiculo, condutor, seguro,
  RNTRC, placa e municipios;
- aceita chave de CT-e vinda do step anterior, mas ainda monta muito dado fixo.

Acao:

- transformar em client parametrizado;
- separar montagem do XML em builder de MDF-e;
- montar XML a partir de `MDFeSolicitacaoFiscal`, `MDFeDocumentoOriginario`,
  `MDFeVeiculo`, `MDFeCondutor`, `MDFePercurso` e CT-es autorizados.

### Fiscal - Persistencia De XML

Arquivo:
`src/CQRS/Application/Yeshua.Fiscal.CQRS.Application.Command/Receivers/Custon/Sefaz/SefazFiscalDocumentStore.cs`

Situacao atual:

- salva XML em storage;
- persiste campos minimos em `DocumentoFiscal`;
- ambiente ainda esta fixo como `2`;
- ainda nao garante idempotencia por chave/produto/tenant.

Acao:

- receber ambiente do request/resultado;
- persistir tambem tentativa especifica de CT-e/MDF-e;
- evitar duplicidade operacional antes de producao.

## 5. Dados Minimos Para Produzir CT-e

O snapshot que chega ao Fiscal precisa conter, no minimo:

- identificador da carga/romaneio;
- ambiente fiscal;
- emitente: CNPJ, IE, razao social, endereco, municipio IBGE, UF, CEP, CRT se
  aplicavel;
- tomador: documento, IE quando houver, endereco e regra de tomador;
- remetente, destinatario, expedidor e recebedor quando aplicavel;
- documentos originarios, preferencialmente NF-e homologada/real conforme
  ambiente;
- chave de acesso da NF-e ou dados equivalentes aceitos pelo CT-e;
- valor da carga;
- valor do frete;
- componentes do frete;
- peso, volumes e produto predominante;
- municipio/UF inicio e fim;
- serie e numero do CT-e ou regra de numeracao;
- tipo CT-e, tipo servico, modal, CFOP, CST/tributacao;
- preferencias fiscais vindas do cliente/transportador.

## 6. Dados Minimos Para Produzir MDF-e

O MDF-e precisa receber do fluxo:

- ambiente fiscal;
- emitente transportador;
- CT-es autorizados, com chave e protocolo;
- carga/romaneio;
- UF e municipio de carregamento;
- UF e municipio de descarregamento;
- percurso por UF quando houver;
- veiculo tracao: placa, RENAVAM, UF, tara/capacidade quando exigido;
- condutor: nome e CPF;
- RNTRC/ANTT;
- seguro: responsavel, seguradora, apolice e averbacao quando exigido;
- totalizadores: peso, valor da carga e quantidade de documentos;
- serie e numero do MDF-e ou regra de numeracao.

## 7. Entidades Ja Disponiveis No Fiscal

A DSL ja possui uma boa base:

- `DocumentoFiscal`;
- `DocumentoFiscalOriginario`;
- `CTeEntradaOficial`;
- `CTeRomaneioConsolidado`;
- `CTeSolicitacaoFiscal`;
- `CTeDocumentoOriginario`;
- `CTeParticipanteSnapshot`;
- `CTeTentativaEmissao`;
- `CTeSaidaMDFe`;
- `MDFeSolicitacaoFiscal`;
- `MDFeDocumentoOriginario`;
- `MDFePercurso`;
- `MDFeVeiculo`;
- `MDFeCondutor`;
- `MDFeTentativaEmissao`;
- `SefazEndpoint`;
- `CertificadoDigital`.

Antes de criar novas tabelas, usar essas entidades e so ampliar a DSL se faltar
campo essencial para a producao.

## 8. Ciclo De Implementacao

### Fase P0 - Congelar O Caminho Atual

Objetivo:

- confirmar que a saga Fiscal ainda roda com o prototipo atual;
- nao melhorar comportamento;
- apenas saber exatamente qual e a base antes da retirada de mocks.

Evidencia:

- API Fiscal sobe;
- Worker Fiscal sobe;
- teste custom da saga fiscal executa ate o ponto conhecido;
- `DocumentoFiscal` recebe XML quando SEFAZ responde com chave valida.

### Fase P1 - Entrada APS Real

Objetivo:

- transformar `CargaProntaParaEmissaoFiscal.v1` em contrato completo de negocio.

Entregas:

- APS monta snapshot fiscal suficiente;
- Fiscal recebe e guarda payload bruto em `CTeEntradaOficial`;
- hash e storage do payload sao gravados;
- nenhum dado de CT-e/MDF-e e inventado no Fiscal.

### Fase P2 - Normalizacao Fiscal Persistida

Objetivo:

- criar a primeira persistencia real do Fiscal a partir do snapshot APS.

Entregas:

- `DocumentoFiscalOriginario` preenchido;
- `CTeRomaneioConsolidado` preenchido;
- rejeitar payload incompleto com erro claro;
- registrar `cStat` apenas quando vier da SEFAZ, nao antes.

### Fase P3 - CT-e Real Em Homologacao

Objetivo:

- retirar o XML fixo do CT-e e autorizar a partir das entidades fiscais.

Entregas:

- builder CT-e usa `CTeSolicitacaoFiscal`;
- builder usa documentos originarios reais;
- client CT-e recebe endpoint/certificado/ambiente como parametros;
- `CTeTentativaEmissao` registra tentativa;
- `DocumentoFiscal` registra chave/protocolo/XML;
- `CTeSaidaMDFe` nasce somente se CT-e autorizado.

### Fase P4 - MDF-e Real Em Homologacao

Objetivo:

- retirar os fixos do MDF-e e autorizar a partir do CT-e autorizado.

Entregas:

- builder MDF-e usa `MDFeSolicitacaoFiscal`;
- builder usa `MDFeDocumentoOriginario`, `MDFeVeiculo`, `MDFeCondutor` e
  `MDFePercurso`;
- client MDF-e recebe endpoint/certificado/ambiente como parametros;
- `MDFeTentativaEmissao` registra tentativa;
- `DocumentoFiscal` registra chave/protocolo/XML;
- `DocumentosFiscaisDaCargaConcluidos.v1` nasce somente depois do MDF-e
  autorizado ou com retorno fiscal terminal definido.

### Fase P5 - Retorno APS Real

Objetivo:

- APS consumir o retorno fiscal sem depender de consulta manual.

Entregas:

- Fiscal publica retorno com CT-es e MDF-e;
- APS recebe inbox;
- APS atualiza status da carga;
- saga APS finaliza ou aguarda acao humana conforme resultado.

### Fase P6 - Preparacao De Producao

Objetivo:

- deixar o mesmo fluxo pronto para trocar homologacao por producao.

Entregas:

- certificados configurados por ambiente;
- endpoints em `SefazEndpoint`;
- storage persistente de XML;
- logs minimos por saga, documento e retorno SEFAZ;
- idempotencia por chave/documento;
- nenhuma classe de homologacao no caminho quente;
- smoke test ponta a ponta APS -> Fiscal -> APS;
- checklist manual antes de `tpAmb=1`.

## 9. Testes Do Ciclo

### Teste Fiscal Isolado

Uso:

- validar SEFAZ, XML e persistencia dentro do Fiscal.

Limite:

- nao prova APS -> Fiscal -> APS.

### Teste Ponta A Ponta

Uso:

- iniciar pela saga APS `CargaStandard`;
- deixar outbox transportar para Fiscal;
- deixar Fiscal emitir CT-e/MDF-e;
- deixar Fiscal publicar retorno;
- validar APS recebendo retorno.

Esse e o teste que prepara producao.

## 10. Pendencias De Producao

- Definir se a NF-e homologada vira entrada obrigatoria no primeiro teste real.
- Resolver numeracao fiscal CT-e/MDF-e por emitente, serie e ambiente.
- Carregar certificado por `CertificadoDigital`, nao por constante.
- Carregar endpoint por `SefazEndpoint`, nao por constante.
- Garantir armazenamento persistente de XML no deploy.
- Garantir que XML de autorizacao e `procCTe`/`procMDFe` fiquem rastreaveis.
- Tratar rejeicao fiscal como resultado de negocio, nao como falha tecnica pura.
- Tratar falha de transporte/timeout como retry operacional.
- Definir quando saga deve finalizar com rejeicao terminal.
- Remover eventos `interno-prototipo` dos steps de producao.

## 11. Proxima Rodada Recomendada

Comecar por P1 e P2.

Motivo:

- sem snapshot fiscal real do APS, CT-e e MDF-e continuam dependendo de dados
  inventados;
- ja existem entidades suficientes no Fiscal;
- a mudanca fica no miolo customizado de APS/Fiscal, sem DSL estrutural;
- depois disso a troca do client SEFAZ para dados reais fica objetiva.

