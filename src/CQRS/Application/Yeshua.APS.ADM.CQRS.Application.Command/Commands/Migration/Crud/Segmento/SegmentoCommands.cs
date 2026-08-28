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
    public struct SegmentoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string SEG_ID { get; set; }
        public string SEG_DESCRICAO { get; set; }
        public string SEG_ID_SEGUIMENTO_PAI { get; set; }
        public string GRS_ID { get; set; }
        public string SEG_INTEGRACAO_ERP { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration