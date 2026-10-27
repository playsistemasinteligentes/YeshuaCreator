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
    public struct RevisaoRegistroSessaoReadCommand : ICommandRead, IOperationalTelemetryCommand
    {
        public int? Id { get; set; }
        public int? SessaoId { get; set; }
        public int? Versao { get; set; }
        public int? AutorUserId { get; set; }
        public DateTime? RevisadoEm { get; set; }
        public string? Motivo { get; set; }
        public string? Registro { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public string? OperationalEntityId { get; set; }
 public Pagination Paginacao { get; set; }
 public string OperationalEntity => "RevisaoRegistroSessao";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration