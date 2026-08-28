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
    public interface IIndicadoresDepartamentosQueryRead 
    {
        public QueryModel IndicadoresDepartamentosQuery(Command.Read.IndicadoresDepartamentosReadCommand Command );
        public QueryModel IndicadoresDepartamentosDEP_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresDepartamentosIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresDepartamentosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresDepartamentosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByINDDEP_IDQuery(int value );
        public QueryModel ExistsByDEP_IDQuery(int value );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByINDDEP_IDQuery(int value );
        public QueryModel FirstByDEP_IDQuery(int value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration