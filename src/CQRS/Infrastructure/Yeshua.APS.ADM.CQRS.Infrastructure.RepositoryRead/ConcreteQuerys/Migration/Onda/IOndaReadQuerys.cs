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
    public interface IOndaQueryRead 
    {
        public QueryModel OndaQuery(Command.Read.OndaReadCommand Command );
        public QueryModel OndaVIN_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OndaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OndaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByOND_IDQuery(string value );
        public QueryModel ExistsByOND_ESPESSURAQuery(Decimal value );
        public QueryModel ExistsByOND_PESO_COLAQuery(Decimal value );
        public QueryModel ExistsByOND_RENDIMENTO_ONDA_1Query(Decimal value );
        public QueryModel ExistsByOND_RENDIMENTO_ONDA_2Query(Decimal value );
        public QueryModel ExistsByOND_PROFUNDIDADE_VINCOQuery(int value );
        public QueryModel ExistsByOND_ID_INTEGRACAOQuery(string value );
        public QueryModel ExistsByVIN_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByOND_IDQuery(string value );
        public QueryModel FirstByOND_ESPESSURAQuery(Decimal value );
        public QueryModel FirstByOND_PESO_COLAQuery(Decimal value );
        public QueryModel FirstByOND_RENDIMENTO_ONDA_1Query(Decimal value );
        public QueryModel FirstByOND_RENDIMENTO_ONDA_2Query(Decimal value );
        public QueryModel FirstByOND_PROFUNDIDADE_VINCOQuery(int value );
        public QueryModel FirstByOND_ID_INTEGRACAOQuery(string value );
        public QueryModel FirstByVIN_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration