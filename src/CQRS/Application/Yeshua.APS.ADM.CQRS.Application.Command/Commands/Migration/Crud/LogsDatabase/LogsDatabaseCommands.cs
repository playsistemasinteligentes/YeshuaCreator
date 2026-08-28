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
    public struct LogsDatabaseCrudCommand : ICommand
    {
        public int LOGS_ID { get; set; }
        public string LOGS_TABLE { get; set; }
        public string LOGS_KEY { get; set; }
        public string LOGS_KEY1 { get; set; }
        public string LOGS_KEY2 { get; set; }
        public string LOGS_KEY3 { get; set; }
        public string LOGS_KEY4 { get; set; }
        public string LOGS_COLUMN { get; set; }
        public string LOGS_BEFORE { get; set; }
        public string LOGS_AFTER { get; set; }
        public string LOGS_ACTION { get; set; }
        public DateTime LOGS_DATE { get; set; }
        public int USE_ID { get; set; }
        public string LOGS_ORIGEM { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration