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
    public interface IPlanoAmostralTesteQueryRead 
    {
        public QueryModel PlanoAmostralTesteQuery(Command.Read.PlanoAmostralTesteReadCommand Command );
        public QueryModel PlanoAmostralTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PlanoAmostralTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByGRP_TIPOQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByPAT_IDQuery(int value );
        public QueryModel ExistsByPAT_QTD_CAIXAS_DEQuery(int value );
        public QueryModel ExistsByPAT_QTD_CAIXAS_ATEQuery(int value );
        public QueryModel ExistsByPAT_N_AMOSTRAGEMQuery(int value );
        public QueryModel ExistsByPAT_PERCENT_ESPECIFQuery(Decimal value );
        public QueryModel FirstByGRP_TIPOQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByPAT_IDQuery(int value );
        public QueryModel FirstByPAT_QTD_CAIXAS_DEQuery(int value );
        public QueryModel FirstByPAT_QTD_CAIXAS_ATEQuery(int value );
        public QueryModel FirstByPAT_N_AMOSTRAGEMQuery(int value );
        public QueryModel FirstByPAT_PERCENT_ESPECIFQuery(Decimal value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration