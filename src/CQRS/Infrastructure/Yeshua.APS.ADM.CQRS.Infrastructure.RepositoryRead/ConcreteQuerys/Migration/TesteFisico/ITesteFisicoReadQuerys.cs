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
    public interface ITesteFisicoQueryRead 
    {
        public QueryModel TesteFisicoQuery(Command.Read.TesteFisicoReadCommand Command );
        public QueryModel TesteFisicoUSR_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TesteFisicoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TesteFisicoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TesteFisicoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTES_IDQuery(int value );
        public QueryModel ExistsByITE_IDQuery(int value );
        public QueryModel ExistsByUSR_IDQuery(int value );
        public QueryModel ExistsByTES_NOME_TECNICOQuery(string value );
        public QueryModel ExistsByTES_AMOSTRAQuery(int value );
        public QueryModel ExistsByTES_OPQuery(string value );
        public QueryModel ExistsByTES_VALOR_NUMERICOQuery(Decimal value );
        public QueryModel ExistsByTES_VALOR_DATAQuery(DateTime value );
        public QueryModel ExistsByTES_VALOR_TEXTOQuery(string value );
        public QueryModel ExistsByTES_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByFPR_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTES_IDQuery(int value );
        public QueryModel FirstByITE_IDQuery(int value );
        public QueryModel FirstByUSR_IDQuery(int value );
        public QueryModel FirstByTES_NOME_TECNICOQuery(string value );
        public QueryModel FirstByTES_AMOSTRAQuery(int value );
        public QueryModel FirstByTES_OPQuery(string value );
        public QueryModel FirstByTES_VALOR_NUMERICOQuery(Decimal value );
        public QueryModel FirstByTES_VALOR_DATAQuery(DateTime value );
        public QueryModel FirstByTES_VALOR_TEXTOQuery(string value );
        public QueryModel FirstByTES_EMISSAOQuery(DateTime value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByFPR_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration