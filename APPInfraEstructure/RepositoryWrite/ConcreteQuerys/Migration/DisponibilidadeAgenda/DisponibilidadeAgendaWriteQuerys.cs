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
        public QueryModel UpdateDisponibilidadeAgendaQuery(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET ProfissionalId = @ProfissionalId, DataHora = @DataHora WHERE Id = @Id ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
                Id = DisponibilidadeAgenda.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteDisponibilidadeAgendaQuery(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" DELETE FROM DisponibilidadeAgenda WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = DisponibilidadeAgenda.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration