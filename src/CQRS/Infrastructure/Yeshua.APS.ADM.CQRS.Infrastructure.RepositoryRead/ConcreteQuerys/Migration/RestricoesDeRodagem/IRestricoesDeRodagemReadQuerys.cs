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
    public interface IRestricoesDeRodagemQueryRead 
    {
        public QueryModel RestricoesDeRodagemQuery(Command.Read.RestricoesDeRodagemReadCommand Command );
        public QueryModel RestricoesDeRodagemTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RestricoesDeRodagemUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByRES_IDQuery(int value );
        public QueryModel ExistsByRES_TIPOQuery(string value );
        public QueryModel ExistsByRES_HORA_INIQuery(string value );
        public QueryModel ExistsByRES_HORA_FIMQuery(string value );
        public QueryModel ExistsByRES_VELOCIDADE_HORA_RUSHQuery(Decimal value );
        public QueryModel ExistsByTVE_IDQuery(int value );
        public QueryModel ExistsByMAP_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByRES_IDQuery(int value );
        public QueryModel FirstByRES_TIPOQuery(string value );
        public QueryModel FirstByRES_HORA_INIQuery(string value );
        public QueryModel FirstByRES_HORA_FIMQuery(string value );
        public QueryModel FirstByRES_VELOCIDADE_HORA_RUSHQuery(Decimal value );
        public QueryModel FirstByTVE_IDQuery(int value );
        public QueryModel FirstByMAP_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration