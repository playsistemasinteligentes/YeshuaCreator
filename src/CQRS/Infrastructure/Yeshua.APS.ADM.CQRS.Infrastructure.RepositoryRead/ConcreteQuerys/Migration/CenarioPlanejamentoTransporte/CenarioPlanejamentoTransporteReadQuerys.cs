// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
using System.Data.SqlTypes;
using Command.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Query.Read 
{
    public class CenarioPlanejamentoTransporteQueryRead : QueryBase, ICenarioPlanejamentoTransporteQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CenarioPlanejamentoTransporteQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CenarioPlanejamentoTransporteQuery(Command.Read.CenarioPlanejamentoTransporteReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo from CenarioPlanejamentoTransporte ";
if (!string.IsNullOrEmpty(Command.CenarioId)) dict["CenarioId"] = $"%{Command.CenarioId}%";
if (!string.IsNullOrEmpty(Command.CenarioId)) whereClauses.Add($"CenarioId like @CenarioId");
if (!string.IsNullOrEmpty(Command.Descricao)) dict["Descricao"] = $"%{Command.Descricao}%";
if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"Descricao like @Descricao");
if (!string.IsNullOrEmpty(Command.Objetivo)) dict["Objetivo"] = $"%{Command.Objetivo}%";
if (!string.IsNullOrEmpty(Command.Objetivo)) whereClauses.Add($"Objetivo like @Objetivo");
if (Command.QuantidadeCargas.HasValue) dict["QuantidadeCargas"] = Command.QuantidadeCargas.Value;
if (Command.QuantidadeCargas.HasValue) whereClauses.Add($"QuantidadeCargas = @QuantidadeCargas");
if (Command.QuantidadePedidosNaoAtendidos.HasValue) dict["QuantidadePedidosNaoAtendidos"] = Command.QuantidadePedidosNaoAtendidos.Value;
if (Command.QuantidadePedidosNaoAtendidos.HasValue) whereClauses.Add($"QuantidadePedidosNaoAtendidos = @QuantidadePedidosNaoAtendidos");
if (!string.IsNullOrEmpty(Command.AlertasResumo)) dict["AlertasResumo"] = $"%{Command.AlertasResumo}%";
if (!string.IsNullOrEmpty(Command.AlertasResumo)) whereClauses.Add($"AlertasResumo like @AlertasResumo");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY CenarioId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ExistsByCenarioIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["CenarioId"] = value; //04
                      whereClauses.Add($" CenarioId = @CenarioId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["Descricao"] = value; //04
                      whereClauses.Add($" Descricao = @Descricao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByObjetivoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["Objetivo"] = value; //04
                      whereClauses.Add($" Objetivo = @Objetivo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadeCargasQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["QuantidadeCargas"] = value; //04
                      whereClauses.Add($" QuantidadeCargas = @QuantidadeCargas ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadePedidosNaoAtendidosQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["QuantidadePedidosNaoAtendidos"] = value; //04
                      whereClauses.Add($" QuantidadePedidosNaoAtendidos = @QuantidadePedidosNaoAtendidos ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCustoTotalQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["CustoTotal"] = value; //04
                      whereClauses.Add($" CustoTotal = @CustoTotal ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAderenciaCubagemQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["AderenciaCubagem"] = value; //04
                      whereClauses.Add($" AderenciaCubagem = @AderenciaCubagem ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAtrasoPrevistoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["AtrasoPrevisto"] = value; //04
                      whereClauses.Add($" AtrasoPrevisto = @AtrasoPrevisto ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAlertasResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CenarioPlanejamentoTransporte ";
                      dict["AlertasResumo"] = value; //04
                      whereClauses.Add($" AlertasResumo = @AlertasResumo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCenarioIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["CenarioId"] = value; //06
                      whereClauses.Add($" CenarioId = @CenarioId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["Descricao"] = value; //06
                      whereClauses.Add($" Descricao = @Descricao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByObjetivoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["Objetivo"] = value; //06
                      whereClauses.Add($" Objetivo = @Objetivo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadeCargasQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["QuantidadeCargas"] = value; //06
                      whereClauses.Add($" QuantidadeCargas = @QuantidadeCargas ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadePedidosNaoAtendidosQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["QuantidadePedidosNaoAtendidos"] = value; //06
                      whereClauses.Add($" QuantidadePedidosNaoAtendidos = @QuantidadePedidosNaoAtendidos ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCustoTotalQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["CustoTotal"] = value; //06
                      whereClauses.Add($" CustoTotal = @CustoTotal ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAderenciaCubagemQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["AderenciaCubagem"] = value; //06
                      whereClauses.Add($" AderenciaCubagem = @AderenciaCubagem ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAtrasoPrevistoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["AtrasoPrevisto"] = value; //06
                      whereClauses.Add($" AtrasoPrevisto = @AtrasoPrevisto ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAlertasResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CenarioId, Descricao, Objetivo, QuantidadeCargas, QuantidadePedidosNaoAtendidos, CustoTotal, AderenciaCubagem, AtrasoPrevisto, AlertasResumo FROM CenarioPlanejamentoTransporte ";
                      dict["AlertasResumo"] = value; //06
                      whereClauses.Add($" AlertasResumo = @AlertasResumo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration