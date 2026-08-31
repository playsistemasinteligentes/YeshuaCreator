# APS ADM - Planejamento De Transporte: DSL, Use Cases E Tela Custom

Este documento registra a proposta de organizacao do planejamento de transporte
do APS ADM no padrao Yeshua, usando o legado como referencia funcional sem
copiar sua estrutura.

## Decisao Base

- Uma funcao publica executavel deve nascer como `UseCase` quando nao for CRUD.
- Nao criar um use case com N metodos publicos internos na DSL.
- Reuso interno fica em servicos/strategies customizados do aplicativo.
- Tela de planejamento de transporte nao deve ser aba customizada de entidade.
- Tela de planejamento de transporte deve ser pagina customizada completa,
  dentro da casca do front Yeshua.
- O front custom chama use cases e projections; nao chama diretamente tabelas
  nem views fisicas do banco.

## Entidades APS Ja Existentes E Relevantes

Estas entidades ja aparecem nas migrations atuais do APS ADM e formam o chao
inicial do planejamento de transporte:

- `Carga`: carga operacional, originada de `T_CARGA`.
- `ItenCarga`: relacao entre carga e pedido, originada de `T_ITENS_CARGA`.
- `CargaPrevista`: previsao/plano de carga, originada de `T_CARGA_PREVISTA`.
- `Order`: pedido operacional, originado de `T_ORDENS`.
- `ConsultaPedido`: projection de pedido, declarada com `FromView("V_CONSULTA_PEDIDO")`.
- `Cliente`: dados comerciais/logisticos do cliente.
- `Municipio`: destino geografico.
- `Transportadora`: transportadora.
- `TipoVeiculo`: tipo/capacidade de veiculo.
- `Veiculo`: veiculo concreto.
- `CalendarioDisponibilidadeVeiculos`: disponibilidade por periodo.
- `ItenCalendarioDisponibilidadeVeiculos`: quantidade disponivel por tipo de veiculo.
- `RestricoesDeRodagem`: restricoes por horario/tipo/mapa.
- `PontosMapa`: ponto geografico ou logistico.
- `RotaPontosMapa`: rota factivel entre pontos.
- `RotaRealizada`: rastreamento/execucao de rota realizada.
- `Ocorrencia`: motivo/ocorrencia ligada a carga.

## Entidades/Projections Que Faltam Para A Tela

Estas declaracoes devem entrar em uma migration posterior, preferencialmente
em `M000004`, apos alinhamento.

### `PedidoPlanejavel`

Projection customizada de leitura. Nao cria tabela fisica e nao exige view no
banco.

Uso:

- Alimentar as lentes de pedido.
- Trazer somente o envelope rapido para tela.
- Permitir agrupamento local ou expansao remota.

Campos minimos:

- `PedidoId`
- `ClienteId`
- `ClienteNome`
- `Estado`
- `Municipio`
- `Regiao`
- `Bairro`
- `RotaId`
- `EmbarqueAlvo`
- `DataEntregaDe`
- `DataEntregaAte`
- `Peso`
- `Volume`
- `SaldoAExpedir`
- `Status`
- `CargaAtualId`
- `VersaoPlanejamento`
- `AlertasResumo`

### `CargaPlanejavel`

Projection customizada de leitura sobre cargas abertas, consolidadas ou
sugeridas para a tela.

Uso:

- Mostrar cargas em aberto.
- Permitir retirar pedido, trocar pedido, unir cargas e dividir cargas.
- Servir de comparativo contra sugestoes do otimizador.

Campos minimos:

- `CargaId`
- `Status`
- `TransportadoraId`
- `VeiculoId`
- `TipoVeiculoId`
- `PesoTeorico`
- `VolumeTeorico`
- `InicioJanelaEmbarque`
- `FimJanelaEmbarque`
- `EmbarqueAlvo`
- `QuantidadePedidos`
- `AlertasResumo`

### `OpcaoPlanejamentoTransporte`

Projection transiente de opcoes criadas por otimizador, agente de IA ou
strategy customizada. No primeiro momento, nao precisa persistir.

Uso:

- Representar um grupo de decisao.
- Permitir escolher uma opcao e invalidar opcoes conflitantes.

Campos minimos:

- `OpcaoId`
- `GrupoDecisaoId`
- `Pedidos`
- `Peso`
- `Volume`
- `CustoEstimado`
- `AderenciaCubagem`
- `AderenciaJanelaEntrega`
- `RiscoResumo`
- `OpcoesConflitantes`

### `CenarioPlanejamentoTransporte`

Projection transiente de um plano completo.

Uso:

- Otimizador entrega um plano fechado.
- Usuario aceita, ajusta ou rejeita o plano.

Campos minimos:

- `CenarioId`
- `Descricao`
- `Objetivo`
- `Cargas`
- `PedidosNaoAtendidos`
- `CustoTotal`
- `AderenciaCubagem`
- `AtrasoPrevisto`
- `AlertasResumo`

### `ExperienciaPlanejamentoTransporte`

Entidade persistida de aprendizado operacional.

Uso:

- Registrar roteiro bom, roteiro ruim, combinacao impraticavel, restricao
  humana e explicacao.
- Alimentar futuras strategies, agente de IA e otimizador.

Campos minimos:

- `Id`
- `Tipo`
- `Referencia`
- `PedidoId`
- `ClienteId`
- `Municipio`
- `Regiao`
- `RotaId`
- `Peso`
- `Volume`
- `Observacao`
- `CriadoEm`
- `CriadoPor`

## Use Cases Propostos

Grupo sugerido:

`AddUsecaseGroup("APSADM").AddUseCaseSubGrup("PlanejamentoTransporte")`

Cada item abaixo deve virar um command publico separado, seguindo o padrao ja
existente da DSL.

- `BuscarContextoPlanejamentoTransporte`: abre o recorte de trabalho.
- `ListarLentesPlanejamentoTransporte`: informa as lentes disponiveis.
- `AbrirNoLentePlanejamentoTransporte`: expande um no da arvore.
- `RevalidarSelecaoPlanejamentoTransporte`: confere IDs/versoes antes de montar carga.
- `CriarCargaDaSelecaoPlanejamentoTransporte`: cria carga a partir dos pedidos selecionados.
- `ListarCargasAbertasPlanejamentoTransporte`: mostra cargas em aberto/consolidadas.
- `RemoverPedidoDaCargaPlanejamentoTransporte`: retira pedido de uma carga.
- `TrocarPedidoEntreCargasPlanejamentoTransporte`: troca pedido entre cargas.
- `UnirCargasPlanejamentoTransporte`: transforma duas cargas em uma.
- `DividirCargaPlanejamentoTransporte`: transforma uma carga em duas.
- `GerarGruposDecisaoPlanejamentoTransporte`: pede opcoes concorrentes ao otimizador/strategy.
- `AceitarOpcaoPlanejamentoTransporte`: aceita uma opcao e invalida conflitos.
- `DescartarOpcaoPlanejamentoTransporte`: descarta opcao explicitamente.
- `GerarCenariosPlanejamentoTransporte`: pede cenarios completos ao otimizador.
- `AplicarCenarioPlanejamentoTransporte`: aplica um cenario completo.
- `CatalogarExperienciaPlanejamentoTransporte`: registra aprendizado operacional.

## Codigo Customizado Previsto

O miolo especifico deve ficar no aplicativo APS ADM, em `Custon`, nao no Shared
global.

- Strategy de lente: monta grupos por estado/municipio, rota, regiao ou outro criterio.
- Provider de projection: resolve `PedidoPlanejavel`, `CargaPlanejavel`,
  `OpcaoPlanejamentoTransporte` e `CenarioPlanejamentoTransporte`.
- Servico de montagem de carga: valida selecao, cria/ajusta `Carga` e `ItenCarga`.
- Adapter do otimizador: gera grupos de decisao e cenarios completos.
- Servico de experiencia operacional: grava decisoes humanas relevantes.

## Tela Custom Completa

O front atual possui:

- `wwwroot/spa/scripts/router.js`: carrega views por hash.
- `wwwroot/spa/scripts/menu.js`: abre itens do menu chamando CRUD.
- `wwwroot/Custon/extensions.js`: hooks atuais do CRUD.

Para planejamento de transporte, a tela deve ficar fora do CRUD:

- `wwwroot/Custon/pages/planejamento-transporte.html`
- `wwwroot/Custon/pages/planejamento-transporte.js`
- `wwwroot/Custon/pages/planejamento-transporte.css`

Fluxo da tela:

- Usuario entra em `#planejamento-transporte`.
- Tela chama `BuscarContextoPlanejamentoTransporte`.
- Tela chama `ListarLentesPlanejamentoTransporte`.
- Ao escolher lente, tela chama `AbrirNoLentePlanejamentoTransporte` quando
  precisar de expansao remota.
- Selecoes ficam no estado local da tela como IDs e versoes.
- Antes de gravar, tela chama `RevalidarSelecaoPlanejamentoTransporte`.
- Carga nasce por `CriarCargaDaSelecaoPlanejamentoTransporte`.

## Pendencias De Arquitetura

- `pendencia`: criar conceito oficial de tela custom completa na DSL/Engine,
  sem confundir com `CustomTab`.
- `pendencia`: menu gerado deve suportar item de tipo pagina custom, alem de
  CRUD.
- `pendencia`: router do front deve carregar pagina custom preservada em
  `Custon`, sem sobrescrita pela Engine.
- `pendencia`: definir se projections transientes entram na DSL como
  `FromView` ou recebem um nome mais claro no futuro, mantendo a regra de nao
  criar view fisica no banco.
- `pendencia`: definir contrato padrao para use case de leitura rapida usado
  por telas custom e por agentes de IA.

## Regra De Performance

- O recorte inicial deve ser pequeno e explicito.
- Para volumes comuns, carregar envelopes leves e agrupar no front.
- Para volumes grandes ou lentes complexas, expandir por no e retornar somente
  resumo/IDs/envelopes necessarios.
- Nunca carregar tabelas completas para a tela.
- Validacao forte acontece no command antes da gravacao.
- Otimizador, humano e agente de IA devem usar os mesmos use cases publicos.

## Construcao Inicial

- `M000004` declara as projections `PedidoPlanejavel`, `CargaPlanejavel`,
  `OpcaoPlanejamentoTransporte` e `CenarioPlanejamentoTransporte`.
- `M000004` declara a entidade persistida `ExperienciaPlanejamentoTransporte`.
- `M000004` declara os use cases publicos do subgrupo
  `APSADM/PlanejamentoTransporte`.
- O front padrao passou a aceitar item de menu `customPage` via
  `window.yeshuaExtensions`.
- O front APS ADM registra a pagina custom `planejamento-transporte` em
  `wwwroot/Custon/extensions.js`.
- A primeira tela custom foi criada em `wwwroot/Custon/pages`, com fallback de
  simulacao enquanto os receivers ainda nao possuem miolo.
