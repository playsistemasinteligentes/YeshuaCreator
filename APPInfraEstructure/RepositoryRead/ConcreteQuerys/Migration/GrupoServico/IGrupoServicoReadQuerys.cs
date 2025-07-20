using Shered.DB;
namespace IQuery.Read
{
    public interface IGrupoServicoQueryRead 
    {
        public QueryModel GrupoServicoQuery(Command.Read.GrupoServicoReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByDescricaoQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByDescricaoQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration