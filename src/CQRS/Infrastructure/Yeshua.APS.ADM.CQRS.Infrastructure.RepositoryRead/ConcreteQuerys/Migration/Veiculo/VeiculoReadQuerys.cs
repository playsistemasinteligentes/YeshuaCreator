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
    public class VeiculoQueryRead : QueryBase, IVeiculoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public VeiculoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel VeiculoQuery(Command.Read.VeiculoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] from [Veiculo] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (!string.IsNullOrEmpty(Command.VEI_PLACA)) dict["VEI_PLACA"] = $"%{Command.VEI_PLACA}%";
if (!string.IsNullOrEmpty(Command.VEI_PLACA)) whereClauses.Add($"[VEI_PLACA] like @VEI_PLACA");
if (!string.IsNullOrEmpty(Command.VEI_UF)) dict["VEI_UF"] = $"%{Command.VEI_UF}%";
if (!string.IsNullOrEmpty(Command.VEI_UF)) whereClauses.Add($"[VEI_UF] like @VEI_UF");
if (Command.TIP_ID.HasValue) dict["TIP_ID"] = Command.TIP_ID.Value;
if (Command.TIP_ID.HasValue) whereClauses.Add($"[TIP_ID] = @TIP_ID");
if (!string.IsNullOrEmpty(Command.VEI_MODELO)) dict["VEI_MODELO"] = $"%{Command.VEI_MODELO}%";
if (!string.IsNullOrEmpty(Command.VEI_MODELO)) whereClauses.Add($"[VEI_MODELO] like @VEI_MODELO");
if (!string.IsNullOrEmpty(Command.VEI_NOME_MOTORISTA)) dict["VEI_NOME_MOTORISTA"] = $"%{Command.VEI_NOME_MOTORISTA}%";
if (!string.IsNullOrEmpty(Command.VEI_NOME_MOTORISTA)) whereClauses.Add($"[VEI_NOME_MOTORISTA] like @VEI_NOME_MOTORISTA");
if (!string.IsNullOrEmpty(Command.VEI_DADOS_CONTATO)) dict["VEI_DADOS_CONTATO"] = $"%{Command.VEI_DADOS_CONTATO}%";
if (!string.IsNullOrEmpty(Command.VEI_DADOS_CONTATO)) whereClauses.Add($"[VEI_DADOS_CONTATO] like @VEI_DADOS_CONTATO");
if (!string.IsNullOrEmpty(Command.VEI_CPF_MOTORISTA)) dict["VEI_CPF_MOTORISTA"] = $"%{Command.VEI_CPF_MOTORISTA}%";
if (!string.IsNullOrEmpty(Command.VEI_CPF_MOTORISTA)) whereClauses.Add($"[VEI_CPF_MOTORISTA] like @VEI_CPF_MOTORISTA");
if (!string.IsNullOrEmpty(Command.TCA_ID)) dict["TCA_ID"] = $"%{Command.TCA_ID}%";
if (!string.IsNullOrEmpty(Command.TCA_ID)) whereClauses.Add($"[TCA_ID] like @TCA_ID");
if (!string.IsNullOrEmpty(Command.VEI_STATUS)) dict["VEI_STATUS"] = $"%{Command.VEI_STATUS}%";
if (!string.IsNullOrEmpty(Command.VEI_STATUS)) whereClauses.Add($"[VEI_STATUS] like @VEI_STATUS");
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
        public QueryModel VeiculoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel VeiculoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [Veiculo] ";
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
        public QueryModel ExistsByVEI_PLACAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_PLACA"] = value; //04
                      whereClauses.Add($" [VEI_PLACA] = @VEI_PLACA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_UFQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_UF"] = value; //04
                      whereClauses.Add($" [VEI_UF] = @VEI_UF ");//04
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
            this.Query = $"SELECT 1 FROM [Veiculo] ";
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
        public QueryModel ExistsByVEI_CAPACIDADE_M3Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_M3"] = value; //04
                      whereClauses.Add($" [VEI_CAPACIDADE_M3] = @VEI_CAPACIDADE_M3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_CAPACIDADE_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_LARGURA"] = value; //04
                      whereClauses.Add($" [VEI_CAPACIDADE_LARGURA] = @VEI_CAPACIDADE_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_CAPACIDADE_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" [VEI_CAPACIDADE_COMPRIMENTO] = @VEI_CAPACIDADE_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_CAPACIDADE_ALTURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_ALTURA"] = value; //04
                      whereClauses.Add($" [VEI_CAPACIDADE_ALTURA] = @VEI_CAPACIDADE_ALTURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_MODELOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_MODELO"] = value; //04
                      whereClauses.Add($" [VEI_MODELO] = @VEI_MODELO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_NOME_MOTORISTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_NOME_MOTORISTA"] = value; //04
                      whereClauses.Add($" [VEI_NOME_MOTORISTA] = @VEI_NOME_MOTORISTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_DADOS_CONTATOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_DADOS_CONTATO"] = value; //04
                      whereClauses.Add($" [VEI_DADOS_CONTATO] = @VEI_DADOS_CONTATO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_CPF_MOTORISTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CPF_MOTORISTA"] = value; //04
                      whereClauses.Add($" [VEI_CPF_MOTORISTA] = @VEI_CPF_MOTORISTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTCA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TCA_ID"] = value; //04
                      whereClauses.Add($" [TCA_ID] = @TCA_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_EMISSAO"] = value; //04
                      whereClauses.Add($" [VEI_EMISSAO] = @VEI_EMISSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_VENCIMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_VENCIMENTO"] = value; //04
                      whereClauses.Add($" [VEI_VENCIMENTO] = @VEI_VENCIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_STATUS"] = value; //04
                      whereClauses.Add($" [VEI_STATUS] = @VEI_STATUS ");//04
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
            this.Query = $"SELECT 1 FROM [Veiculo] ";
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
            this.Query = $"SELECT 1 FROM [Veiculo] ";
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
            this.Query = $"SELECT 1 FROM [Veiculo] ";
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
            this.Query = $"SELECT 1 FROM [Veiculo] ";
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
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
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
        public QueryModel FirstByVEI_PLACAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_PLACA"] = value; //06
                      whereClauses.Add($" [VEI_PLACA] = @VEI_PLACA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_UFQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_UF"] = value; //06
                      whereClauses.Add($" [VEI_UF] = @VEI_UF ");//06
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
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
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
        public QueryModel FirstByVEI_CAPACIDADE_M3Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_M3"] = value; //06
                      whereClauses.Add($" [VEI_CAPACIDADE_M3] = @VEI_CAPACIDADE_M3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_CAPACIDADE_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_LARGURA"] = value; //06
                      whereClauses.Add($" [VEI_CAPACIDADE_LARGURA] = @VEI_CAPACIDADE_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_CAPACIDADE_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" [VEI_CAPACIDADE_COMPRIMENTO] = @VEI_CAPACIDADE_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_CAPACIDADE_ALTURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CAPACIDADE_ALTURA"] = value; //06
                      whereClauses.Add($" [VEI_CAPACIDADE_ALTURA] = @VEI_CAPACIDADE_ALTURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_MODELOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_MODELO"] = value; //06
                      whereClauses.Add($" [VEI_MODELO] = @VEI_MODELO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_NOME_MOTORISTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_NOME_MOTORISTA"] = value; //06
                      whereClauses.Add($" [VEI_NOME_MOTORISTA] = @VEI_NOME_MOTORISTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_DADOS_CONTATOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_DADOS_CONTATO"] = value; //06
                      whereClauses.Add($" [VEI_DADOS_CONTATO] = @VEI_DADOS_CONTATO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_CPF_MOTORISTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_CPF_MOTORISTA"] = value; //06
                      whereClauses.Add($" [VEI_CPF_MOTORISTA] = @VEI_CPF_MOTORISTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTCA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TCA_ID"] = value; //06
                      whereClauses.Add($" [TCA_ID] = @TCA_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_EMISSAO"] = value; //06
                      whereClauses.Add($" [VEI_EMISSAO] = @VEI_EMISSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_VENCIMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_VENCIMENTO"] = value; //06
                      whereClauses.Add($" [VEI_VENCIMENTO] = @VEI_VENCIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["VEI_STATUS"] = value; //06
                      whereClauses.Add($" [VEI_STATUS] = @VEI_STATUS ");//06
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
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
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
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
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
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
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
            this.Query = $"SELECT [Id], [VEI_PLACA], [VEI_UF], [TIP_ID], [VEI_CAPACIDADE_M3], [VEI_CAPACIDADE_LARGURA], [VEI_CAPACIDADE_COMPRIMENTO], [VEI_CAPACIDADE_ALTURA], [VEI_MODELO], [VEI_NOME_MOTORISTA], [VEI_DADOS_CONTATO], [VEI_CPF_MOTORISTA], [TCA_ID], [VEI_EMISSAO], [VEI_VENCIMENTO], [VEI_STATUS], [TenantID], [Deleted], [Changed], [UserId] FROM [Veiculo] ";
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