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
    public interface ISegmentoQueryRead 
    {
        public QueryModel SegmentoQuery(Command.Read.SegmentoReadCommand Command );
        public QueryModel SegmentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SegmentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsBySEG_IDQuery(string value );
        public QueryModel ExistsBySEG_DESCRICAOQuery(string value );
        public QueryModel ExistsBySEG_ID_SEGUIMENTO_PAIQuery(string value );
        public QueryModel ExistsByGRS_IDQuery(string value );
        public QueryModel ExistsBySEG_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstBySEG_IDQuery(string value );
        public QueryModel FirstBySEG_DESCRICAOQuery(string value );
        public QueryModel FirstBySEG_ID_SEGUIMENTO_PAIQuery(string value );
        public QueryModel FirstByGRS_IDQuery(string value );
        public QueryModel FirstBySEG_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration