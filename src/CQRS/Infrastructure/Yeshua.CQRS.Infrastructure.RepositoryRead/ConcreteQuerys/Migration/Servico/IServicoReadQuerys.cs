using Shered.DB;
namespace IQuery.Read
{
    public interface IServicoQueryRead 
    {
        public QueryModel ServicoQuery(Command.Read.ServicoReadCommand Command );
        public QueryModel ServicoGrupoServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ServicoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ServicoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByGrupoServicoIdQuery(int value );
        public QueryModel ExistsByNomeQuery(string value );
        public QueryModel ExistsByValorQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByGrupoServicoIdQuery(int value );
        public QueryModel FirstByNomeQuery(string value );
        public QueryModel FirstByValorQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration