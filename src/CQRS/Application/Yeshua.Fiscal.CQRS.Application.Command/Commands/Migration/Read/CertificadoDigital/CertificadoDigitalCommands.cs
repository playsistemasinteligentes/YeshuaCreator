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
    public struct CertificadoDigitalReadCommand : ICommandRead, IOperationalTelemetryCommand
    {
        public int? Id { get; set; }
        public string? Apelido { get; set; }
        public string? DocumentoTitular { get; set; }
        public string? StorageKey { get; set; }
        public string? Thumbprint { get; set; }
        public DateTime? ValidoDe { get; set; }
        public DateTime? ValidoAte { get; set; }
        public int? Ativo { get; set; }
        public string? OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public string? SenhaStorageKey { get; set; }
 public Pagination Paginacao { get; set; }
 public string OperationalEntity => "CertificadoDigital";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration