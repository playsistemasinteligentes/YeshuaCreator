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
    public struct EstruturaProdutoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public DateTime EST_DATA_VALIDADE { get; set; }
        public string PRO_ID_PRODUTO { get; set; }
        public string PRO_ID_COMPONENTE { get; set; }
        public Decimal EST_QUANT { get; set; }
        public DateTime EST_DATA_INCLUSAO { get; set; }
        public Decimal EST_BASE_PRODUCAO { get; set; }
        public string EST_TIPO_REQUISICAO { get; set; }
        public string EST_CODIGO_DE_EXCECAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration