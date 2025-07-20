using Shered.DB;
namespace IQuery.Read
{
    public interface IYperfilPermitionsQueryRead 
    {
        public QueryModel YperfilPermitionsQuery(Command.Read.YperfilPermitionsReadCommand Command);
        public QueryModel YperfilPermitionsPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel YperfilPermitionsPermitionsIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByPerfilIdQuery(int value);
        public QueryModel ExistsByPermitionsIdQuery(string value);
        public QueryModel FirstByPerfilIdQuery(int value);
        public QueryModel FirstByPermitionsIdQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration