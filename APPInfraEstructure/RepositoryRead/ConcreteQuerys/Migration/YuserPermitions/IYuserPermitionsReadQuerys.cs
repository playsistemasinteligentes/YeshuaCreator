using Shered.DB;
namespace IQuery.Read
{
    public interface IYuserPermitionsQueryRead 
    {
        public QueryModel YuserPermitionsQuery(Command.Read.YuserPermitionsReadCommand Command);
        public QueryModel YuserPermitionsPermitionsIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel YuserPermitionsUserIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByPermitionsIdQuery(string value);
        public QueryModel ExistsByUserIdQuery(int value);
        public QueryModel FirstByPermitionsIdQuery(string value);
        public QueryModel FirstByUserIdQuery(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration