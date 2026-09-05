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
    public class PedidoPlanejavelQueryRead : QueryBase, IPedidoPlanejavelQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public PedidoPlanejavelQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel PedidoPlanejavelQuery(Command.Read.PedidoPlanejavelReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] from [PedidoPlanejavel] ";
if (!string.IsNullOrEmpty(Command.PedidoId)) dict["PedidoId"] = $"%{Command.PedidoId}%";
if (!string.IsNullOrEmpty(Command.PedidoId)) whereClauses.Add($"[PedidoId] like @PedidoId");
if (!string.IsNullOrEmpty(Command.ClienteId)) dict["ClienteId"] = $"%{Command.ClienteId}%";
if (!string.IsNullOrEmpty(Command.ClienteId)) whereClauses.Add($"[ClienteId] like @ClienteId");
if (!string.IsNullOrEmpty(Command.ClienteNome)) dict["ClienteNome"] = $"%{Command.ClienteNome}%";
if (!string.IsNullOrEmpty(Command.ClienteNome)) whereClauses.Add($"[ClienteNome] like @ClienteNome");
if (!string.IsNullOrEmpty(Command.Estado)) dict["Estado"] = $"%{Command.Estado}%";
if (!string.IsNullOrEmpty(Command.Estado)) whereClauses.Add($"[Estado] like @Estado");
if (!string.IsNullOrEmpty(Command.Municipio)) dict["Municipio"] = $"%{Command.Municipio}%";
if (!string.IsNullOrEmpty(Command.Municipio)) whereClauses.Add($"[Municipio] like @Municipio");
if (!string.IsNullOrEmpty(Command.Regiao)) dict["Regiao"] = $"%{Command.Regiao}%";
if (!string.IsNullOrEmpty(Command.Regiao)) whereClauses.Add($"[Regiao] like @Regiao");
if (!string.IsNullOrEmpty(Command.Bairro)) dict["Bairro"] = $"%{Command.Bairro}%";
if (!string.IsNullOrEmpty(Command.Bairro)) whereClauses.Add($"[Bairro] like @Bairro");
if (!string.IsNullOrEmpty(Command.RotaId)) dict["RotaId"] = $"%{Command.RotaId}%";
if (!string.IsNullOrEmpty(Command.RotaId)) whereClauses.Add($"[RotaId] like @RotaId");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"[Status] like @Status");
if (!string.IsNullOrEmpty(Command.CargaAtualId)) dict["CargaAtualId"] = $"%{Command.CargaAtualId}%";
if (!string.IsNullOrEmpty(Command.CargaAtualId)) whereClauses.Add($"[CargaAtualId] like @CargaAtualId");
if (!string.IsNullOrEmpty(Command.VersaoPlanejamento)) dict["VersaoPlanejamento"] = $"%{Command.VersaoPlanejamento}%";
if (!string.IsNullOrEmpty(Command.VersaoPlanejamento)) whereClauses.Add($"[VersaoPlanejamento] like @VersaoPlanejamento");
if (!string.IsNullOrEmpty(Command.AlertasResumo)) dict["AlertasResumo"] = $"%{Command.AlertasResumo}%";
if (!string.IsNullOrEmpty(Command.AlertasResumo)) whereClauses.Add($"[AlertasResumo] like @AlertasResumo");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [PedidoId] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ExistsByPedidoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["PedidoId"] = value; //04
                      whereClauses.Add($" [PedidoId] = @PedidoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByClienteIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["ClienteId"] = value; //04
                      whereClauses.Add($" [ClienteId] = @ClienteId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByClienteNomeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["ClienteNome"] = value; //04
                      whereClauses.Add($" [ClienteNome] = @ClienteNome ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEstadoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Estado"] = value; //04
                      whereClauses.Add($" [Estado] = @Estado ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Municipio"] = value; //04
                      whereClauses.Add($" [Municipio] = @Municipio ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRegiaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Regiao"] = value; //04
                      whereClauses.Add($" [Regiao] = @Regiao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBairroQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Bairro"] = value; //04
                      whereClauses.Add($" [Bairro] = @Bairro ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRotaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["RotaId"] = value; //04
                      whereClauses.Add($" [RotaId] = @RotaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEmbarqueAlvoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["EmbarqueAlvo"] = value; //04
                      whereClauses.Add($" [EmbarqueAlvo] = @EmbarqueAlvo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataEntregaDeQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["DataEntregaDe"] = value; //04
                      whereClauses.Add($" [DataEntregaDe] = @DataEntregaDe ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataEntregaAteQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["DataEntregaAte"] = value; //04
                      whereClauses.Add($" [DataEntregaAte] = @DataEntregaAte ");//04
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
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Peso"] = value; //04
                      whereClauses.Add($" [Peso] = @Peso ");//04
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
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Volume"] = value; //04
                      whereClauses.Add($" [Volume] = @Volume ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySaldoAExpedirQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["SaldoAExpedir"] = value; //04
                      whereClauses.Add($" [SaldoAExpedir] = @SaldoAExpedir ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["Status"] = value; //04
                      whereClauses.Add($" [Status] = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCargaAtualIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["CargaAtualId"] = value; //04
                      whereClauses.Add($" [CargaAtualId] = @CargaAtualId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVersaoPlanejamentoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["VersaoPlanejamento"] = value; //04
                      whereClauses.Add($" [VersaoPlanejamento] = @VersaoPlanejamento ");//04
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
            this.Query = $"SELECT 1 FROM [PedidoPlanejavel] ";
                      dict["AlertasResumo"] = value; //04
                      whereClauses.Add($" [AlertasResumo] = @AlertasResumo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPedidoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["PedidoId"] = value; //06
                      whereClauses.Add($" [PedidoId] = @PedidoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByClienteIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["ClienteId"] = value; //06
                      whereClauses.Add($" [ClienteId] = @ClienteId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByClienteNomeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["ClienteNome"] = value; //06
                      whereClauses.Add($" [ClienteNome] = @ClienteNome ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEstadoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Estado"] = value; //06
                      whereClauses.Add($" [Estado] = @Estado ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Municipio"] = value; //06
                      whereClauses.Add($" [Municipio] = @Municipio ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRegiaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Regiao"] = value; //06
                      whereClauses.Add($" [Regiao] = @Regiao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBairroQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Bairro"] = value; //06
                      whereClauses.Add($" [Bairro] = @Bairro ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRotaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["RotaId"] = value; //06
                      whereClauses.Add($" [RotaId] = @RotaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEmbarqueAlvoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["EmbarqueAlvo"] = value; //06
                      whereClauses.Add($" [EmbarqueAlvo] = @EmbarqueAlvo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataEntregaDeQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["DataEntregaDe"] = value; //06
                      whereClauses.Add($" [DataEntregaDe] = @DataEntregaDe ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataEntregaAteQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["DataEntregaAte"] = value; //06
                      whereClauses.Add($" [DataEntregaAte] = @DataEntregaAte ");//06
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
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Peso"] = value; //06
                      whereClauses.Add($" [Peso] = @Peso ");//06
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
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Volume"] = value; //06
                      whereClauses.Add($" [Volume] = @Volume ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySaldoAExpedirQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["SaldoAExpedir"] = value; //06
                      whereClauses.Add($" [SaldoAExpedir] = @SaldoAExpedir ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["Status"] = value; //06
                      whereClauses.Add($" [Status] = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCargaAtualIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["CargaAtualId"] = value; //06
                      whereClauses.Add($" [CargaAtualId] = @CargaAtualId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVersaoPlanejamentoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["VersaoPlanejamento"] = value; //06
                      whereClauses.Add($" [VersaoPlanejamento] = @VersaoPlanejamento ");//06
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
            this.Query = $"SELECT [PedidoId], [ClienteId], [ClienteNome], [Estado], [Municipio], [Regiao], [Bairro], [RotaId], [EmbarqueAlvo], [DataEntregaDe], [DataEntregaAte], [Peso], [Volume], [SaldoAExpedir], [Status], [CargaAtualId], [VersaoPlanejamento], [AlertasResumo] FROM [PedidoPlanejavel] ";
                      dict["AlertasResumo"] = value; //06
                      whereClauses.Add($" [AlertasResumo] = @AlertasResumo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration