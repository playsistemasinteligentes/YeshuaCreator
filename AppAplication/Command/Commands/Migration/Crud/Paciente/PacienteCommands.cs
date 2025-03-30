using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
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
        public string PrincipaisQueixas { get; set; }
        public string ObservacaoAdicional { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration