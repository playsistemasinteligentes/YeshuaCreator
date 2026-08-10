using Shered.DB;
namespace IQuery.Read
{
    public interface IEspecialidadeQueryRead 
    {
        public QueryModel EspecialidadeQuery(Command.Read.EspecialidadeReadCommand Command );
        public QueryModel EspecialidadeTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EspecialidadeUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByDescricaoQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByDescricaoQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration