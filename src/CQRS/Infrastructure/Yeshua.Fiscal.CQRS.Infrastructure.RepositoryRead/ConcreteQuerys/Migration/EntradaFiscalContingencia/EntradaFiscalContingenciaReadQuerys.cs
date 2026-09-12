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
    public class EntradaFiscalContingenciaQueryRead : QueryBase, IEntradaFiscalContingenciaQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public EntradaFiscalContingenciaQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel EntradaFiscalContingenciaQuery(Command.Read.EntradaFiscalContingenciaReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] from [EntradaFiscalContingencia] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"[CorrelationId] like @CorrelationId");
if (!string.IsNullOrEmpty(Command.CargaId)) dict["CargaId"] = $"%{Command.CargaId}%";
if (!string.IsNullOrEmpty(Command.CargaId)) whereClauses.Add($"[CargaId] like @CargaId");
if (Command.TipoSolicitante.HasValue)
{
    dict["TipoSolicitante"] = Command.TipoSolicitante.Value;
    whereClauses.Add($"[TipoSolicitante] = @TipoSolicitante");
}
if (Command.Ambiente.HasValue)
{
    dict["Ambiente"] = Command.Ambiente.Value;
    whereClauses.Add($"[Ambiente] = @Ambiente");
}
if (!string.IsNullOrEmpty(Command.SourceApplication)) dict["SourceApplication"] = $"%{Command.SourceApplication}%";
if (!string.IsNullOrEmpty(Command.SourceApplication)) whereClauses.Add($"[SourceApplication] like @SourceApplication");
if (!string.IsNullOrEmpty(Command.SourceModule)) dict["SourceModule"] = $"%{Command.SourceModule}%";
if (!string.IsNullOrEmpty(Command.SourceModule)) whereClauses.Add($"[SourceModule] like @SourceModule");
if (!string.IsNullOrEmpty(Command.SourceMessageId)) dict["SourceMessageId"] = $"%{Command.SourceMessageId}%";
if (!string.IsNullOrEmpty(Command.SourceMessageId)) whereClauses.Add($"[SourceMessageId] like @SourceMessageId");
if (!string.IsNullOrEmpty(Command.EmitenteFiscalDocumento)) dict["EmitenteFiscalDocumento"] = $"%{Command.EmitenteFiscalDocumento}%";
if (!string.IsNullOrEmpty(Command.EmitenteFiscalDocumento)) whereClauses.Add($"[EmitenteFiscalDocumento] like @EmitenteFiscalDocumento");
if (!string.IsNullOrEmpty(Command.TomadorDocumento)) dict["TomadorDocumento"] = $"%{Command.TomadorDocumento}%";
if (!string.IsNullOrEmpty(Command.TomadorDocumento)) whereClauses.Add($"[TomadorDocumento] like @TomadorDocumento");
if (!string.IsNullOrEmpty(Command.TransportadorDocumento)) dict["TransportadorDocumento"] = $"%{Command.TransportadorDocumento}%";
if (!string.IsNullOrEmpty(Command.TransportadorDocumento)) whereClauses.Add($"[TransportadorDocumento] like @TransportadorDocumento");
if (!string.IsNullOrEmpty(Command.RemetenteDocumento)) dict["RemetenteDocumento"] = $"%{Command.RemetenteDocumento}%";
if (!string.IsNullOrEmpty(Command.RemetenteDocumento)) whereClauses.Add($"[RemetenteDocumento] like @RemetenteDocumento");
if (!string.IsNullOrEmpty(Command.DestinatarioDocumento)) dict["DestinatarioDocumento"] = $"%{Command.DestinatarioDocumento}%";
if (!string.IsNullOrEmpty(Command.DestinatarioDocumento)) whereClauses.Add($"[DestinatarioDocumento] like @DestinatarioDocumento");
if (!string.IsNullOrEmpty(Command.UFInicio)) dict["UFInicio"] = $"%{Command.UFInicio}%";
if (!string.IsNullOrEmpty(Command.UFInicio)) whereClauses.Add($"[UFInicio] like @UFInicio");
if (!string.IsNullOrEmpty(Command.UFFim)) dict["UFFim"] = $"%{Command.UFFim}%";
if (!string.IsNullOrEmpty(Command.UFFim)) whereClauses.Add($"[UFFim] like @UFFim");
if (!string.IsNullOrEmpty(Command.MunicipioInicioCodigoIbge)) dict["MunicipioInicioCodigoIbge"] = $"%{Command.MunicipioInicioCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioInicioCodigoIbge)) whereClauses.Add($"[MunicipioInicioCodigoIbge] like @MunicipioInicioCodigoIbge");
if (!string.IsNullOrEmpty(Command.MunicipioFimCodigoIbge)) dict["MunicipioFimCodigoIbge"] = $"%{Command.MunicipioFimCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioFimCodigoIbge)) whereClauses.Add($"[MunicipioFimCodigoIbge] like @MunicipioFimCodigoIbge");
if (!string.IsNullOrEmpty(Command.RNTRC)) dict["RNTRC"] = $"%{Command.RNTRC}%";
if (!string.IsNullOrEmpty(Command.RNTRC)) whereClauses.Add($"[RNTRC] like @RNTRC");
if (!string.IsNullOrEmpty(Command.PlacaVeiculo)) dict["PlacaVeiculo"] = $"%{Command.PlacaVeiculo}%";
if (!string.IsNullOrEmpty(Command.PlacaVeiculo)) whereClauses.Add($"[PlacaVeiculo] like @PlacaVeiculo");
if (!string.IsNullOrEmpty(Command.UFVeiculo)) dict["UFVeiculo"] = $"%{Command.UFVeiculo}%";
if (!string.IsNullOrEmpty(Command.UFVeiculo)) whereClauses.Add($"[UFVeiculo] like @UFVeiculo");
if (!string.IsNullOrEmpty(Command.CondutorDocumento)) dict["CondutorDocumento"] = $"%{Command.CondutorDocumento}%";
if (!string.IsNullOrEmpty(Command.CondutorDocumento)) whereClauses.Add($"[CondutorDocumento] like @CondutorDocumento");
if (!string.IsNullOrEmpty(Command.CondutorNome)) dict["CondutorNome"] = $"%{Command.CondutorNome}%";
if (!string.IsNullOrEmpty(Command.CondutorNome)) whereClauses.Add($"[CondutorNome] like @CondutorNome");
if (Command.QuantidadeDocumentos.HasValue) dict["QuantidadeDocumentos"] = Command.QuantidadeDocumentos.Value;
if (Command.QuantidadeDocumentos.HasValue) whereClauses.Add($"[QuantidadeDocumentos] = @QuantidadeDocumentos");
if (!string.IsNullOrEmpty(Command.PendenciasJson)) dict["PendenciasJson"] = $"%{Command.PendenciasJson}%";
if (!string.IsNullOrEmpty(Command.PendenciasJson)) whereClauses.Add($"[PendenciasJson] like @PendenciasJson");
if (!string.IsNullOrEmpty(Command.SnapshotJson)) dict["SnapshotJson"] = $"%{Command.SnapshotJson}%";
if (!string.IsNullOrEmpty(Command.SnapshotJson)) whereClauses.Add($"[SnapshotJson] like @SnapshotJson");
if (!string.IsNullOrEmpty(Command.EmissaoFiscalCorrelationId)) dict["EmissaoFiscalCorrelationId"] = $"%{Command.EmissaoFiscalCorrelationId}%";
if (!string.IsNullOrEmpty(Command.EmissaoFiscalCorrelationId)) whereClauses.Add($"[EmissaoFiscalCorrelationId] like @EmissaoFiscalCorrelationId");
if (Command.EmissaoFiscalSagaId.HasValue) dict["EmissaoFiscalSagaId"] = Command.EmissaoFiscalSagaId.Value;
if (Command.EmissaoFiscalSagaId.HasValue) whereClauses.Add($"[EmissaoFiscalSagaId] = @EmissaoFiscalSagaId");
if (Command.Status.HasValue)
{
    dict["Status"] = Command.Status.Value;
    whereClauses.Add($"[Status] = @Status");
}
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel EntradaFiscalContingenciaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel EntradaFiscalContingenciaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CorrelationId"] = value; //04
                      whereClauses.Add($" [CorrelationId] = @CorrelationId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCargaIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CargaId"] = value; //04
                      whereClauses.Add($" [CargaId] = @CargaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoSolicitanteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoSolicitante"] = value; //04
                      whereClauses.Add($" [TipoSolicitante] = @TipoSolicitante ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAmbienteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Ambiente"] = value; //04
                      whereClauses.Add($" [Ambiente] = @Ambiente ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySourceApplicationQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SourceApplication"] = value; //04
                      whereClauses.Add($" [SourceApplication] = @SourceApplication ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySourceModuleQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SourceModule"] = value; //04
                      whereClauses.Add($" [SourceModule] = @SourceModule ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySourceMessageIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SourceMessageId"] = value; //04
                      whereClauses.Add($" [SourceMessageId] = @SourceMessageId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEmitenteFiscalDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmitenteFiscalDocumento"] = value; //04
                      whereClauses.Add($" [EmitenteFiscalDocumento] = @EmitenteFiscalDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTomadorDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TomadorDocumento"] = value; //04
                      whereClauses.Add($" [TomadorDocumento] = @TomadorDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTransportadorDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TransportadorDocumento"] = value; //04
                      whereClauses.Add($" [TransportadorDocumento] = @TransportadorDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRemetenteDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RemetenteDocumento"] = value; //04
                      whereClauses.Add($" [RemetenteDocumento] = @RemetenteDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDestinatarioDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DestinatarioDocumento"] = value; //04
                      whereClauses.Add($" [DestinatarioDocumento] = @DestinatarioDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFInicioQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFInicio"] = value; //04
                      whereClauses.Add($" [UFInicio] = @UFInicio ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFFimQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFFim"] = value; //04
                      whereClauses.Add($" [UFFim] = @UFFim ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioInicioCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioInicioCodigoIbge"] = value; //04
                      whereClauses.Add($" [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioFimCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioFimCodigoIbge"] = value; //04
                      whereClauses.Add($" [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRNTRCQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RNTRC"] = value; //04
                      whereClauses.Add($" [RNTRC] = @RNTRC ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPlacaVeiculoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PlacaVeiculo"] = value; //04
                      whereClauses.Add($" [PlacaVeiculo] = @PlacaVeiculo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFVeiculoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFVeiculo"] = value; //04
                      whereClauses.Add($" [UFVeiculo] = @UFVeiculo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCondutorDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CondutorDocumento"] = value; //04
                      whereClauses.Add($" [CondutorDocumento] = @CondutorDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCondutorNomeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CondutorNome"] = value; //04
                      whereClauses.Add($" [CondutorNome] = @CondutorNome ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadeDocumentosQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadeDocumentos"] = value; //04
                      whereClauses.Add($" [QuantidadeDocumentos] = @QuantidadeDocumentos ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByValorCargaQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValorCarga"] = value; //04
                      whereClauses.Add($" [ValorCarga] = @ValorCarga ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPesoBrutoQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PesoBruto"] = value; //04
                      whereClauses.Add($" [PesoBruto] = @PesoBruto ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVolumeQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Volume"] = value; //04
                      whereClauses.Add($" [Volume] = @Volume ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPendenciasJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PendenciasJson"] = value; //04
                      whereClauses.Add($" [PendenciasJson] = @PendenciasJson ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySnapshotJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SnapshotJson"] = value; //04
                      whereClauses.Add($" [SnapshotJson] = @SnapshotJson ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEmissaoFiscalCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmissaoFiscalCorrelationId"] = value; //04
                      whereClauses.Add($" [EmissaoFiscalCorrelationId] = @EmissaoFiscalCorrelationId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEmissaoFiscalSagaIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmissaoFiscalSagaId"] = value; //04
                      whereClauses.Add($" [EmissaoFiscalSagaId] = @EmissaoFiscalSagaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCriadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CriadoEmUtc"] = value; //04
                      whereClauses.Add($" [CriadoEmUtc] = @CriadoEmUtc ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAtualizadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AtualizadoEmUtc"] = value; //04
                      whereClauses.Add($" [AtualizadoEmUtc] = @AtualizadoEmUtc ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" [Status] = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" [TenantID] = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CorrelationId"] = value; //06
                      whereClauses.Add($" [CorrelationId] = @CorrelationId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCargaIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CargaId"] = value; //06
                      whereClauses.Add($" [CargaId] = @CargaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoSolicitanteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoSolicitante"] = value; //06
                      whereClauses.Add($" [TipoSolicitante] = @TipoSolicitante ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAmbienteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Ambiente"] = value; //06
                      whereClauses.Add($" [Ambiente] = @Ambiente ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySourceApplicationQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SourceApplication"] = value; //06
                      whereClauses.Add($" [SourceApplication] = @SourceApplication ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySourceModuleQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SourceModule"] = value; //06
                      whereClauses.Add($" [SourceModule] = @SourceModule ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySourceMessageIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SourceMessageId"] = value; //06
                      whereClauses.Add($" [SourceMessageId] = @SourceMessageId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEmitenteFiscalDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmitenteFiscalDocumento"] = value; //06
                      whereClauses.Add($" [EmitenteFiscalDocumento] = @EmitenteFiscalDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTomadorDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TomadorDocumento"] = value; //06
                      whereClauses.Add($" [TomadorDocumento] = @TomadorDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTransportadorDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TransportadorDocumento"] = value; //06
                      whereClauses.Add($" [TransportadorDocumento] = @TransportadorDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRemetenteDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RemetenteDocumento"] = value; //06
                      whereClauses.Add($" [RemetenteDocumento] = @RemetenteDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDestinatarioDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DestinatarioDocumento"] = value; //06
                      whereClauses.Add($" [DestinatarioDocumento] = @DestinatarioDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFInicioQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFInicio"] = value; //06
                      whereClauses.Add($" [UFInicio] = @UFInicio ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFFimQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFFim"] = value; //06
                      whereClauses.Add($" [UFFim] = @UFFim ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioInicioCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioInicioCodigoIbge"] = value; //06
                      whereClauses.Add($" [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioFimCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioFimCodigoIbge"] = value; //06
                      whereClauses.Add($" [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRNTRCQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RNTRC"] = value; //06
                      whereClauses.Add($" [RNTRC] = @RNTRC ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPlacaVeiculoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PlacaVeiculo"] = value; //06
                      whereClauses.Add($" [PlacaVeiculo] = @PlacaVeiculo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFVeiculoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFVeiculo"] = value; //06
                      whereClauses.Add($" [UFVeiculo] = @UFVeiculo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCondutorDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CondutorDocumento"] = value; //06
                      whereClauses.Add($" [CondutorDocumento] = @CondutorDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCondutorNomeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CondutorNome"] = value; //06
                      whereClauses.Add($" [CondutorNome] = @CondutorNome ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadeDocumentosQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadeDocumentos"] = value; //06
                      whereClauses.Add($" [QuantidadeDocumentos] = @QuantidadeDocumentos ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByValorCargaQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValorCarga"] = value; //06
                      whereClauses.Add($" [ValorCarga] = @ValorCarga ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPesoBrutoQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PesoBruto"] = value; //06
                      whereClauses.Add($" [PesoBruto] = @PesoBruto ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVolumeQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Volume"] = value; //06
                      whereClauses.Add($" [Volume] = @Volume ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPendenciasJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PendenciasJson"] = value; //06
                      whereClauses.Add($" [PendenciasJson] = @PendenciasJson ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySnapshotJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SnapshotJson"] = value; //06
                      whereClauses.Add($" [SnapshotJson] = @SnapshotJson ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEmissaoFiscalCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmissaoFiscalCorrelationId"] = value; //06
                      whereClauses.Add($" [EmissaoFiscalCorrelationId] = @EmissaoFiscalCorrelationId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEmissaoFiscalSagaIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmissaoFiscalSagaId"] = value; //06
                      whereClauses.Add($" [EmissaoFiscalSagaId] = @EmissaoFiscalSagaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCriadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CriadoEmUtc"] = value; //06
                      whereClauses.Add($" [CriadoEmUtc] = @CriadoEmUtc ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAtualizadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AtualizadoEmUtc"] = value; //06
                      whereClauses.Add($" [AtualizadoEmUtc] = @AtualizadoEmUtc ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" [Status] = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" [TenantID] = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" [Changed] = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EntradaFiscalContingencia] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" [UserId] = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration