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
    public class PoliticaOnduladeiraQueryRead : QueryBase, IPoliticaOnduladeiraQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public PoliticaOnduladeiraQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel PoliticaOnduladeiraQuery(Command.Read.PoliticaOnduladeiraReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId from PoliticaOnduladeira ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.POL_ID.HasValue) dict["POL_ID"] = Command.POL_ID.Value;
if (Command.POL_ID.HasValue) whereClauses.Add($"POL_ID = @POL_ID");
if (Command.POL_NIVEL.HasValue) dict["POL_NIVEL"] = Command.POL_NIVEL.Value;
if (Command.POL_NIVEL.HasValue) whereClauses.Add($"POL_NIVEL = @POL_NIVEL");
if (Command.POL_PROMOCAO.HasValue) dict["POL_PROMOCAO"] = Command.POL_PROMOCAO.Value;
if (Command.POL_PROMOCAO.HasValue) whereClauses.Add($"POL_PROMOCAO = @POL_PROMOCAO");
if (Command.POL_DIAS_ANTECIPACAO.HasValue) dict["POL_DIAS_ANTECIPACAO"] = Command.POL_DIAS_ANTECIPACAO.Value;
if (Command.POL_DIAS_ANTECIPACAO.HasValue) whereClauses.Add($"POL_DIAS_ANTECIPACAO = @POL_DIAS_ANTECIPACAO");
if (Command.POL_METROS_LINEARES.HasValue) dict["POL_METROS_LINEARES"] = Command.POL_METROS_LINEARES.Value;
if (Command.POL_METROS_LINEARES.HasValue) whereClauses.Add($"POL_METROS_LINEARES = @POL_METROS_LINEARES");
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
        public QueryModel PoliticaOnduladeiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel PoliticaOnduladeiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
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
        public QueryModel ExistsByPOL_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_ID"] = value; //04
                      whereClauses.Add($" POL_ID = @POL_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPOL_NIVELQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_NIVEL"] = value; //04
                      whereClauses.Add($" POL_NIVEL = @POL_NIVEL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPOL_PROMOCAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_PROMOCAO"] = value; //04
                      whereClauses.Add($" POL_PROMOCAO = @POL_PROMOCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPOL_DIAS_ANTECIPACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_DIAS_ANTECIPACAO"] = value; //04
                      whereClauses.Add($" POL_DIAS_ANTECIPACAO = @POL_DIAS_ANTECIPACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPOL_METROS_LINEARESQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_METROS_LINEARES"] = value; //04
                      whereClauses.Add($" POL_METROS_LINEARES = @POL_METROS_LINEARES ");//04
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
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT 1 FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
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
        public QueryModel FirstByPOL_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_ID"] = value; //06
                      whereClauses.Add($" POL_ID = @POL_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPOL_NIVELQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_NIVEL"] = value; //06
                      whereClauses.Add($" POL_NIVEL = @POL_NIVEL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPOL_PROMOCAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_PROMOCAO"] = value; //06
                      whereClauses.Add($" POL_PROMOCAO = @POL_PROMOCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPOL_DIAS_ANTECIPACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_DIAS_ANTECIPACAO"] = value; //06
                      whereClauses.Add($" POL_DIAS_ANTECIPACAO = @POL_DIAS_ANTECIPACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPOL_METROS_LINEARESQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["POL_METROS_LINEARES"] = value; //06
                      whereClauses.Add($" POL_METROS_LINEARES = @POL_METROS_LINEARES ");//06
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
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
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
            this.Query = $"SELECT Id, POL_ID, POL_NIVEL, POL_PROMOCAO, POL_DIAS_ANTECIPACAO, POL_METROS_LINEARES, TenantID, Deleted, Changed, UserId FROM PoliticaOnduladeira ";
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