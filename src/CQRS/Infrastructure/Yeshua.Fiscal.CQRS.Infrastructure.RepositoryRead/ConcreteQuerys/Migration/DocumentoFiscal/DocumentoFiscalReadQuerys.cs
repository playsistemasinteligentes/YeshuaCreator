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
    public class DocumentoFiscalQueryRead : QueryBase, IDocumentoFiscalQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public DocumentoFiscalQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel DocumentoFiscalQuery(Command.Read.DocumentoFiscalReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] from [DocumentoFiscal] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"[CorrelationId] like @CorrelationId");
if (Command.ProdutoFiscal.HasValue)
{
    dict["ProdutoFiscal"] = Command.ProdutoFiscal.Value;
    whereClauses.Add($"[ProdutoFiscal] = @ProdutoFiscal");
}
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) dict["ChaveAcesso"] = $"%{Command.ChaveAcesso}%";
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) whereClauses.Add($"[ChaveAcesso] like @ChaveAcesso");
if (Command.Serie.HasValue) dict["Serie"] = Command.Serie.Value;
if (Command.Serie.HasValue) whereClauses.Add($"[Serie] = @Serie");
if (Command.Numero.HasValue) dict["Numero"] = Command.Numero.Value;
if (Command.Numero.HasValue) whereClauses.Add($"[Numero] = @Numero");
if (Command.Ambiente.HasValue)
{
    dict["Ambiente"] = Command.Ambiente.Value;
    whereClauses.Add($"[Ambiente] = @Ambiente");
}
if (!string.IsNullOrEmpty(Command.UFEmitente)) dict["UFEmitente"] = $"%{Command.UFEmitente}%";
if (!string.IsNullOrEmpty(Command.UFEmitente)) whereClauses.Add($"[UFEmitente] like @UFEmitente");
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) dict["EmitenteDocumento"] = $"%{Command.EmitenteDocumento}%";
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) whereClauses.Add($"[EmitenteDocumento] like @EmitenteDocumento");
if (!string.IsNullOrEmpty(Command.DestinatarioDocumento)) dict["DestinatarioDocumento"] = $"%{Command.DestinatarioDocumento}%";
if (!string.IsNullOrEmpty(Command.DestinatarioDocumento)) whereClauses.Add($"[DestinatarioDocumento] like @DestinatarioDocumento");
if (!string.IsNullOrEmpty(Command.XmlStorageKey)) dict["XmlStorageKey"] = $"%{Command.XmlStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlStorageKey)) whereClauses.Add($"[XmlStorageKey] like @XmlStorageKey");
if (!string.IsNullOrEmpty(Command.XmlHash)) dict["XmlHash"] = $"%{Command.XmlHash}%";
if (!string.IsNullOrEmpty(Command.XmlHash)) whereClauses.Add($"[XmlHash] like @XmlHash");
if (!string.IsNullOrEmpty(Command.ProtocoloAutorizacao)) dict["ProtocoloAutorizacao"] = $"%{Command.ProtocoloAutorizacao}%";
if (!string.IsNullOrEmpty(Command.ProtocoloAutorizacao)) whereClauses.Add($"[ProtocoloAutorizacao] like @ProtocoloAutorizacao");
if (!string.IsNullOrEmpty(Command.CodigoRetorno)) dict["CodigoRetorno"] = $"%{Command.CodigoRetorno}%";
if (!string.IsNullOrEmpty(Command.CodigoRetorno)) whereClauses.Add($"[CodigoRetorno] like @CodigoRetorno");
if (!string.IsNullOrEmpty(Command.MensagemRetorno)) dict["MensagemRetorno"] = $"%{Command.MensagemRetorno}%";
if (!string.IsNullOrEmpty(Command.MensagemRetorno)) whereClauses.Add($"[MensagemRetorno] like @MensagemRetorno");
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
        public QueryModel DocumentoFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel DocumentoFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByProdutoFiscalQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByChaveAcessoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsBySerieQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByNumeroQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByAmbienteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByDestinatarioDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByXmlStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlStorageKey"] = value; //04
                      whereClauses.Add($" [XmlStorageKey] = @XmlStorageKey ");//04
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByProtocoloAutorizacaoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByCodigoRetornoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
        public QueryModel ExistsByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT 1 FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByProdutoFiscalQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByChaveAcessoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstBySerieQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByNumeroQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByAmbienteQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByDestinatarioDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByXmlStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["XmlStorageKey"] = value; //06
                      whereClauses.Add($" [XmlStorageKey] = @XmlStorageKey ");//06
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByProtocoloAutorizacaoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByCodigoRetornoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
        public QueryModel FirstByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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
            this.Query = $"SELECT [Id], [CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [DocumentoFiscal] ";
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