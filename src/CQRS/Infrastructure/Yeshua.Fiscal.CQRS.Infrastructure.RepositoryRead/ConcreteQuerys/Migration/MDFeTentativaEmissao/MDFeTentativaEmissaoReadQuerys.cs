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
    public class MDFeTentativaEmissaoQueryRead : QueryBase, IMDFeTentativaEmissaoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeTentativaEmissaoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel MDFeTentativaEmissaoQuery(Command.Read.MDFeTentativaEmissaoReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] from [MDFeTentativaEmissao] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.MDFeSolicitacaoFiscalId.HasValue) dict["MDFeSolicitacaoFiscalId"] = Command.MDFeSolicitacaoFiscalId.Value;
if (Command.MDFeSolicitacaoFiscalId.HasValue) whereClauses.Add($"[MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId");
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) dict["ChaveAcesso"] = $"%{Command.ChaveAcesso}%";
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) whereClauses.Add($"[ChaveAcesso] like @ChaveAcesso");
if (Command.Numero.HasValue) dict["Numero"] = Command.Numero.Value;
if (Command.Numero.HasValue) whereClauses.Add($"[Numero] = @Numero");
if (Command.Serie.HasValue) dict["Serie"] = Command.Serie.Value;
if (Command.Serie.HasValue) whereClauses.Add($"[Serie] = @Serie");
if (Command.Tentativa.HasValue) dict["Tentativa"] = Command.Tentativa.Value;
if (Command.Tentativa.HasValue) whereClauses.Add($"[Tentativa] = @Tentativa");
if (!string.IsNullOrEmpty(Command.XmlAssinadoStorageKey)) dict["XmlAssinadoStorageKey"] = $"%{Command.XmlAssinadoStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlAssinadoStorageKey)) whereClauses.Add($"[XmlAssinadoStorageKey] like @XmlAssinadoStorageKey");
if (!string.IsNullOrEmpty(Command.XmlProcStorageKey)) dict["XmlProcStorageKey"] = $"%{Command.XmlProcStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlProcStorageKey)) whereClauses.Add($"[XmlProcStorageKey] like @XmlProcStorageKey");
if (!string.IsNullOrEmpty(Command.XmlHash)) dict["XmlHash"] = $"%{Command.XmlHash}%";
if (!string.IsNullOrEmpty(Command.XmlHash)) whereClauses.Add($"[XmlHash] like @XmlHash");
if (!string.IsNullOrEmpty(Command.CodigoRetorno)) dict["CodigoRetorno"] = $"%{Command.CodigoRetorno}%";
if (!string.IsNullOrEmpty(Command.CodigoRetorno)) whereClauses.Add($"[CodigoRetorno] like @CodigoRetorno");
if (!string.IsNullOrEmpty(Command.MensagemRetorno)) dict["MensagemRetorno"] = $"%{Command.MensagemRetorno}%";
if (!string.IsNullOrEmpty(Command.MensagemRetorno)) whereClauses.Add($"[MensagemRetorno] like @MensagemRetorno");
if (!string.IsNullOrEmpty(Command.ProtocoloAutorizacao)) dict["ProtocoloAutorizacao"] = $"%{Command.ProtocoloAutorizacao}%";
if (!string.IsNullOrEmpty(Command.ProtocoloAutorizacao)) whereClauses.Add($"[ProtocoloAutorizacao] like @ProtocoloAutorizacao");
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
        public QueryModel MDFeTentativaEmissaoMDFeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [MDFeSolicitacaoFiscal] ";
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
        public QueryModel MDFeTentativaEmissaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel MDFeTentativaEmissaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
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
        public QueryModel ExistsByMDFeSolicitacaoFiscalIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MDFeSolicitacaoFiscalId"] = value; //04
                      whereClauses.Add($" [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChaveAcessoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ChaveAcesso"] = value; //04
                      whereClauses.Add($" [ChaveAcesso] = @ChaveAcesso ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByNumeroQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Numero"] = value; //04
                      whereClauses.Add($" [Numero] = @Numero ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySerieQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Serie"] = value; //04
                      whereClauses.Add($" [Serie] = @Serie ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTentativaQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Tentativa"] = value; //04
                      whereClauses.Add($" [Tentativa] = @Tentativa ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByXmlAssinadoStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlAssinadoStorageKey"] = value; //04
                      whereClauses.Add($" [XmlAssinadoStorageKey] = @XmlAssinadoStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByXmlProcStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlProcStorageKey"] = value; //04
                      whereClauses.Add($" [XmlProcStorageKey] = @XmlProcStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByXmlHashQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlHash"] = value; //04
                      whereClauses.Add($" [XmlHash] = @XmlHash ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCodigoRetornoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CodigoRetorno"] = value; //04
                      whereClauses.Add($" [CodigoRetorno] = @CodigoRetorno ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMensagemRetornoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MensagemRetorno"] = value; //04
                      whereClauses.Add($" [MensagemRetorno] = @MensagemRetorno ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProtocoloAutorizacaoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ProtocoloAutorizacao"] = value; //04
                      whereClauses.Add($" [ProtocoloAutorizacao] = @ProtocoloAutorizacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEnviadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EnviadoEmUtc"] = value; //04
                      whereClauses.Add($" [EnviadoEmUtc] = @EnviadoEmUtc ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAutorizadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AutorizadoEmUtc"] = value; //04
                      whereClauses.Add($" [AutorizadoEmUtc] = @AutorizadoEmUtc ");//04
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
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT 1 FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
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
        public QueryModel FirstByMDFeSolicitacaoFiscalIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MDFeSolicitacaoFiscalId"] = value; //06
                      whereClauses.Add($" [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChaveAcessoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ChaveAcesso"] = value; //06
                      whereClauses.Add($" [ChaveAcesso] = @ChaveAcesso ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByNumeroQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Numero"] = value; //06
                      whereClauses.Add($" [Numero] = @Numero ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySerieQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Serie"] = value; //06
                      whereClauses.Add($" [Serie] = @Serie ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTentativaQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Tentativa"] = value; //06
                      whereClauses.Add($" [Tentativa] = @Tentativa ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByXmlAssinadoStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlAssinadoStorageKey"] = value; //06
                      whereClauses.Add($" [XmlAssinadoStorageKey] = @XmlAssinadoStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByXmlProcStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlProcStorageKey"] = value; //06
                      whereClauses.Add($" [XmlProcStorageKey] = @XmlProcStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByXmlHashQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlHash"] = value; //06
                      whereClauses.Add($" [XmlHash] = @XmlHash ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCodigoRetornoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CodigoRetorno"] = value; //06
                      whereClauses.Add($" [CodigoRetorno] = @CodigoRetorno ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMensagemRetornoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MensagemRetorno"] = value; //06
                      whereClauses.Add($" [MensagemRetorno] = @MensagemRetorno ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProtocoloAutorizacaoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ProtocoloAutorizacao"] = value; //06
                      whereClauses.Add($" [ProtocoloAutorizacao] = @ProtocoloAutorizacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEnviadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EnviadoEmUtc"] = value; //06
                      whereClauses.Add($" [EnviadoEmUtc] = @EnviadoEmUtc ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAutorizadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AutorizadoEmUtc"] = value; //06
                      whereClauses.Add($" [AutorizadoEmUtc] = @AutorizadoEmUtc ");//06
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
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
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
            this.Query = $"SELECT [Id], [MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [MDFeTentativaEmissao] ";
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