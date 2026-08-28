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
    public interface IClpMedicoesHQueryRead 
    {
        public QueryModel ClpMedicoesHQuery(Command.Read.ClpMedicoesHReadCommand Command );
        public QueryModel ClpMedicoesHTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ClpMedicoesHUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIDQuery(int value );
        public QueryModel ExistsByMAQUINA_IDQuery(string value );
        public QueryModel ExistsByDATA_INIQuery(DateTime value );
        public QueryModel ExistsByDATA_FIMQuery(DateTime value );
        public QueryModel ExistsByCLP_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByQTDQuery(Decimal value );
        public QueryModel ExistsByGRUPOQuery(Decimal value );
        public QueryModel ExistsBySTATUSQuery(int value );
        public QueryModel ExistsByURN_IDQuery(string value );
        public QueryModel ExistsByURM_IDQuery(string value );
        public QueryModel ExistsByID_LOTE_CLPQuery(int value );
        public QueryModel ExistsByOCO_IDQuery(string value );
        public QueryModel ExistsByFASEQuery(int value );
        public QueryModel ExistsByCLP_ORIGEMQuery(string value );
        public QueryModel ExistsByCLP_LOTEQuery(int value );
        public QueryModel ExistsByCOMPACTAQuery(int value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIDQuery(int value );
        public QueryModel FirstByMAQUINA_IDQuery(string value );
        public QueryModel FirstByDATA_INIQuery(DateTime value );
        public QueryModel FirstByDATA_FIMQuery(DateTime value );
        public QueryModel FirstByCLP_EMISSAOQuery(DateTime value );
        public QueryModel FirstByQTDQuery(Decimal value );
        public QueryModel FirstByGRUPOQuery(Decimal value );
        public QueryModel FirstBySTATUSQuery(int value );
        public QueryModel FirstByURN_IDQuery(string value );
        public QueryModel FirstByURM_IDQuery(string value );
        public QueryModel FirstByID_LOTE_CLPQuery(int value );
        public QueryModel FirstByOCO_IDQuery(string value );
        public QueryModel FirstByFASEQuery(int value );
        public QueryModel FirstByCLP_ORIGEMQuery(string value );
        public QueryModel FirstByCLP_LOTEQuery(int value );
        public QueryModel FirstByCOMPACTAQuery(int value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration