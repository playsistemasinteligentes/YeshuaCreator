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
    public interface IRelatoriosQueryRead 
    {
        public QueryModel RelatoriosQuery(Command.Read.RelatoriosReadCommand Command );
        public QueryModel RelatoriosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RelatoriosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByREL_IDQuery(int value );
        public QueryModel ExistsByREL_NOME_RELATORIOQuery(string value );
        public QueryModel ExistsByREL_NOME_CAMPOQuery(string value );
        public QueryModel ExistsByREL_TIPO_CAMPOQuery(string value );
        public QueryModel ExistsByREL_POS_XQuery(int value );
        public QueryModel ExistsByREL_POS_YQuery(int value );
        public QueryModel ExistsByREL_TAMANHO_FONTEQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByREL_IDQuery(int value );
        public QueryModel FirstByREL_NOME_RELATORIOQuery(string value );
        public QueryModel FirstByREL_NOME_CAMPOQuery(string value );
        public QueryModel FirstByREL_TIPO_CAMPOQuery(string value );
        public QueryModel FirstByREL_POS_XQuery(int value );
        public QueryModel FirstByREL_POS_YQuery(int value );
        public QueryModel FirstByREL_TAMANHO_FONTEQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration