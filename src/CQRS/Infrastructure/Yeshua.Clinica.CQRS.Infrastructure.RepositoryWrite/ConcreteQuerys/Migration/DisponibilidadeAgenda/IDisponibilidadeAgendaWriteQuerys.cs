using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IDisponibilidadeAgendaQueryWrite 
     {
        public QueryModel InserirDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda);
        public QueryModel UpdateDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda);
        QueryModel UpdateProfissionalId(int id, int value);
        QueryModel UpdateDataHora(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteDisponibilidadeAgendaQuery(IDisponibilidadeAgendaEntity DisponibilidadeAgenda);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration