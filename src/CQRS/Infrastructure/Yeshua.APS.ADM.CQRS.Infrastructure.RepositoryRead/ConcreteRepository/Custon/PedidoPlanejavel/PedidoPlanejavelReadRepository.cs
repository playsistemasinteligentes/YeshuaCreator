// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read.Repository
{
    public partial class PedidoPlanejavelReadRepository
    {
        private static readonly IReadOnlyDictionary<string, string> PlanejamentoFields =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Estado"] = "estado",
                ["Municipio"] = "municipio",
                ["Regiao"] = "regiao",
                ["Bairro"] = "bairro",
                ["RotaId"] = "rotaid"
            };

        public PlanejamentoTransporteContextDTO GetPlanejamentoContext(DateTime embarqueDe, DateTime embarqueAte, int limitePedidos)
        {
            var parameters = CreateBaseParameters(embarqueDe, embarqueAte, limitePedidos);
            var sql = BasePedidoPlanejavelCte() + @"
SELECT
    COUNT(1) AS quantidadepedidos,
    ISNULL(SUM(peso), 0) AS peso,
    ISNULL(SUM(volume), 0) AS volume
FROM Pedidos;";

            var result = _unitOfWork.QueryFirstOrDefault<PlanejamentoTransporteContextDTO>(sql, parameters)
                ?? new PlanejamentoTransporteContextDTO();

            result.quantidadecargas = _unitOfWork.QueryFirstOrDefault<int>(@"
SELECT COUNT(1)
FROM [Carga]
WHERE ([Deleted] IS NULL OR [Deleted] = 0)
  AND ISNULL([CAR_STATUS], 0) < 9;", null);

            return result;
        }

        public IEnumerable<PlanejamentoTransporteLensGroupDTO> GetPlanejamentoLensGroups(
            DateTime embarqueDe,
            DateTime embarqueAte,
            int limitePedidos,
            IReadOnlyDictionary<string, string> filtros,
            string campoAgrupamento)
        {
            var field = ResolveField(campoAgrupamento);
            var parameters = CreateBaseParameters(embarqueDe, embarqueAte, limitePedidos);
            var where = AppendFilters(parameters, filtros);

            var sql = BasePedidoPlanejavelCte() + $@"
SELECT
    {field} AS valor,
    COUNT(1) AS quantidadepedidos,
    ISNULL(SUM(peso), 0) AS peso,
    ISNULL(SUM(volume), 0) AS volume
FROM Pedidos
{where}
GROUP BY {field}
ORDER BY {field};";

            return _unitOfWork.Query<PlanejamentoTransporteLensGroupDTO>(sql, parameters);
        }

        public IEnumerable<PedidoPlanejavelDTO> GetPlanejamentoPedidos(
            DateTime embarqueDe,
            DateTime embarqueAte,
            int limitePedidos,
            IReadOnlyDictionary<string, string> filtros)
        {
            var parameters = CreateBaseParameters(embarqueDe, embarqueAte, limitePedidos);
            var where = AppendFilters(parameters, filtros);

            var sql = BasePedidoPlanejavelCte() + $@"
SELECT *
FROM Pedidos
{where}
ORDER BY estado, municipio, regiao, bairro, pedidoid;";

            return _unitOfWork.Query<PedidoPlanejavelDTO>(sql, parameters);
        }

        public IEnumerable<PedidoPlanejavelDTO> GetPlanejamentoPedidosByIds(
            DateTime embarqueDe,
            DateTime embarqueAte,
            int limitePedidos,
            IEnumerable<string> pedidoIds)
        {
            var ids = pedidoIds
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (ids.Length == 0)
                return Enumerable.Empty<PedidoPlanejavelDTO>();

            var parameters = CreateBaseParameters(embarqueDe, embarqueAte, Math.Max(limitePedidos, ids.Length));
            parameters.Add("PedidoIds", ids);

            var sql = BasePedidoPlanejavelCte() + @"
SELECT *
FROM Pedidos
WHERE pedidoid IN @PedidoIds
ORDER BY estado, municipio, regiao, bairro, pedidoid;";

            return _unitOfWork.Query<PedidoPlanejavelDTO>(sql, parameters);
        }

        partial void TryGetPedidoPlanejavelCustom(Command.Read.PedidoPlanejavelReadCommand command, ref DataPagination<PedidoPlanejavelDTO> result, ref bool handled)
        {
            var pageSize = command.Paginacao?.PageSize ?? 100;
            var limite = NormalizeLimit(pageSize <= 0 ? 100 : pageSize);
            var pedidos = GetPlanejamentoPedidos(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(7), limite, new Dictionary<string, string>()).ToList();

            result = new DataPagination<PedidoPlanejavelDTO>(
                pedidos,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? pedidos.Count,
                command.Paginacao?.PageWhithCount ?? false ? pedidos.Count : null);

            handled = true;
        }

        private static DynamicParameters CreateBaseParameters(DateTime embarqueDe, DateTime embarqueAte, int limitePedidos)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmbarqueDe", embarqueDe.Date);
            parameters.Add("EmbarqueAte", embarqueAte.Date);
            parameters.Add("LimitePedidos", NormalizeLimit(limitePedidos));
            return parameters;
        }

        private static int NormalizeLimit(int limitePedidos)
        {
            if (limitePedidos < 50)
                return 50;

            if (limitePedidos > 5000)
                return 5000;

            return limitePedidos;
        }

        private static string AppendFilters(DynamicParameters parameters, IReadOnlyDictionary<string, string> filtros)
        {
            if (filtros == null || filtros.Count == 0)
                return string.Empty;

            var sql = new StringBuilder("WHERE 1 = 1");
            var index = 0;

            foreach (var item in filtros)
            {
                if (!PlanejamentoFields.TryGetValue(item.Key, out var field) || string.IsNullOrWhiteSpace(item.Value))
                    continue;

                var parameterName = "Filtro" + index++;
                sql.Append(" AND ").Append(field).Append(" = @").Append(parameterName);
                parameters.Add(parameterName, item.Value);
            }

            return sql.Length == "WHERE 1 = 1".Length ? string.Empty : sql.ToString();
        }

        private static string ResolveField(string field)
        {
            if (PlanejamentoFields.TryGetValue(field ?? string.Empty, out var resolved))
                return resolved;

            throw new ArgumentOutOfRangeException(nameof(field), field, "Campo de lente nao suportado.");
        }

        private static string BasePedidoPlanejavelCte()
        {
            return @"
WITH Pedidos AS
(
    SELECT TOP (@LimitePedidos)
        o.[ORD_ID] AS pedidoid,
        o.[CLI_ID] AS clienteid,
        COALESCE(NULLIF(LTRIM(RTRIM(c.[CLI_NOME])), ''), o.[CLI_ID], '') AS clientenome,
        COALESCE(NULLIF(LTRIM(RTRIM(o.[UF_ID_ENTREGA])), ''), NULLIF(LTRIM(RTRIM(m.[UF_COD])), ''), 'NA') AS estado,
        COALESCE(NULLIF(LTRIM(RTRIM(m.[MUN_NOME])), ''), NULLIF(LTRIM(RTRIM(o.[MUN_ID_ENTREGA])), ''), 'Sem municipio') AS municipio,
        COALESCE(NULLIF(LTRIM(RTRIM(o.[ORD_REGIAO_ENTREGA])), ''), 'Sem regiao') AS regiao,
        COALESCE(NULLIF(LTRIM(RTRIM(o.[ORD_BAIRRO_ENTREGA])), ''), 'Sem bairro') AS bairro,
        COALESCE(NULLIF(LTRIM(RTRIM(o.[GRP_ID])), ''), NULLIF(LTRIM(RTRIM(o.[ORD_REGIAO_ENTREGA])), ''), 'Sem rota') AS rotaid,
        COALESCE(o.[ORD_EMBARQUE_ALVO], o.[ORD_INICIO_JANELA_EMBARQUE], o.[ORD_DATA_ENTREGA_DE], o.[ORD_DATA_ENTREGA_ATE]) AS embarquealvo,
        o.[ORD_DATA_ENTREGA_DE] AS dataentregade,
        o.[ORD_DATA_ENTREGA_ATE] AS dataentregaate,
        CAST(ISNULL(o.[ORD_QUANTIDADE], 0) * COALESCE(o.[ORD_PESO_UNITARIO_BRUTO], o.[ORD_PESO_UNITARIO], 0) AS decimal(18, 6)) AS peso,
        CAST(ISNULL(o.[ORD_QUANTIDADE], 0) * ISNULL(o.[ORD_M2_UNITARIO], 0) AS decimal(18, 6)) AS volume,
        CAST(ISNULL(o.[ORD_QUANTIDADE], 0) AS decimal(18, 6)) AS saldoaexpedir,
        COALESCE(NULLIF(LTRIM(RTRIM(o.[ORD_STATUS])), ''), NULLIF(LTRIM(RTRIM(o.[ORD_STATUS_PLANEJAMENTO])), ''), 'Aberto') AS status,
        ic.[CAR_ID] AS cargaatualid,
        CONCAT(o.[ORD_ID], '|', CONVERT(varchar(19), ISNULL(o.[Changed], CONVERT(datetime, '19000101', 112)), 126)) AS versaoplanejamento,
        CASE
            WHEN ic.[CAR_ID] IS NOT NULL THEN 'Pedido ja vinculado a carga'
            WHEN o.[ORD_EMBARQUE_ALVO] IS NULL AND o.[ORD_INICIO_JANELA_EMBARQUE] IS NULL THEN 'Sem janela de embarque'
            ELSE ''
        END AS alertasresumo
    FROM [Order] o
    LEFT JOIN [Cliente] c ON c.[CLI_ID] = o.[CLI_ID]
    LEFT JOIN [Municipio] m ON m.[MUN_ID] = o.[MUN_ID_ENTREGA]
    OUTER APPLY
    (
        SELECT TOP 1 it.[CAR_ID]
        FROM [ItenCarga] it
        INNER JOIN [Carga] car ON car.[CAR_ID] = it.[CAR_ID]
          AND (car.[Deleted] IS NULL OR car.[Deleted] = 0)
          AND ISNULL(car.[CAR_STATUS], 0) < 9
        WHERE it.[ORD_ID] = o.[ORD_ID]
          AND (it.[Deleted] IS NULL OR it.[Deleted] = 0)
        ORDER BY it.[Changed] DESC, it.[Id] DESC
    ) ic
    WHERE (o.[Deleted] IS NULL OR o.[Deleted] = 0)
      AND COALESCE(o.[ORD_EMBARQUE_ALVO], o.[ORD_INICIO_JANELA_EMBARQUE], o.[ORD_DATA_ENTREGA_DE], o.[ORD_DATA_ENTREGA_ATE]) >= @EmbarqueDe
      AND COALESCE(o.[ORD_EMBARQUE_ALVO], o.[ORD_INICIO_JANELA_EMBARQUE], o.[ORD_DATA_ENTREGA_DE], o.[ORD_DATA_ENTREGA_ATE]) < DATEADD(day, 1, @EmbarqueAte)
    ORDER BY COALESCE(o.[ORD_EMBARQUE_ALVO], o.[ORD_INICIO_JANELA_EMBARQUE], o.[ORD_DATA_ENTREGA_DE], o.[ORD_DATA_ENTREGA_ATE]), o.[UF_ID_ENTREGA], o.[MUN_ID_ENTREGA], o.[ORD_ID]
)
";
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
