using Shered.DB;
namespace IQuery.Read
{
    public interface IYconfigNotificationQueryRead 
    {
        public QueryModel YconfigNotificationQuery(Command.Read.YconfigNotificationReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByEmailAdressQuery(string value);
        public QueryModel ExistsByEmailPasswordQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByEmailAdressQuery(string value);
        public QueryModel FirstByEmailPasswordQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration