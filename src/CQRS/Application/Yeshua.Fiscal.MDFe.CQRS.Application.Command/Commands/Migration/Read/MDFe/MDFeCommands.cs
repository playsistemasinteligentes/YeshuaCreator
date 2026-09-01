// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct MDFeReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string ChaveAcesso { get; set; }
        public int? Serie { get; set; }
        public int? Numero { get; set; }
        public string UfCarregamento { get; set; }
        public string UfDescarregamento { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime? EmitidoEm { get; set; }
        public DateTime? AutorizadoEm { get; set; }
        public DateTime? IniciadoEm { get; set; }
        public DateTime? EncerradoEm { get; set; }
        public DateTime? CanceladoEm { get; set; }
        public List<int> Situacao { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration