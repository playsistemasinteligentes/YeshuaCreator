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
    public class TipoVeiculoQueryRead : QueryBase, ITipoVeiculoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public TipoVeiculoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel TipoVeiculoQuery(Command.Read.TipoVeiculoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] from [TipoVeiculo] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.TIP_ID.HasValue) dict["TIP_ID"] = Command.TIP_ID.Value;
if (Command.TIP_ID.HasValue) whereClauses.Add($"[TIP_ID] = @TIP_ID");
if (!string.IsNullOrEmpty(Command.TIP_DESCRICAO)) dict["TIP_DESCRICAO"] = $"%{Command.TIP_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.TIP_DESCRICAO)) whereClauses.Add($"[TIP_DESCRICAO] like @TIP_DESCRICAO");
if (Command.TIP_QTD_DISPONIVEL.HasValue) dict["TIP_QTD_DISPONIVEL"] = Command.TIP_QTD_DISPONIVEL.Value;
if (Command.TIP_QTD_DISPONIVEL.HasValue) whereClauses.Add($"[TIP_QTD_DISPONIVEL] = @TIP_QTD_DISPONIVEL");
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
        public QueryModel TipoVeiculoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
            this.Parameters = null;
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
        public QueryModel TipoVeiculoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
            this.Parameters = null;
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
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
        public QueryModel ExistsByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_ID"] = value; //04
                      whereClauses.Add($" [TIP_ID] = @TIP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_DESCRICAO"] = value; //04
                      whereClauses.Add($" [TIP_DESCRICAO] = @TIP_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_QTD_DISPONIVELQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_QTD_DISPONIVEL"] = value; //04
                      whereClauses.Add($" [TIP_QTD_DISPONIVEL] = @TIP_QTD_DISPONIVEL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_VALOR_KMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VALOR_KM"] = value; //04
                      whereClauses.Add($" [TIP_VALOR_KM] = @TIP_VALOR_KM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_VALOR_DIARIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VALOR_DIARIA"] = value; //04
                      whereClauses.Add($" [TIP_VALOR_DIARIA] = @TIP_VALOR_DIARIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_VALOR_AJUDANTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VALOR_AJUDANTE"] = value; //04
                      whereClauses.Add($" [TIP_VALOR_AJUDANTE] = @TIP_VALOR_AJUDANTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_QTD_EIXOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_QTD_EIXOS"] = value; //04
                      whereClauses.Add($" [TIP_QTD_EIXOS] = @TIP_QTD_EIXOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_VELOCIDADE_MEDIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VELOCIDADE_MEDIA"] = value; //04
                      whereClauses.Add($" [TIP_VELOCIDADE_MEDIA] = @TIP_VELOCIDADE_MEDIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_ALTURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_ALTURA"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_ALTURA] = @TIP_CAPACIDADE_ALTURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_COMPRIMENTO] = @TIP_CAPACIDADE_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_LARGURA"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_LARGURA] = @TIP_CAPACIDADE_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_ALTURA_PESCOCO_E"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_ALTURA_PESCOCO_E] = @TIP_CAPACIDADE_ALTURA_PESCOCO_E ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_LARGURA_PESCOCO_E"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_LARGURA_PESCOCO_E] = @TIP_CAPACIDADE_LARGURA_PESCOCO_E ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_ALTURA_PESCOCO_D"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_ALTURA_PESCOCO_D] = @TIP_CAPACIDADE_ALTURA_PESCOCO_D ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_LARGURA_PESCOCO_D"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_LARGURA_PESCOCO_D] = @TIP_CAPACIDADE_LARGURA_PESCOCO_D ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_CAPACIDADE_M3Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_M3"] = value; //04
                      whereClauses.Add($" [TIP_CAPACIDADE_M3] = @TIP_CAPACIDADE_M3 ");//04
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
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
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
        public QueryModel FirstByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_ID"] = value; //06
                      whereClauses.Add($" [TIP_ID] = @TIP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_DESCRICAO"] = value; //06
                      whereClauses.Add($" [TIP_DESCRICAO] = @TIP_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_QTD_DISPONIVELQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_QTD_DISPONIVEL"] = value; //06
                      whereClauses.Add($" [TIP_QTD_DISPONIVEL] = @TIP_QTD_DISPONIVEL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_VALOR_KMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VALOR_KM"] = value; //06
                      whereClauses.Add($" [TIP_VALOR_KM] = @TIP_VALOR_KM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_VALOR_DIARIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VALOR_DIARIA"] = value; //06
                      whereClauses.Add($" [TIP_VALOR_DIARIA] = @TIP_VALOR_DIARIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_VALOR_AJUDANTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VALOR_AJUDANTE"] = value; //06
                      whereClauses.Add($" [TIP_VALOR_AJUDANTE] = @TIP_VALOR_AJUDANTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_QTD_EIXOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_QTD_EIXOS"] = value; //06
                      whereClauses.Add($" [TIP_QTD_EIXOS] = @TIP_QTD_EIXOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_VELOCIDADE_MEDIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_VELOCIDADE_MEDIA"] = value; //06
                      whereClauses.Add($" [TIP_VELOCIDADE_MEDIA] = @TIP_VELOCIDADE_MEDIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_ALTURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_ALTURA"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_ALTURA] = @TIP_CAPACIDADE_ALTURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_COMPRIMENTO] = @TIP_CAPACIDADE_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_LARGURA"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_LARGURA] = @TIP_CAPACIDADE_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_ALTURA_PESCOCO_E"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_ALTURA_PESCOCO_E] = @TIP_CAPACIDADE_ALTURA_PESCOCO_E ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_LARGURA_PESCOCO_E"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_LARGURA_PESCOCO_E] = @TIP_CAPACIDADE_LARGURA_PESCOCO_E ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_ALTURA_PESCOCO_D"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_ALTURA_PESCOCO_D] = @TIP_CAPACIDADE_ALTURA_PESCOCO_D ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_LARGURA_PESCOCO_D"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_LARGURA_PESCOCO_D] = @TIP_CAPACIDADE_LARGURA_PESCOCO_D ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_CAPACIDADE_M3Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_CAPACIDADE_M3"] = value; //06
                      whereClauses.Add($" [TIP_CAPACIDADE_M3] = @TIP_CAPACIDADE_M3 ");//06
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
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
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
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId] FROM [TipoVeiculo] ";
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