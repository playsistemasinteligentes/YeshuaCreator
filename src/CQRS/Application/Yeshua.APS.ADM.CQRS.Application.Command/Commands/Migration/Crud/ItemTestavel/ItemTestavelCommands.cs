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
    public struct ItemTestavelCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int ITE_ID { get; set; }
        public string ITE_DESCRICAO { get; set; }
        public string ITE_OBS { get; set; }
        public int? ITE_NUMERO_DE_TESTES { get; set; }
        public string ITE_CONDICIONAL_DE_AVALIACAO { get; set; }
        public Decimal? ITE_VALOR_DA_CONDICIONAL { get; set; }
        public string ITE_VALOR_CALCULADO_DA_CONDICIONAL { get; set; }
        public string ITE_TIPO_AVALIACAO_FINAL { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration