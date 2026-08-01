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