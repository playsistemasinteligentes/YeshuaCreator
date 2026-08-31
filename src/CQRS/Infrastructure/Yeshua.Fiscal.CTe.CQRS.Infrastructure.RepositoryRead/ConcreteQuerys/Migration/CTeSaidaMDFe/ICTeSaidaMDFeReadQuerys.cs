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
    public interface ICTeSaidaMDFeQueryRead 
    {
        public QueryModel CTeSaidaMDFeQuery(Command.Read.CTeSaidaMDFeReadCommand Command );
        public QueryModel CTeSaidaMDFeCTeTentativaEmissaoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeSaidaMDFeTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeSaidaMDFeUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCTeTentativaEmissaoIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByChaveAcessoCTeQuery(string value );
        public QueryModel ExistsBySnapshotHashQuery(string value );
        public QueryModel ExistsByOutboxMessageIdQuery(string value );
        public QueryModel ExistsByPublicadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByUltimoErroQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCTeTentativaEmissaoIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByChaveAcessoCTeQuery(string value );
        public QueryModel FirstBySnapshotHashQuery(string value );
        public QueryModel FirstByOutboxMessageIdQuery(string value );
        public QueryModel FirstByPublicadoEmUtcQuery(DateTime value );
        public QueryModel FirstByUltimoErroQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration