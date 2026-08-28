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
    public struct ClpMedicoesReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? Id2 { get; set; }
        public string MaquinaId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? Emissao { get; set; }
        public Decimal? Quantidade { get; set; }
        public Decimal? Grupo { get; set; }
        public int? Status { get; set; }
        public string TurnoId { get; set; }
        public string TurmaId { get; set; }
        public int? IdLoteClp { get; set; }
        public string OcorrenciaId { get; set; }
        public int? Fase { get; set; }
        public string ClpOrigem { get; set; }
        public int? CLP_LOTE { get; set; }
        public int? COMPACTA { get; set; }
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