using Shered.DB;
namespace IQuery.Read
{
    public interface IProfissionalQueryRead 
    {
        public QueryModel ProfissionalQuery(Command.Read.ProfissionalReadCommand Command );
        public QueryModel ProfissionalEspecialidadeIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ProfissionalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ProfissionalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByNomeQuery(string value );
        public QueryModel ExistsByEspecialidadeIdQuery(int value );
        public QueryModel ExistsByTelefoneQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByNomeQuery(string value );
        public QueryModel FirstByEspecialidadeIdQuery(int value );
        public QueryModel FirstByTelefoneQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration