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
namespace Command.Write
{
    public struct ExperienciaPlanejamentoTransporteCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int Tipo { get; set; }
        public string Referencia { get; set; }
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public string Municipio { get; set; }
        public string Regiao { get; set; }
        public string RotaId { get; set; }
        public Decimal? Peso { get; set; }
        public Decimal? Volume { get; set; }
        public string Observacao { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration