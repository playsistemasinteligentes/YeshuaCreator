# Mapeamento - Planejamento De Transporte APS

Este documento registra o primeiro mapa funcional da frente de transporte do APS
legado para orientar a reengenharia incremental no Yeshua.

## Recorte

O foco inicial nao e otimizar transporte completo. O foco e subir uma bancada
operacional para montagem e ajuste manual assistido de cargas.

O objetivo da primeira fatia e permitir que o operador:

- visualize uma carga principal;
- veja os itens planejados da carga;
- pesquise pedidos futuros;
- mova pedido entre cargas;
- altere quantidade planejada;
- crie carga operacional a partir da tela;
- veja ocupacao, volume, peso, datas e alertas principais;
- preserve decisoes manuais para que o otimizador trabalhe em volta delas.

## Fontes Legadas Observadas

- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/Areas/PlugAndPlay/Models/Transporte/Transporte.cs`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/Areas/PlugAndPlay/Models/Transporte/V_ITEM_CARGA.cs`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/Areas/PlugAndPlay/Controllers/APSController.cs`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/Areas/PlugAndPlay/Views/APS/OtimizarCarga.cshtml`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/wwwroot/Functions/Script/OtimizadorCarga/OtimizadorCarga.js`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/wwwroot/Functions/Script/modal-unir-cargas.js`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/wwwroot/Functions/Script/modal-alterar-dados-carga.js`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/wwwroot/Functions/Script/AvaliarCarga/AvaliarCarga.js`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/Areas/PlugAndPlay/Controllers/PainelGestaoTransporteController.cs`
- `C:/Users/AngeloRicardoFontana/Source/Workspaces/APS Net 7/DynamicForms/Areas/PlugAndPlay/Views/PainelGestaoTransporte/Index.cshtml`

## DSL Atual Relacionada

Ja existem no Studio APS ADM:

- `Carga`, origem legada `T_CARGA`.
- `CargaPrevista`, origem legada `T_CARGA_PREVISTA`.
- `ItenCarga`, origem legada `T_ITENS_CARGA`.
- `UsuariosCarga`, origem legada `T_USUARIOS_DA_CARGA`.
- `ConsultaPedido`, `FromView("V_CONSULTA_PEDIDO")`.
- `RoteiroPedido`, `FromView("V_ROTEIRO_PEDIDO")`.
- conector externo com operacoes de `Cargas.AdicionarCarga` e
  `Cargas.AdicionarPedido`.

Observacao importante: `ItenCarga.CAR_ID` ainda esta declarado como campo simples.
Para a aba de relacionamento natural da carga, ele deve virar FK logica para
`Carga.CAR_ID` com `RelationTab` na declaracao da coluna. Isso nao muda a
estrategia de banco agora; e metadata de tela/relacao no Yeshua.

## Entidades E Views Do Transporte

### Carga

No legado, `Carga` concentra dados de planejamento, agendamento, pesagem,
status, veiculo, transportadora, doca, romaneio e justificativas.

Principais campos operacionais:

- `CAR_ID`
- `CAR_STATUS`
- `CAR_EMBARQUE_ALVO`
- `CAR_DATA_INICIO_PREVISTO`
- `CAR_DATA_FIM_PREVISTO`
- `CAR_INICIO_JANELA_EMBARQUE`
- `CAR_FIM_JANELA_EMBARQUE`
- `TIP_ID`
- `VEI_PLACA`
- `TRA_ID`
- `CAR_ID_DOCA`
- `CAR_VOLUME_TEORICO`
- `CAR_PESO_TEORICO`
- `CAR_PESO_REAL`
- `CAR_VOLUME_REAL`
- `CAR_PESAGEM_LIBERADA`
- `OCO_ID_LIBERACAO` / `OCO_ID_LIERACAO`
- `CAR_OBS_LIBERACAO` / `CAR_OBS_LIERACAO`
- `CAR_JUSTIFICATIVA_DE_CARREGAMENTO`
- `CAR_ID_JUNTADA`
- `CAR_DATA_ROMANEIO_CONSOLIDADO`

Regras locais ja transcritas em `CargaBusinessRules`:

- status obrigatorio quando nao for remocao;
- tipo de veiculo obrigatorio quando status da carga e maior que 1;
- liberar pesagem quando ocorrencia e observacao de liberacao estao preenchidas.

Fluxos ainda nao transcritos para miolo Yeshua:

- validacao de transicao de status considerando itens romaneados/consolidados;
- geracao de `CAR_ID` por tipo de carga;
- consolidacao de romaneio;
- desconsolidacao de romaneio;
- importacao/validacao de peso da balanca;
- baixa de estoque por carga consolidada;
- uniao de cargas;
- atualizacao de ordem de entrega por cliente;
- mapa de pontos de entrega;
- relatorios de plano de carga e carga consolidada.

### ItenCarga

Representa o pedido dentro da carga.

Principais campos:

- `CAR_ID`
- `ORD_ID`
- `ITC_ENTREGA_PLANEJADA`
- `ITC_ENTREGA_REALIZADA`
- `ITC_ORDEM_ENTREGA`
- `ITC_QTD_PLANEJADA`
- `ITC_QTD_REALIZADA`
- `ORD_HASH_KEY`
- `NOT_ID`
- `NOT_EMISSAO`

Regras legadas relevantes:

- quantidade planejada deve ser maior que zero;
- item romaneado nao pode ser alterado livremente;
- item romaneado nao pode ser excluido antes de desfazer romaneio;
- alteracao somente de `ITC_ENTREGA_REALIZADA` era permitida como retorno de
  canhoto;
- no romaneio simplificado, atualizar quantidade realizada disparava geracao de
  etiqueta, apontamento de producao e romaneio.

Classificacao:

- validacao simples de quantidade cabe no behavior custom de `ItenCarga`;
- bloqueio por item romaneado precisa de fatos carregados pelo Receiver;
- romaneio simplificado nao deve ficar no CRUD comum: deve virar command
  operacional especifico.

### V_ITEM_CARGA

No legado e uma view usada como interface de edicao. O `BeforeChanges` converte
`V_ITEM_CARGA` para `ItenCarga` antes de persistir.

No Yeshua, a direcao correta e:

- manter a visao de leitura como `FromView`;
- nao gravar CRUD direto na view;
- criar action/use case de tela para mutar `ItenCarga`.

Nome candidato de intencao:

- `PlanejamentoTransporte.AlterarItemDaCarga`

### CargasWeb

E uma view/DTO operacional para a tela `OtimizarCarga`, consolidando carga,
pedido, produto, cliente, rota, dimensoes, estoque, datas, frete, prioridade,
ocupacao e dados de veiculo.

Ela e leitura rica de tela, nao entidade de dominio mutavel.

Nome candidato no Yeshua:

- `CargaPlanejamentoConsulta`, usando `FromView("CargaPlanejamentoConsulta")`.

Observacao: o nome legado `V_CARGASWEB_ESTOQUE` pode ficar em `LegacySource` ou
na implementacao customizada do repositorio durante a transicao, mas a DSL nao
deve obrigar que exista uma view fisica no banco.

### PedidosParaExpedicao

No legado e objeto de algoritmo/tela. Agrupa pedidos que devem viajar juntos e
carrega localizacao, janela de embarque, entrega e rotas factiveis.

No Yeshua, tende a ser DTO de query ou modelo interno do miolo de planejamento,
nao entidade CRUD.

### Veiculo, TipoVeiculo E Disponibilidade

Entidades de suporte para capacidade, tipo de carroceria, disponibilidade,
restricoes e visualizacao/validacao de ocupacao.

Fluxos candidatos:

- selecionar tipo de veiculo para uma ou varias cargas;
- consultar disponibilidade por data/tipo;
- avaliar ocupacao 3D/packing de uma carga.

### Painel De Gestao Em Transito

O legado possui outra frente, diferente da montagem de carga:

- `PainelGestaoTransporteController`;
- view `PainelGestaoTransporte/Index.cshtml`;
- mapa Leaflet;
- cargas em transito;
- canhotos;
- rota realizada.

Esta frente deve ficar para segunda fatia. Ela e monitoramento/execucao de
transporte, nao montagem manual de carga.

## Acoes Legadas Encontradas

### Alterar item individual da carga

Fonte: `APSController.AlterarItensCargaIndividual`.

Comportamento:

- recebe carga antiga, pedido, nova carga e nova quantidade;
- se a nova carga nao existe, retorna erro;
- se o item nao existe, cria `ItenCarga`;
- se continua na mesma carga, atualiza quantidade;
- se muda de carga, exclui item antigo e cria copia na nova carga.

Yeshua:

- command de use case/action de entidade/tela;
- Receiver carrega carga e item atual;
- dominio valida quantidade e bloqueio de romaneio;
- Receiver persiste insert/update/delete em `ItenCarga`.

### Salvar composicao total da carga

Fonte: `APSController.SalvarItensCargaTotal`.

Comportamento:

- recebe lista inteira da tela;
- trata pedidos repetidos;
- atualiza tipo de veiculo da carga principal;
- exclui pedidos ocultos;
- insere/atualiza itens;
- quando item sai de outra carga, apaga antigo e cria novo na principal.

Yeshua:

- command operacional de tela;
- nao deve ser CRUD de `Carga` nem CRUD de `ItenCarga` isoladamente, pois a
  intencao e uma composicao de planejamento.

Nome candidato:

- `PlanejamentoTransporte.SalvarComposicaoCarga`

### Buscar pedidos futuros

Fonte: `APSController.obterPedidosFuturosAPS`.

Comportamento:

- consulta `V_PEDIDOS_A_PLANEJAR_EXPEDICAO`;
- filtra por data de embarque, estoque, tipo de produto, frete, prioridade,
  carga, pedido, UF, municipio/regiao, cliente e raio geografico;
- ordena por UF, municipio, cliente e embarque.

Yeshua:

- query/read command gerado ou customizado;
- sem mutacao;
- primeira necessidade clara de consulta rica para tela.

Nome candidato:

- `PlanejamentoTransporte.BuscarPedidosDisponiveis`

### Buscar/transferir pedido

Fonte: `APSController.BuscarTransferirPedido`.

Comportamento:

- procura pedido na carga;
- se nao achar, procura por pedido em qualquer carga;
- se nao achar, carrega `Order` com produto, municipio e cliente.

Yeshua:

- query auxiliar de tela;
- pode alimentar um painel lateral de transferencia.

### Unir cargas

Fonte: `APSController.UnirCargas` e `Carga.UnirCargas`.

Comportamento:

- cria nova carga;
- escolhe dados-base pela carga selecionada;
- move itens das cargas antigas;
- opcionalmente une apenas itens de certas cidades;
- marca cargas antigas como estudo/status 1;
- usa `CAR_ID_JUNTADA`;
- retorna o ID da nova carga.

Yeshua:

- use case operacional, nao CRUD;
- Receiver carrega cargas/itens, calcula nova carga e persiste conjunto;
- dominio valida se as cargas sao univeis;
- eventos podem registrar `CargasUnidas`.

### Alterar tipo de veiculo em lote

Fonte: `APSController.AtualizarTiposVeiculos`.

Comportamento:

- recebe `tipId` e lista de cargas;
- atualiza `TIP_ID` de todas.

Yeshua:

- action de tela simples;
- pode virar `PlanejamentoTransporte.AlterarTipoVeiculoDasCargas`.

### Gravar cargas simuladas

Fonte: `APSController.gravarCargasSimuladas`.

Comportamento:

- recebe resultado simulado do otimizador;
- cria cargas e itens;
- depois remove itens antigos de estudo/principal.

Yeshua:

- use case de aceite de simulacao;
- deve registrar origem da decisao: manual, sugestao do otimizador ou simulacao
  aprovada.

### Avaliar carga / visualizacao 3D

Fonte: `APSController.setAvaliarCargaTotal` e `AvaliarCarga.js`.

Comportamento:

- carrega pedidos da carga;
- carrega tipo de veiculo disponivel;
- chama packing;
- retorna itens embarcados, nao embarcados e percentual ocupado;
- bloqueia visualizacao para carga consolidada.

Yeshua:

- query/use case de avaliacao;
- sem persistencia obrigatoria;
- pode virar servico customizado de avaliacao de ocupacao.

### Consolidar romaneio

Fonte: `Carga.ConsolidarRomaneio`.

Comportamento:

- valida existencia da carga;
- exige transportadora e placa;
- valida itens romaneados;
- integra peso de balanca conforme parametro;
- valida conjuntos/kits;
- exige justificativa quando quantidade romaneada fica abaixo da tolerancia;
- gera movimentos de venda/saida de estoque;
- atualiza status para consolidada.

Yeshua:

- command operacional proprio;
- nao deve ser comportamento escondido de update de `Carga`;
- precisa fatos de romaneio, saldos, parametros, balanca e usuario carregados
  pelo Receiver.

### Desconsolidar romaneio

Fonte: `Carga.DesconsolidarRomaneio`.

Comportamento:

- encontra movimentos de venda da carga;
- marca movimentos como estornados;
- volta status da carga para carregando;
- evita reabrir pedido/fila automaticamente.

Yeshua:

- command operacional proprio;
- evento de estorno pode ser usado para auditoria e operacao.

## Primeira Fatia Recomendada

Nome:

- `PlanejamentoTransporte.MontarCargaManual`

Escopo funcional pequeno:

- abrir uma carga;
- listar itens planejados;
- listar pedidos disponiveis/futuros;
- alterar quantidade planejada de um item;
- mover item para outra carga existente;
- criar uma carga nova pela tela quando operador informar `NOVO`;
- salvar composicao atual;
- calcular resumo simples: peso, volume, ocupacao e quantidade de pedidos.

Fora da primeira fatia:

- consolidar/desconsolidar romaneio;
- balanca;
- canhoto;
- mapa em transito;
- relatorios PDF;
- packing 3D completo;
- otimizador de transporte;
- disponibilidade detalhada por calendario de veiculo.

## Diretriz De Experiencia

A tela nova nao deve reconstruir literalmente a tela antiga. O legado fica como
referencia funcional para nao perder capacidades, mas o fluxo deve ser
redesenhado com a menor quantidade possivel de cliques.

Principio:

- a tela e uma bancada de decisao de expedicao;
- o operador nao deve abrir varios cadastros para montar uma carga;
- a carga deve aceitar alteracoes rapidas no proprio contexto da bancada;
- o sistema deve calcular impacto sem exigir salvamentos intermediarios;
- decisoes manuais devem poder ser fixadas;
- o otimizador deve respeitar decisoes fixadas e trabalhar no restante.

Layout funcional candidato:

- faixa superior com periodo de embarque, filtros rapidos, modo do otimizador e
  status de processamento;
- area principal com cargas em montagem;
- lateral de pedidos candidatos/disponiveis;
- lateral ou rodape de impacto: peso, volume, ocupacao, atraso, estoque,
  qualidade, financeiro e alertas;
- mapa alternavel ou combinado com a grade, mostrando pedidos/cargas por ponto
  geografico, regiao e rota;
- comandos rapidos para criar carga, mover pedido, dividir quantidade, fixar
  pedido, desfazer, salvar composicao e pedir sugestao.

Interacoes desejadas:

- mover pedido para carga com arrastar ou um comando direto;
- criar carga digitando `NOVO` ou acionando botao de criacao rapida;
- alterar quantidade planejada sem abrir formulario completo;
- selecionar varios pedidos e aplicar uma unica acao;
- fixar uma carga, pedido ou ordem de entrega contra mudanca do otimizador;
- comparar plano atual com plano sugerido antes de gravar;
- salvar uma composicao inteira em uma intencao unica.

## Ponto De Partida Operacional

O planejador de transporte tende a pensar primeiro por grupo de trabalho, nao
por pedido isolado. O ponto de partida da tela deve responder rapidamente:

- o que existe para cada roteiro/regiao;
- o que existe por UF e municipio;
- quais municipios concentram volume suficiente para uma carga;
- quais grupos possuem alerta financeiro, qualidade, estoque, atraso ou
  restricao operacional;
- quais cargas ja existem para aquele roteiro;
- o que deve ficar fixado para que o otimizador trabalhe somente no restante.

Isso aproxima a tela do relatorio operacional legado organizado por estado e
municipio, mas sem copiar a forma antiga. A nova bancada deve transformar esse
relatorio em uma fila interativa: selecionar roteiro, resolver municipios,
montar ou ajustar cargas, fixar decisoes e pedir sugestoes do otimizador.

Consulta inicial candidata:

- `PlanejamentoTransporte.BuscarRoteirosEnvelope`

Campos minimos do envelope:

- roteiro/regiao;
- UF;
- municipios;
- quantidade de pedidos;
- peso e volume resumidos;
- janela de embarque;
- latitude/longitude ou agrupador geografico;
- quantidade compacta de alertas;
- cargas em montagem relacionadas.

Pedido detalhado, produto, dimensoes, saldo, restricoes especificas e historico
devem continuar sob demanda.

## Agrupamentos Inteligentes

O agrupamento basico deve nascer simples e legivel para a operacao:

- estado;
- regiao;
- municipio;
- bairro, quando o municipio for grande ou operacionalmente relevante.

Esses agrupamentos nao devem ser tratados como caixas rigidas. O planejador
precisa enxergar conexoes viaveis entre grupos, especialmente quando uma carga
interestadual ou multi-regiao for melhor que uma carga isolada por UF.

Fontes candidatas para criar ligacoes entre grupos:

- historico de cargas realmente praticadas;
- rotas previamente aprovadas;
- distancia, tempo e janela de embarque;
- compatibilidade de cliente, restricao financeira, qualidade e estoque;
- sugestao do otimizador.

Na tela, o operador deve conseguir atacar um grupo ou uma ligacao com uma acao
direta. Exemplo: clicar em `SP Capital`, `Vale do Paraiba` ou na ligacao entre
os dois e criar uma composicao inicial sem abrir varios cadastros.

Consultas candidatas:

- `PlanejamentoTransporte.BuscarGruposDeEmbarque`
- `PlanejamentoTransporte.BuscarLigacoesViaveisEntreGrupos`
- `PlanejamentoTransporte.BuscarPedidosDoGrupo`
- `PlanejamentoTransporte.BuscarPedidosDaLigacao`

Essas consultas continuam sendo projections/read models resolvidas pelo
repositorio do aplicativo. Elas devem carregar envelopes pequenos e permitir
drill-down sob demanda.

## Niveis De Autonomia Do Otimizador

O otimizador deve trabalhar como copiloto ou como piloto completo, conforme a
necessidade operacional.

Modos candidatos:

- `Manual`: operador decide tudo; sistema so valida e calcula impacto.
- `Checagem`: operador monta; otimizador aponta problemas e oportunidades.
- `Sugestao`: otimizador sugere pedidos, veiculo, uniao ou divisao de cargas,
  mas nao muda nada sem aceite.
- `Parcial`: operador fixa parte do plano; otimizador reorganiza somente o que
  nao esta fixado.
- `Automatico`: otimizador pode assumir 100% da montagem dentro das restricoes
  informadas.

Esses modos nao precisam virar DSL pesada neste momento. Para o primeiro
recorte, podem nascer como parametros do command de planejamento e como
comportamento customizado do APS.

## Otimizador Como Gerador De Cenarios

Absorver todas as regras humanas, comerciais e operacionais dentro do
otimizador tende a ser inviavel. O caminho preferencial para transporte e usar
o otimizador como gerador de cenarios, nao como unico dono da decisao.

Direcao:

- a tela organiza o trabalho por grupos, ligacoes, cargas e alertas;
- o otimizador gera duas, tres ou quatro alternativas de composicao;
- cada alternativa mostra impacto operacional de forma comparavel;
- o operador aceita, mistura, fixa ou descarta partes do cenario;
- as decisoes manuais viram restricoes/fatos para a proxima rodada;
- o otimizador melhora com historico praticado, mas sem exigir que todas as
  excecoes virem regra dura.

Comparacoes minimas por cenario:

- quantidade de cargas;
- ocupacao por volume e peso;
- atraso ou antecipacao;
- distancia/rota estimada;
- restricoes financeiras, qualidade, estoque e cliente;
- pedidos deixados de fora;
- diferenca contra o plano atual.

Isso cria um ciclo homem-maquina mais realista: o sistema reduz o espaco de
decisao, aponta oportunidades e prepara composicoes, mas a operacao continua
conseguindo lidar com excecoes que nao valem virar regra permanente.

## Espaco De Opcoes E Propagacao De Decisoes

O otimizador pode trabalhar internamente como um gerador de muitas opcoes
candidatas de carga. A tela e o agente nao precisam expor todas as combinacoes;
eles devem mostrar poucas decisoes promissoras e deixar a propagacao de
conflitos acontecer no motor de planejamento.

Modelo conceitual:

- `OpcaoMontagemCarga`: uma carga candidata com conjunto de pedidos, veiculo,
  ocupacao, rota, risco, atraso e score por objetivo.
- `ConflitoOpcao`: indica que duas opcoes disputam o mesmo pedido, veiculo,
  janela, doca ou restricao operacional.
- `DecisaoPlanejamento`: aceite, descarte, fixacao ou restricao manual aplicada
  por humano ou agente.
- `CenarioMontagemCarga`: conjunto compativel de opcoes aceitas ou candidatas.

Quando uma opcao e aceita, pedidos ja consumidos eliminam opcoes concorrentes.
Quando uma opcao e descartada, o otimizador pode gerar variacoes para os pedidos
restantes. Isso se aproxima de problemas conhecidos como set packing, set
covering, branch and bound e otimizacao multiobjetivo, mas a tela deve esconder
a complexidade matematica.

Regras de produto:

- operador humano ve poucas alternativas de alto valor;
- agente pode avaliar mais alternativas sem depender de tela;
- otimizador pode gerar dezenas ou centenas de candidatas internamente;
- comandos oficiais continuam sendo aceitar, descartar, fixar, gerar variacao e
  aplicar cenario;
- cada decisao reduz o espaco de busca e vira fato para a proxima rodada.

Commands candidatos:

- `PlanejamentoTransporte.GerarOpcoesDeCarga`
- `PlanejamentoTransporte.AceitarOpcaoDeCarga`
- `PlanejamentoTransporte.DescartarOpcaoDeCarga`
- `PlanejamentoTransporte.FixarDecisaoDePlanejamento`
- `PlanejamentoTransporte.GerarVariacoesParaPedidosRestantes`

## Pre-Consolidacao Do Modelo De Trabalho

O nucleo do planejamento de transporte nao deve ser a tela, nem o grupo, nem o
otimizador. O nucleo deve ser o estado planejavel e as transformacoes possiveis
sobre esse estado.

### Objetos Centrais

- `PedidoPlanejavel`: menor unidade operacional de decisao. Representa pedido,
  quantidade, destino, janela, peso, volume, cliente, prioridade, carga atual,
  restricoes e alertas.
- `CargaPlanejavel`: carga real, aberta, sugerida, fixada, consolidada ou
  desmontada. Representa veiculo, rota, capacidade, status, janela, itens e
  travas.
- `ItemCargaPlanejavel`: vinculo entre pedido e carga, com quantidade,
  sequencia, estado de alocacao, origem da decisao e restricoes.
- `AgrupamentoPlanejamento`: lente de trabalho sobre pedidos planejaveis. Pode
  ser estado, regiao, municipio, bairro, rota, cliente ou outra forma de
  agrupamento manual/visual.
- `LigacaoViavelEntreGrupos`: relacao operacional entre agrupamentos que podem
  formar uma carga melhor juntos.
- `OpcaoMontagemCarga`: uma transformacao candidata. Exemplo: criar carga,
  completar carga aberta, trocar pedido, unir cargas ou dividir carga.
- `ConflitoEntreOpcoes`: informa que uma opcao disputa pedido, carga, veiculo,
  janela, doca ou outra restricao com outra opcao.
- `GrupoDecisaoPlanejamento`: conjunto de opcoes concorrentes, normalmente
  gerado pelo otimizador, no qual aceitar uma opcao elimina ou enfraquece outras.
- `CenarioMontagemCarga`: conjunto de opcoes compativeis que descreve um plano
  possivel.
- `RestricaoPlanejamento`: regra dura, trava operacional, alerta ou preferencia
  que influencia a decisao.
- `DecisaoPlanejamento`: aceite, descarte, fixacao, ajuste manual, pedido de
  nova sugestao ou aplicacao de cenario.

### Atores E Bordas

- `Humano`: opera pela tela, escolhe grupos, avalia opcoes, fixa excecoes e
  aplica decisoes.
- `Interface`: nao decide o negocio; apresenta envelopes, drill-down, alertas,
  cenarios e comandos rapidos.
- `AgenteIA`: pode assistir o humano ou operar sozinho. Enxerga mais estado que
  a tela, mas executa o mesmo conjunto de commands.
- `Otimizador`: gera opcoes, cenarios, scores, ligacoes viaveis e variacoes. Nao
  grava o plano real diretamente.
- `Application/Commands`: borda executavel oficial. Recebe intencoes do humano,
  da interface, do agente ou de automacoes e chama dominio/repositorios.

Observacao: `Application/Commands` nao e ator de negocio, mas deve ser tratado
como borda arquitetural central. Todo caminho que altera o plano passa por ela.

### Consolidacao Provisoria - Tres Pilares

Neste momento, os tres pilares devem ficar separados para evitar confusao
conceitual. Eles podem se conectar no futuro, mas o primeiro desenho deve
validar cada um isoladamente.

#### Pilar 1 - Lentes De Pedidos

A lente e uma forma de agrupar pedidos planejaveis. Ela nao entrega cargas
prontas e nao precisa conhecer objetivo de otimizacao.

Exemplos:

- por estado;
- por regiao;
- por municipio;
- por bairro;
- por rota;
- por cliente, se fizer sentido operacional.

Fluxo mental:

1. escolher uma lente;
2. ver grupos de pedidos;
3. selecionar pedidos ou grupo;
4. acompanhar cubagem, peso, prazo e alertas enquanto seleciona;
5. criar uma pre-carga ou carga a partir da selecao;
6. aplicar por command.

Este pilar deve funcionar sem otimizador. Ele e a bancada manual/agil.

Comportamento esperado da tela:

- escolher uma lente;
- listar o primeiro nivel da lente, por exemplo estados ou rotas;
- abrir o segundo nivel, por exemplo municipios;
- abrir o terceiro nivel, por exemplo regioes ou bairros;
- permitir mais de uma regiao/bairro aberta ao mesmo tempo;
- mostrar uma lista de pedidos por regiao/bairro aberto;
- marcar pedidos individualmente ou selecionar regioes abertas;
- sumarizar a selecao em tempo real: cubagem, peso, quantidade, prazo e alertas;
- colocar a selecao em uma pre-carga;
- transformar a pre-carga em carga real somente por command explicito.

O resumo da selecao nao deve ser tratado como carga consolidada. Ele e apenas
uma area temporaria de trabalho ate o operador ou agente aplicar a decisao.

Exemplo de lente por estado:

1. lista estados;
2. clicar em `SP` abre municipios de `SP`;
3. clicar em `Sao Paulo` abre regioes/bairros;
4. clicar em `Zona Leste` e `Zona Oeste` abre as duas listas de pedidos;
5. operador seleciona pedidos de ambas;
6. pre-carga sumariza a selecao sem gravar;
7. command cria a carga quando houver decisao explicita.

Implementacao tecnica candidata:

- cada lente pode ser uma strategy de agrupamento;
- strategies retornam envelopes leves de grupos;
- pedidos detalhados entram somente quando o grupo e aberto;
- a selecao fica no front/agente ate ser aplicada por command;
- o backend recalcula e valida antes de gravar a carga.

### Contrato Das Strategies De Lente

O front nao deve conhecer a regra interna de cada agrupamento. Ele deve conhecer
somente um contrato generico de arvore.

A strategy de lente pertence ao backend/custom do aplicativo e define:

- identificador da lente;
- nome exibivel;
- niveis da arvore;
- como agrupar pedidos em cada nivel;
- quais campos entram no envelope de cada no;
- se a expansao pode ser resolvida em memoria pelo front ou se exige chamada ao
  backend;
- quais comandos podem nascer da selecao.

Exemplo conceitual:

- `LenteEstadoMunicipioPedido`: `Estado -> Municipio -> Pedido`;
- `LenteEstadoMunicipioRegiaoBairroPedido`: `Estado -> Municipio -> Regiao ->
  Bairro -> Pedido`;
- `LenteRotaMunicipioPedido`: `Rota -> Municipio -> Pedido`;
- `LenteClienteMunicipioPedido`: `Cliente -> Municipio -> Pedido`.

O front renderiza sempre o mesmo componente:

1. recebe lista de lentes disponiveis;
2. recebe metadata dos niveis da lente escolhida;
3. mostra o primeiro nivel;
4. ao abrir um no, pede ou calcula os filhos;
5. quando chegar em pedidos, permite selecao;
6. sumariza a selecao localmente;
7. envia IDs e versoes para command de aplicacao.

Assim, criar uma nova strategy de agrupamento nao exige uma tela nova. Exige
apenas uma nova implementacao de lente e, quando necessario, um provedor
customizado de dados/indices no backend.

### Performance Das Lentes

Para a primeira versao, a estrategia preferencial e hibrida:

- criar um `ContextoPlanejamentoTransporte`, com recorte explicito de fabrica,
  periodo, doca, status, pedidos elegiveis e versao do snapshot;
- carregar no front/agente apenas `PedidoPlanejavelEnvelope`, nao o pedido
  completo;
- o envelope contem somente campos de decisao rapida: id, cliente resumido,
  destino, estado, municipio, regiao, bairro, rota, janela, volume, peso,
  alertas compactos, carga atual e versao;
- a lente carrega/armazena indices de agrupamento, nao detalhes pesados;
- expandir a arvore deve usar os dados ja carregados quando o recorte for
  pequeno ou medio;
- para recortes grandes, a expansao chama o backend e recebe apenas o proximo
  nivel ou IDs dos pedidos daquele no;
- pedido detalhado, historico, produto, saldo, restricoes ricas e explicacoes
  entram somente sob demanda;
- criar carga sempre passa por command, que revalida IDs, versoes e status
  antes de gravar.

Com isso, quando o recorte tiver 150 ou 200 pedidos, a tela pode trabalhar tudo
em memoria com custo baixo. Quando o recorte crescer para milhares ou dezenas de
milhares, a mesma tela continua funcionando por expansao lazy e virtualizacao.

O front nao deve virar dono das regras de negocio. Ele pode agrupar, somar e
filtrar envelopes para velocidade de interacao, mas o backend precisa confirmar
a decisao final.

Padrao recomendado:

- `BuscarContextoPlanejamentoTransporte`: abre o recorte e retorna metadata,
  versao e limites;
- `BuscarPedidosPlanejaveisEnvelope`: retorna envelopes leves do recorte;
- `BuscarIndiceDaLente`: retorna arvore/indices da lente escolhida, ou IDs por
  no quando a tela ja tem os envelopes;
- `BuscarNoDaLente`: carrega o proximo nivel sob demanda em recortes grandes;
- `RevalidarSelecaoPlanejamento`: confere se os pedidos selecionados continuam
  elegiveis;
- `CriarCargaDaSelecao`: aplica a decisao no plano real.

Concorrencia:

- selecao na tela nao deve bloquear pedido por padrao;
- command final deve usar versao/status para impedir gravacao de pedido
  cancelado, alterado ou ja consumido por outro fluxo;
- se a operacao exigir reserva, criar uma reserva curta e explicita de
  planejamento, nunca um lock invisivel longo;
- eventos externos como cancelamento comercial devem invalidar ou sinalizar
  pedidos do contexto antes da aplicacao.

#### Pilar 2 - Grupos De Decisao

Grupo de decisao e saida do otimizador. Ele ja olha para opcoes de carga
pre-formadas, nao apenas para pedidos soltos.

Exemplo:

- opcao A: pedidos `1 + 2 + 3`;
- opcao B: pedidos `3 + 4 + 5`;
- opcao C: pedidos `1 + 6 + 7`.

Se o operador ou agente aceita a opcao B, as opcoes que disputam `3`, `4` ou
`5` morrem ou precisam ser recalculadas.

Fluxo mental:

1. otimizador gera opcoes concorrentes;
2. humano ou agente escolhe um caminho;
3. sistema elimina conflitos;
4. otimizador recalcula o que sobrou;
5. no final, mostra pedidos sobrando, atrasos, ocupacao, custo e riscos;
6. humano/agente pode voltar, escolher outro caminho e comparar resultado.

Este pilar se aproxima do processo interno de otimizacao, mas com exposicao
controlada para humano.

#### Pilar 3 - Cenarios Prontos

Cenario pronto e o plano completo entregue pelo otimizador.

Exemplo:

- cenario por menor custo;
- cenario por maior cubagem;
- cenario por menor atraso;
- cenario por fabrica mais vazia;
- cenario por menor risco.

Fluxo mental:

1. otimizador recebe objetivo;
2. monta todas as cargas;
3. entrega um ou mais cenarios fechados;
4. humano ou agente aceita, rejeita ou ajusta;
5. rejeicoes e ajustes entram no catalogo de experiencias.

Este pilar e util, mas carrega o maior risco historico: o otimizador pode
entregar muitas cargas impraticaveis se nao conhecer excecoes reais da operacao.

### Regra Provisoria De Separacao

- lente mostra grupos de pedidos;
- grupo de decisao mostra opcoes concorrentes de carga;
- cenario pronto mostra um plano completo;
- objetivos de otimizacao pertencem principalmente ao otimizador e aos cenarios,
  nao as lentes manuais;
- correlacoes entre os tres pilares ficam para uma rodada posterior.

### Entradas Principais De Trabalho

- por agrupamento geografico: estado, regiao, municipio ou bairro;
- por carga aberta: completar, limpar, trocar, unir ou dividir carga existente;
- por pedidos livres: criar primeira composicao a partir de pedidos ainda nao
  alocados;
- por problemas: financeiro, qualidade, estoque, atraso, excesso de cubagem ou
  carga consolidada;
- por oportunidade: ligacao viavel, carga quase cheia, rota historica ou
  sugestao do otimizador;
- por agente: fila de trabalho headless, sem dependencia de tela.

### Fluxo 1 - Montagem Manual Por Lente

1. Buscar envelopes de pedidos agrupados pela lente escolhida.
2. Selecionar grupo de pedidos.
3. Marcar pedidos manualmente ou selecionar o grupo inteiro.
4. Acompanhar cubagem, peso, prazo e alertas da selecao.
5. Criar pre-carga ou carga rapida.
6. Ajustar, fixar e aplicar por command.

### Fluxo 2 - Ajuste De Carga Aberta

1. Buscar cargas abertas e seus resumos.
2. Selecionar carga com problema ou oportunidade.
3. Gerar opcoes: retirar pedido, trocar pedido, completar carga, dividir carga
   ou unir com outra carga.
4. Mostrar impacto antes de aplicar.
5. Fixar partes que nao devem ser alteradas.
6. Aplicar transformacao por command.

### Fluxo 3 - Grupo De Decisao Do Otimizador

1. Receber estado planejavel atual.
2. Gerar opcoes candidatas de carga.
3. Apresentar grupos de opcoes concorrentes.
4. Aceitar, descartar ou fixar uma opcao.
5. Eliminar opcoes conflitantes.
6. Recalcular opcoes para pedidos restantes.
7. Aplicar conjunto final por command.

### Fluxo 4 - Agente Operando Sem Tela

1. Ler fila de trabalho e politica operacional.
2. Consultar envelopes, restricoes, cargas e pedidos.
3. Pedir opcoes ao otimizador ou criar opcoes por heuristica simples.
4. Aplicar decisoes permitidas automaticamente.
5. Solicitar aprovacao humana quando risco ou politica exigir.
6. Registrar decisoes, justificativas e sobras.

### Fluxo Principal A - Otimizador Monta Tudo

1. Humano, agente ou automacao escolhe objetivo principal, como custo, cubagem,
   prazo ou risco.
2. Otimizador gera o plano inteiro com todas as cargas montadas.
3. Interface ou agente apresenta o plano como cenario fechado.
4. Operador aceita, rejeita ou ajusta pontos criticos.
5. Rejeicoes e ajustes viram experiencia catalogada: roteiro bom, roteiro ruim,
   combinacao impraticavel, cliente sensivel, restricao nao parametrizada.
6. Proxima rodada usa essas experiencias como sinais, sem transformar tudo em
   parametro duro.

Observacao: este fluxo e valido, mas nao deve ser o caminho principal da
operacao manual. Ele repete o risco historico do APS antigo quando o otimizador
monta cargas impraticaveis e o operador precisa desmontar muita coisa depois.

### Fluxo Principal B - Otimizador Entrega Grupos De Decisao

1. Otimizador recebe o estado planejavel.
2. Em vez de entregar somente o plano final, ele gera grupos/opcoes de decisao.
3. Cada grupo representa opcoes concorrentes que se cancelam parcialmente.
4. Humano ou agente aceita uma opcao.
5. O sistema elimina as concorrentes que disputam os mesmos pedidos, cargas,
   veiculos, janelas ou restricoes.
6. O otimizador recalcula variacoes para o que sobrou.

Este fluxo tende a ser mais compreensivel que expor centenas de combinacoes e
mais flexivel que aceitar ou rejeitar um plano completo.

### Fluxo Principal C - Montagem Manual Por Lentes

1. Usuario ou agente escolhe uma lente de pedidos: estado, cidade, regiao,
   bairro, rota ou outra strategy de agrupamento.
2. Sistema mostra envelopes leves agrupados.
3. Usuario marca pedidos ou grupos de pedidos.
4. Sistema monta uma carga rapida ou pre-carga.
5. Usuario ajusta, fixa e aplica.
6. A decisao registrada alimenta historico e futuras sugestoes.

Este fluxo deve existir mesmo sem otimizador. Ele e a garantia de operacao
agil quando o otimizador nao souber decidir bem.

### Fluxo 5 - Tratamento De Plano Consolidado

1. Identificar carga, item ou pedido consolidado.
2. Bloquear edicao comum.
3. Oferecer somente commands operacionais explicitos, como reabrir, estornar,
   substituir ou criar compensacao.
4. Registrar a decisao e seu impacto.

### Regra De Base

O grupo nao e a base do modelo; ele e uma lente de trabalho. A base e sempre:

- pedidos planejaveis;
- cargas planejaveis;
- itens de carga;
- restricoes;
- opcoes;
- cenarios;
- decisoes.

Essa base permite que a tela comece por mapa, grupo, pedido solto, carga aberta,
problema, cenario ou agente sem trocar o nucleo.

## Estrategia De Views E Performance Extrema

Nao abandonar views como conceito de tela/leitura. Para transporte, `FromView`
deve representar uma projection/read model resolvida pelo repositorio de
leitura do aplicativo. A implementacao padrao fica em codigo gerenciado; nao
deve criar nem exigir view fisica no banco.

Regra:

- view de leitura nao deve virar caminho de escrita;
- mutacao deve passar por command/use case e gravar entidades reais;
- projection grande deve ser quebrada em consultas menores quando a tela nao
  precisa de todos os dados ao mesmo tempo;
- a tela deve carregar primeiro o minimo necessario para navegar e decidir.

Padrao recomendado para a bancada:

- `Envelope`: primeira consulta traz poucos campos para muitos pedidos.
  Exemplo: pedido, carga atual, cliente resumido, embarque, quantidade, peso,
  volume, latitude, longitude, status/alertas compactos.
- `Detalhe sob demanda`: ao selecionar pedido/carga, buscar produto, dimensoes,
  roteiro, estoque detalhado, restricoes e historico.
- `Fatia temporal`: carregar por janela de embarque, como hoje, amanha, semana
  ou periodo escolhido.
- `Fatia geografica`: carregar por UF, municipio, regiao, raio ou viewport do
  mapa.
- `Virtualizacao`: grade e mapa nao devem renderizar milhares de elementos
  pesados de uma vez.
- `Resumo incremental`: peso, volume e ocupacao da carga devem ser calculados
  por dados ja carregados ou por endpoint especifico pequeno.
- `Prefetch controlado`: ao navegar para a proxima faixa de tempo ou mapa, o
  sistema pode antecipar a proxima pagina sem bloquear a tela.
- `Cache de leitura`: listas estaveis como tipo de veiculo, regioes e pontos de
  mapa podem ser cacheadas no front/host com invalidez explicita.

Consultas candidatas:

- `PlanejamentoTransporte.BuscarPedidosEnvelope`
- `PlanejamentoTransporte.BuscarPedidoDetalhe`
- `PlanejamentoTransporte.BuscarCargasEnvelope`
- `PlanejamentoTransporte.BuscarCargaDetalhe`
- `PlanejamentoTransporte.BuscarMapaPedidos`
- `PlanejamentoTransporte.CalcularResumoCarga`

O primeiro endpoint da tela nao deve tentar materializar a antiga
`V_CARGASWEB_ESTOQUE` inteira. Ele deve carregar uma projecao leve suficiente
para montar a bancada e deixar o restante para chamadas sob demanda.

## O Que Fica Na DSL

Na DSL devem ficar apenas declaracoes estruturais:

- `Carga`
- `ItenCarga`
- `CargaPlanejamentoConsulta` como `FromView("CargaPlanejamentoConsulta")`
- `PedidoDisponivelExpedicao` como `FromView("PedidoDisponivelExpedicao")`
- `ItenCarga.CAR_ID` como FK logica para `Carga.CAR_ID` com `RelationTab`
- `ItenCarga.ORD_ID` como FK logica para `Order.ORD_ID`
- `Carga.CustomTab("Planejamento", "Planejamento")`
- use cases/actions expostos para a tela:
  - `PlanejamentoTransporte.BuscarPedidosDisponiveis`
  - `PlanejamentoTransporte.AlterarItemDaCarga`
  - `PlanejamentoTransporte.SalvarComposicaoCarga`
  - `PlanejamentoTransporte.UnirCargas`
  - `PlanejamentoTransporte.AvaliarCarga`

## O Que A Engine Deve Gerar

- metadata de `CustomTab`;
- metadata de `RelationTab`;
- endpoints/commands/receivers de use case declarados;
- read commands para visoes/projections `FromView`;
- DTOs de entrada/saida dos use cases;
- contratos de repositories;
- cascas customizaveis em `Custon` para miolos de use case;
- front host capaz de abrir uma aba customizada por entidade.

## O Que Fica No Codigo Customizado APS

- regra de montagem de carga;
- calculo de peso, volume e ocupacao;
- validacao de item romaneado;
- decisao de criar, mover, atualizar ou excluir `ItenCarga`;
- merge/uniao de cargas;
- filtros ricos de pedidos futuros quando nao couberem no query gerado;
- integracao com packing/otimizador;
- regras de romaneio, balanca e estoque;
- componentes de front especificos da bancada de transporte.

## Pendencias De Arquitetura Registradas

- pendencia: action de tela para mutar entidade real a partir de view `FromView`.
- observacao: caso concreto `V_ITEM_CARGA` para `ItenCarga`.

- pendencia: definir padrao de tela operacional customizada por entidade.
- observacao: caso concreto `Carga.CustomTab("Planejamento")`, com componente
  livre no front do APS.

- pendencia: padrao de command de composicao de varios objetos.
- observacao: `SalvarItensCargaTotal` altera `Carga` e muitos `ItenCarga` em
  uma unica intencao.

- pendencia: padrao de fatos carregados pelo Receiver para dominio sem I/O.
- observacao: bloqueio de item romaneado exige saber se ha movimento/reserva
  ativa para `CAR_ID + ORD_ID`.

- pendencia: padrao de consulta rica de tela.
- observacao: pedidos futuros usam view, filtros de negocio, raio geografico e
  ordenacao operacional.

- pendencia: padrao para aceitar resultado de simulacao/otimizador.
- observacao: gravar cargas simuladas deve preservar origem da decisao e itens
  fixados manualmente.

## Decisao Provisoria

Subir o sistema e construir primeiro a bancada manual assistida de transporte.
As regras antigas de romaneio, balanca e estoque ficam registradas, mas nao
devem bloquear a primeira tela de montagem manual de cargas.
