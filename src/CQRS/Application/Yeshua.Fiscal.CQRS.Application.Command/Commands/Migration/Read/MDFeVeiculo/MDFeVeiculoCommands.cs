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
    public struct MDFeVeiculoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? MDFeSolicitacaoFiscalId { get; set; }
        public string? Placa { get; set; }
        public string? Renavam { get; set; }
        public Decimal? Tara { get; set; }
        public Decimal? CapacidadeKg { get; set; }
        public Decimal? CapacidadeM3 { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration