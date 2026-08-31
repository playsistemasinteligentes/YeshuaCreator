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
    public class OpcaoPlanejamentoTransporteQueryRead : QueryBase, IOpcaoPlanejamentoTransporteQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public OpcaoPlanejamentoTransporteQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel OpcaoPlanejamentoTransporteQuery(Command.Read.OpcaoPlanejamentoTransporteReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo from OpcaoPlanejamentoTransporte ";
if (!string.IsNullOrEmpty(Command.OpcaoId)) dict["OpcaoId"] = $"%{Command.OpcaoId}%";
if (!string.IsNullOrEmpty(Command.OpcaoId)) whereClauses.Add($"OpcaoId like @OpcaoId");
if (!string.IsNullOrEmpty(Command.GrupoDecisaoId)) dict["GrupoDecisaoId"] = $"%{Command.GrupoDecisaoId}%";
if (!string.IsNullOrEmpty(Command.GrupoDecisaoId)) whereClauses.Add($"GrupoDecisaoId like @GrupoDecisaoId");
if (!string.IsNullOrEmpty(Command.RiscoResumo)) dict["RiscoResumo"] = $"%{Command.RiscoResumo}%";
if (!string.IsNullOrEmpty(Command.RiscoResumo)) whereClauses.Add($"RiscoResumo like @RiscoResumo");
if (!string.IsNullOrEmpty(Command.PedidosResumo)) dict["PedidosResumo"] = $"%{Command.PedidosResumo}%";
if (!string.IsNullOrEmpty(Command.PedidosResumo)) whereClauses.Add($"PedidosResumo like @PedidosResumo");
if (!string.IsNullOrEmpty(Command.OpcoesConflitantesResumo)) dict["OpcoesConflitantesResumo"] = $"%{Command.OpcoesConflitantesResumo}%";
if (!string.IsNullOrEmpty(Command.OpcoesConflitantesResumo)) whereClauses.Add($"OpcoesConflitantesResumo like @OpcoesConflitantesResumo");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY OpcaoId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ExistsByOpcaoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["OpcaoId"] = value; //04
                      whereClauses.Add($" OpcaoId = @OpcaoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGrupoDecisaoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["GrupoDecisaoId"] = value; //04
                      whereClauses.Add($" GrupoDecisaoId = @GrupoDecisaoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPesoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["Peso"] = value; //04
                      whereClauses.Add($" Peso = @Peso ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVolumeQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["Volume"] = value; //04
                      whereClauses.Add($" Volume = @Volume ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCustoEstimadoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["CustoEstimado"] = value; //04
                      whereClauses.Add($" CustoEstimado = @CustoEstimado ");//04
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
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["AderenciaCubagem"] = value; //04
                      whereClauses.Add($" AderenciaCubagem = @AderenciaCubagem ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAderenciaJanelaEntregaQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["AderenciaJanelaEntrega"] = value; //04
                      whereClauses.Add($" AderenciaJanelaEntrega = @AderenciaJanelaEntrega ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRiscoResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["RiscoResumo"] = value; //04
                      whereClauses.Add($" RiscoResumo = @RiscoResumo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPedidosResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["PedidosResumo"] = value; //04
                      whereClauses.Add($" PedidosResumo = @PedidosResumo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOpcoesConflitantesResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM OpcaoPlanejamentoTransporte ";
                      dict["OpcoesConflitantesResumo"] = value; //04
                      whereClauses.Add($" OpcoesConflitantesResumo = @OpcoesConflitantesResumo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOpcaoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["OpcaoId"] = value; //06
                      whereClauses.Add($" OpcaoId = @OpcaoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGrupoDecisaoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["GrupoDecisaoId"] = value; //06
                      whereClauses.Add($" GrupoDecisaoId = @GrupoDecisaoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPesoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["Peso"] = value; //06
                      whereClauses.Add($" Peso = @Peso ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVolumeQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["Volume"] = value; //06
                      whereClauses.Add($" Volume = @Volume ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCustoEstimadoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["CustoEstimado"] = value; //06
                      whereClauses.Add($" CustoEstimado = @CustoEstimado ");//06
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
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["AderenciaCubagem"] = value; //06
                      whereClauses.Add($" AderenciaCubagem = @AderenciaCubagem ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAderenciaJanelaEntregaQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["AderenciaJanelaEntrega"] = value; //06
                      whereClauses.Add($" AderenciaJanelaEntrega = @AderenciaJanelaEntrega ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRiscoResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["RiscoResumo"] = value; //06
                      whereClauses.Add($" RiscoResumo = @RiscoResumo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPedidosResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["PedidosResumo"] = value; //06
                      whereClauses.Add($" PedidosResumo = @PedidosResumo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOpcoesConflitantesResumoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo FROM OpcaoPlanejamentoTransporte ";
                      dict["OpcoesConflitantesResumo"] = value; //06
                      whereClauses.Add($" OpcoesConflitantesResumo = @OpcoesConflitantesResumo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration