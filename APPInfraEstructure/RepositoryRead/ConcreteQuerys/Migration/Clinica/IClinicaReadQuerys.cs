using Shered.DB;
namespace IQuery.Read
{
    public interface IClinicaQueryRead 
    {
        public QueryModel ClinicaQuery(Command.Read.ClinicaReadCommand Command );
        public QueryModel ClinicaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ClinicaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByNomeQuery(string value );
        public QueryModel ExistsByEnderecoQuery(string value );
        public QueryModel ExistsByTelefoneQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByNomeQuery(string value );
        public QueryModel FirstByEnderecoQuery(string value );
        public QueryModel FirstByTelefoneQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration