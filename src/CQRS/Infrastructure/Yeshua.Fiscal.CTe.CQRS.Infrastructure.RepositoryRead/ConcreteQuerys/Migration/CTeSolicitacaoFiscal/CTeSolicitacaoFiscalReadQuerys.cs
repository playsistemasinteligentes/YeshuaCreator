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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId from CTeSolicitacaoFiscal ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.EntradaOficialId.HasValue) dict["EntradaOficialId"] = Command.EntradaOficialId.Value;
if (Command.EntradaOficialId.HasValue) whereClauses.Add($"EntradaOficialId = @EntradaOficialId");
if (Command.RomaneioConsolidadoId.HasValue) dict["RomaneioConsolidadoId"] = Command.RomaneioConsolidadoId.Value;
if (Command.RomaneioConsolidadoId.HasValue) whereClauses.Add($"RomaneioConsolidadoId = @RomaneioConsolidadoId");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"CorrelationId like @CorrelationId");
if (Command.Ambiente != null && Command.Ambiente.Any())
{
    var paramList_Ambiente = new List<string>();
    for (int i = 0; i < Command.Ambiente.Count; i++)
    {
        string paramName = "Ambiente_" + i;
        dict[paramName] = Command.Ambiente[i];
        paramList_Ambiente.Add("@" + paramName);
    }
    whereClauses.Add($"t0.Ambiente IN ({string.Join(", ", paramList_Ambiente)})");
}
if (!string.IsNullOrEmpty(Command.UFEmitente)) dict["UFEmitente"] = $"%{Command.UFEmitente}%";
if (!string.IsNullOrEmpty(Command.UFEmitente)) whereClauses.Add($"UFEmitente like @UFEmitente");
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) dict["EmitenteDocumento"] = $"%{Command.EmitenteDocumento}%";
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) whereClauses.Add($"EmitenteDocumento like @EmitenteDocumento");
if (Command.ProdutoFiscal != null && Command.ProdutoFiscal.Any())
{
    var paramList_ProdutoFiscal = new List<string>();
    for (int i = 0; i < Command.ProdutoFiscal.Count; i++)
    {
        string paramName = "ProdutoFiscal_" + i;
        dict[paramName] = Command.ProdutoFiscal[i];
        paramList_ProdutoFiscal.Add("@" + paramName);
    }
    whereClauses.Add($"t0.ProdutoFiscal IN ({string.Join(", ", paramList_ProdutoFiscal)})");
}
if (Command.TipoCTe != null && Command.TipoCTe.Any())
{
    var paramList_TipoCTe = new List<string>();
    for (int i = 0; i < Command.TipoCTe.Count; i++)
    {
        string paramName = "TipoCTe_" + i;
        dict[paramName] = Command.TipoCTe[i];
        paramList_TipoCTe.Add("@" + paramName);
    }
    whereClauses.Add($"t0.TipoCTe IN ({string.Join(", ", paramList_TipoCTe)})");
}
if (Command.TipoServico != null && Command.TipoServico.Any())
{
    var paramList_TipoServico = new List<string>();
    for (int i = 0; i < Command.TipoServico.Count; i++)
    {
        string paramName = "TipoServico_" + i;
        dict[paramName] = Command.TipoServico[i];
        paramList_TipoServico.Add("@" + paramName);
    }
    whereClauses.Add($"t0.TipoServico IN ({string.Join(", ", paramList_TipoServico)})");
}
if (Command.Modal != null && Command.Modal.Any())
{
    var paramList_Modal = new List<string>();
    for (int i = 0; i < Command.Modal.Count; i++)
    {
        string paramName = "Modal_" + i;
        dict[paramName] = Command.Modal[i];
        paramList_Modal.Add("@" + paramName);
    }
    whereClauses.Add($"t0.Modal IN ({string.Join(", ", paramList_Modal)})");
}
if (Command.Globalizado != null && Command.Globalizado.Any())
{
    var paramList_Globalizado = new List<string>();
    for (int i = 0; i < Command.Globalizado.Count; i++)
    {
        string paramName = "Globalizado_" + i;
        dict[paramName] = Command.Globalizado[i];
        paramList_Globalizado.Add("@" + paramName);
    }
    whereClauses.Add($"t0.Globalizado IN ({string.Join(", ", paramList_Globalizado)})");
}
if (!string.IsNullOrEmpty(Command.UFInicio)) dict["UFInicio"] = $"%{Command.UFInicio}%";
if (!string.IsNullOrEmpty(Command.UFInicio)) whereClauses.Add($"UFInicio like @UFInicio");
if (!string.IsNullOrEmpty(Command.UFFim)) dict["UFFim"] = $"%{Command.UFFim}%";
if (!string.IsNullOrEmpty(Command.UFFim)) whereClauses.Add($"UFFim like @UFFim");
if (!string.IsNullOrEmpty(Command.MunicipioInicioCodigoIbge)) dict["MunicipioInicioCodigoIbge"] = $"%{Command.MunicipioInicioCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioInicioCodigoIbge)) whereClauses.Add($"MunicipioInicioCodigoIbge like @MunicipioInicioCodigoIbge");
if (!string.IsNullOrEmpty(Command.MunicipioFimCodigoIbge)) dict["MunicipioFimCodigoIbge"] = $"%{Command.MunicipioFimCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioFimCodigoIbge)) whereClauses.Add($"MunicipioFimCodigoIbge like @MunicipioFimCodigoIbge");
if (!string.IsNullOrEmpty(Command.PreferenciasManifestoJson)) dict["PreferenciasManifestoJson"] = $"%{Command.PreferenciasManifestoJson}%";
if (!string.IsNullOrEmpty(Command.PreferenciasManifestoJson)) whereClauses.Add($"PreferenciasManifestoJson like @PreferenciasManifestoJson");
if (Command.Status != null && Command.Status.Any())
{
    var paramList_Status = new List<string>();
    for (int i = 0; i < Command.Status.Count; i++)
    {
        string paramName = "Status_" + i;
        dict[paramName] = Command.Status[i];
        paramList_Status.Add("@" + paramName);
    }
    whereClauses.Add($"t0.Status IN ({string.Join(", ", paramList_Status)})");
}
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel CTeSolicitacaoFiscalEntradaOficialIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id from CTeEntradaOficial ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel CTeSolicitacaoFiscalRomaneioConsolidadoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id from CTeRomaneioConsolidado ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel CTeSolicitacaoFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yTenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"Id = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel CTeSolicitacaoFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yUser ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" Id = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEntradaOficialIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EntradaOficialId"] = value; //04
                      whereClauses.Add($" EntradaOficialId = @EntradaOficialId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRomaneioConsolidadoIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["RomaneioConsolidadoId"] = value; //04
                      whereClauses.Add($" RomaneioConsolidadoId = @RomaneioConsolidadoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCorrelationIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CorrelationId"] = value; //04
                      whereClauses.Add($" CorrelationId = @CorrelationId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAmbienteQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Ambiente"] = value; //04
                      whereClauses.Add($" Ambiente = @Ambiente ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFEmitenteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UFEmitente"] = value; //04
                      whereClauses.Add($" UFEmitente = @UFEmitente ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEmitenteDocumentoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EmitenteDocumento"] = value; //04
                      whereClauses.Add($" EmitenteDocumento = @EmitenteDocumento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProdutoFiscalQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProdutoFiscal"] = value; //04
                      whereClauses.Add($" ProdutoFiscal = @ProdutoFiscal ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoCTeQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TipoCTe"] = value; //04
                      whereClauses.Add($" TipoCTe = @TipoCTe ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoServicoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TipoServico"] = value; //04
                      whereClauses.Add($" TipoServico = @TipoServico ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByModalQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Modal"] = value; //04
                      whereClauses.Add($" Modal = @Modal ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGlobalizadoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Globalizado"] = value; //04
                      whereClauses.Add($" Globalizado = @Globalizado ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFInicioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UFInicio"] = value; //04
                      whereClauses.Add($" UFInicio = @UFInicio ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFFimQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UFFim"] = value; //04
                      whereClauses.Add($" UFFim = @UFFim ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioInicioCodigoIbgeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MunicipioInicioCodigoIbge"] = value; //04
                      whereClauses.Add($" MunicipioInicioCodigoIbge = @MunicipioInicioCodigoIbge ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioFimCodigoIbgeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MunicipioFimCodigoIbge"] = value; //04
                      whereClauses.Add($" MunicipioFimCodigoIbge = @MunicipioFimCodigoIbge ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByValorServicoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ValorServico"] = value; //04
                      whereClauses.Add($" ValorServico = @ValorServico ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByValorCargaQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ValorCarga"] = value; //04
                      whereClauses.Add($" ValorCarga = @ValorCarga ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPreferenciasManifestoJsonQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PreferenciasManifestoJson"] = value; //04
                      whereClauses.Add($" PreferenciasManifestoJson = @PreferenciasManifestoJson ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" Status = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" TenantID = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" Deleted = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" Changed = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" UserId = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" Id = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEntradaOficialIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EntradaOficialId"] = value; //06
                      whereClauses.Add($" EntradaOficialId = @EntradaOficialId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRomaneioConsolidadoIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["RomaneioConsolidadoId"] = value; //06
                      whereClauses.Add($" RomaneioConsolidadoId = @RomaneioConsolidadoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCorrelationIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CorrelationId"] = value; //06
                      whereClauses.Add($" CorrelationId = @CorrelationId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAmbienteQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Ambiente"] = value; //06
                      whereClauses.Add($" Ambiente = @Ambiente ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFEmitenteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UFEmitente"] = value; //06
                      whereClauses.Add($" UFEmitente = @UFEmitente ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEmitenteDocumentoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EmitenteDocumento"] = value; //06
                      whereClauses.Add($" EmitenteDocumento = @EmitenteDocumento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProdutoFiscalQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProdutoFiscal"] = value; //06
                      whereClauses.Add($" ProdutoFiscal = @ProdutoFiscal ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoCTeQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TipoCTe"] = value; //06
                      whereClauses.Add($" TipoCTe = @TipoCTe ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoServicoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TipoServico"] = value; //06
                      whereClauses.Add($" TipoServico = @TipoServico ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByModalQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Modal"] = value; //06
                      whereClauses.Add($" Modal = @Modal ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGlobalizadoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Globalizado"] = value; //06
                      whereClauses.Add($" Globalizado = @Globalizado ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFInicioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UFInicio"] = value; //06
                      whereClauses.Add($" UFInicio = @UFInicio ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFFimQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UFFim"] = value; //06
                      whereClauses.Add($" UFFim = @UFFim ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioInicioCodigoIbgeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MunicipioInicioCodigoIbge"] = value; //06
                      whereClauses.Add($" MunicipioInicioCodigoIbge = @MunicipioInicioCodigoIbge ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioFimCodigoIbgeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MunicipioFimCodigoIbge"] = value; //06
                      whereClauses.Add($" MunicipioFimCodigoIbge = @MunicipioFimCodigoIbge ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByValorServicoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ValorServico"] = value; //06
                      whereClauses.Add($" ValorServico = @ValorServico ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByValorCargaQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ValorCarga"] = value; //06
                      whereClauses.Add($" ValorCarga = @ValorCarga ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPreferenciasManifestoJsonQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PreferenciasManifestoJson"] = value; //06
                      whereClauses.Add($" PreferenciasManifestoJson = @PreferenciasManifestoJson ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" Status = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" TenantID = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" Deleted = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" Changed = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, EntradaOficialId, RomaneioConsolidadoId, CorrelationId, Ambiente, UFEmitente, EmitenteDocumento, ProdutoFiscal, TipoCTe, TipoServico, Modal, Globalizado, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, ValorServico, ValorCarga, PreferenciasManifestoJson, Status, TenantID, Deleted, Changed, UserId FROM CTeSolicitacaoFiscal ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" UserId = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration