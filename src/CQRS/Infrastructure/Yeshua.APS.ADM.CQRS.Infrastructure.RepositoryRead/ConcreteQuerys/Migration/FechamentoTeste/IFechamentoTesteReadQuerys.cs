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
    public interface IFechamentoTesteQueryRead 
    {
        public QueryModel FechamentoTesteQuery(Command.Read.FechamentoTesteReadCommand Command );
        public QueryModel FechamentoTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FechamentoTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByFEC_IDQuery(int value );
        public QueryModel ExistsByFEC_QTDQuery(int value );
        public QueryModel ExistsByGRP_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByFEC_IDQuery(int value );
        public QueryModel FirstByFEC_QTDQuery(int value );
        public QueryModel FirstByGRP_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration