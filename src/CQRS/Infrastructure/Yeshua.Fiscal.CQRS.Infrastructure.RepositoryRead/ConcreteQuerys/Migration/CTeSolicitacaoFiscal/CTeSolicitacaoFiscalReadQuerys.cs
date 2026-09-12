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
    public class CTeSolicitacaoFiscalQueryRead : QueryBase, ICTeSolicitacaoFiscalQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CTeSolicitacaoFiscalQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CTeSolicitacaoFiscalQuery(Command.Read.CTeSolicitacaoFiscalReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] from [CTeSolicitacaoFiscal] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.EntradaOficialId.HasValue) dict["EntradaOficialId"] = Command.EntradaOficialId.Value;
if (Command.EntradaOficialId.HasValue) whereClauses.Add($"[EntradaOficialId] = @EntradaOficialId");
if (Command.RomaneioConsolidadoId.HasValue) dict["RomaneioConsolidadoId"] = Command.RomaneioConsolidadoId.Value;
if (Command.RomaneioConsolidadoId.HasValue) whereClauses.Add($"[RomaneioConsolidadoId] = @RomaneioConsolidadoId");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"[CorrelationId] like @CorrelationId");
if (Command.Ambiente.HasValue)
{
    dict["Ambiente"] = Command.Ambiente.Value;
    whereClauses.Add($"[Ambiente] = @Ambiente");
}
if (!string.IsNullOrEmpty(Command.UFEmitente)) dict["UFEmitente"] = $"%{Command.UFEmitente}%";
if (!string.IsNullOrEmpty(Command.UFEmitente)) whereClauses.Add($"[UFEmitente] like @UFEmitente");
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) dict["EmitenteDocumento"] = $"%{Command.EmitenteDocumento}%";
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) whereClauses.Add($"[EmitenteDocumento] like @EmitenteDocumento");
if (Command.ProdutoFiscal.HasValue)
{
    dict["ProdutoFiscal"] = Command.ProdutoFiscal.Value;
    whereClauses.Add($"[ProdutoFiscal] = @ProdutoFiscal");
}
if (Command.TipoCTe.HasValue)
{
    dict["TipoCTe"] = Command.TipoCTe.Value;
    whereClauses.Add($"[TipoCTe] = @TipoCTe");
}
if (Command.TipoServico.HasValue)
{
    dict["TipoServico"] = Command.TipoServico.Value;
    whereClauses.Add($"[TipoServico] = @TipoServico");
}
if (Command.Modal.HasValue)
{
    dict["Modal"] = Command.Modal.Value;
    whereClauses.Add($"[Modal] = @Modal");
}
if (Command.Globalizado.HasValue)
{
    dict["Globalizado"] = Command.Globalizado.Value;
    whereClauses.Add($"[Globalizado] = @Globalizado");
}
if (!string.IsNullOrEmpty(Command.UFInicio)) dict["UFInicio"] = $"%{Command.UFInicio}%";
if (!string.IsNullOrEmpty(Command.UFInicio)) whereClauses.Add($"[UFInicio] like @UFInicio");
if (!string.IsNullOrEmpty(Command.UFFim)) dict["UFFim"] = $"%{Command.UFFim}%";
if (!string.IsNullOrEmpty(Command.UFFim)) whereClauses.Add($"[UFFim] like @UFFim");
if (!string.IsNullOrEmpty(Command.MunicipioInicioCodigoIbge)) dict["MunicipioInicioCodigoIbge"] = $"%{Command.MunicipioInicioCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioInicioCodigoIbge)) whereClauses.Add($"[MunicipioInicioCodigoIbge] like @MunicipioInicioCodigoIbge");
if (!string.IsNullOrEmpty(Command.MunicipioFimCodigoIbge)) dict["MunicipioFimCodigoIbge"] = $"%{Command.MunicipioFimCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioFimCodigoIbge)) whereClauses.Add($"[MunicipioFimCodigoIbge] like @MunicipioFimCodigoIbge");
if (!string.IsNullOrEmpty(Command.PreferenciasManifestoJson)) dict["PreferenciasManifestoJson"] = $"%{Command.PreferenciasManifestoJson}%";
if (!string.IsNullOrEmpty(Command.PreferenciasManifestoJson)) whereClauses.Add($"[PreferenciasManifestoJson] like @PreferenciasManifestoJson");
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
        public QueryModel CTeSolicitacaoFiscalEntradaOficialIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [CTeEntradaOficial] ";
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
        public QueryModel CTeSolicitacaoFiscalRomaneioConsolidadoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [CTeRomaneioConsolidado] ";
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
        public QueryModel CTeSolicitacaoFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CTeSolicitacaoFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel ExistsByEntradaOficialIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EntradaOficialId"] = value; //04
                      whereClauses.Add($" [EntradaOficialId] = @EntradaOficialId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRomaneioConsolidadoIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RomaneioConsolidadoId"] = value; //04
                      whereClauses.Add($" [RomaneioConsolidadoId] = @RomaneioConsolidadoId ");//04
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel ExistsByAmbienteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel ExistsByUFEmitenteQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFEmitente"] = value; //04
                      whereClauses.Add($" [UFEmitente] = @UFEmitente ");//04
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel ExistsByProdutoFiscalQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ProdutoFiscal"] = value; //04
                      whereClauses.Add($" [ProdutoFiscal] = @ProdutoFiscal ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoCTeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoCTe"] = value; //04
                      whereClauses.Add($" [TipoCTe] = @TipoCTe ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoServicoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoServico"] = value; //04
                      whereClauses.Add($" [TipoServico] = @TipoServico ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByModalQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Modal"] = value; //04
                      whereClauses.Add($" [Modal] = @Modal ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGlobalizadoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Globalizado"] = value; //04
                      whereClauses.Add($" [Globalizado] = @Globalizado ");//04
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel ExistsByValorServicoQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValorServico"] = value; //04
                      whereClauses.Add($" [ValorServico] = @ValorServico ");//04
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel ExistsByPreferenciasManifestoJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PreferenciasManifestoJson"] = value; //04
                      whereClauses.Add($" [PreferenciasManifestoJson] = @PreferenciasManifestoJson ");//04
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel FirstByEntradaOficialIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EntradaOficialId"] = value; //06
                      whereClauses.Add($" [EntradaOficialId] = @EntradaOficialId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRomaneioConsolidadoIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RomaneioConsolidadoId"] = value; //06
                      whereClauses.Add($" [RomaneioConsolidadoId] = @RomaneioConsolidadoId ");//06
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel FirstByAmbienteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel FirstByUFEmitenteQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFEmitente"] = value; //06
                      whereClauses.Add($" [UFEmitente] = @UFEmitente ");//06
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel FirstByProdutoFiscalQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ProdutoFiscal"] = value; //06
                      whereClauses.Add($" [ProdutoFiscal] = @ProdutoFiscal ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoCTeQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoCTe"] = value; //06
                      whereClauses.Add($" [TipoCTe] = @TipoCTe ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoServicoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoServico"] = value; //06
                      whereClauses.Add($" [TipoServico] = @TipoServico ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByModalQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Modal"] = value; //06
                      whereClauses.Add($" [Modal] = @Modal ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGlobalizadoQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Globalizado"] = value; //06
                      whereClauses.Add($" [Globalizado] = @Globalizado ");//06
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel FirstByValorServicoQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValorServico"] = value; //06
                      whereClauses.Add($" [ValorServico] = @ValorServico ");//06
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
        public QueryModel FirstByPreferenciasManifestoJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PreferenciasManifestoJson"] = value; //06
                      whereClauses.Add($" [PreferenciasManifestoJson] = @PreferenciasManifestoJson ");//06
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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
            this.Query = $"SELECT [Id], [EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [CTeSolicitacaoFiscal] ";
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