using Shered.DB;
namespace IQuery.Read
{
    public interface IProfissionalQueryRead 
    {
        public QueryModel ProfissionalQuery(Command.Read.ProfissionalReadCommand Command);
        public QueryModel ProfissionalEspecialidadeIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByEspecialidadeIdQuery(int value);
        public QueryModel ExistsByTelefoneQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByEspecialidadeIdQuery(int value);
        public QueryModel FirstByTelefoneQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration