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
    public class NFeProdutoSnapshotQueryRead : QueryBase, INFeProdutoSnapshotQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public NFeProdutoSnapshotQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel NFeProdutoSnapshotQuery(Command.Read.NFeProdutoSnapshotReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] from [NFeProdutoSnapshot] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.DocumentoFiscalOriginarioId.HasValue) dict["DocumentoFiscalOriginarioId"] = Command.DocumentoFiscalOriginarioId.Value;
if (Command.DocumentoFiscalOriginarioId.HasValue) whereClauses.Add($"[DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"[CorrelationId] like @CorrelationId");
if (!string.IsNullOrEmpty(Command.CargaId)) dict["CargaId"] = $"%{Command.CargaId}%";
if (!string.IsNullOrEmpty(Command.CargaId)) whereClauses.Add($"[CargaId] like @CargaId");
if (!string.IsNullOrEmpty(Command.PedidoId)) dict["PedidoId"] = $"%{Command.PedidoId}%";
if (!string.IsNullOrEmpty(Command.PedidoId)) whereClauses.Add($"[PedidoId] like @PedidoId");
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) dict["ChaveAcesso"] = $"%{Command.ChaveAcesso}%";
if (!string.IsNullOrEmpty(Command.ChaveAcesso)) whereClauses.Add($"[ChaveAcesso] like @ChaveAcesso");
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) dict["EmitenteDocumento"] = $"%{Command.EmitenteDocumento}%";
if (!string.IsNullOrEmpty(Command.EmitenteDocumento)) whereClauses.Add($"[EmitenteDocumento] like @EmitenteDocumento");
if (!string.IsNullOrEmpty(Command.DestinatarioDocumento)) dict["DestinatarioDocumento"] = $"%{Command.DestinatarioDocumento}%";
if (!string.IsNullOrEmpty(Command.DestinatarioDocumento)) whereClauses.Add($"[DestinatarioDocumento] like @DestinatarioDocumento");
if (!string.IsNullOrEmpty(Command.UFOrigem)) dict["UFOrigem"] = $"%{Command.UFOrigem}%";
if (!string.IsNullOrEmpty(Command.UFOrigem)) whereClauses.Add($"[UFOrigem] like @UFOrigem");
if (!string.IsNullOrEmpty(Command.UFDestino)) dict["UFDestino"] = $"%{Command.UFDestino}%";
if (!string.IsNullOrEmpty(Command.UFDestino)) whereClauses.Add($"[UFDestino] like @UFDestino");
if (!string.IsNullOrEmpty(Command.MunicipioOrigemCodigoIbge)) dict["MunicipioOrigemCodigoIbge"] = $"%{Command.MunicipioOrigemCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioOrigemCodigoIbge)) whereClauses.Add($"[MunicipioOrigemCodigoIbge] like @MunicipioOrigemCodigoIbge");
if (!string.IsNullOrEmpty(Command.MunicipioDestinoCodigoIbge)) dict["MunicipioDestinoCodigoIbge"] = $"%{Command.MunicipioDestinoCodigoIbge}%";
if (!string.IsNullOrEmpty(Command.MunicipioDestinoCodigoIbge)) whereClauses.Add($"[MunicipioDestinoCodigoIbge] like @MunicipioDestinoCodigoIbge");
if (!string.IsNullOrEmpty(Command.XmlStorageKey)) dict["XmlStorageKey"] = $"%{Command.XmlStorageKey}%";
if (!string.IsNullOrEmpty(Command.XmlStorageKey)) whereClauses.Add($"[XmlStorageKey] like @XmlStorageKey");
if (!string.IsNullOrEmpty(Command.SnapshotJson)) dict["SnapshotJson"] = $"%{Command.SnapshotJson}%";
if (!string.IsNullOrEmpty(Command.SnapshotJson)) whereClauses.Add($"[SnapshotJson] like @SnapshotJson");
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
        public QueryModel NFeProdutoSnapshotDocumentoFiscalOriginarioIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel NFeProdutoSnapshotTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel NFeProdutoSnapshotUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByDocumentoFiscalOriginarioIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByPedidoIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PedidoId"] = value; //04
                      whereClauses.Add($" [PedidoId] = @PedidoId ");//04
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByEmitenteDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByUFOrigemQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFOrigem"] = value; //04
                      whereClauses.Add($" [UFOrigem] = @UFOrigem ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUFDestinoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFDestino"] = value; //04
                      whereClauses.Add($" [UFDestino] = @UFDestino ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioOrigemCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioOrigemCodigoIbge"] = value; //04
                      whereClauses.Add($" [MunicipioOrigemCodigoIbge] = @MunicipioOrigemCodigoIbge ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMunicipioDestinoCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioDestinoCodigoIbge"] = value; //04
                      whereClauses.Add($" [MunicipioDestinoCodigoIbge] = @MunicipioDestinoCodigoIbge ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByValorDocumentoQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValorDocumento"] = value; //04
                      whereClauses.Add($" [ValorDocumento] = @ValorDocumento ");//04
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByXmlStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsBySnapshotJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
        public QueryModel ExistsByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT 1 FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByDocumentoFiscalOriginarioIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByCorrelationIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByPedidoIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PedidoId"] = value; //06
                      whereClauses.Add($" [PedidoId] = @PedidoId ");//06
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByEmitenteDocumentoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByUFOrigemQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFOrigem"] = value; //06
                      whereClauses.Add($" [UFOrigem] = @UFOrigem ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUFDestinoQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UFDestino"] = value; //06
                      whereClauses.Add($" [UFDestino] = @UFDestino ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioOrigemCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioOrigemCodigoIbge"] = value; //06
                      whereClauses.Add($" [MunicipioOrigemCodigoIbge] = @MunicipioOrigemCodigoIbge ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMunicipioDestinoCodigoIbgeQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MunicipioDestinoCodigoIbge"] = value; //06
                      whereClauses.Add($" [MunicipioDestinoCodigoIbge] = @MunicipioDestinoCodigoIbge ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByValorDocumentoQuery(Decimal value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValorDocumento"] = value; //06
                      whereClauses.Add($" [ValorDocumento] = @ValorDocumento ");//06
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByXmlStorageKeyQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstBySnapshotJsonQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
        public QueryModel FirstByStatusQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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
            this.Query = $"SELECT [Id], [DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId] FROM [NFeProdutoSnapshot] ";
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