using Shered.DB;
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
    public class yGrantQueryRead : QueryBase, IyGrantQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public yGrantQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel yGrantQuery(Command.Read.yGrantReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Description, TenantID, Deleted, Changed, UserId from yGrant ";
if (!string.IsNullOrEmpty(Command.Id)) parametersDict["Id"] = $"%{Command.Id}%";
if (!string.IsNullOrEmpty(Command.Id)) whereClauses.Add($"Id like @Id");
if (!string.IsNullOrEmpty(Command.Description)) parametersDict["Description"] = $"%{Command.Description}%";
if (!string.IsNullOrEmpty(Command.Description)) whereClauses.Add($"Description like @Description");
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) parametersDict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            parametersDict["Offset"] = offset;
            parametersDict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel yGrantTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yTenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["Id"] = _correntUser.TenantID;
 whereClauses.Add($"Id = @Id");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel yGrantUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yUser ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Id"] = value; 
                      whereClauses.Add($" Id = @Id ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDescriptionQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Description"] = value; 
                      whereClauses.Add($" Description = @Description ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["TenantID"] = value; 
                      whereClauses.Add($" TenantID = @TenantID ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Deleted"] = value; 
                      whereClauses.Add($" Deleted = @Deleted ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Changed"] = value; 
                      whereClauses.Add($" Changed = @Changed ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["UserId"] = value; 
                      whereClauses.Add($" UserId = @UserId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Id"] = value; 
                      whereClauses.Add($" Id = @Id ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDescriptionQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Description"] = value; 
                      whereClauses.Add($" Description = @Description ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["TenantID"] = value; 
                      whereClauses.Add($" TenantID = @TenantID ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Deleted"] = value; 
                      whereClauses.Add($" Deleted = @Deleted ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Changed"] = value; 
                      whereClauses.Add($" Changed = @Changed ");
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yGrant ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["UserId"] = value; 
                      whereClauses.Add($" UserId = @UserId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration