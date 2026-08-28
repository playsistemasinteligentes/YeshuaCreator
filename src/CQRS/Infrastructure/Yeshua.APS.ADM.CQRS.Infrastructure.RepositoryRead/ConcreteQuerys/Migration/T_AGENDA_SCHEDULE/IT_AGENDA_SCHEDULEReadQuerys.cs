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
    public interface IT_AGENDA_SCHEDULEQueryRead 
    {
        public QueryModel T_AGENDA_SCHEDULEQuery(Command.Read.T_AGENDA_SCHEDULEReadCommand Command );
        public QueryModel T_AGENDA_SCHEDULETenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_AGENDA_SCHEDULEUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByAGE_IDQuery(int value );
        public QueryModel ExistsByAGE_DATA_ESPECIFICAQuery(DateTime value );
        public QueryModel ExistsByAGE_HORARIO_INICIOQuery(string value );
        public QueryModel ExistsByAGE_HORARIO_FIMQuery(string value );
        public QueryModel ExistsByAGE_SEGUNDAQuery(string value );
        public QueryModel ExistsByAGE_TERCAQuery(string value );
        public QueryModel ExistsByAGE_QUARTAQuery(string value );
        public QueryModel ExistsByAGE_QUINTAQuery(string value );
        public QueryModel ExistsByAGE_SEXTAQuery(string value );
        public QueryModel ExistsByAGE_SABADOQuery(string value );
        public QueryModel ExistsByAGE_DOMINGOQuery(string value );
        public QueryModel ExistsByAGE_INTERVALOQuery(Decimal value );
        public QueryModel ExistsByAGE_ORDEM_EXECUCAOQuery(string value );
        public QueryModel ExistsByAGE_PARAMETROSQuery(string value );
        public QueryModel ExistsByAGE_EXCECAOQuery(string value );
        public QueryModel ExistsByAGE_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByAGE_IDQuery(int value );
        public QueryModel FirstByAGE_DATA_ESPECIFICAQuery(DateTime value );
        public QueryModel FirstByAGE_HORARIO_INICIOQuery(string value );
        public QueryModel FirstByAGE_HORARIO_FIMQuery(string value );
        public QueryModel FirstByAGE_SEGUNDAQuery(string value );
        public QueryModel FirstByAGE_TERCAQuery(string value );
        public QueryModel FirstByAGE_QUARTAQuery(string value );
        public QueryModel FirstByAGE_QUINTAQuery(string value );
        public QueryModel FirstByAGE_SEXTAQuery(string value );
        public QueryModel FirstByAGE_SABADOQuery(string value );
        public QueryModel FirstByAGE_DOMINGOQuery(string value );
        public QueryModel FirstByAGE_INTERVALOQuery(Decimal value );
        public QueryModel FirstByAGE_ORDEM_EXECUCAOQuery(string value );
        public QueryModel FirstByAGE_PARAMETROSQuery(string value );
        public QueryModel FirstByAGE_EXCECAOQuery(string value );
        public QueryModel FirstByAGE_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration