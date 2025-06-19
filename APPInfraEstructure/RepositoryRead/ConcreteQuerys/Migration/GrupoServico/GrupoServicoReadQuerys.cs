using Dominio.Entitys.GrupoServico;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.GrupoServico
{
    public class GrupoServicoReadQuery : QueryBase
    {
        public QueryModel GrupoServicoQuery(Command.Commands.Read.GrupoServicoReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Descricao from GrupoServico ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Descricao)) parametersDict["Descricao"] = $"%{Command.Descricao}%";
if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"Descricao like @Descricao");
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration