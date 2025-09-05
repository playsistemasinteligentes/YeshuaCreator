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
    public class yConfigArctetureQueryRead : QueryBase, IyConfigArctetureQueryRead
    {
        protected readonly ICurrentUser _currentUser;
        public yConfigArctetureQueryRead(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel yConfigArctetureQuery(Command.Read.yConfigArctetureReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, AuditTrackerActived, AuditCRUDActived, TenantID, Deleted, Changed, UserId from yConfigArcteture ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.AuditTrackerActived.HasValue) parametersDict["AuditTrackerActived"] = Command.AuditTrackerActived.Value;
if (Command.AuditTrackerActived.HasValue) whereClauses.Add($"AuditTrackerActived = @AuditTrackerActived");
if (Command.AuditCRUDActived.HasValue) parametersDict["AuditCRUDActived"] = Command.AuditCRUDActived.Value;
if (Command.AuditCRUDActived.HasValue) whereClauses.Add($"AuditCRUDActived = @AuditCRUDActived");
 parametersDict["TenantID"] = _currentUser.TenantID;
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
        public QueryModel yConfigArctetureTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
 parametersDict["Id"] = _currentUser.TenantID;
 whereClauses.Add($"Id = @Id");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel yConfigArctetureUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
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
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
        public QueryModel ExistsByAuditTrackerActivedQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["AuditTrackerActived"] = value; 
                      whereClauses.Add($" AuditTrackerActived = @AuditTrackerActived ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAuditCRUDActivedQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["AuditCRUDActived"] = value; 
                      whereClauses.Add($" AuditCRUDActived = @AuditCRUDActived ");
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
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
            this.Query = $"SELECT 1 FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
        public QueryModel FirstByAuditTrackerActivedQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["AuditTrackerActived"] = value; 
                      whereClauses.Add($" AuditTrackerActived = @AuditTrackerActived ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAuditCRUDActivedQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["AuditCRUDActived"] = value; 
                      whereClauses.Add($" AuditCRUDActived = @AuditCRUDActived ");
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
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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
            this.Query = $"SELECT * FROM yConfigArcteture ";
 parametersDict["TenantID"] = _currentUser.TenantID;
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