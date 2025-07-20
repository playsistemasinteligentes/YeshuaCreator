using Shered.DB;
namespace IQuery.Read
{
    public interface IEspecialidadeQueryRead 
    {
        public QueryModel EspecialidadeQuery(Command.Read.EspecialidadeReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByDescricaoQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByDescricaoQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration