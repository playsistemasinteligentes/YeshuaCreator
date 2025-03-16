using Dominio.Entitys.Profissional;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Profissional
{
    public class ProfissionalReadQuery : QueryBase
    {
        public QueryModel ProfissionalQuery(Command.Commands.Read.ProfissionalReadCommand Command)
        {
            this.Query = $@" select Id, Nome, EspecialidadeId, Telefone from Profissional ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel ProfissionalEspecialidadeIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Descricao from Especialidade ";
            return new QueryModel(this.Query, null);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration