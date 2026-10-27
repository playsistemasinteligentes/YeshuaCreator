// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IRevisaoRegistroSessaoQueryRead 
    {
        public QueryModel RevisaoRegistroSessaoQuery(Command.Read.RevisaoRegistroSessaoReadCommand Command );
        public QueryModel RevisaoRegistroSessaoSessaoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RevisaoRegistroSessaoAutorUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RevisaoRegistroSessaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RevisaoRegistroSessaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsBySessaoIdQuery(int value );
        public QueryModel ExistsByVersaoQuery(int value );
        public QueryModel ExistsByAutorUserIdQuery(int value );
        public QueryModel ExistsByRevisadoEmQuery(DateTime value );
        public QueryModel ExistsByMotivoQuery(string value );
        public QueryModel ExistsByRegistroQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstBySessaoIdQuery(int value );
        public QueryModel FirstByVersaoQuery(int value );
        public QueryModel FirstByAutorUserIdQuery(int value );
        public QueryModel FirstByRevisadoEmQuery(DateTime value );
        public QueryModel FirstByMotivoQuery(string value );
        public QueryModel FirstByRegistroQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration