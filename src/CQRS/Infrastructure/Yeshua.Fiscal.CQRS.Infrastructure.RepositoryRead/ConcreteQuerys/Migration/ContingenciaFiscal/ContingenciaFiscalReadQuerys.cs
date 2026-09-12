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
    public class ContingenciaFiscalQueryRead : QueryBase, IContingenciaFiscalQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ContingenciaFiscalQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ContingenciaFiscalQuery(Command.Read.ContingenciaFiscalReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] from [ContingenciaFiscal] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.EmissaoFiscalTransporteId.HasValue) dict["EmissaoFiscalTransporteId"] = Command.EmissaoFiscalTransporteId.Value;
if (Command.EmissaoFiscalTransporteId.HasValue) whereClauses.Add($"[EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId");
if (Command.EntradaFiscalContingenciaId.HasValue) dict["EntradaFiscalContingenciaId"] = Command.EntradaFiscalContingenciaId.Value;
if (Command.EntradaFiscalContingenciaId.HasValue) whereClauses.Add($"[EntradaFiscalContingenciaId] = @EntradaFiscalContingenciaId");
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
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) dict["EmitenteDocumento"] = $"%{Command.EmitenteDocumento}%";
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) whereClauses.Add($"[EmitenteDocumento] like @EmitenteDocumento");
if (!string.IsNullOrEmpty(Command.TomadorDocumento)) dict["TomadorDocumento"] = $"%{Command.TomadorDocumento}%";
if (!string.IsNullOrEmpty(Command.TomadorDocumento)) whereClauses.Add($"[TomadorDocumento] like @TomadorDocumento");
if (!string.IsNullOrEmpty(Command.TransportadorDocumento)) dict["TransportadorDocumento"] = $"%{Command.TransportadorDocumento}%";
if (!string.IsNullOrEmpty(Command.TransportadorDocumento)) whereClauses.Add($"[TransportadorDocumento] like @TransportadorDocumento");
if (Command.QuantidadeDocumentos.HasValue) dict["QuantidadeDocumentos"] = Command.QuantidadeDocumentos.Value;
if (Command.QuantidadeDocumentos.HasValue) whereClauses.Add($"[QuantidadeDocumentos] = @QuantidadeDocumentos");
if (Command.QuantidadeCTe.HasValue) dict["QuantidadeCTe"] = Command.QuantidadeCTe.Value;
if (Command.QuantidadeCTe.HasValue) whereClauses.Add($"[QuantidadeCTe] = @QuantidadeCTe");
if (Command.QuantidadeMDFe.HasValue) dict["QuantidadeMDFe"] = Command.QuantidadeMDFe.Value;
if (Command.QuantidadeMDFe.HasValue) whereClauses.Add($"[QuantidadeMDFe] = @QuantidadeMDFe");
if (!string.IsNullOrEmpty(Command.UltimaMensagem)) dict["UltimaMensagem"] = $"%{Command.UltimaMensagem}%";
if (!string.IsNullOrEmpty(Command.UltimaMensagem)) whereClauses.Add($"[UltimaMensagem] like @UltimaMensagem");
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
        public QueryModel ContingenciaFiscalEmissaoFiscalTransporteIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [EmissaoFiscalTransporte] ";
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
        public QueryModel ContingenciaFiscalEntradaFiscalContingenciaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [EntradaFiscalContingencia] ";
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
        public QueryModel ContingenciaFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ContingenciaFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
        public QueryModel ExistsByEmissaoFiscalTransporteIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmissaoFiscalTransporteId"] = value; //04
                      whereClauses.Add($" [EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEntradaFiscalContingenciaIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EntradaFiscalContingenciaId"] = value; //04
                      whereClauses.Add($" [EntradaFiscalContingenciaId] = @EntradaFiscalContingenciaId ");//04
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
        public QueryModel ExistsByEmitenteDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmitenteDocumento"] = value; //04
                      whereClauses.Add($" [EmitenteDocumento] = @EmitenteDocumento ");//04
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
        public QueryModel ExistsByQuantidadeDocumentosQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
        public QueryModel ExistsByQuantidadeCTeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadeCTe"] = value; //04
                      whereClauses.Add($" [QuantidadeCTe] = @QuantidadeCTe ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadeMDFeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadeMDFe"] = value; //04
                      whereClauses.Add($" [QuantidadeMDFe] = @QuantidadeMDFe ");//04
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
        public QueryModel ExistsByUltimaMensagemQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UltimaMensagem"] = value; //04
                      whereClauses.Add($" [UltimaMensagem] = @UltimaMensagem ");//04
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
        public QueryModel ExistsByConcluidoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ConcluidoEmUtc"] = value; //04
                      whereClauses.Add($" [ConcluidoEmUtc] = @ConcluidoEmUtc ");//04
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT 1 FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
        public QueryModel FirstByEmissaoFiscalTransporteIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmissaoFiscalTransporteId"] = value; //06
                      whereClauses.Add($" [EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEntradaFiscalContingenciaIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EntradaFiscalContingenciaId"] = value; //06
                      whereClauses.Add($" [EntradaFiscalContingenciaId] = @EntradaFiscalContingenciaId ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
        public QueryModel FirstByEmitenteDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EmitenteDocumento"] = value; //06
                      whereClauses.Add($" [EmitenteDocumento] = @EmitenteDocumento ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
        public QueryModel FirstByQuantidadeDocumentosQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
        public QueryModel FirstByQuantidadeCTeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadeCTe"] = value; //06
                      whereClauses.Add($" [QuantidadeCTe] = @QuantidadeCTe ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadeMDFeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadeMDFe"] = value; //06
                      whereClauses.Add($" [QuantidadeMDFe] = @QuantidadeMDFe ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
        public QueryModel FirstByUltimaMensagemQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UltimaMensagem"] = value; //06
                      whereClauses.Add($" [UltimaMensagem] = @UltimaMensagem ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
        public QueryModel FirstByConcluidoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ConcluidoEmUtc"] = value; //06
                      whereClauses.Add($" [ConcluidoEmUtc] = @ConcluidoEmUtc ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [ContingenciaFiscal] ";
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