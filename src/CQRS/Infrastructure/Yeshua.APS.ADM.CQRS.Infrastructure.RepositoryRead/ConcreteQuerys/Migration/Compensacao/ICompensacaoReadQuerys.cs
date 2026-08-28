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
    public interface ICompensacaoQueryRead 
    {
        public QueryModel CompensacaoQuery(Command.Read.CompensacaoReadCommand Command );
        public QueryModel CompensacaoGRP_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CompensacaoOND_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CompensacaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CompensacaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCOM_IDQuery(int value );
        public QueryModel ExistsByGRP_IDQuery(string value );
        public QueryModel ExistsByOND_IDQuery(string value );
        public QueryModel ExistsByCOM_VINCO1_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO2_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO3_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO4_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO5_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO6_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO7_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO8_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO9_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO10_ONDQuery(int value );
        public QueryModel ExistsByCOM_VINCO1_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO2_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO3_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO4_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO5_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO6_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO7_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO8_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO9_CONVERSAOQuery(int value );
        public QueryModel ExistsByCOM_VINCO10_CONVERSAOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCOM_IDQuery(int value );
        public QueryModel FirstByGRP_IDQuery(string value );
        public QueryModel FirstByOND_IDQuery(string value );
        public QueryModel FirstByCOM_VINCO1_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO2_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO3_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO4_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO5_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO6_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO7_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO8_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO9_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO10_ONDQuery(int value );
        public QueryModel FirstByCOM_VINCO1_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO2_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO3_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO4_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO5_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO6_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO7_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO8_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO9_CONVERSAOQuery(int value );
        public QueryModel FirstByCOM_VINCO10_CONVERSAOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration