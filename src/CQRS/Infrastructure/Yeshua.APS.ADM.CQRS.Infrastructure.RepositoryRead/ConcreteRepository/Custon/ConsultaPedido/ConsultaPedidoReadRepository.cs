// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Command.Read;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Repository;
using System.Dynamic;

namespace Read.Repository
{
    public partial class ConsultaPedidoReadRepository
    {
        partial void TryGetConsultaPedidoCustom(
            ConsultaPedidoReadCommand command,
            ref DataPagination<ConsultaPedidoDTO> result,
            ref bool handled)
        {
            handled = true;

            var whereClauses = new List<string>
            {
                "o.TenantID = @TenantID",
                "o.Deleted = @Deleted"
            };

            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            dict["TenantID"] = _executionContext.TenantID;
            dict["Deleted"] = false;

            AddStringFilter(whereClauses, dict, "PedidoId", command.PedidoId, "o.ORD_ID");
            AddStringFilter(whereClauses, dict, "ClienteId", command.ClienteId, "o.CLI_ID");
            AddStringFilter(whereClauses, dict, "ClienteNome", command.ClienteNome, "c.CLI_NOME");
            AddStringFilter(whereClauses, dict, "RazaoSocial", command.RazaoSocial, "c.CLI_RAZAO_SOCIAL");
            AddStringFilter(whereClauses, dict, "ProdutoId", command.ProdutoId, "o.PRO_ID");
            AddStringFilter(whereClauses, dict, "ProdutoDescricao", command.ProdutoDescricao, "p.Descricao");
            AddStringFilter(whereClauses, dict, "Status", command.Status, "o.ORD_STATUS");
            AddStringFilter(whereClauses, dict, "Estagio", command.Estagio, "o.ORD_STATUS_PLANEJAMENTO");
            AddStringFilter(whereClauses, dict, "CorFila", command.CorFila, "o.ORD_COR_FILA");
            AddStringFilter(whereClauses, dict, "PedidoCliente", command.PedidoCliente, "o.ORD_PED_CLI");

            var page = command.Paginacao?.Page ?? 1;
            var pageSize = command.Paginacao?.PageSize ?? 20;
            var offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;

            var sql = $@"
select
    o.ORD_ID as pedidoid,
    o.CLI_ID as clienteid,
    coalesce(c.CLI_NOME, '') as clientenome,
    coalesce(c.CLI_RAZAO_SOCIAL, '') as razaosocial,
    o.PRO_ID as produtoid,
    coalesce(p.Descricao, '') as produtodescricao,
    coalesce(o.ORD_STATUS, '') as status,
    coalesce(o.ORD_STATUS_PLANEJAMENTO, o.ORD_STATUS, '') as estagio,
    o.ORD_DATA_ENTREGA_DE as dataentregade,
    o.ORD_DATA_ENTREGA_ATE as dataentregaate,
    coalesce(o.ORD_EMBARQUE_ALVO, o.ORD_DATA_ENTREGA_DE) as embarquealvo,
    o.ORD_QUANTIDADE as quantidade,
    o.ORD_QUANTIDADE as saldoaproduzir,
    o.ORD_QUANTIDADE as saldoaexpedir,
    coalesce(o.ORD_COR_FILA, '') as corfila,
    coalesce(o.ORD_PED_CLI, '') as pedidocliente
from [Order] o
left join Cliente c
    on c.CLI_ID = o.CLI_ID
    and c.TenantID = o.TenantID
    and c.Deleted = @Deleted
left join Produto p
    on p.Id = o.PRO_ID
    and p.TenantID = o.TenantID
    and p.Deleted = @Deleted
where {string.Join(" and ", whereClauses)}
order by o.ORD_ID
offset @Offset rows fetch next @PageSize rows only";

            var items = _unitOfWork.Query<ConsultaPedidoDTO>(sql, parameters).ToList();
            result = new DataPagination<ConsultaPedidoDTO>(
                items,
                page,
                pageSize,
                command.Paginacao?.PageWhithCount ?? false ? items.Count : 0);
        }

        private static void AddStringFilter(
            List<string> whereClauses,
            IDictionary<string, object> parameters,
            string parameterName,
            string value,
            string sqlColumn)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            parameters[parameterName] = $"%{value}%";
            whereClauses.Add($"{sqlColumn} like @{parameterName}");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
