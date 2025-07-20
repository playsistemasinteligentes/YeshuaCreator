using Shered.DB;
namespace IQuery.Read
{
    public interface IClinicaQueryRead 
    {
        public QueryModel ClinicaQuery(Command.Read.ClinicaReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByEnderecoQuery(string value);
        public QueryModel ExistsByTelefoneQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByEnderecoQuery(string value);
        public QueryModel FirstByTelefoneQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration