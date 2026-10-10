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
    public interface IyModuleQueryRead 
    {
        public QueryModel yModuleQuery(Command.Read.yModuleReadCommand Command );
        public QueryModel ExistsByIdQuery(string value );
        public QueryModel ExistsByDescriptionQuery(string value );
        public QueryModel FirstByIdQuery(string value );
        public QueryModel FirstByDescriptionQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration