using Shered.DB;
namespace IQuery.Read
{
    public interface IDisponibilidadeAgendaQueryRead 
    {
        public QueryModel DisponibilidadeAgendaQuery(Command.Read.DisponibilidadeAgendaReadCommand Command );
        public QueryModel DisponibilidadeAgendaProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel DisponibilidadeAgendaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel DisponibilidadeAgendaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByProfissionalIdQuery(int value );
        public QueryModel ExistsByDataHoraQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByProfissionalIdQuery(int value );
        public QueryModel FirstByDataHoraQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration