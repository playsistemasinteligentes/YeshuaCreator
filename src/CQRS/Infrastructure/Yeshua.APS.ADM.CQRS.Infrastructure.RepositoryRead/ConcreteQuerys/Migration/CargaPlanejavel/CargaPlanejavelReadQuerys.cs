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
    public class CargaPlanejavelQueryRead : QueryBase, ICargaPlanejavelQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CargaPlanejavelQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CargaPlanejavelQuery(Command.Read.CargaPlanejavelReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo from CargaPlanejavel ";
if (!string.IsNullOrEmpty(Command.CargaId)) dict["CargaId"] = $"%{Command.CargaId}%";
if (!string.IsNullOrEmpty(Command.CargaId)) whereClauses.Add($"CargaId like @CargaId");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"Status like @Status");
if (!string.IsNullOrEmpty(Command.TransportadoraId)) dict["TransportadoraId"] = $"%{Command.TransportadoraId}%";
if (!string.IsNullOrEmpty(Command.TransportadoraId)) whereClauses.Add($"TransportadoraId like @TransportadoraId");
if (!string.IsNullOrEmpty(Command.VeiculoId)) dict["VeiculoId"] = $"%{Command.VeiculoId}%";
if (!string.IsNullOrEmpty(Command.VeiculoId)) whereClauses.Add($"VeiculoId like @VeiculoId");
if (Command.TipoVeiculoId.HasValue) dict["TipoVeiculoId"] = Command.TipoVeiculoId.Value;
if (Command.TipoVeiculoId.HasValue) whereClauses.Add($"TipoVeiculoId = @TipoVeiculoId");
if (Command.QuantidadePedidos.HasValue) dict["QuantidadePedidos"] = Command.QuantidadePedidos.Value;
if (Command.QuantidadePedidos.HasValue) whereClauses.Add($"QuantidadePedidos = @QuantidadePedidos");
if (!string.IsNullOrEmpty(Command.AlertasResumo)) dict["AlertasResumo"] = $"%{Command.AlertasResumo}%";
if (!string.IsNullOrEmpty(Command.AlertasResumo)) whereClauses.Add($"AlertasResumo like @AlertasResumo");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY CargaId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ExistsByCargaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["CargaId"] = value; //04
                      whereClauses.Add($" CargaId = @CargaId ");//04
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
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["Status"] = value; //04
                      whereClauses.Add($" Status = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTransportadoraIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["TransportadoraId"] = value; //04
                      whereClauses.Add($" TransportadoraId = @TransportadoraId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVeiculoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["VeiculoId"] = value; //04
                      whereClauses.Add($" VeiculoId = @VeiculoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoVeiculoIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["TipoVeiculoId"] = value; //04
                      whereClauses.Add($" TipoVeiculoId = @TipoVeiculoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPesoTeoricoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["PesoTeorico"] = value; //04
                      whereClauses.Add($" PesoTeorico = @PesoTeorico ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVolumeTeoricoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["VolumeTeorico"] = value; //04
                      whereClauses.Add($" VolumeTeorico = @VolumeTeorico ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByInicioJanelaEmbarqueQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["InicioJanelaEmbarque"] = value; //04
                      whereClauses.Add($" InicioJanelaEmbarque = @InicioJanelaEmbarque ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFimJanelaEmbarqueQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["FimJanelaEmbarque"] = value; //04
                      whereClauses.Add($" FimJanelaEmbarque = @FimJanelaEmbarque ");//04
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
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["EmbarqueAlvo"] = value; //04
                      whereClauses.Add($" EmbarqueAlvo = @EmbarqueAlvo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadePedidosQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["QuantidadePedidos"] = value; //04
                      whereClauses.Add($" QuantidadePedidos = @QuantidadePedidos ");//04
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
            this.Query = $"SELECT 1 FROM CargaPlanejavel ";
                      dict["AlertasResumo"] = value; //04
                      whereClauses.Add($" AlertasResumo = @AlertasResumo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCargaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["CargaId"] = value; //06
                      whereClauses.Add($" CargaId = @CargaId ");//06
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
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["Status"] = value; //06
                      whereClauses.Add($" Status = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTransportadoraIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["TransportadoraId"] = value; //06
                      whereClauses.Add($" TransportadoraId = @TransportadoraId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVeiculoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["VeiculoId"] = value; //06
                      whereClauses.Add($" VeiculoId = @VeiculoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoVeiculoIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["TipoVeiculoId"] = value; //06
                      whereClauses.Add($" TipoVeiculoId = @TipoVeiculoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPesoTeoricoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["PesoTeorico"] = value; //06
                      whereClauses.Add($" PesoTeorico = @PesoTeorico ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVolumeTeoricoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["VolumeTeorico"] = value; //06
                      whereClauses.Add($" VolumeTeorico = @VolumeTeorico ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByInicioJanelaEmbarqueQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["InicioJanelaEmbarque"] = value; //06
                      whereClauses.Add($" InicioJanelaEmbarque = @InicioJanelaEmbarque ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFimJanelaEmbarqueQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["FimJanelaEmbarque"] = value; //06
                      whereClauses.Add($" FimJanelaEmbarque = @FimJanelaEmbarque ");//06
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
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["EmbarqueAlvo"] = value; //06
                      whereClauses.Add($" EmbarqueAlvo = @EmbarqueAlvo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadePedidosQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
                      dict["QuantidadePedidos"] = value; //06
                      whereClauses.Add($" QuantidadePedidos = @QuantidadePedidos ");//06
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
            this.Query = $"SELECT CargaId, Status, TransportadoraId, VeiculoId, TipoVeiculoId, PesoTeorico, VolumeTeorico, InicioJanelaEmbarque, FimJanelaEmbarque, EmbarqueAlvo, QuantidadePedidos, AlertasResumo FROM CargaPlanejavel ";
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