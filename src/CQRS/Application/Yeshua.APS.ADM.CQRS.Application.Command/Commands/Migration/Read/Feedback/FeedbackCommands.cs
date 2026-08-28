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
    public struct FeedbackReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? Datafinal { get; set; }
        public string MaquinaId { get; set; }
        public string OcorrenciaId { get; set; }
        public string TurnoId { get; set; }
        public string TurmaId { get; set; }
        public int? UsuarioId { get; set; }
        public string OrderId { get; set; }
        public string ProdutoId { get; set; }
        public string Observacoes { get; set; }
        public Decimal? Grupo { get; set; }
        public string DiaTurma { get; set; }
        public int? SequenciaTransformacao { get; set; }
        public int? SequenciaRepeticao { get; set; }
        public Decimal? QuantidadePulsos { get; set; }
        public Decimal? QuantidadePecasPorPulso { get; set; }
        public Decimal? FEE_QTD_TOTAL_PRODUCAO_AJUSTADA { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration