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
    public interface IItensCalendarioQueryRead 
    {
        public QueryModel ItensCalendarioQuery(Command.Read.ItensCalendarioReadCommand Command );
        public QueryModel ItensCalendarioURM_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensCalendarioURN_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensCalendarioCAL_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensCalendarioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensCalendarioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByICA_IDQuery(int value );
        public QueryModel ExistsByICA_DATA_DEQuery(DateTime value );
        public QueryModel ExistsByICA_DATA_ATEQuery(DateTime value );
        public QueryModel ExistsByICA_OBSERVACAOQuery(string value );
        public QueryModel ExistsByICA_TIPOQuery(int value );
        public QueryModel ExistsByURM_IDQuery(string value );
        public QueryModel ExistsByURN_IDQuery(string value );
        public QueryModel ExistsByCAL_IDQuery(int value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByICA_LIMPESA_MAQUINAQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByICA_IDQuery(int value );
        public QueryModel FirstByICA_DATA_DEQuery(DateTime value );
        public QueryModel FirstByICA_DATA_ATEQuery(DateTime value );
        public QueryModel FirstByICA_OBSERVACAOQuery(string value );
        public QueryModel FirstByICA_TIPOQuery(int value );
        public QueryModel FirstByURM_IDQuery(string value );
        public QueryModel FirstByURN_IDQuery(string value );
        public QueryModel FirstByCAL_IDQuery(int value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByICA_LIMPESA_MAQUINAQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration