using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct PacienteReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? Genero { get; set; }
        public string Escolaridade { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string NomeResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string PrincipaisQueixas { get; set; }
        public string ObservacaoAdicional { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration