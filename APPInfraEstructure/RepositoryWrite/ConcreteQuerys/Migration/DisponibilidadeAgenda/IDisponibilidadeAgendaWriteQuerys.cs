using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IDisponibilidadeAgendaQueryWrite 
     {
        public QueryModel InserirDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda);
        public QueryModel UpdateDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda);
        public QueryModel UpdateProfissionalId(IDisponibilidadeAgendaEntity entity);
        public QueryModel UpdateDataHora(IDisponibilidadeAgendaEntity entity);
        public QueryModel UpdateTenantID(IDisponibilidadeAgendaEntity entity);
        public QueryModel UpdateDeleted(IDisponibilidadeAgendaEntity entity);
        public QueryModel UpdateChanged(IDisponibilidadeAgendaEntity entity);
        public QueryModel UpdateUserId(IDisponibilidadeAgendaEntity entity);
        public QueryModel DeleteDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration