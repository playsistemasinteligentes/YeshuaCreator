using Shered.DB;
namespace IQuery.Read
{
    public interface IYpserPermitionsQueryRead 
    {
        public QueryModel YpserPermitionsQuery(Command.Read.YpserPermitionsReadCommand Command);
        public QueryModel YpserPermitionsUserIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel YpserPermitionsPermitionsIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByUserIdQuery(int value);
        public QueryModel ExistsByPermitionsIdQuery(string value);
        public QueryModel FirstByUserIdQuery(int value);
        public QueryModel FirstByPermitionsIdQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration