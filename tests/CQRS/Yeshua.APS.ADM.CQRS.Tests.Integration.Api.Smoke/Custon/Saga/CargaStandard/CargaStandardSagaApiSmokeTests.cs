// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Saga.CargaStandard;

public partial class CargaStandardSagaApiSmokeTests
{
    private const string BuscarContextoEndpoint = "yapi/APSADM/PlanejamentoTransporteBuscarContextoPlanejamentoTransporteUseCase";
    private const string AbrirNoLenteEndpoint = "yapi/APSADM/PlanejamentoTransporteAbrirNoLentePlanejamentoTransporteUseCase";
    private const string CriarCargaEndpoint = "yapi/APSADM/PlanejamentoTransporteCriarCargaDaSelecaoPlanejamentoTransporteUseCase";
    private const string CriarMunicipioEndpoint = "yapi/Municipio/PostMunicipio";
    private const string CriarClienteEndpoint = "yapi/Cliente/PostCliente";
    private const string CriarPontosMapaEndpoint = "yapi/PontosMapa/PostPontosMapa";
    private const string CriarPedidoEndpoint = "yapi/Order/PostOrder";

    partial void Configure(SagaSmokeTestOptions options)
    {
        options.Enabled = true;
        options.Timeout = TimeSpan.FromSeconds(240);
        options.PollInterval = TimeSpan.FromSeconds(2);
        options.BuildStartPayload = BuildContextPayload;
        options.StartSagaAsync = StartCargaStandardSagaAsync;
        options.BuildSagaReadPayload = BuildSagaReadPayload;
        options.IsExpectedOutcome = (saga, steps) =>
            GetInt(saga, "Status") == 2
            && StepHasStatus(steps, "LiberarCargaParaExpedicao", 5);
        options.AssertOutcome = AssertSagaCompletedEndToEnd;
    }

    private static JsonObject BuildContextPayload()
    {
        return new JsonObject
        {
            ["EmbarqueDe"] = DateTime.Today.AddDays(-30),
            ["EmbarqueAte"] = DateTime.Today.AddDays(90),
            ["PlantaId"] = string.Empty,
            ["LimitePedidos"] = 5000
        };
    }

    private static async Task<JsonObject> StartCargaStandardSagaAsync(HttpClient client, JsonObject payload, CancellationToken cancellationToken)
    {
        var pedidoSemeado = await EnsurePedidoPlanejavelAsync(client, cancellationToken);

        using var contextResponse = await client.PostAsJsonAsync(BuscarContextoEndpoint, payload, JsonOptions, cancellationToken);
        var contextState = await ApiResponseAssertions.ReadSuccessStateAsync(contextResponse);
        var contextData = GetResponsePayload(contextState);
        var quantidadePedidos = ApiJson.GetRequiredProperty(contextData, "QuantidadePedidos").GetValue<int>();
        Assert.True(quantidadePedidos > 0, "Nenhum PedidoPlanejavel foi encontrado para iniciar a saga CargaStandard.");

        var contextoId = ApiJson.GetRequiredProperty(contextData, "ContextoId").GetValue<string>();
        var pedidos = await LoadFirstPedidosAsync(client, contextoId, cancellationToken);
        Assert.True(pedidos.Count > 0, "A lente estado-municipio nao retornou pedidos para criar carga.");

        string? ultimaMensagem = null;
        foreach (var pedido in pedidos.OrderByDescending(pedido => string.Equals(GetString(pedido, "PedidoId"), pedidoSemeado, StringComparison.OrdinalIgnoreCase)))
        {
            var pedidoRefs = new JsonArray();
            pedidoRefs.Add(new JsonObject
            {
                ["PedidoId"] = GetString(pedido, "PedidoId"),
                ["VersaoPlanejamento"] = GetString(pedido, "VersaoPlanejamento") ?? string.Empty
            });

            var criarCargaPayload = new JsonObject
            {
                ["ContextoId"] = contextoId,
                ["Pedidos"] = pedidoRefs,
                ["TipoVeiculoId"] = string.Empty,
                ["Observacao"] = "Teste automatizado E2E da saga CargaStandard."
            };

            using var criarCargaResponse = await client.PostAsJsonAsync(CriarCargaEndpoint, criarCargaPayload, JsonOptions, cancellationToken);
            var criarCargaState = await ApiResponseAssertions.ReadSuccessStateAsync(criarCargaResponse);
            var criarCargaData = GetResponsePayload(criarCargaState);
            var criada = ApiJson.GetRequiredProperty(criarCargaData, "Criada").GetValue<bool>();
            ultimaMensagem = GetString(criarCargaData, "Mensagem") ?? "CriarCargaDaSelecaoPlanejamentoTransporte retornou Criada=false.";

            if (criada)
                return criarCargaState;
        }

        Assert.Fail(ultimaMensagem ?? "Nenhum pedido livre foi encontrado para iniciar a saga CargaStandard.");
        return new JsonObject();
    }

    private static async Task<string> EnsurePedidoPlanejavelAsync(HttpClient client, CancellationToken cancellationToken)
    {
        var municipioId = await CreateAndReadIdAsync(client, CriarMunicipioEndpoint, BuildMunicipioPayload(), "mun_id", cancellationToken);
        var clienteId = await CreateAndReadIdAsync(client, CriarClienteEndpoint, BuildClientePayload(municipioId), "cli_id", cancellationToken);
        var pontoId = await CreateAndReadIdAsync(client, CriarPontosMapaEndpoint, BuildPontosMapaPayload(), "pon_id", cancellationToken);
        return await CreateAndReadIdAsync(client, CriarPedidoEndpoint, BuildPedidoPayload(clienteId, municipioId, pontoId), "ord_id", cancellationToken);
    }

    private static async Task<string> CreateAndReadIdAsync(HttpClient client, string endpoint, JsonObject payload, string idPropertyName, CancellationToken cancellationToken)
    {
        using var response = await client.PostAsJsonAsync(endpoint, payload, JsonOptions, cancellationToken);
        var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);
        return ApiJson.GetRequiredProperty(state, "data", idPropertyName).GetValue<string>();
    }

    private static JsonObject BuildMunicipioPayload()
    {
        return new JsonObject
        {
            ["MUN_ID"] = ApiTestData.KeyText(12),
            ["MUN_NOME"] = "SAO PAULO",
            ["UF_COD"] = "SP",
            ["MUN_CODIGO_IBGE"] = "3550308",
            ["MUN_LATITUDE"] = -23.550520m,
            ["MUN_LONGITUDE"] = -46.633308m,
            ["MUN_ID_INTEGRACAO_ERP"] = ApiTestData.Text("MUN ERP", 80),
            ["MUN_CODIGO_SIAFI"] = "7107",
            ["MUN_CODIGO_CNPJ"] = "3550308",
            ["MUN_DISTANCIA_KM"] = 120.0m
        };
    }

    private static JsonObject BuildClientePayload(string municipioId)
    {
        return new JsonObject
        {
            ["CLI_ID"] = ApiTestData.KeyText(12),
            ["CLI_NOME"] = ApiTestData.Text("Cliente planejamento", 80),
            ["CLI_FONE"] = "11999999999",
            ["CLI_OBS"] = "Seed smoke saga CargaStandard",
            ["CLI_ENDERECO_ENTREGA"] = "Rua Teste 100",
            ["CLI_CPF_CNPJ"] = "00000000000191",
            ["CLI_BAIRRO_ENTREGA"] = "CENTRO",
            ["CLI_CEP_ENTREGA"] = "01001000",
            ["CLI_EMAIL"] = "seed@local.test",
            ["CLI_INTEGRACAO"] = ApiTestData.Text("CLI INT", 80),
            ["MUN_ID_ENTREGA"] = municipioId,
            ["CLI_TRANSLADO"] = 0m,
            ["CLI_REGIAO_ENTREGA"] = "CENTRO",
            ["CLI_EXIGENTE_NA_IMPRESSAO"] = 0,
            ["CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO"] = 0m,
            ["CLI_TEMPO_DESCARREGAMENTO_UNITARIO"] = 0m,
            ["CLI_PERCENTUAL_JANELA_EMBARQUE"] = 0m,
            ["REP_ID"] = "REP",
            ["CLI_RAZAO_SOCIAL"] = ApiTestData.Text("Cliente planejamento LTDA", 80),
            ["CLI_EMAIL_MONITORAMENTO_TRANSPORTE"] = "seed@local.test",
            ["CLI_CONTATO"] = "Teste",
            ["CLI_SETOR"] = "Logistica",
            ["SEG_ID"] = "SEG",
            ["CLI_TIPO"] = "C",
            ["CLI_INTEGRACAO_ERP"] = "ERP",
            ["CLI_LATITUDE_ENTREGA"] = -23.550520m,
            ["CLI_LONGITUDE_ENTREGA"] = -46.633308m
        };
    }

    private static JsonObject BuildPontosMapaPayload()
    {
        return new JsonObject
        {
            ["PON_ID"] = ApiTestData.KeyText(12),
            ["PON_DESCRICAO"] = "SAO PAULO CENTRO",
            ["PON_TIPO"] = "REG",
            ["PON_LATITUDE"] = -23.550520m,
            ["PON_LONGITUDE"] = -46.633308m,
            ["PON_DISTANCIA_KM"] = 120.0m
        };
    }

    private static JsonObject BuildPedidoPayload(string clienteId, string municipioId, string pontoId)
    {
        var embarque = DateTime.Today.AddDays(1).AddHours(8);
        return new JsonObject
        {
            ["ORD_ID"] = "APS" + ApiTestData.KeyText(12),
            ["ORD_ID_RESERVA"] = string.Empty,
            ["ORD_ID_CONJUNTO"] = "CONJ",
            ["PRO_ID"] = "PROD",
            ["PRO_ID_CONJUNTO"] = "PROD",
            ["CLI_ID"] = clienteId,
            ["ORD_PRECO_UNITARIO"] = 10m,
            ["ORD_QUANTIDADE"] = 100m,
            ["ORD_DATA_ENTREGA_DE"] = embarque,
            ["ORD_DATA_ENTREGA_ATE"] = embarque.AddHours(8),
            ["ORD_TIPO"] = 1,
            ["ORD_TOLERANCIA_MAIS"] = 0m,
            ["ORD_TOLERANCIA_MENOS"] = 0m,
            ["HASH_KEY"] = ApiTestData.Text("HASH", 80),
            ["ORD_INICIO_JANELA_EMBARQUE"] = embarque,
            ["ORD_FIM_JANELA_EMBARQUE"] = embarque.AddHours(8),
            ["ORD_EMBARQUE_ALVO"] = embarque,
            ["ORD_INICIO_GRUPO_PRODUTIVO"] = embarque,
            ["ORD_FIM_GRUPO_PRODUTIVO"] = embarque.AddHours(8),
            ["ORD_PESO_UNITARIO"] = 1.25m,
            ["ORD_PESO_UNITARIO_BRUTO"] = 1.30m,
            ["ORD_M2_UNITARIO"] = 0.75m,
            ["ORD_MIT"] = "MIT",
            ["CAR_TIPO_CARREGAMENTO"] = "NORMAL",
            ["ORD_STATUS"] = "ABERTO",
            ["ORD_TIPO_FRETE"] = "CIF",
            ["ORD_ENDERECO_ENTREGA"] = "Rua Teste 100",
            ["ORD_BAIRRO_ENTREGA"] = "CENTRO",
            ["UF_ID_ENTREGA"] = "SP",
            ["ORD_CEP_ENTREGA"] = "01001000",
            ["MUN_ID_ENTREGA"] = municipioId,
            ["ORD_REGIAO_ENTREGA"] = pontoId,
            ["ORD_LARGURA"] = 500m,
            ["ORD_COMPRIMENTO"] = 700m,
            ["ORD_GRAMATURA"] = 450m,
            ["GRP_ID"] = "ROTA-SP",
            ["ORD_ID_INTEGRACAO"] = ApiTestData.Text("ORD INT", 80),
            ["ORD_OBSERVACAO_OTIMIZADOR"] = "Seed smoke saga CargaStandard",
            ["ORD_COR_FILA"] = "AZUL",
            ["ORD_PED_CLI"] = ApiTestData.Text("PED CLI", 80),
            ["ORD_OP_INTEGRACAO"] = "OP",
            ["ORD_LOTE_PILOTO"] = "N",
            ["ORD_PRIORIDADE"] = 1,
            ["ORD_EMISSAO"] = DateTime.UtcNow,
            ["REP_ID"] = "REP",
            ["ORD_RESINA"] = "N",
            ["ORD_ENDURECEDOR_MIOLO"] = "N",
            ["PRO_ID_INTEGRACAO_ERP"] = "PROD",
            ["ORD_VINCOS_ONDULADEIRA"] = string.Empty,
            ["ORD_ERP_CUSTOS_FIXOS"] = 0m,
            ["ORD_ERP_CUSTOS_VARIAVEIS"] = 0m,
            ["ORD_ERP_DESPESAS_VAR_VENDA"] = 0m,
            ["ORD_ERP_IMPOSTOS"] = 0m,
            ["ORD_STATUS_PLANEJAMENTO"] = "PL",
            ["ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"] = 0,
            ["ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = 0,
            ["ORD_PROMOVE_DE"] = 0m,
            ["ORD_PROMOVE_ATE"] = 0m,
            ["ORD_TRAVA_COMPOSICAO"] = "N",
            ["ORD_TRAVA_RESINA"] = "N",
            ["ORD_PROMOVE_RESINA"] = "N",
            ["ORD_LATITUDE_ENTREGA"] = -23.550520m,
            ["ORD_LONGITUDE_ENTREGA"] = -46.633308m,
            ["TMP_TIPO_CARGA"] = "NORMAL",
            ["PRO_ID_PALETE"] = string.Empty,
            ["PRO_ID_TAMPO"] = string.Empty,
            ["ORD_PILHAS_POR_PALETE"] = 1,
            ["ORD_CHAPAS_POR_PILHA"] = 1,
            ["ORD_STATUS_ESTATISTICA"] = "OK",
            ["OCO_ID_MOTIVO_ATRASO"] = string.Empty,
            ["OTK_VERSSAO"] = 1
        };
    }

    private static JsonObject BuildSagaReadPayload(JsonObject startState, JsonObject _)
    {
        var data = GetResponsePayload(startState);
        var cargaId = ApiJson.GetRequiredProperty(data, "CargaId").GetValue<string>();

        return new JsonObject
        {
            ["EntityType"] = "Carga",
            ["EntityId"] = cargaId,
            ["Type"] = "CargaStandardSaga",
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 5)
        };
    }

    private static async Task<List<JsonObject>> LoadFirstPedidosAsync(HttpClient client, string contextoId, CancellationToken cancellationToken)
    {
        var estados = await OpenLensNodeAsync(client, contextoId, string.Empty, 0, cancellationToken);
        var pedidos = new List<JsonObject>();

        foreach (var estado in GetCandidateNodes(estados).Take(10))
        {
            var municipios = await OpenLensNodeAsync(client, contextoId, GetString(estado, "NoId") ?? string.Empty, 1, cancellationToken);
            foreach (var municipio in GetCandidateNodes(municipios).Take(10))
            {
                var leaf = await OpenLensNodeAsync(client, contextoId, GetString(municipio, "NoId") ?? string.Empty, 2, cancellationToken);
                pedidos.AddRange(GetArray(leaf, "Pedidos").OfType<JsonObject>());

                if (pedidos.Count >= 50)
                    return pedidos;
            }
        }

        return pedidos;
    }

    private static async Task<JsonObject> OpenLensNodeAsync(HttpClient client, string contextoId, string noId, int nivel, CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            ["ContextoId"] = contextoId,
            ["LenteId"] = "estado-municipio",
            ["NoId"] = noId,
            ["Nivel"] = nivel
        };

        using var response = await client.PostAsJsonAsync(AbrirNoLenteEndpoint, payload, JsonOptions, cancellationToken);
        return await ApiResponseAssertions.ReadSuccessStateAsync(response);
    }

    private static JsonObject PickFirstNode(JsonObject state, string levelName)
    {
        var node = GetCandidateNodes(state).FirstOrDefault();

        Assert.NotNull(node);
        return node!;
    }

    private static IEnumerable<JsonObject> GetCandidateNodes(JsonObject state)
    {
        return GetArray(state, "Nos")
            .OfType<JsonObject>()
            .Where(item => GetInt(item, "QuantidadePedidos") > 0)
            .OrderByDescending(item => GetInt(item, "QuantidadePedidos"));
    }

    private static JsonArray GetArray(JsonObject state, string propertyName)
    {
        var data = GetResponsePayload(state);
        var items = ApiJson.GetProperty(data, propertyName) as JsonArray;
        Assert.NotNull(items);
        return items!;
    }

    private static JsonObject GetResponsePayload(JsonObject state)
    {
        return ApiJson.GetProperty(state, "data") as JsonObject ?? state;
    }

    private static void AssertSagaCompletedEndToEnd(JsonObject saga, JsonArray steps)
    {
        var status = GetInt(saga, "Status");
        Assert.Equal(2, status);

        Assert.True(StepHasStatus(steps, "CriarCarga", 5), "O passo CriarCarga nao foi concluido.");
        Assert.True(StepHasStatus(steps, "PublicarCargaProntaParaEmissaoFiscal", 5), "O APS nao publicou a carga para o Fiscal.");
        Assert.True(StepHasStatus(steps, "AguardarResultadoFiscalDaCarga", 5), "O APS nao recebeu o retorno fiscal.");
        Assert.True(StepHasStatus(steps, "LiberarCargaParaExpedicao", 5), "A carga nao foi liberada para expedicao.");
    }

    private static bool StepHasStatus(JsonArray steps, string stepKey, int status)
    {
        return steps.OfType<JsonObject>().Any(step =>
            string.Equals(GetString(step, "StepKey"), stepKey, StringComparison.OrdinalIgnoreCase)
            && GetInt(step, "Status") == status);
    }

    private static string? GetString(JsonNode? node, string propertyName)
    {
        return ApiJson.GetProperty(node, propertyName)?.GetValue<string>();
    }

    private static int GetInt(JsonNode? node, string propertyName)
    {
        var value = ApiJson.GetProperty(node, propertyName);
        return value is null ? 0 : value.GetValue<int>();
    }
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
