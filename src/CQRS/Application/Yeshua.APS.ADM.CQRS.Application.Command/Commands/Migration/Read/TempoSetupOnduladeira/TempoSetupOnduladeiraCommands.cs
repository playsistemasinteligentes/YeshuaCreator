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
    public struct TempoSetupOnduladeiraReadCommand : ICommandRead
    {
        public int? TEM_ID { get; set; }
        public string OND_ID_DE { get; set; }
        public string OND_ID_PARA { get; set; }
        public string TEM_RESINA_DE { get; set; }
        public string TEM_RESINA_PARA { get; set; }
        public int? TEM_TEMPO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration