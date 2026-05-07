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
        protected readonly IExecutionContext _executionContext;
        public DisponibilidadeAgendaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            this.Query = $@" INSERT INTO DisponibilidadeAgenda (ProfissionalId, DataHora, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ProfissionalId, @DataHora, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ProfissionalId = DisponibilidadeAgenda.ProfissionalId,
                DataHora = DisponibilidadeAgenda.DataHora,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
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
                UserId = _executionContext.UserId,
                Id = DisponibilidadeAgenda.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissionalId(int id, int value)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET ProfissionalId = @ProfissionalId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProfissionalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataHora(int id, DateTime value)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET DataHora = @DataHora WHERE Id = @Id ";
            this.Parameters = new
            {
                DataHora = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE DisponibilidadeAgenda SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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