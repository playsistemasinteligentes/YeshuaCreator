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
    public interface ILaudoTesteFisicoQueryRead 
    {
        public QueryModel LaudoTesteFisicoQuery(Command.Read.LaudoTesteFisicoReadCommand Command );
        public QueryModel LaudoTesteFisicoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel LaudoTesteFisicoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByLTF_IDQuery(int value );
        public QueryModel ExistsByLTF_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByLTF_VALORQuery(Decimal value );
        public QueryModel ExistsByLTF_OBSQuery(string value );
        public QueryModel ExistsByLTF_STATUSQuery(string value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByROT_PRO_IDQuery(string value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByLTF_IDQuery(int value );
        public QueryModel FirstByLTF_EMISSAOQuery(DateTime value );
        public QueryModel FirstByLTF_VALORQuery(Decimal value );
        public QueryModel FirstByLTF_OBSQuery(string value );
        public QueryModel FirstByLTF_STATUSQuery(string value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByROT_PRO_IDQuery(string value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration