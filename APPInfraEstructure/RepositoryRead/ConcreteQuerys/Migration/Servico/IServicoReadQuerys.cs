using Shered.DB;
namespace IQuery.Read
{
    public interface IServicoQueryRead 
    {
        public QueryModel ServicoQuery(Command.Read.ServicoReadCommand Command);
        public QueryModel ServicoGrupoServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByGrupoServicoIdQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByValorQuery(Decimal value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByGrupoServicoIdQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByValorQuery(Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration