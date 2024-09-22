using Dominio.Entitys.DisponibilidadeAgenda;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.DisponibilidadeAgenda
{
    public class DisponibilidadeAgendaWriteQuery : QueryBase
    {
        public QueryModel InserirDisponibilidadeAgendaQuery(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" INSERT INTO DisponibilidadeAgenda (ProfissionalId, DataHora) VALUES(@ProfissionalId, @DataHora) ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
