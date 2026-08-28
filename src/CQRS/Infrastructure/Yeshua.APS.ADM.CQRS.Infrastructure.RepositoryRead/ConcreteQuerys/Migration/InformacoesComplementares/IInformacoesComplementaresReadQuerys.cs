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
    public interface IInformacoesComplementaresQueryRead 
    {
        public QueryModel InformacoesComplementaresQuery(Command.Read.InformacoesComplementaresReadCommand Command );
        public QueryModel InformacoesComplementaresMET_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel InformacoesComplementaresTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel InformacoesComplementaresUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByINF_IDQuery(int value );
        public QueryModel ExistsByINF_DESCRICAOQuery(string value );
        public QueryModel ExistsByINF_VALORQuery(Decimal value );
        public QueryModel ExistsByMET_IDQuery(int value );
        public QueryModel ExistsByINF_DATAQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByINF_IDQuery(int value );
        public QueryModel FirstByINF_DESCRICAOQuery(string value );
        public QueryModel FirstByINF_VALORQuery(Decimal value );
        public QueryModel FirstByMET_IDQuery(int value );
        public QueryModel FirstByINF_DATAQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration