using Dominio.Entitys.Yuser;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Yuser
{
    public class YuserReadQuery : QueryBase
    {
        public QueryModel YuserQuery(Command.Commands.Read.YuserReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, Senha, Login from Yuser ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.Senha)) parametersDict["Senha"] = $"%{Command.Senha}%";
if (!string.IsNullOrEmpty(Command.Senha)) whereClauses.Add($"Senha like @Senha");
if (!string.IsNullOrEmpty(Command.Login)) parametersDict["Login"] = $"%{Command.Login}%";
if (!string.IsNullOrEmpty(Command.Login)) whereClauses.Add($"Login like @Login");
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration