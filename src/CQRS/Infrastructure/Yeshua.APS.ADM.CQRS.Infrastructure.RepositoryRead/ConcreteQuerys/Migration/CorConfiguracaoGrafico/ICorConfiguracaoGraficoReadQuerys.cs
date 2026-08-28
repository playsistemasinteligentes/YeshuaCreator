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
    public interface ICorConfiguracaoGraficoQueryRead 
    {
        public QueryModel CorConfiguracaoGraficoQuery(Command.Read.CorConfiguracaoGraficoReadCommand Command );
        public QueryModel CorConfiguracaoGraficoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CorConfiguracaoGraficoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByCOR_IDQuery(string value );
        public QueryModel ExistsByCOR_PERCENTUAL_INIQuery(Decimal value );
        public QueryModel ExistsByCOR_PERCENTUAL_FIMQuery(Decimal value );
        public QueryModel ExistsByCOR_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByCOR_IDQuery(string value );
        public QueryModel FirstByCOR_PERCENTUAL_INIQuery(Decimal value );
        public QueryModel FirstByCOR_PERCENTUAL_FIMQuery(Decimal value );
        public QueryModel FirstByCOR_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration