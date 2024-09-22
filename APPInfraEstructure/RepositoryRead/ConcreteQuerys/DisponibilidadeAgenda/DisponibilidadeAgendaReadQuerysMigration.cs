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
        public QueryModel SelectAllDisponibilidadeAgendaQuery()
        {
            this.Query = $@" select Id, ProfissionalId, DataHora from DisponibilidadeAgenda ";
            return new QueryModel(this.Query, null);
        }
    }
}
