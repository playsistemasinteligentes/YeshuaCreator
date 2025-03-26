using Dominio.Entitys.Y_PerfilPermitions;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Y_PerfilPermitions
{
    public class Y_PerfilPermitionsReadQuery : QueryBase
    {
        public QueryModel Y_PerfilPermitionsQuery(Command.Commands.Read.Y_PerfilPermitionsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select PerfilId, PermitionsId from Y_PerfilPermitions ";
if (Command.PerfilId.HasValue) parametersDict["PerfilId"] = Command.PerfilId.Value;
if (Command.PerfilId.HasValue) whereClauses.Add($"PerfilId = @PerfilId");
if (!string.IsNullOrEmpty(Command.PermitionsId)) parametersDict["PermitionsId"] = $"%{Command.PermitionsId}%";
if (!string.IsNullOrEmpty(Command.PermitionsId)) whereClauses.Add($"PermitionsId like @PermitionsId");
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel Y_PerfilPermitionsPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from Y_Perfil ";
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
                      }; 
                      whereClauses.Add($" Id like @Id "); 
                 }
            }
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel Y_PerfilPermitionsPermitionsIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from Y_Permtions ";
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
                      }; 
                      whereClauses.Add($" Id like @Id "); 
                 }
            }
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration