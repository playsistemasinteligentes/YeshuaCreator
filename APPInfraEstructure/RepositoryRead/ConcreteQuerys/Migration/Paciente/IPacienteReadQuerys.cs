using Shered.DB;
namespace IQuery.Read
{
    public interface IPacienteQueryRead 
    {
        public QueryModel PacienteQuery(Command.Read.PacienteReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByTelefoneQuery(string value);
        public QueryModel ExistsByDataNascimentoQuery(DateTime value);
        public QueryModel ExistsByGeneroQuery(int value);
        public QueryModel ExistsByEscolaridadeQuery(string value);
        public QueryModel ExistsByProfissaoQuery(string value);
        public QueryModel ExistsByEnderecoQuery(string value);
        public QueryModel ExistsByNomeResponsavelQuery(string value);
        public QueryModel ExistsByTelefoneResponsavelQuery(string value);
        public QueryModel ExistsByPrincipaisQueixasQuery(string value);
        public QueryModel ExistsByObservacaoAdicionalQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByTelefoneQuery(string value);
        public QueryModel FirstByDataNascimentoQuery(DateTime value);
        public QueryModel FirstByGeneroQuery(int value);
        public QueryModel FirstByEscolaridadeQuery(string value);
        public QueryModel FirstByProfissaoQuery(string value);
        public QueryModel FirstByEnderecoQuery(string value);
        public QueryModel FirstByNomeResponsavelQuery(string value);
        public QueryModel FirstByTelefoneResponsavelQuery(string value);
        public QueryModel FirstByPrincipaisQueixasQuery(string value);
        public QueryModel FirstByObservacaoAdicionalQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration