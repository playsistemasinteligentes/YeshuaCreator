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
    public interface IMovimentosQueryRead 
    {
        public QueryModel MovimentosQuery(Command.Read.MovimentosReadCommand Command );
        public QueryModel MovimentosMOV_PLAIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentosTr_Unidade_UNI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMOV_IDQuery(int value );
        public QueryModel ExistsByMOV_DATAQuery(string value );
        public QueryModel ExistsByMOV_VALORQuery(Decimal value );
        public QueryModel ExistsByMOV_PLAIDQuery(int value );
        public QueryModel ExistsByMOV_UNIDQuery(int value );
        public QueryModel ExistsByTr_Unidade_UNI_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMOV_IDQuery(int value );
        public QueryModel FirstByMOV_DATAQuery(string value );
        public QueryModel FirstByMOV_VALORQuery(Decimal value );
        public QueryModel FirstByMOV_PLAIDQuery(int value );
        public QueryModel FirstByMOV_UNIDQuery(int value );
        public QueryModel FirstByTr_Unidade_UNI_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration