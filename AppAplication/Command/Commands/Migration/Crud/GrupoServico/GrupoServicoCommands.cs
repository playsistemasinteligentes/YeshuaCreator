using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct GrupoServicoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration