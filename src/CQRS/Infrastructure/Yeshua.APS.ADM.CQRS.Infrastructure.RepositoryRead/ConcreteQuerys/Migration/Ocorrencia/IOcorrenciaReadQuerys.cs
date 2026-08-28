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
    public interface IOcorrenciaQueryRead 
    {
        public QueryModel OcorrenciaQuery(Command.Read.OcorrenciaReadCommand Command );
        public QueryModel OcorrenciaTIP_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OcorrenciaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OcorrenciaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByOCO_IDQuery(string value );
        public QueryModel ExistsByOCO_DESCRICAOQuery(string value );
        public QueryModel ExistsByTIP_IDQuery(int value );
        public QueryModel ExistsByGMA_IDQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsBySPRQuery(int value );
        public QueryModel ExistsByOCO_SUB_TIPOQuery(string value );
        public QueryModel ExistsBySUB_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByOCO_IDQuery(string value );
        public QueryModel FirstByOCO_DESCRICAOQuery(string value );
        public QueryModel FirstByTIP_IDQuery(int value );
        public QueryModel FirstByGMA_IDQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstBySPRQuery(int value );
        public QueryModel FirstByOCO_SUB_TIPOQuery(string value );
        public QueryModel FirstBySUB_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration