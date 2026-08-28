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
    public interface IItenCalendarioDisponibilidadeVeiculosQueryRead 
    {
        public QueryModel ItenCalendarioDisponibilidadeVeiculosQuery(Command.Read.ItenCalendarioDisponibilidadeVeiculosReadCommand Command );
        public QueryModel ItenCalendarioDisponibilidadeVeiculosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItenCalendarioDisponibilidadeVeiculosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCDV_IDQuery(int value );
        public QueryModel ExistsByTIP_IDQuery(int value );
        public QueryModel ExistsByIDV_QTDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCDV_IDQuery(int value );
        public QueryModel FirstByTIP_IDQuery(int value );
        public QueryModel FirstByIDV_QTDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration