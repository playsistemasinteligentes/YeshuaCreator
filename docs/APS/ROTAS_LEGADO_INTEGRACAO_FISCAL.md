# APS - Rotas Legado E Integracao Fiscal

Este documento registra o estudo inicial sobre o conceito de rota no APS legado
e como ele deve alimentar o fluxo APS -> Fiscal no Yeshua.

## Objetivo

Entender como o APS legado representava rotas, pontos, cidades, UFs e percurso
para que o Yeshua consiga montar um snapshot fiscal da carga sem acoplar o
modulo Fiscal ao banco ou ao dominio interno do APS.

## Fontes Consultadas

- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Models\Transporte\Transporte.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Models\Transporte\RotaRealizada.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Map\Transporte\TransporteMap.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Map\OrderMap.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Controllers\PontoMapaController.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Controllers\PainelGestaoTransporteController.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\Controllers\RoteirizadorController.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DynamicForms\Areas\PlugAndPlay\MapUtil\MapUtil.cs`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Tables\Transporte\T_PONTOS_MAPA.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Tables\Transporte\T_MAPA.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Tables\Transporte\T_ROTAS_FACTIVEIS.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Tables\Transporte\T_ROTA_REALIZADA.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Views\V_CARGASWEB.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Views\TRANSPORTE\V_PONTOS_ENTREGA.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Views\TRANSPORTE\V_DATASET_EXPEDICAO_CARGA.sql`
- `C:\Users\AngeloRicardoFontana\Source\Workspaces\APS Net 7\DBPlugPlay\dbo\Views\TRANSPORTE\V_CARGAS_EM_TRANSITO.sql`

## Conceitos Encontrados No Legado

### Ponto De Mapa

Tabela: `T_PONTOS_MAPA`.

Modelo: `PontosMapa`.

Representa um ponto logistico ou geografico. O proprio comentario da tabela
indica que um ponto pode ser cidade, rua, rodovia, cliente, bairro, regiao, CEP
ou latitude/longitude solta.

Campos principais:

- `PON_ID`: identificador do ponto.
- `PON_DESCRICAO`: nome/descricao.
- `PON_TIPO`: tipo do ponto.
- `PON_LATITUDE` e `PON_LONGITUDE`: coordenadas.
- `PON_DISTANCIA_KM`: distancia auxiliar usada em projections/otimizacao.

Tipos conhecidos:

- `CID`: cidade.
- `RUA`: rua.
- `ROD`: rodovia.
- `CLI`: cliente.
- `BAI`: bairro.
- `REG`: regiao.
- `CEP`: CEP.
- `LLE`: latitude/longitude.

### Mapa

Tabela: `T_MAPA`.

Modelo: `Mapa`.

Representa ligacoes entre pontos. E o grafo logistico do APS legado.

Campos principais:

- `MAP_ID`: id interno.
- `PON_ID`: ponto origem.
- `PON_ID_VIZINHO`: ponto vizinho/destino.
- `MAP_DISTANCIA`: distancia.
- `MAP_CUSTO_PEDAGIO_POR_EIXO`: pedagio por eixo.
- `ROD_ID`: rodovia.
- `MAP_ALTURA_ROD`: restricao de altura.

Regra importante no legado:

- `Mapa.BeforeChanges` valida que origem e vizinho nao sejam iguais.
- Ao inserir uma ligacao `A -> B`, o codigo cria ou atualiza tambem `B -> A`.
- Ao excluir, a ligacao inversa tambem acompanha a alteracao.

No Yeshua, isso e comportamento de dominio de `Mapa`, nao regra fiscal.

### Rota Factivel

Tabela: `T_ROTAS_FACTIVEIS`.

Modelo: `RotaPontosMapa`.

Representa uma rota possivel entre origem e destino, composta por pontos
ordenados do roteiro.

Campos principais:

- `ROT_ID`: codigo da rota.
- `PON_ID_ORIGEM`: ponto origem.
- `PON_ID_DESTINO`: ponto destino.
- `PON_ID_ROTEIRO`: ponto que compoe o percurso.
- `ROT_ORDEM_ROTEIRO`: ordem do ponto no percurso.
- `ROT_CUSTO_TOTAL`: custo total da rota.
- `ROT_DISTANCIA`: distancia.
- `ROT_TIPO`: `AE` para A Estrela ou `MA` para manual.

O legado declarou chave composta por `ROT_ID`, destino, origem e ponto do
roteiro. No APS ADM do Yeshua a migracao foi simplificada com `Id` interno,
mantendo as colunas legadas como dados de negocio/transicao.

### Pedido Para Expedicao

Projection/modelo: `OrderOpt` e `PedidosParaExpedicao`.

Fonte principal de planejamento: `V_PEDIDOS_A_PLANEJAR_EXPEDICAO`.

O legado ja trazia no envelope do pedido:

- UF.
- municipio.
- municipio IBGE/id.
- bairro.
- endereco.
- CEP.
- ponto de municipio.
- ponto de regiao.
- distancia por municipio/regiao.
- carga atual.
- janela de embarque.
- dados de cubagem/peso.

Regra importante:

- Quando o pedido informa outro municipio ou outra regiao de entrega, o legado
  trata como entrega triangular.
- Se existir regiao e nao houver conflito de municipio, o destino operacional
  pode ser a regiao.
- Se houver municipio triangular diferente, o destino volta a ser a cidade,
  ignorando a regiao do cliente.

Essa logica tambem aparece em `V_CARGASWEB`.

### Pontos De Entrega

View: `V_PONTOS_ENTREGA`.

Modelo: `PontosEntrega`.

Representa os pontos de entrega de uma carga ou de um dia.

Campos principais:

- `CAR_ID`: carga.
- `ORD_ID`: pedido.
- `ITC_ORDEM_ENTREGA`: sequencia planejada de entrega.
- `MUN_ID_ENTREGA`: municipio.
- `UF_ID_ENTREGA`: UF.
- `ORD_REGIAO_ENTREGA`: regiao.
- `ORD_ENDERECO_ENTREGA`, `ORD_BAIRRO_ENTREGA`, `ORD_CEP_ENTREGA`.
- latitude/longitude efetiva.

Regra importante:

- Se o pedido tem latitude/longitude propria, usa a coordenada do pedido.
- Senao usa a coordenada do ponto de mapa do municipio.

O controller `PontoMapaController.ObterPontosEntrega` monta tambem um link do
Google Maps usando a origem configurada e os pontos de entrega ordenados.

### Origem Da Expedicao

O ponto origem e buscado pelo parametro:

- `EXPEDICAO_ID_PONTO_MAPA_ORIGEM`

Esse parametro aparece em:

- `APSController.OtimizarCarga`.
- `PontoMapaController.PontosEntrega`.
- `PontoMapaController.ObterPontosEntrega`.
- `PainelGestaoTransporteController.Origem`.
- `PainelGestaoTransporteController.RotaCarga`.

Para o fluxo fiscal, essa origem precisa virar parte explicita do snapshot da
carga.

### Rota Realizada

Tabela: `T_ROTA_REALIZADA`.

Modelo: `RotaRealizada`.

Representa rastreio real da carga em transito:

- `CAR_ID`.
- `ROT_DATA_HORA`.
- `ROT_LAT`.
- `ROT_LONG`.

View: `V_CARGAS_EM_TRANSITO`.

Essa view pega a ultima coordenada por carga com status entre 6 e 7.

Importante:

- Essa informacao e pos-saida. Serve para acompanhamento, prova operacional,
  canhoto, encerramento ou auditoria.
- Ela nao deve ser a fonte principal para emitir CT-e/MDF-e, porque o fiscal
  precisa do plano antes ou no momento da emissao.

### Roteirizador OSM/Itinero

Arquivos:

- `RoteirizadorController.cs`
- `MapUtil.cs`

O legado tem uma prova tecnica com Itinero, OSM e KDTree:

- carrega arquivo OSM para `RouterDb`;
- resolve pontos por latitude/longitude;
- calcula rota de caminhao;
- calcula TSP para multiplos pontos;
- exporta GeoJSON.

Pelo codigo encontrado, isso estava mais proximo de experimento/prototipo do
que de caminho operacional obrigatorio do fiscal.

## Como O Legado Funcionava Na Pratica

O desenho funcional era este:

1. `T_PONTOS_MAPA` mantinha cidades, regioes e outros pontos logisticos.
2. `T_MAPA` guardava ligacoes entre pontos.
3. `Mapa.BeforeChanges` mantinha a ligacao inversa do grafo.
4. `T_ROTAS_FACTIVEIS` guardava rotas possiveis e pontos ordenados do percurso.
5. Pedidos e clientes informavam municipio/regiao/endereco de entrega.
6. Views como `V_PEDIDOS_A_PLANEJAR_EXPEDICAO`, `V_CARGASWEB` e
   `V_DATASET_EXPEDICAO` montavam projections para planejamento.
7. `V_PONTOS_ENTREGA` resolvia os pontos efetivos da carga, com coordenadas e
   ordem de entrega.
8. Telas de mapa usavam origem configurada + pontos de entrega para mostrar a
   rota ao usuario.
9. `T_ROTA_REALIZADA` guardava coordenadas reais depois que a carga entrava em
   transito.

## Alimentacao Dos Pontos De Mapa

As procedures de interface tambem alimentavam `T_PONTOS_MAPA` a partir de
`T_MUNICIPIOS`.

Padrao encontrado:

- inserir municipio em `T_PONTOS_MAPA`;
- usar `MUN_ID` como `PON_ID`;
- usar latitude/longitude do municipio;
- marcar como ponto de cidade.

Observacao importante:

- a maior parte do codigo trabalha com `PON_TIPO = 'CID'`;
- alguns scripts antigos de Softbox aparecem procurando `PON_TIPO = 'MUN'`;
- isso deve virar regra explicita de conversao/saneamento, porque cidade fiscal
  nao pode depender dessa variacao historica.

## Tres Significados Diferentes De Rota

No legado, a palavra rota aparece com tres sentidos diferentes.

### Rota De Planejamento

E o agrupamento operacional usado para montar carga:

- UF.
- municipio.
- regiao.
- bairro.
- rota factivel.
- carga aberta.
- janela de embarque.

Fonte: projections de planejamento e tela de expedicao.

### Percurso Planejado

E por onde a carga deve passar.

Fonte preferencial:

- `T_ROTAS_FACTIVEIS` + `T_PONTOS_MAPA` + municipio/UF.

Fallback:

- origem + pontos de entrega ordenados por `ITC_ORDEM_ENTREGA`.

### Rota Realizada

E por onde a carga passou de fato.

Fonte:

- `T_ROTA_REALIZADA`.

Uso:

- acompanhamento em transito;
- canhoto;
- auditoria;
- comparacao planejado x realizado;
- possivel suporte a encerramento posterior.

## O Que Ja Existe No Yeshua

No APS ADM:

- `PontosMapa` ja esta declarado com `LegacySource("T_PONTOS_MAPA")`.
- `Mapa` ja esta declarado com `LegacySource("T_MAPA")`.
- `RotaPontosMapa` ja esta declarado com `LegacySource("T_ROTAS_FACTIVEIS")`.
- `RotaRealizada` ja esta declarado com `LegacySource("T_ROTA_REALIZADA")`.
- `PedidoPlanejavel` ja tem `Estado`, `Municipio`, `Regiao`, `Bairro` e
  `RotaId`.
- `CargaPlanejavel` ja representa cargas operacionais para a tela.
- A saga `CargaStandard` publica `CargaProntaParaEmissaoFiscal.v1` para o
  modulo Fiscal.

No Fiscal:

- `CTeRomaneioConsolidado` ja possui `RotaSnapshotJson` e
  `CargaSnapshotJson`.
- `MDFeSolicitacaoFiscal` ja possui `TransporteSnapshotJson`.
- `MDFePercurso` ja existe para percurso por UF.
- A saga `EmissaoFiscalCargaStandard` ja inicia por
  `CargaProntaParaEmissaoFiscal.v1`.

## Lacuna Atual

O `CargaFiscalSnapshotBuilder` do APS ADM ainda esta muito simples.

Ele carrega:

- carga;
- veiculo;
- transportadora;
- alguns dados basicos de peso/volume;
- pendencias fiscais.

Ele ainda nao carrega de forma forte:

- origem de expedicao;
- pontos de entrega da carga;
- municipios e UFs de entrega;
- ordem de entrega;
- documentos originarios por pedido/nota;
- rota factivel associada;
- cidades/UFs do percurso planejado;
- fonte/confianca da rota.

Portanto, o Fiscal ja tem onde guardar rota, mas o APS ainda nao entrega uma
rota fiscalmente suficiente.

## Proposta De Integracao

Criar no APS ADM um provedor customizado de snapshot fiscal da carga.

Nome sugerido:

- `CargaFiscalSnapshotProvider`

Responsabilidade:

- ler dados internos do APS;
- montar um contrato canonico;
- entregar ao evento `CargaProntaParaEmissaoFiscal.v1`;
- nao expor tabelas internas ao Fiscal.

O Fiscal deve continuar recebendo por API/inbox/outbox Yeshua. Ele nao deve
consultar tabelas do APS.

## Contrato Sugerido Para Rota Fiscal

Dentro de `CargaProntaParaEmissaoFiscal.v1`, a parte de rota deveria evoluir
para algo nesta linha:

```csharp
public sealed class CargaFiscalRotaSnapshot
{
    public CargaFiscalPontoSnapshot Origem { get; set; }
    public CargaFiscalPontoSnapshot DestinoFinal { get; set; }
    public List<CargaFiscalPontoEntregaSnapshot> PontosEntrega { get; set; }
    public List<CargaFiscalPontoPercursoSnapshot> PontosPercurso { get; set; }
    public List<string> UfsEntrega { get; set; }
    public List<string> UfsPercurso { get; set; }
    public string FontePercurso { get; set; }
    public string ConfiancaPercurso { get; set; }
}
```

Campos importantes por ponto:

- ponto id;
- tipo do ponto;
- descricao;
- municipio IBGE;
- municipio nome;
- UF;
- latitude;
- longitude;
- ordem;
- pedido id;
- nota id quando houver.

## Regra De Extracao Fiscal

### Origem

Buscar pelo parametro `EXPEDICAO_ID_PONTO_MAPA_ORIGEM`.

Depois resolver:

- `PON_ID`;
- descricao;
- latitude/longitude;
- municipio IBGE quando o ponto for cidade;
- UF pela tabela de municipios.

### Entregas

Buscar pela carga:

- `T_CARGA`;
- `T_ITENS_CARGA`;
- `T_ORDENS`;
- `T_CLIENTES`;
- `T_MUNICIPIOS`;
- `T_PONTOS_MAPA`.

Aplicar a mesma regra operacional do legado:

- pedido pode sobrescrever municipio/regiao do cliente;
- entrega triangular deve preservar municipio real;
- quando municipio triangular conflita com regiao, usar cidade como destino
  operacional.

Ordenar por:

- `ITC_ORDEM_ENTREGA`.

### Percurso

Primeira fonte:

- `T_ROTAS_FACTIVEIS`, quando a carga ou a selecao tiver `ROT_ID` confiavel.

Resolucao:

- ordenar por `ROT_ORDEM_ROTEIRO`;
- juntar `PON_ID_ROTEIRO` em `T_PONTOS_MAPA`;
- quando `PON_TIPO = 'CID'`, juntar `PON_ID` em `T_MUNICIPIOS` para extrair
  UF e municipio;
- montar `UfsPercurso` ordenado e sem repeticao consecutiva.

Fallback:

- origem + pontos de entrega ordenados.

Nesse fallback, a confianca deve ser marcada como menor, porque ele prova onde
a carga entrega, mas nao prova todos os estados intermediarios por onde passa.

### Realizado

`T_ROTA_REALIZADA` nao entra no snapshot de emissao por padrao.

Ele entra depois como:

- auditoria;
- monitoramento;
- comparacao planejado x realizado;
- apoio a canhoto;
- possivel evento de encerramento ou pos-operacao.

## Performance

Para extrema velocidade:

- montar o snapshot uma vez, no step `publicarCargaProntaParaEmissaoFiscal`;
- usar consultas estreitas, somente com campos fiscais/logisticos necessarios;
- nao fazer calculo OSM/Itinero no caminho quente de emissao;
- nao deixar Fiscal consultar APS;
- guardar no evento dados suficientes para o Fiscal trabalhar sozinho;
- cachear `ROT_ID -> pontos/UFs do percurso` quando a rota factivel for estavel;
- invalidar cache quando `T_ROTAS_FACTIVEIS`, `T_PONTOS_MAPA` ou `T_MAPA`
  mudarem;
- quando nao houver rota factivel, enviar fallback explicito em vez de tentar
  descobrir percurso caro durante a emissao.

## Como Isso Encaixa Na Saga

Fluxo proposto:

1. `CargaStandard.prepararCargaParaFiscal`
   - valida se a carga tem dados minimos.
   - opcionalmente registra pendencias.
2. `CargaStandard.publicarCargaProntaParaEmissaoFiscal`
   - chama `CargaFiscalSnapshotProvider`.
   - monta o contrato completo.
   - publica `CargaProntaParaEmissaoFiscal.v1`.
3. Fiscal recebe pelo endpoint `/yapi/Fiscal/Inbox/YeshuaModuleEvent`.
4. Bridge do Fiscal inicia `EmissaoFiscalCargaStandard`.
5. `EmissaoFiscalCargaStandard.receberCargaProntaParaEmissaoFiscal`
   - grava/normaliza snapshot.
   - popula `CTeRomaneioConsolidado.RotaSnapshotJson`.
   - popula `MDFeSolicitacaoFiscal.TransporteSnapshotJson`.
   - cria `MDFePercurso` a partir de `UfsPercurso` quando aplicavel.

## Decisao Recomendada

Seguir com um contrato de snapshot da carga fiscal produzido pelo APS e
consumido pelo Fiscal.

O APS e dono de:

- carga;
- pedidos;
- itens da carga;
- sequencia de entrega;
- origem operacional;
- rota planejada/factivel;
- pontos e UFs do percurso planejado;
- dados de transporte disponiveis no planejamento.

O Fiscal e dono de:

- normalizacao fiscal;
- CT-e;
- MDF-e;
- regras SEFAZ;
- XML;
- assinatura;
- autorizacao;
- retorno fiscal.

## Pendencias Arquiteturais

- `pendencia`: criar contrato oficial `CargaProntaParaEmissaoFiscal.v1` com
  rota, entregas, documentos originarios, transporte e preferencias fiscais.
- `pendencia`: decidir se `CargaFiscalSnapshotProvider` nasce como use case
  declarado na DSL ou como servico custom interno chamado pelo step da saga.
- `pendencia`: evoluir `CargaFiscalSnapshotBuilder` para buscar pontos de
  entrega e percurso planejado.
- `pendencia`: definir cache leve para rota factivel por `ROT_ID`.
- `pendencia`: decidir como resolver UF de pontos que nao sao cidade
  (`REG`, `ROD`, `BAI`, `CEP`, `LLE`).
- `pendencia`: normalizar dados legados que tratam cidade como `CID` em quase
  todo o sistema, mas aparecem como `MUN` em scripts antigos de interface.
- `pendencia`: separar no contrato `UfsEntrega` de `UfsPercurso`, pois sao
  conceitos fiscais/operacionais diferentes.
- `pendencia`: definir se o fallback origem + entregas e aceitavel para P0 de
  MDF-e ou se exige rota factivel completa para cargas interestaduais.
