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
    public interface IT_HORARIO_RECEBIMENTOQueryRead 
    {
        public QueryModel T_HORARIO_RECEBIMENTOQuery(Command.Read.T_HORARIO_RECEBIMENTOReadCommand Command );
        public QueryModel T_HORARIO_RECEBIMENTOCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_HORARIO_RECEBIMENTOTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_HORARIO_RECEBIMENTOUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByHRE_DIA_DA_SEMANAQuery(int value );
        public QueryModel ExistsByHRE_HORA_INICIALQuery(DateTime value );
        public QueryModel ExistsByHRE_HORA_FINALQuery(DateTime value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByHRE_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByHRE_DIA_DA_SEMANAQuery(int value );
        public QueryModel FirstByHRE_HORA_INICIALQuery(DateTime value );
        public QueryModel FirstByHRE_HORA_FINALQuery(DateTime value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByHRE_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration