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
    public class TesteFisicoQueryRead : QueryBase, ITesteFisicoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public TesteFisicoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel TesteFisicoQuery(Command.Read.TesteFisicoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] from [TesteFisico] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.TES_ID.HasValue) dict["TES_ID"] = Command.TES_ID.Value;
if (Command.TES_ID.HasValue) whereClauses.Add($"[TES_ID] = @TES_ID");
if (Command.ITE_ID.HasValue) dict["ITE_ID"] = Command.ITE_ID.Value;
if (Command.ITE_ID.HasValue) whereClauses.Add($"[ITE_ID] = @ITE_ID");
if (Command.USR_ID.HasValue) dict["USR_ID"] = Command.USR_ID.Value;
if (Command.USR_ID.HasValue) whereClauses.Add($"[USR_ID] = @USR_ID");
if (!string.IsNullOrEmpty(Command.TES_NOME_TECNICO)) dict["TES_NOME_TECNICO"] = $"%{Command.TES_NOME_TECNICO}%";
if (!string.IsNullOrEmpty(Command.TES_NOME_TECNICO)) whereClauses.Add($"[TES_NOME_TECNICO] like @TES_NOME_TECNICO");
if (Command.TES_AMOSTRA.HasValue) dict["TES_AMOSTRA"] = Command.TES_AMOSTRA.Value;
if (Command.TES_AMOSTRA.HasValue) whereClauses.Add($"[TES_AMOSTRA] = @TES_AMOSTRA");
if (!string.IsNullOrEmpty(Command.TES_OP)) dict["TES_OP"] = $"%{Command.TES_OP}%";
if (!string.IsNullOrEmpty(Command.TES_OP)) whereClauses.Add($"[TES_OP] like @TES_OP");
if (!string.IsNullOrEmpty(Command.TES_VALOR_TEXTO)) dict["TES_VALOR_TEXTO"] = $"%{Command.TES_VALOR_TEXTO}%";
if (!string.IsNullOrEmpty(Command.TES_VALOR_TEXTO)) whereClauses.Add($"[TES_VALOR_TEXTO] like @TES_VALOR_TEXTO");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"[ORD_ID] like @ORD_ID");
if (!string.IsNullOrEmpty(Command.PRO_ID)) dict["PRO_ID"] = $"%{Command.PRO_ID}%";
if (!string.IsNullOrEmpty(Command.PRO_ID)) whereClauses.Add($"[PRO_ID] like @PRO_ID");
if (!string.IsNullOrEmpty(Command.MAQ_ID)) dict["MAQ_ID"] = $"%{Command.MAQ_ID}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID)) whereClauses.Add($"[MAQ_ID] like @MAQ_ID");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"[FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO");
if (Command.FPR_SEQ_TRANFORMACAO.HasValue) dict["FPR_SEQ_TRANFORMACAO"] = Command.FPR_SEQ_TRANFORMACAO.Value;
if (Command.FPR_SEQ_TRANFORMACAO.HasValue) whereClauses.Add($"[FPR_SEQ_TRANFORMACAO] = @FPR_SEQ_TRANFORMACAO");
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
        public QueryModel TesteFisicoUSR_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [USE_ID] from [Usuario] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["USE_ID"] = numero; //01
                      whereClauses.Add($" [USE_ID] = @USE_ID");//01 
                 }
                 else 
                 {
                      dict["USE_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [USE_ID] like @USE_ID ");//02
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
        public QueryModel TesteFisicoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [ORD_ID] from [Order] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["ORD_ID"] = numero; //01
                      whereClauses.Add($" [ORD_ID] = @ORD_ID");//01 
                 }
                 else 
                 {
                      dict["ORD_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [ORD_ID] like @ORD_ID ");//02
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
        public QueryModel TesteFisicoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel TesteFisicoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
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
        public QueryModel ExistsByTES_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_ID"] = value; //04
                      whereClauses.Add($" [TES_ID] = @TES_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITE_ID"] = value; //04
                      whereClauses.Add($" [ITE_ID] = @ITE_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUSR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["USR_ID"] = value; //04
                      whereClauses.Add($" [USR_ID] = @USR_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_NOME_TECNICOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_NOME_TECNICO"] = value; //04
                      whereClauses.Add($" [TES_NOME_TECNICO] = @TES_NOME_TECNICO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_AMOSTRAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_AMOSTRA"] = value; //04
                      whereClauses.Add($" [TES_AMOSTRA] = @TES_AMOSTRA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_OPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_OP"] = value; //04
                      whereClauses.Add($" [TES_OP] = @TES_OP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_VALOR_NUMERICOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_VALOR_NUMERICO"] = value; //04
                      whereClauses.Add($" [TES_VALOR_NUMERICO] = @TES_VALOR_NUMERICO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_VALOR_DATAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_VALOR_DATA"] = value; //04
                      whereClauses.Add($" [TES_VALOR_DATA] = @TES_VALOR_DATA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_VALOR_TEXTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_VALOR_TEXTO"] = value; //04
                      whereClauses.Add($" [TES_VALOR_TEXTO] = @TES_VALOR_TEXTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTES_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_EMISSAO"] = value; //04
                      whereClauses.Add($" [TES_EMISSAO] = @TES_EMISSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //04
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //04
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID"] = value; //04
                      whereClauses.Add($" [MAQ_ID] = @MAQ_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //04
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_SEQ_TRANFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_TRANFORMACAO"] = value; //04
                      whereClauses.Add($" [FPR_SEQ_TRANFORMACAO] = @FPR_SEQ_TRANFORMACAO ");//04
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
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
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
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
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
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
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
            this.Query = $"SELECT 1 FROM [TesteFisico] ";
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
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
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
        public QueryModel FirstByTES_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_ID"] = value; //06
                      whereClauses.Add($" [TES_ID] = @TES_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITE_ID"] = value; //06
                      whereClauses.Add($" [ITE_ID] = @ITE_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUSR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["USR_ID"] = value; //06
                      whereClauses.Add($" [USR_ID] = @USR_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_NOME_TECNICOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_NOME_TECNICO"] = value; //06
                      whereClauses.Add($" [TES_NOME_TECNICO] = @TES_NOME_TECNICO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_AMOSTRAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_AMOSTRA"] = value; //06
                      whereClauses.Add($" [TES_AMOSTRA] = @TES_AMOSTRA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_OPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_OP"] = value; //06
                      whereClauses.Add($" [TES_OP] = @TES_OP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_VALOR_NUMERICOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_VALOR_NUMERICO"] = value; //06
                      whereClauses.Add($" [TES_VALOR_NUMERICO] = @TES_VALOR_NUMERICO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_VALOR_DATAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_VALOR_DATA"] = value; //06
                      whereClauses.Add($" [TES_VALOR_DATA] = @TES_VALOR_DATA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_VALOR_TEXTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_VALOR_TEXTO"] = value; //06
                      whereClauses.Add($" [TES_VALOR_TEXTO] = @TES_VALOR_TEXTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTES_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TES_EMISSAO"] = value; //06
                      whereClauses.Add($" [TES_EMISSAO] = @TES_EMISSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //06
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //06
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID"] = value; //06
                      whereClauses.Add($" [MAQ_ID] = @MAQ_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //06
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_SEQ_TRANFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_TRANFORMACAO"] = value; //06
                      whereClauses.Add($" [FPR_SEQ_TRANFORMACAO] = @FPR_SEQ_TRANFORMACAO ");//06
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
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
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
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
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
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
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
            this.Query = $"SELECT [Id], [TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId] FROM [TesteFisico] ";
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