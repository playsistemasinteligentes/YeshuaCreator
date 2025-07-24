using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class DisponibilidadeAgendaQueryWrite : QueryBase, IDisponibilidadeAgendaQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public DisponibilidadeAgendaQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" INSERT INTO DisponibilidadeAgenda (ProfissionalId, DataHora, TenantID, Deleted, UserId) OUTPUT INSERTED.Id VALUES(@ProfissionalId, @DataHora, @TenantID, @Deleted, @UserId) ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
                TenantID = _correntUser.TenantID,
                Deleted = "",
                UserId = _correntUser.UserId,
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
        public QueryModel UpdateProfissionalId(IDisponibilidadeAgendaEntity entity)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET ProfissionalId = @ProfissionalId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProfissionalId = entity.ProfissionalId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataHora(IDisponibilidadeAgendaEntity entity)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET DataHora = @DataHora WHERE Id = @Id ";
            this.Parameters = new
            {
                DataHora = entity.DataHora,
                Id = entity.Id,
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration