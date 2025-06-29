using Dominio.Entitys;
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
        public QueryModel InserirDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" INSERT INTO DisponibilidadeAgenda (ProfissionalId, DataHora) OUTPUT INSERTED.Id VALUES(@ProfissionalId, @DataHora) ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
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
        public QueryModel DeleteDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
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