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
    public class EmissaoFiscalTransporteDocumentoQueryRead : QueryBase, IEmissaoFiscalTransporteDocumentoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public EmissaoFiscalTransporteDocumentoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel EmissaoFiscalTransporteDocumentoQuery(Command.Read.EmissaoFiscalTransporteDocumentoReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] from [EmissaoFiscalTransporteDocumento] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.EmissaoFiscalTransporteId.HasValue) dict["EmissaoFiscalTransporteId"] = Command.EmissaoFiscalTransporteId.Value;
if (Command.EmissaoFiscalTransporteId.HasValue) whereClauses.Add($"[EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId");
if (Command.DocumentoFiscalId.HasValue) dict["DocumentoFiscalId"] = Command.DocumentoFiscalId.Value;
if (Command.DocumentoFiscalId.HasValue) whereClauses.Add($"[DocumentoFiscalId] = @DocumentoFiscalId");
if (Command.DocumentoFiscalOriginarioId.HasValue) dict["DocumentoFiscalOriginarioId"] = Command.DocumentoFiscalOriginarioId.Value;
if (Command.DocumentoFiscalOriginarioId.HasValue) whereClauses.Add($"[DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId");
if (Command.NFeProdutoSnapshotId.HasValue) dict["NFeProdutoSnapshotId"] = Command.NFeProdutoSnapshotId.Value;
if (Command.NFeProdutoSnapshotId.HasValue) whereClauses.Add($"[NFeProdutoSnapshotId] = @NFeProdutoSnapshotId");
if (Command.ProdutoFiscal.HasValue)
{
    dict["ProdutoFiscal"] = Command.ProdutoFiscal.Value;
    whereClauses.Add($"[ProdutoFiscal] = @ProdutoFiscal");
}
if (Command.Papel.HasValue)
{
    dict["Papel"] = Command.Papel.Value;
    whereClauses.Add($"[Papel] = @Papel");
}
if (!string.IsNullOrEmpty(Command.TipoEvento)) dict["TipoEvento"] = $"%{Command.TipoEvento}%";
if (!string.IsNullOrEmpty(Command.TipoEvento)) whereClauses.Add($"[TipoEvento] like @TipoEvento");
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) dict["ChaveAcesso"] = $"%{Command.ChaveAcesso}%";
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) whereClauses.Add($"[ChaveAcesso] like @ChaveAcesso");
if (!string.IsNullOrEmpty(Command.XmlStorageKey)) dict["XmlStorageKey"] = $"%{Command.XmlStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlStorageKey)) whereClauses.Add($"[XmlStorageKey] like @XmlStorageKey");
if (!string.IsNullOrEmpty(Command.PdfStorageKey)) dict["PdfStorageKey"] = $"%{Command.PdfStorageKey}%";
if (!string.IsNullOrEmpty(Command.PdfStorageKey)) whereClauses.Add($"[PdfStorageKey] like @PdfStorageKey");
if (!string.IsNullOrEmpty(Command.Protocolo)) dict["Protocolo"] = $"%{Command.Protocolo}%";
if (!string.IsNullOrEmpty(Command.Protocolo)) whereClauses.Add($"[Protocolo] like @Protocolo");
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
        public QueryModel EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel EmissaoFiscalTransporteDocumentoDocumentoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [DocumentoFiscal] ";
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
        public QueryModel EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [DocumentoFiscalOriginario] ";
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
        public QueryModel EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [NFeProdutoSnapshot] ";
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
        public QueryModel EmissaoFiscalTransporteDocumentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel EmissaoFiscalTransporteDocumentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel ExistsByDocumentoFiscalIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DocumentoFiscalId"] = value; //04
                      whereClauses.Add($" [DocumentoFiscalId] = @DocumentoFiscalId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDocumentoFiscalOriginarioIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DocumentoFiscalOriginarioId"] = value; //04
                      whereClauses.Add($" [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByNFeProdutoSnapshotIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["NFeProdutoSnapshotId"] = value; //04
                      whereClauses.Add($" [NFeProdutoSnapshotId] = @NFeProdutoSnapshotId ");//04
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel ExistsByPapelQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Papel"] = value; //04
                      whereClauses.Add($" [Papel] = @Papel ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoEventoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoEvento"] = value; //04
                      whereClauses.Add($" [TipoEvento] = @TipoEvento ");//04
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel ExistsByXmlStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel ExistsByPdfStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PdfStorageKey"] = value; //04
                      whereClauses.Add($" [PdfStorageKey] = @PdfStorageKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProtocoloQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Protocolo"] = value; //04
                      whereClauses.Add($" [Protocolo] = @Protocolo ");//04
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel ExistsByCriadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel ExistsByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT 1 FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel FirstByDocumentoFiscalIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DocumentoFiscalId"] = value; //06
                      whereClauses.Add($" [DocumentoFiscalId] = @DocumentoFiscalId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDocumentoFiscalOriginarioIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DocumentoFiscalOriginarioId"] = value; //06
                      whereClauses.Add($" [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByNFeProdutoSnapshotIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["NFeProdutoSnapshotId"] = value; //06
                      whereClauses.Add($" [NFeProdutoSnapshotId] = @NFeProdutoSnapshotId ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel FirstByPapelQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Papel"] = value; //06
                      whereClauses.Add($" [Papel] = @Papel ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoEventoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TipoEvento"] = value; //06
                      whereClauses.Add($" [TipoEvento] = @TipoEvento ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel FirstByXmlStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel FirstByPdfStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PdfStorageKey"] = value; //06
                      whereClauses.Add($" [PdfStorageKey] = @PdfStorageKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProtocoloQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Protocolo"] = value; //06
                      whereClauses.Add($" [Protocolo] = @Protocolo ");//06
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel FirstByCriadoEmUtcQuery(DateTime value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
        public QueryModel FirstByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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
            this.Query = $"SELECT [Id], [EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [EmissaoFiscalTransporteDocumento] ";
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