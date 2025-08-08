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
    public class ClinicaQueryRead : QueryBase, IClinicaQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public ClinicaQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel ClinicaQuery(Command.Read.ClinicaReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, Endereco, Telefone, TenantID, Deleted, Changed, UserId from Clinica ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.Endereco)) parametersDict["Endereco"] = $"%{Command.Endereco}%";
if (!string.IsNullOrEmpty(Command.Endereco)) whereClauses.Add($"Endereco like @Endereco");
if (!string.IsNullOrEmpty(Command.Telefone)) parametersDict["Telefone"] = $"%{Command.Telefone}%";
if (!string.IsNullOrEmpty(Command.Telefone)) whereClauses.Add($"Telefone like @Telefone");
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
        public QueryModel ClinicaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ClinicaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Clinica ";
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
        public QueryModel ExistsByNomeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Clinica ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Nome"] = value; 
                      whereClauses.Add($" Nome = @Nome ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEnderecoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Clinica ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Endereco"] = value; 
                      whereClauses.Add($" Endereco = @Endereco ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTelefoneQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Clinica ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Telefone"] = value; 
                      whereClauses.Add($" Telefone = @Telefone ");
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
            this.Query = $"SELECT 1 FROM Clinica ";
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
            this.Query = $"SELECT 1 FROM Clinica ";
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
            this.Query = $"SELECT 1 FROM Clinica ";
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
            this.Query = $"SELECT 1 FROM Clinica ";
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
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Clinica ";
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
        public QueryModel FirstByNomeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Clinica ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Nome"] = value; 
                      whereClauses.Add($" Nome = @Nome ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEnderecoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Clinica ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Endereco"] = value; 
                      whereClauses.Add($" Endereco = @Endereco ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTelefoneQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Clinica ";
 parametersDict["TenantID"] = _correntUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Telefone"] = value; 
                      whereClauses.Add($" Telefone = @Telefone ");
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
            this.Query = $"SELECT * FROM Clinica ";
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
            this.Query = $"SELECT * FROM Clinica ";
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
            this.Query = $"SELECT * FROM Clinica ";
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
            this.Query = $"SELECT * FROM Clinica ";
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