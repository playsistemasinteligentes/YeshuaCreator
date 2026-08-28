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
    public struct CompensacaoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int COM_ID { get; set; }
        public string GRP_ID { get; set; }
        public string OND_ID { get; set; }
        public int? COM_VINCO1_OND { get; set; }
        public int? COM_VINCO2_OND { get; set; }
        public int? COM_VINCO3_OND { get; set; }
        public int? COM_VINCO4_OND { get; set; }
        public int? COM_VINCO5_OND { get; set; }
        public int? COM_VINCO6_OND { get; set; }
        public int? COM_VINCO7_OND { get; set; }
        public int? COM_VINCO8_OND { get; set; }
        public int? COM_VINCO9_OND { get; set; }
        public int? COM_VINCO10_OND { get; set; }
        public int? COM_VINCO1_CONVERSAO { get; set; }
        public int? COM_VINCO2_CONVERSAO { get; set; }
        public int? COM_VINCO3_CONVERSAO { get; set; }
        public int? COM_VINCO4_CONVERSAO { get; set; }
        public int? COM_VINCO5_CONVERSAO { get; set; }
        public int? COM_VINCO6_CONVERSAO { get; set; }
        public int? COM_VINCO7_CONVERSAO { get; set; }
        public int? COM_VINCO8_CONVERSAO { get; set; }
        public int? COM_VINCO9_CONVERSAO { get; set; }
        public int? COM_VINCO10_CONVERSAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration