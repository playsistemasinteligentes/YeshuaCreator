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
    public interface IParametrosDeCustoQueryRead 
    {
        public QueryModel ParametrosDeCustoQuery(Command.Read.ParametrosDeCustoReadCommand Command );
        public QueryModel ParametrosDeCustoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ParametrosDeCustoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPAR_IDQuery(int value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByCUS_IDQuery(string value );
        public QueryModel ExistsByPAR_VALORQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPAR_IDQuery(int value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByCUS_IDQuery(string value );
        public QueryModel FirstByPAR_VALORQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration