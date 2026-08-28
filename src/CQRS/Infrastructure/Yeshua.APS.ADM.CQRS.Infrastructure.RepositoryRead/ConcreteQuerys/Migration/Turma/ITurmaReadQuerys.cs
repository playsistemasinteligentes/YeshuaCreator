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
    public interface ITurmaQueryRead 
    {
        public QueryModel TurmaQuery(Command.Read.TurmaReadCommand Command );
        public QueryModel TurmaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TurmaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(string value );
        public QueryModel ExistsByDescricaoQuery(string value );
        public QueryModel ExistsByTURM_HORA_INI_DIA1Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA1Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_INI_DIA2Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA2Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_INI_DIA3Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA3Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_INI_DIA4Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA4Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_INI_DIA5Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA5Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_INI_DIA6Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA6Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_INI_DIA7Query(DateTime value );
        public QueryModel ExistsByTURM_HORA_FIM_DIA7Query(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(string value );
        public QueryModel FirstByDescricaoQuery(string value );
        public QueryModel FirstByTURM_HORA_INI_DIA1Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA1Query(DateTime value );
        public QueryModel FirstByTURM_HORA_INI_DIA2Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA2Query(DateTime value );
        public QueryModel FirstByTURM_HORA_INI_DIA3Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA3Query(DateTime value );
        public QueryModel FirstByTURM_HORA_INI_DIA4Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA4Query(DateTime value );
        public QueryModel FirstByTURM_HORA_INI_DIA5Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA5Query(DateTime value );
        public QueryModel FirstByTURM_HORA_INI_DIA6Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA6Query(DateTime value );
        public QueryModel FirstByTURM_HORA_INI_DIA7Query(DateTime value );
        public QueryModel FirstByTURM_HORA_FIM_DIA7Query(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration