using Dominio.Entitys.Y_Company;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Y_Company
{
    public class Y_CompanyReadQuery : QueryBase
    {
        public QueryModel Y_CompanyQuery(Command.Commands.Read.Y_CompanyReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, ProxyServer, UserIDAdmin from Y_Company ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.ProxyServer)) parametersDict["ProxyServer"] = $"%{Command.ProxyServer}%";
if (!string.IsNullOrEmpty(Command.ProxyServer)) whereClauses.Add($"ProxyServer like @ProxyServer");
if (Command.UserIDAdmin.HasValue) parametersDict["UserIDAdmin"] = Command.UserIDAdmin.Value;
if (Command.UserIDAdmin.HasValue) whereClauses.Add($"UserIDAdmin = @UserIDAdmin");
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel Y_CompanyUserIDAdminQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Y_User ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      this.Parameters = new { Id = numero}; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      this.Parameters = new { 
                       Id = $"%{Command.searchFK}%", 
                       Nome = $"%{Command.searchFK}%", 
                      }; 
                      whereClauses.Add($" Id like @Id "); 
                      whereClauses.Add($" Nome like @Nome "); 
                 }
            }
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration