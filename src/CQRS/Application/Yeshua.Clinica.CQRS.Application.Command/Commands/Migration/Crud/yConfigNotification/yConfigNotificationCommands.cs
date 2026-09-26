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
    public struct yConfigNotificationCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public string OperationalEntityId { get; set; }
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public string? EmailSmtpClient { get; set; }
        public int? EmailPort { get; set; }
        public string? EmailUserName { get; set; }
        public string? EmailPassword { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "yConfigNotification";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration