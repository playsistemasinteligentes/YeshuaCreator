using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct MDFeEncerramentoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? MDFeId { get; set; }
        public string ChaveAcesso { get; set; }
        public string UfCarregamento { get; set; }
        public string UfDescarregamento { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime? SolicitadoEm { get; set; }
        public DateTime? AutorizadoEm { get; set; }
        public string Protocolo { get; set; }
        public string CodigoRetorno { get; set; }
        public string MensagemRetorno { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration