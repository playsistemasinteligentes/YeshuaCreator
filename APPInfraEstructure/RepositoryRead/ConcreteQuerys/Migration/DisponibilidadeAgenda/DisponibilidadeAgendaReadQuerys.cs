using Dominio.Entitys.DisponibilidadeAgenda;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.DisponibilidadeAgenda
{
    public class DisponibilidadeAgendaReadQuery : QueryBase
    {
        public QueryModel DisponibilidadeAgendaQuery(Command.Commands.Read.DisponibilidadeAgendaReadCommand Command)
        {
            this.Query = $@" select Id, ProfissionalId, DataHora from DisponibilidadeAgenda ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel DisponibilidadeAgendaProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Profissional ";
            return new QueryModel(this.Query, null);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration