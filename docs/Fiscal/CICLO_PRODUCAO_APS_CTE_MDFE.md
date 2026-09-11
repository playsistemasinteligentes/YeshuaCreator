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
4. Fiscal aguarda o ERP/sistema externo informar os documentos originarios da
   carga.
5. Fiscal prepara a entrada fiscal com documentos, snapshots e romaneio.
6. Fiscal monta solicitacoes de CT-e.
7. Fiscal prepara XML CT-e real.
8. Fiscal assina, valida e autoriza CT-e na SEFAZ.
9. Fiscal persiste XML, protocolo, chave, `cStat`, `xMotivo` e status.
10. Fiscal publica CT-e autorizado para MDF-e.
11. Fiscal monta solicitacao de MDF-e.
12. Fiscal prepara XML MDF-e real.
13. Fiscal assina, valida e autoriza MDF-e na SEFAZ.
14. Fiscal persiste XML, protocolo, chave, `cStat`, `xMotivo` e status.
15. Fiscal publica `DocumentosFiscaisDaCargaConcluidos.v1`.
16. APS recebe o retorno fiscal e libera a proxima etapa da carga.

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
- steps atuais:
  - `AguardarDadosTransporte`;
  - `AguardarAgendamento`;
  - `AguardarInicioCarregamento`;
  - `AguardarFinalizacaoCarregamento`;
  - `PrepararCargaParaModuloFiscal`;
  - `PublicarCargaProntaParaEmissaoFiscal`;
  - `AguardarFinalizacaoFiscal`;
  - `LiberarCargaParaExpedicao`;
- o step `PublicarCargaProntaParaEmissaoFiscal` publica
  `CargaProntaParaEmissaoFiscal.v1`;
- entrega para o modulo `Fiscal` via Yeshua API;
- o step `AguardarFinalizacaoFiscal` espera
  `DocumentosFiscaisDaCargaConcluidos.v1` voltar do Fiscal.

### Fiscal

DSL em `Yeshua.Studio.Fiscal`:

- saga `EmissaoFiscalCargaStandard`;
- inicia por `CargaProntaParaEmissaoFiscal.v1`;
- steps atuais:
  - `ReceberCargaProntaParaEmissaoFiscal`;
  - `AguardarDocumentosOriginariosDaCarga`;
  - `PrepararEntradaFiscalDaCarga`;
  - `MontarSolicitacoesCTe`;
  - `PrepararCTe`;
  - `AutorizarCTeNaSefaz`;
  - `PublicarCTeAutorizadoParaMDFe`;
  - `MontarSolicitacaoMDFe`;
  - `PrepararMDFe`;
  - `AutorizarMDFeNaSefaz`;
  - `PublicarDocumentosFiscaisDaCargaConcluidos`.

Essa e a sequencia canonica do primeiro ciclo. O ponto de espera mais
importante do desenho e `AguardarDocumentosOriginariosDaCarga`: o Fiscal nao
deve tentar descobrir sozinho quais NF-es pertencem a carga; ele aguarda uma
ordem explicita do ERP/sistema externo informando os documentos originarios da
carga.

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

- `AguardarDocumentosOriginariosDaCargaHandler.cs`
- `PrepararEntradaFiscalDaCargaHandler.cs`
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

## 8. Plano De Implementacao Por Step

Este plano amarra cada step ao requisito final de producao. A regra e simples:
um step so deve avancar quando tiver deixado uma evidencia operacional
persistida ou uma espera clara para outro sistema/pessoa.

### 8.1 APS - `CargaStandard`

#### 1. `AguardarDadosTransporte`

Classificacao: `IntencaoWait`.

Responsabilidade:

- esperar ou validar que a carga possui dados minimos de transporte;
- nao resolver CT-e, MDF-e, NF-e nem regras SEFAZ;
- deixar claro o que falta quando a carga ainda nao pode seguir.

Entrada minima:

- carga/romaneio;
- transportadora quando aplicavel;
- veiculo ou tipo de veiculo quando ja definido;
- condutor quando o processo exigir;
- dados basicos de origem e destino.

Saida/evidencia:

- step aplicado somente quando os dados minimos existem;
- payload do step com resumo dos dados aceitos e lista de faltas quando houver.

Pendencia aceitavel no primeiro ciclo:

- se o cadastro ainda nao tiver todos os campos fiscais, usar fallback documentado
  e registrar o campo faltante no payload.

#### 2. `AguardarAgendamento`

Classificacao: `IntencaoWait`.

Responsabilidade:

- esperar agendamento operacional quando ele for parte do fluxo do cliente;
- nao misturar agendamento com emissao fiscal.

Entrada minima:

- identificador da carga;
- janela prevista ou confirmacao de que o fluxo nao exige agendamento.

Saida/evidencia:

- agendamento confirmado ou dispensado explicitamente;
- data/hora planejada registrada no payload do step.

#### 3. `AguardarInicioCarregamento`

Classificacao: `IntencaoWait`.

Responsabilidade:

- esperar o inicio operacional do carregamento;
- marcar que a carga saiu do estado apenas planejado.

Entrada minima:

- carga apta;
- operador/sistema que confirmou o inicio;
- data/hora do inicio.

Saida/evidencia:

- inicio de carregamento registrado;
- step aplicado sem gerar ainda evento fiscal.

#### 4. `AguardarFinalizacaoCarregamento`

Classificacao: `IntencaoWait`.

Responsabilidade:

- esperar fechamento real do romaneio;
- consolidar o que efetivamente entrou no veiculo.

Entrada minima:

- carga iniciada;
- itens/pedidos efetivamente carregados;
- peso, volumes e divergencias quando existirem.

Saida/evidencia:

- romaneio fechado;
- snapshot operacional pronto para virar entrada fiscal.

#### 5. `PrepararCargaParaModuloFiscal`

Classificacao: `Intencao`.

Responsabilidade:

- montar o snapshot fiscal oficial do APS;
- separar informacao operacional da carga de informacao fiscal que pertence ao
  Fiscal;
- impedir que o Fiscal precise consultar tabelas internas do APS.

Entrada minima:

- carga/romaneio fechado;
- pedidos/itens carregados;
- origem, destinos e rota conhecida no nivel disponivel;
- transporte disponivel: transportadora, veiculo, condutor, RNTRC/ANTT quando
  houver;
- valores, pesos e volumes consolidados;
- preferencias fiscais conhecidas no APS.

Saida/evidencia:

- contrato `CargaProntaParaEmissaoFiscal.v1` preenchido;
- payload com pendencias explicitas quando algo essencial faltar.

Regra de producao:

- nao inventar NF-e;
- nao inventar CT-e;
- nao inventar MDF-e;
- nao consultar SEFAZ.

#### 6. `PublicarCargaProntaParaEmissaoFiscal`

Classificacao: `Intencao`.

Responsabilidade:

- publicar a carga no `yOutbox` para o modulo Fiscal;
- usar transporte `YeshuaApi`;
- nao chamar o Fiscal diretamente dentro do miolo do step.

Entrada minima:

- snapshot fiscal aceito pelo step anterior;
- destino `Fiscal`;
- endpoint `/yapi/Fiscal/Inbox/YeshuaModuleEvent`;
- `sagaCorrelationId` da carga APS.

Saida/evidencia:

- `yOutbox` criado com `CargaProntaParaEmissaoFiscal.v1`;
- `yInbox` local registrando que a publicacao foi enfileirada.

Pendencia tecnica atual:

- garantir que a publicacao do outbox fique no mesmo ciclo transacional da
  mudanca de estado do step quando a Engine evoluir esse padrao.

#### 7. `AguardarFinalizacaoFiscal`

Classificacao: `IntencaoWait`.

Responsabilidade:

- esperar o retorno do modulo Fiscal;
- aplicar `DocumentosFiscaisDaCargaConcluidos.v1`;
- nao consultar banco do Fiscal diretamente.

Entrada minima:

- `sagaCorrelationId` original do APS preservado;
- evento de retorno fiscal recebido no inbox do APS;
- resumo fiscal terminal.

Saida/evidencia:

- step acordado por bridge explicita de inbox para saga;
- payload com CT-es, MDF-e, chaves, protocolos, `cStat`, `xMotivo` e status
  terminal.

Pendencia imediata encontrada:

- o bridge do APS deve apontar para `AguardarFinalizacaoFiscal`, nao para
  `PrepararCargaParaModuloFiscal`.

#### 8. `LiberarCargaParaExpedicao`

Classificacao: `Intencao`.

Responsabilidade:

- liberar a carga somente apos retorno fiscal terminal;
- no primeiro ciclo, sucesso significa CT-e e MDF-e autorizados em homologacao.

Entrada minima:

- step `AguardarFinalizacaoFiscal` aplicado;
- retorno fiscal sem erro tecnico pendente;
- documentos autorizados ou resultado terminal tratado.

Saida/evidencia:

- status da carga atualizado;
- saga APS concluida;
- payload final com resumo fiscal.

### 8.2 Fiscal - `EmissaoFiscalCargaStandard`

#### 1. `ReceberCargaProntaParaEmissaoFiscal`

Classificacao: `Intencao`.

Responsabilidade:

- receber o contrato vindo do APS;
- persistir entrada bruta e metadados;
- iniciar o ciclo fiscal sem depender de tabela do APS.

Entrada minima:

- `CargaProntaParaEmissaoFiscal.v1`;
- `sagaCorrelationId` de origem;
- carga/romaneio e snapshot operacional.

Saida/evidencia:

- `CTeEntradaOficial` gravada;
- payload bruto rastreavel por hash/storage quando disponivel;
- saga Fiscal iniciada ou acordada.

#### 2. `AguardarDocumentosOriginariosDaCarga`

Classificacao: `IntencaoWait`.

Responsabilidade:

- esperar o ERP/sistema externo informar quais NF-es/documentos pertencem a
  carga;
- nao correlacionar notas automaticamente como regra padrao.

Entrada minima para aplicar:

- comando externo `InformarDocumentosOriginariosDaCarga`;
- cargaId;
- lista de documentos originarios;
- chave de acesso ou XML/storage de cada documento.

Saida/evidencia:

- documentos recebidos e pre-validados;
- step acordado por inbox especifico.

Pendencia para producao:

- trocar NF-e inventada por NF-e homologada real ou documento valido para o
  recorte fiscal escolhido.

#### 3. `PrepararEntradaFiscalDaCarga`

Classificacao: `Intencao`.

Responsabilidade:

- normalizar a entrada fiscal;
- persistir a primeira cadeia de dados que CT-e e MDF-e vao consumir.

Entrada minima:

- snapshot APS;
- documentos originarios informados;
- dados de transporte e rota.

Saida/evidencia:

- `DocumentoFiscalOriginario` preenchido;
- `CTeRomaneioConsolidado` preenchido;
- snapshots fiscais de participantes, rota e transporte preenchidos quando
  disponiveis;
- rejeicao clara quando faltar campo essencial.

#### 4. `MontarSolicitacoesCTe`

Classificacao: `Intencao`.

Responsabilidade:

- decidir quantos CT-es serao emitidos para a carga;
- aplicar regra de tomador, tipo de servico, frete, valores e rateios.

Entrada minima:

- entrada fiscal normalizada;
- documentos originarios;
- participantes;
- valor de frete, valor de carga, peso e volumes.

Saida/evidencia:

- uma ou mais `CTeSolicitacaoFiscal`;
- `CTeDocumentoOriginario`;
- `CTeParticipanteSnapshot`;
- regra de divisao registrada no payload.

Pendencia para producao:

- fechar regras reais de rateio, tomador, CFOP e tributacao por cliente/cenario.

#### 5. `PrepararCTe`

Classificacao: `Intencao`.

Responsabilidade:

- montar XML CT-e 4.00 a partir das entidades fiscais;
- escolher endpoint, certificado, serie e numero;
- validar XSD antes de enviar.

Entrada minima:

- `CTeSolicitacaoFiscal`;
- documentos originarios;
- participantes;
- certificado e endpoint de homologacao/producao;
- regra de numeracao.

Saida/evidencia:

- XML CT-e assinado;
- tentativa criada em `CTeTentativaEmissao`;
- erro estrutural tratado antes de chamar SEFAZ.

Pendencia para producao:

- remover XML montado com defaults/fixos do client de homologacao.

#### 6. `AutorizarCTeNaSefaz`

Classificacao: `Intencao`.

Responsabilidade:

- chamar `CTeRecepcaoSincV4`;
- persistir retorno tecnico/fiscal;
- tratar rejeicao fiscal como resultado de negocio.

Entrada minima:

- XML CT-e assinado e validado;
- certificado;
- endpoint correto por UF/ambiente.

Saida/evidencia:

- `DocumentoFiscal` com chave, protocolo, XML, `cStat`, `xMotivo`;
- `CTeTentativaEmissao` atualizada;
- payload do step com resumo SEFAZ.

#### 7. `PublicarCTeAutorizadoParaMDFe`

Classificacao: `Intencao`.

Responsabilidade:

- transformar CT-e autorizado em entrada para MDF-e;
- nao publicar CT-e rejeitado como documento apto.

Entrada minima:

- CT-e com `cStat=100`;
- chave e protocolo;
- totais da carga.

Saida/evidencia:

- `CTeSaidaMDFe` preenchida;
- evento interno ou inbox local para montagem do MDF-e.

#### 8. `MontarSolicitacaoMDFe`

Classificacao: `Intencao`.

Responsabilidade:

- agrupar CT-es autorizados em uma ou mais solicitacoes MDF-e;
- aplicar regras de UF, percurso, veiculo, condutor, RNTRC e seguro.

Entrada minima:

- CT-es autorizados;
- carga/romaneio;
- veiculo;
- condutor;
- percurso;
- totalizadores.

Saida/evidencia:

- `MDFeSolicitacaoFiscal`;
- `MDFeDocumentoOriginario`;
- `MDFeVeiculo`;
- `MDFeCondutor`;
- `MDFePercurso`.

Pendencia para producao:

- definir quando uma mesma carga gera mais de um MDF-e.

#### 9. `PrepararMDFe`

Classificacao: `Intencao`.

Responsabilidade:

- montar XML MDF-e a partir das entidades fiscais;
- assinar e validar schema antes de enviar.

Entrada minima:

- `MDFeSolicitacaoFiscal`;
- CT-es autorizados;
- veiculo, condutor, percurso, RNTRC/ANTT, seguro e totalizadores;
- certificado, endpoint, serie e numero.

Saida/evidencia:

- XML MDF-e assinado;
- tentativa criada em `MDFeTentativaEmissao`;
- erro estrutural tratado antes de chamar SEFAZ.

Pendencia para producao:

- remover veiculo, condutor, RNTRC, seguro e municipios fixos do client atual.

#### 10. `AutorizarMDFeNaSefaz`

Classificacao: `Intencao`.

Responsabilidade:

- chamar `MDFeRecepcaoSinc`;
- persistir retorno tecnico/fiscal;
- tratar rejeicao fiscal como resultado terminal ou recuperavel.

Entrada minima:

- XML MDF-e assinado e validado;
- certificado;
- endpoint correto por ambiente.

Saida/evidencia:

- `DocumentoFiscal` com chave, protocolo, XML, `cStat`, `xMotivo`;
- `MDFeTentativaEmissao` atualizada;
- payload do step com resumo SEFAZ.

#### 11. `PublicarDocumentosFiscaisDaCargaConcluidos`

Classificacao: `Intencao`.

Responsabilidade:

- publicar retorno para o APS;
- encerrar o ciclo fiscal somente com resultado terminal claro.

Entrada minima:

- CT-e autorizado ou rejeicao fiscal terminal definida;
- MDF-e autorizado ou rejeicao fiscal terminal definida;
- `sagaCorrelationId` de origem APS preservado.

Saida/evidencia:

- `yOutbox` com `DocumentosFiscaisDaCargaConcluidos.v1`;
- payload contendo chaves, protocolos, `cStat`, `xMotivo`, status e referencias
  de XML/storage;
- saga Fiscal concluida.

## 9. Ciclo De Implementacao

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

## 10. Testes Do Ciclo

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

## 11. Pendencias De Producao

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

## 12. Proxima Rodada Recomendada

Comecar por P1 e P2.

Motivo:

- sem snapshot fiscal real do APS, CT-e e MDF-e continuam dependendo de dados
  inventados;
- ja existem entidades suficientes no Fiscal;
- a mudanca fica no miolo customizado de APS/Fiscal, sem DSL estrutural;
- depois disso a troca do client SEFAZ para dados reais fica objetiva.
