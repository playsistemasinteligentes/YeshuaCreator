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
    public interface IPeriodicidadeTesteQueryRead 
    {
        public QueryModel PeriodicidadeTesteQuery(Command.Read.PeriodicidadeTesteReadCommand Command );
        public QueryModel PeriodicidadeTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PeriodicidadeTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPER_IDQuery(int value );
        public QueryModel ExistsByPER_QTDQuery(string value );
        public QueryModel ExistsByUNI_IDQuery(string value );
        public QueryModel ExistsByGRP_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPER_IDQuery(int value );
        public QueryModel FirstByPER_QTDQuery(string value );
        public QueryModel FirstByUNI_IDQuery(string value );
        public QueryModel FirstByGRP_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration