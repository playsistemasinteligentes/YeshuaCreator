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
    public struct RoteiroReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string MaquinaId { get; set; }
        public string ProdutoId { get; set; }
        public int? SequenciaTransformacao { get; set; }
        public string GrupoMaquinaId { get; set; }
        public Decimal? PecasPorPulso { get; set; }
        public Decimal? PrioridadeInformada { get; set; }
        public string Acao { get; set; }
        public Decimal? Performance { get; set; }
        public Decimal? TempoSetup { get; set; }
        public Decimal? TempoSetupAjuste { get; set; }
        public int? ProximaSequenciaTransformacao { get; set; }
        public string Status { get; set; }
        public Decimal? HierarquiaSequenciaTransformacao { get; set; }
        public int? AvaliaCusto { get; set; }
        public string Operacoes { get; set; }
        public string ExcecaoOperacoes { get; set; }
        public Decimal? PercentualInicioPassoAnterior { get; set; }
        public string LinhaDireta { get; set; }
        public int? TemplateDeTestesId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration