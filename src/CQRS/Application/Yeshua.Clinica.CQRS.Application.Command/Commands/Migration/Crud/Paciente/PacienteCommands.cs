using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct PacienteCrudCommand : ICommand
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
        public string Observacao { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration