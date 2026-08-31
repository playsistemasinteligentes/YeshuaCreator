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
    public class CTeTentativaEmissaoQueryRead : QueryBase, ICTeTentativaEmissaoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CTeTentativaEmissaoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CTeTentativaEmissaoQuery(Command.Read.CTeTentativaEmissaoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId from CTeTentativaEmissao ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.CTeSolicitacaoFiscalId.HasValue) dict["CTeSolicitacaoFiscalId"] = Command.CTeSolicitacaoFiscalId.Value;
if (Command.CTeSolicitacaoFiscalId.HasValue) whereClauses.Add($"CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId");
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) dict["ChaveAcesso"] = $"%{Command.ChaveAcesso}%";
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) whereClauses.Add($"ChaveAcesso like @ChaveAcesso");
if (Command.Numero.HasValue) dict["Numero"] = Command.Numero.Value;
if (Command.Numero.HasValue) whereClauses.Add($"Numero = @Numero");
if (Command.Serie.HasValue) dict["Serie"] = Command.Serie.Value;
if (Command.Serie.HasValue) whereClauses.Add($"Serie = @Serie");
if (Command.Tentativa.HasValue) dict["Tentativa"] = Command.Tentativa.Value;
if (Command.Tentativa.HasValue) whereClauses.Add($"Tentativa = @Tentativa");
if (!string.IsNullOrEmpty(Command.XmlAssinadoStorageKey)) dict["XmlAssinadoStorageKey"] = $"%{Command.XmlAssinadoStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlAssinadoStorageKey)) whereClauses.Add($"XmlAssinadoStorageKey like @XmlAssinadoStorageKey");
if (!string.IsNullOrEmpty(Command.XmlProcStorageKey)) dict["XmlProcStorageKey"] = $"%{Command.XmlProcStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlProcStorageKey)) whereClauses.Add($"XmlProcStorageKey like @XmlProcStorageKey");
if (!string.IsNullOrEmpty(Command.XmlHash)) dict["XmlHash"] = $"%{Command.XmlHash}%";
if (!string.IsNullOrEmpty(Command.XmlHash)) whereClauses.Add($"XmlHash like @XmlHash");
if (!string.IsNullOrEmpty(Command.CodigoRetorno)) dict["CodigoRetorno"] = $"%{Command.CodigoRetorno}%";
if (!string.IsNullOrEmpty(Command.CodigoRetorno)) whereClauses.Add($"CodigoRetorno like @CodigoRetorno");
if (!string.IsNullOrEmpty(Command.MensagemRetorno)) dict["MensagemRetorno"] = $"%{Command.MensagemRetorno}%";
if (!string.IsNullOrEmpty(Command.MensagemRetorno)) whereClauses.Add($"MensagemRetorno like @MensagemRetorno");
if (!string.IsNullOrEmpty(Command.ProtocoloAutorizacao)) dict["ProtocoloAutorizacao"] = $"%{Command.ProtocoloAutorizacao}%";
if (!string.IsNullOrEmpty(Command.ProtocoloAutorizacao)) whereClauses.Add($"ProtocoloAutorizacao like @ProtocoloAutorizacao");
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
        public QueryModel CTeTentativaEmissaoCTeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id from CTeSolicitacaoFiscal ";
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
        public QueryModel CTeTentativaEmissaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CTeTentativaEmissaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
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
        public QueryModel ExistsByCTeSolicitacaoFiscalIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CTeSolicitacaoFiscalId"] = value; //04
                      whereClauses.Add($" CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChaveAcessoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ChaveAcesso"] = value; //04
                      whereClauses.Add($" ChaveAcesso = @ChaveAcesso ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByNumeroQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Numero"] = value; //04
                      whereClauses.Add($" Numero = @Numero ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySerieQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Serie"] = value; //04
                      whereClauses.Add($" Serie = @Serie ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTentativaQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Tentativa"] = value; //04
                      whereClauses.Add($" Tentativa = @Tentativa ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByXmlAssinadoStorageKeyQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["XmlAssinadoStorageKey"] = value; //04
                      whereClauses.Add($" XmlAssinadoStorageKey = @XmlAssinadoStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByXmlProcStorageKeyQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["XmlProcStorageKey"] = value; //04
                      whereClauses.Add($" XmlProcStorageKey = @XmlProcStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByXmlHashQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["XmlHash"] = value; //04
                      whereClauses.Add($" XmlHash = @XmlHash ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCodigoRetornoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CodigoRetorno"] = value; //04
                      whereClauses.Add($" CodigoRetorno = @CodigoRetorno ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMensagemRetornoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MensagemRetorno"] = value; //04
                      whereClauses.Add($" MensagemRetorno = @MensagemRetorno ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProtocoloAutorizacaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProtocoloAutorizacao"] = value; //04
                      whereClauses.Add($" ProtocoloAutorizacao = @ProtocoloAutorizacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEnviadoEmUtcQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EnviadoEmUtc"] = value; //04
                      whereClauses.Add($" EnviadoEmUtc = @EnviadoEmUtc ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAutorizadoEmUtcQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["AutorizadoEmUtc"] = value; //04
                      whereClauses.Add($" AutorizadoEmUtc = @AutorizadoEmUtc ");//04
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
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT 1 FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
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
        public QueryModel FirstByCTeSolicitacaoFiscalIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CTeSolicitacaoFiscalId"] = value; //06
                      whereClauses.Add($" CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChaveAcessoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ChaveAcesso"] = value; //06
                      whereClauses.Add($" ChaveAcesso = @ChaveAcesso ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByNumeroQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Numero"] = value; //06
                      whereClauses.Add($" Numero = @Numero ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySerieQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Serie"] = value; //06
                      whereClauses.Add($" Serie = @Serie ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTentativaQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Tentativa"] = value; //06
                      whereClauses.Add($" Tentativa = @Tentativa ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByXmlAssinadoStorageKeyQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["XmlAssinadoStorageKey"] = value; //06
                      whereClauses.Add($" XmlAssinadoStorageKey = @XmlAssinadoStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByXmlProcStorageKeyQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["XmlProcStorageKey"] = value; //06
                      whereClauses.Add($" XmlProcStorageKey = @XmlProcStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByXmlHashQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["XmlHash"] = value; //06
                      whereClauses.Add($" XmlHash = @XmlHash ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCodigoRetornoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CodigoRetorno"] = value; //06
                      whereClauses.Add($" CodigoRetorno = @CodigoRetorno ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMensagemRetornoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MensagemRetorno"] = value; //06
                      whereClauses.Add($" MensagemRetorno = @MensagemRetorno ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProtocoloAutorizacaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProtocoloAutorizacao"] = value; //06
                      whereClauses.Add($" ProtocoloAutorizacao = @ProtocoloAutorizacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEnviadoEmUtcQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EnviadoEmUtc"] = value; //06
                      whereClauses.Add($" EnviadoEmUtc = @EnviadoEmUtc ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAutorizadoEmUtcQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["AutorizadoEmUtc"] = value; //06
                      whereClauses.Add($" AutorizadoEmUtc = @AutorizadoEmUtc ");//06
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
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
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
            this.Query = $"SELECT Id, CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId FROM CTeTentativaEmissao ";
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