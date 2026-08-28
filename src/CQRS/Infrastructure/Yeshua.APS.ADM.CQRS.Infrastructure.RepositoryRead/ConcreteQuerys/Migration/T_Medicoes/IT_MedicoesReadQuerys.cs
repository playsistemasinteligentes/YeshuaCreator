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
    public interface IT_MedicoesQueryRead 
    {
        public QueryModel T_MedicoesQuery(Command.Read.T_MedicoesReadCommand Command );
        public QueryModel T_MedicoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_MedicoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMED_IDQuery(int value );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByMET_IDQuery(int value );
        public QueryModel ExistsByUNI_IDQuery(int value );
        public QueryModel ExistsByMED_DATAQuery(DateTime value );
        public QueryModel ExistsByMED_VALORQuery(string value );
        public QueryModel ExistsByMED_AC_ANOQuery(string value );
        public QueryModel ExistsByMED_DATAMEDICAOQuery(string value );
        public QueryModel ExistsByMED_PONDERACAOQuery(Decimal value );
        public QueryModel ExistsByDIM_IDQuery(string value );
        public QueryModel ExistsByDIM_DESCRICAOQuery(string value );
        public QueryModel ExistsByDIM_SUBDIMENSAO_IDQuery(string value );
        public QueryModel ExistsByDIM_SUB_DESCRICAOQuery(string value );
        public QueryModel ExistsByPER_IDQuery(string value );
        public QueryModel ExistsByPER_DESCRICAOQuery(string value );
        public QueryModel ExistsByFAT_IDQuery(string value );
        public QueryModel ExistsByFAT_DESCRICAOQuery(string value );
        public QueryModel ExistsByMED_SQLQuery(string value );
        public QueryModel ExistsByDOM_EMPRESAQuery(string value );
        public QueryModel ExistsByDOM_FILIALQuery(string value );
        public QueryModel ExistsByMED_VALOR_DISPERQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMED_IDQuery(int value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByMET_IDQuery(int value );
        public QueryModel FirstByUNI_IDQuery(int value );
        public QueryModel FirstByMED_DATAQuery(DateTime value );
        public QueryModel FirstByMED_VALORQuery(string value );
        public QueryModel FirstByMED_AC_ANOQuery(string value );
        public QueryModel FirstByMED_DATAMEDICAOQuery(string value );
        public QueryModel FirstByMED_PONDERACAOQuery(Decimal value );
        public QueryModel FirstByDIM_IDQuery(string value );
        public QueryModel FirstByDIM_DESCRICAOQuery(string value );
        public QueryModel FirstByDIM_SUBDIMENSAO_IDQuery(string value );
        public QueryModel FirstByDIM_SUB_DESCRICAOQuery(string value );
        public QueryModel FirstByPER_IDQuery(string value );
        public QueryModel FirstByPER_DESCRICAOQuery(string value );
        public QueryModel FirstByFAT_IDQuery(string value );
        public QueryModel FirstByFAT_DESCRICAOQuery(string value );
        public QueryModel FirstByMED_SQLQuery(string value );
        public QueryModel FirstByDOM_EMPRESAQuery(string value );
        public QueryModel FirstByDOM_FILIALQuery(string value );
        public QueryModel FirstByMED_VALOR_DISPERQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration