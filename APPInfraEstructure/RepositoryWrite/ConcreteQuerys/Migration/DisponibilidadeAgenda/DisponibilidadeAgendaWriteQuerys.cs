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
        protected readonly ICurrentUser _currentUser;
        public DisponibilidadeAgendaQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" INSERT INTO DisponibilidadeAgenda (ProfissionalId, DataHora, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ProfissionalId, @DataHora, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET ProfissionalId = @ProfissionalId, DataHora = @DataHora, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
                Changed = DisponibilidadeAgenda.Changed,
                UserId = _currentUser.UserId,
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
        public QueryModel UpdateTenantID(IDisponibilidadeAgendaEntity entity)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IDisponibilidadeAgendaEntity entity)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IDisponibilidadeAgendaEntity entity)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IDisponibilidadeAgendaEntity entity)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
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