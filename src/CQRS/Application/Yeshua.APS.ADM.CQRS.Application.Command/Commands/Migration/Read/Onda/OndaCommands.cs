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
    public struct OndaReadCommand : ICommandRead
    {
        public string OND_ID { get; set; }
        public Decimal? OND_ESPESSURA { get; set; }
        public Decimal? OND_PESO_COLA { get; set; }
        public Decimal? OND_RENDIMENTO_ONDA_1 { get; set; }
        public Decimal? OND_RENDIMENTO_ONDA_2 { get; set; }
        public int? OND_PROFUNDIDADE_VINCO { get; set; }
        public string OND_ID_INTEGRACAO { get; set; }
        public int? VIN_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration