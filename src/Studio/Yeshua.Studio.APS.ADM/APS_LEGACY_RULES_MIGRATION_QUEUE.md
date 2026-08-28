# APS ADM - Fila de migracao de regras por entidade

Este arquivo controla a transcricao incremental das regras do legado APS para o
padrao Yeshua.

A unidade de trabalho e a entidade. Uma entidade so deve ser considerada
concluida quando os quatro pontos abaixo estiverem resolvidos ou explicitamente
marcados como sem regra efetiva:

- `BeforeInsert`
- `BeforeUpdate`
- `AfterInsert`
- `AfterUpdate`

## Criterio de execucao

- Nao copiar o ciclo tecnico `BeforeChanges`/`AfterChanges` literalmente.
- Traduzir regra para `PrepareCustom`, `ValidateCustom`, `CollectEventsCustom`
  ou use case exposto quando a intencao for operacional.
- Se a regra exigir um conceito que o Yeshua ainda nao possui, registrar
  `pendente arquitetura` e nao improvisar no custom.
- Se a regra se encaixar no motor atual, implementar no `Custon`, atualizar esta
  fila e seguir para a proxima entidade.
- Compilar em blocos, nao a cada entidade.

## Pre-decisao arquitetural

- Toda intencao deve entrar por `Command`.
- O `Receiver` organiza o fluxo: carrega contexto, consulta dados externos,
  monta facts simples quando necessario, chama o dominio, persiste e publica
  consequencias.
- O dominio continua forte, mas sem I/O: `DomainBehavior`/`BusinessRules`
  recebem a entidade, o contexto e facts ja carregados.
- Evitar `ReadPort` dentro do dominio por padrao, para nao espalhar consultas e
  dependencias em regras de entidade.
- Fluxos que mexem em varias entidades ou representam botoes/acoes viram
  commands especificos.
- Consequencias pos-persistencia tendem a virar eventos/handlers disparados pelo
  fluxo do command.
- Esta e uma pre-decisao para guiar a classificacao das pendencias; nao
  implementar mudancas de arquitetura agora.

## Legenda

- `feito`: transcrito para codigo customizado.
- `sem regra`: hook inexistente ou hook legado sem comportamento efetivo.
- `pendente analise`: ainda nao separado por operacao.
- `pendente arquitetura`: exige ajuste ou decisao no Yeshua antes da transcricao.
- `parcial`: parte transcrita, parte ainda pendente.

## Fila

| Ordem | Entidade | BeforeInsert | BeforeUpdate | AfterInsert | AfterUpdate | Observacao |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Roteiro | feito | feito | sem regra | sem regra | Transcrito em `RoteiroBusinessRules`; origem era `BeforeChanges`. |
| 2 | Observacoes | feito | feito | sem regra | sem regra | Transcrito em `ObservacoesBusinessRules`; prepara campos vazios e valida vinculo minimo. |
| 3 | Operacoes | feito | sem regra | sem regra | sem regra | Transcrito em `OperacoesBusinessRules`; valida tamanho de `OPE_ID` no registro. |
| 4 | GrupoMaquina | feito | sem regra | sem regra | sem regra | Transcrito em `GrupoMaquinaBusinessRules`; usa `Id` atual da DSL, legado era `GMA_ID`. |
| 5 | TempoSetupOnduladeira | feito | feito | sem regra | sem regra | Transcrito em `TempoSetupOnduladeiraBusinessRules`; ondas vazias para null e par obrigatorio. |
| 6 | TipoAvaliacao | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 7 | TipoInspecaoVisual | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 8 | TipoTeste | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 9 | PeriodicidadeTeste | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 10 | FechamentoTeste | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 11 | Segmento | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 12 | Onda | sem regra | sem regra | sem regra | sem regra | Hook legado apenas filtra tipo e retorna `true`. |
| 13 | T_Negocio | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 14 | T_Indicadores | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 15 | ConsultasIndicadores | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 16 | FilaProducao | sem regra | pendente arquitetura | sem regra | sem regra | Remocao de OP firme/encerrada transcrita em `FilaProducaoBusinessRules`; update/insert dependem de campos alterados, produto, roteiro, corridas e pedido. |
| 17 | LaudoTesteFisico | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 18 | PlanoAmostralTeste | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 19 | Relatorios | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 20 | TemplateTipoInspecaoVisual | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 21 | TemplateTipoTeste | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 22 | ViewControleQABobinas | sem regra | sem regra | sem regra | sem regra | Ja constava como sem regra efetiva no inventario. |
| 23 | Cargos | pendente arquitetura | sem regra | sem regra | sem regra | Regra de duplicidade exige porta de leitura, nao `DbContext` no dominio. |
| 24 | SubOcorrencia | pendente arquitetura | sem regra | sem regra | sem regra | Regra de duplicidade exige porta de leitura, nao `DbContext` no dominio. |
| 25 | Boletim | parcial | parcial | sem regra | sem regra | Validacoes locais transcritas em `BoletimBusinessRules`; acoes/gatilhos com corridas ficam pendentes arquitetura/use case. |
| 26 | Calendario | sem regra | pendente arquitetura | sem regra | sem regra | Delete orquestra `ItensCalendario` e `Maquina`; metodo `Inserir_Itens_Calendario` e acao de tela/use case. |
| 27 | Carga | parcial | parcial | pendente arquitetura | pendente arquitetura | Validacoes locais transcritas em `CargaBusinessRules`; transicao de status, geracao de `CAR_ID`, romaneio, balanca, estoque e acoes ficam pendentes arquitetura/use case. |
| 28 | Cliente | pendente arquitetura | sem regra | sem regra | sem regra | Insert gera `CLI_ID` com semaforo/parametro e atualiza tela; metodo de horarios e acao de tela/use case. |
| 29 | ClpMedicoesH | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 30 | VersaoCusto | sem regra | pendente arquitetura | sem regra | sem regra | Inventario bruto apontava `ContasContabeis`, mas o hook real e de `VersaoCusto`; update recarrega cache e gatilhos geram movimentos de custo. |
| 31 | CorridasOnduladeira | parcial | parcial | pendente arquitetura | pendente arquitetura | Validacoes locais transcritas; sequenciamento/semaforo, reserva, duplicidade, alteracoes com clone e acoes operacionais pendentes. |
| 32 | EstornoDeEstoque | pendente arquitetura | sem regra | sem regra | sem regra | Legado e formulario/comando operacional sem entidade gerada no APS ADM; exige use case para consultar etiqueta/saldo/producao e orquestrar estorno. |
| 33 | EstruturaProduto | feito | feito | sem regra | sem regra | Validacoes locais transcritas em `EstruturaProdutoBusinessRules`. |
| 34 | Etiqueta | pendente arquitetura | pendente arquitetura | pendente arquitetura | sem regra | Hook legado pertence a `InterfaceTelaImpressaoEtiquetas`: emissao/geracao/impressao de etiquetas deve virar use case; nao bloquear CRUD interno de `Etiqueta` por enquanto. |
| 35 | Feedback | pendente arquitetura | sem regra | sem regra | sem regra | Insert calcula `DiaTurma`, `TurmaId` e `TurnoId` via calendario/cache; exige politica/porta de calendario fora do dominio puro. |
| 36 | GrupoProdutoWMSExpedicao | sem regra | sem regra | sem regra | sem regra | Classe herda de `GrupoProdutoAbstrato`, mas nao possui hook efetivo proprio no legado. |
| 37 | InspecaoVisual | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`. |
| 38 | InterfaceTelaSenhaUsuario | pendente arquitetura | sem regra | sem regra | sem regra | Fluxo de alteracao de senha sem entidade gerada; exige use case/autorizacao, hash e usuario logado. |
| 39 | ItensCalendario | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`; metodos de conflito/lacuna sao auxiliares para use cases de calendario. |
| 40 | ItensOrcamento | parcial | parcial | pendente arquitetura | pendente arquitetura | Preparacao local transcrita; geracao de chapas, conjuntos e recalculo/persistencia de custos exigem use case/orquestracao. |
| 41 | Logs | sem regra | sem regra | sem regra | sem regra | Hook legado retorna `true`; sem entidade gerada no dominio APS ADM atual. |
| 42 | Maquina | parcial | parcial | sem regra | sem regra | Validacoes locais transcritas em `MaquinaBusinessRules`; duplicidade de IP/sensor exige porta de leitura. |
| 43 | MaquinaImpressora | parcial | parcial | sem regra | sem regra | Limite local de facao transcrito; exclusividade por facao exige porta de leitura. |
| 44 | MovimentoCusto | pendente arquitetura | sem regra | sem regra | sem regra | Subtipo legado sobre `T_MOVIMENTOS_ESTOQUE`; regra de `TIP_ID` 450/850 exige discriminador/intencao para nao contaminar `MovimentoEstoque` generico. |
| 45 | MovimentoEstoqueAbstrata | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Politica transversal de estorno sequencial consulta movimentos anteriores; exige porta de leitura/politica de estoque por subtipo. |
| 46 | MovimentoEstoqueBobinas | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; prepara campos, busca parametro e entrada de bobina. Exige discriminador/intencao e porta de leitura. |
| 47 | MovimentoEstoqueConsumoMateriaPrima | pendente arquitetura | pendente arquitetura | pendente arquitetura | pendente arquitetura | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; validacoes locais existem, mas dependem de discriminador/intencao. Saldo, reserva, calendario e etiqueta exigem portas/use case. |
| 48 | MovimentoEstoqueDevolucao | pendente arquitetura | pendente arquitetura | pendente arquitetura | pendente arquitetura | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; validacoes/produto/quantidade e `TIP_ID=400` dependem de discriminador/intencao; etiqueta posterior exige use case. |
| 49 | MovimentoEstoquePerdas | pendente arquitetura | pendente arquitetura | pendente arquitetura | pendente arquitetura | Subtipo/interface sobre `T_MOVIMENTOS_ESTOQUE`; valida tipo 500-561/lote/quantidade, saldo, reserva e etiqueta exigem discriminador/use case. |
| 50 | MovimentoEstoquePreProducao | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; preparacao de lote/sub-lote e calendario depende de intencao/discriminador. |
| 51 | MovimentoEstoqueProducao | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Subtipo/interface sobre `T_MOVIMENTOS_ESTOQUE`; apontamento por etiqueta/codigo de barras cria reserva e consumo. Exige command/use case, discriminador e facts. |
| 52 | MovimentoEstoqueReservaDeEstoque | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Subtipo/interface sobre `T_MOVIMENTOS_ESTOQUE`; reserva, troca de produto e romaneio exigem command/use case, facts e discriminador. |
| 53 | MovimentoEstoqueSaidaInventario | pendente arquitetura | pendente arquitetura | pendente arquitetura | pendente arquitetura | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; entrada/saida de inventario validam produto/quantidade/saldo, criam reserva e etiqueta. Exige command/use case e discriminador. |
| 54 | MovimentoEstoqueTransferenciaSimples | pendente arquitetura | pendente arquitetura | pendente arquitetura | pendente arquitetura | Subtipo/interface sobre `T_MOVIMENTOS_ESTOQUE`; transferencia/desmontagem de lote exige command/use case, facts, discriminador e evento de etiqueta. |
| 55 | MovimentoEstoqueVendas | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; preparacao de calendario e impressao auxiliar exigem intencao/contexto operacional. |
| 56 | MovimentoEstoqueVersaoCusto | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Subtipo sobre `T_MOVIMENTOS_ESTOQUE`; preparacao de calendario exige intencao/contexto operacional. |
| 57 | Ocorrencia | parcial | parcial | sem regra | sem regra | Validacao local de `TIP_ID` transcrita; consulta do tipo e geracao de ocorrencias especializadas exigem command/use case e facts. |
| 58 | Order | parcial | parcial | sem regra | sem regra | Validacoes locais de produto/cliente transcritas; geracao de id, municipio, retrabalho, explosao de OPs, suspensao/encerramento e alteracoes com clone exigem command/use case e facts. |
| 59 | Param | sem regra | sem regra | pendente arquitetura | pendente arquitetura | `AfterChanges` sincroniza cache de parametro; consequencia pos-persistencia deve virar evento/handler ou politica operacional. |
| 60 | ProdutoCaixa | parcial | parcial | pendente arquitetura | pendente arquitetura | Defaults/validacoes puras em `ProdutoBusinessRules`; geracao de ID, semaforo, clone, arquivos, orcamento, estrutura, chapa, conjunto, cliche, faca, roteiro e caches exigem command/use case, fatos carregados e discriminador de subtipo de produto. |
| 61 | ProdutoChapaIntermediaria | parcial | parcial | pendente arquitetura | pendente arquitetura | Defaults simples de paletizacao/dimensoes em `ProdutoBusinessRules`; roteiros e estruturas de chapa apos persistencia exigem evento/handler ou command especifico. |
| 62 | ProdutoChapaVenda | parcial | parcial | sem regra | sem regra | Defaults simples de paletizacao em `ProdutoBusinessRules`. |
| 63 | ProdutoCliches | sem regra | sem regra | pendente arquitetura | sem regra | Insert gera indisponibilidade em calendario/itens de calendario; deve virar evento/handler ou command pos-persistencia. |
| 64 | ProdutoConjunto | transcrito | transcrito | sem regra | sem regra | `PRO_OUT` padrao transcrito em `ProdutoBusinessRules`. |
| 65 | ProdutoFaca | sem regra | sem regra | pendente arquitetura | sem regra | Insert gera indisponibilidade em calendario/itens de calendario; deve virar evento/handler ou command pos-persistencia. |
| 66 | ResultLote | sem regra | sem regra | sem regra | sem regra | `BeforeChanges` retorna true; metodos ocultos de preencher especificacao/valor de boletim dependem de consultas e devem virar command/query com facts carregados. |
| 67 | SegmentosProdutos | pendente arquitetura | sem regra | sem regra | sem regra | Regra de insert consulta filhos de segmento; precisa porta de leitura. |
| 68 | T_LOGS_DATABASE | parcial | parcial | sem regra | sem regra | Parse de `LOGS_KEY` para `LOGS_KEY1..4` em `LogsDatabaseBusinessRules`; gerador antigo de logs por clone/reflection fica substituido conceitualmente pelo tracker de dominio. |
| 69 | T_PlanoAcao | sem regra | sem regra | sem regra | sem regra | `BeforeChanges` retorna true. |
| 70 | T_PREFERENCIAS | parcial | parcial | pendente arquitetura | pendente arquitetura | `BUFFER` e `USE_ID` por contexto em `T_PREFERENCIASBusinessRules`; upsert por preferencia existente, validacao ORDERBY via metadata e sincronizacao de cache/singleton exigem command/query/evento. |
| 71 | T_Usuario | parcial | pendente arquitetura | sem regra | sem regra | Hash SHA1 no insert transcrito em `UsuarioBusinessRules`; update precisa saber se `USE_SENHA` mudou para evitar rehash indevido, entao depende de command/facts de campos alterados. |
| 72 | TargetProduto | pendente arquitetura | pendente arquitetura | sem regra | sem regra | Aprovar target atualiza `Roteiro`; insert calcula dia/turma/turno via calendario/cache; deve ser command com fatos carregados. |
| 73 | TesteFisico | pendente arquitetura | sem regra | sem regra | sem regra | Delete remove `ResultLote` relacionado; precisa orquestracao de receiver/use case ou politica de cascade explicita. |
| 74 | V_CONSULTA_PEDIDO | pendente arquitetura | pendente arquitetura | sem regra | sem regra | View editavel indiretamente: update converte campos permitidos para `Order`, normaliza status textual e expoe tracker/relatorio; precisa conceito de consulta com action/use case. |
| 75 | V_DISPONIBILIDADE_CLICHE | pendente arquitetura | pendente arquitetura | sem regra | sem regra | View/form cria disponibilidade de calendario fixo `CAL_ID=100`; deve virar action/use case sobre `ItensCalendario` com garantia de calendario. |
| 76 | V_DISPONIBILIDADE_FACA | pendente arquitetura | pendente arquitetura | sem regra | sem regra | View/form cria disponibilidade de calendario fixo `CAL_ID=100`; deve virar action/use case sobre `ItensCalendario` com garantia de calendario. |
| 77 | V_ITEM_CARGA | pendente arquitetura | pendente arquitetura | sem regra | sem regra | View/form converte para `ItenCarga`; precisa action/use case de consulta para mutacao em entidade real. |
