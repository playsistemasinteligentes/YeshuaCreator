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
    public interface ICalendarioDisponibilidadeVeiculosQueryRead 
    {
        public QueryModel CalendarioDisponibilidadeVeiculosQuery(Command.Read.CalendarioDisponibilidadeVeiculosReadCommand Command );
        public QueryModel CalendarioDisponibilidadeVeiculosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CalendarioDisponibilidadeVeiculosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCDV_IDQuery(int value );
        public QueryModel ExistsByCDV_DATA_DEQuery(DateTime value );
        public QueryModel ExistsByCDV_DATA_ATEQuery(DateTime value );
        public QueryModel ExistsByCDV_SEGUNDAQuery(int value );
        public QueryModel ExistsByCDV_TERCAQuery(int value );
        public QueryModel ExistsByCDV_QUARTAQuery(int value );
        public QueryModel ExistsByCDV_QUINTAQuery(int value );
        public QueryModel ExistsByCDV_SEXTAQuery(int value );
        public QueryModel ExistsByCDV_SABADOQuery(int value );
        public QueryModel ExistsByCDV_DOMINGOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCDV_IDQuery(int value );
        public QueryModel FirstByCDV_DATA_DEQuery(DateTime value );
        public QueryModel FirstByCDV_DATA_ATEQuery(DateTime value );
        public QueryModel FirstByCDV_SEGUNDAQuery(int value );
        public QueryModel FirstByCDV_TERCAQuery(int value );
        public QueryModel FirstByCDV_QUARTAQuery(int value );
        public QueryModel FirstByCDV_QUINTAQuery(int value );
        public QueryModel FirstByCDV_SEXTAQuery(int value );
        public QueryModel FirstByCDV_SABADOQuery(int value );
        public QueryModel FirstByCDV_DOMINGOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration