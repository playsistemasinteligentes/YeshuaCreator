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
    public struct TipoVeiculoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int TIP_ID { get; set; }
        public string TIP_DESCRICAO { get; set; }
        public int? TIP_QTD_DISPONIVEL { get; set; }
        public Decimal? TIP_VALOR_KM { get; set; }
        public Decimal? TIP_VALOR_DIARIA { get; set; }
        public Decimal? TIP_VALOR_AJUDANTE { get; set; }
        public Decimal? TIP_QTD_EIXOS { get; set; }
        public Decimal? TIP_VELOCIDADE_MEDIA { get; set; }
        public Decimal? TIP_CAPACIDADE_ALTURA { get; set; }
        public Decimal? TIP_CAPACIDADE_COMPRIMENTO { get; set; }
        public Decimal? TIP_CAPACIDADE_LARGURA { get; set; }
        public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_E { get; set; }
        public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E { get; set; }
        public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_E { get; set; }
        public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_D { get; set; }
        public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D { get; set; }
        public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_D { get; set; }
        public Decimal? TIP_CAPACIDADE_M3 { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration