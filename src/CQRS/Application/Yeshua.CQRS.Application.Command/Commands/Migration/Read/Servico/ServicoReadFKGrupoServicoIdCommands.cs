using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct ServicoReadFKGrupoServicoIdCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration