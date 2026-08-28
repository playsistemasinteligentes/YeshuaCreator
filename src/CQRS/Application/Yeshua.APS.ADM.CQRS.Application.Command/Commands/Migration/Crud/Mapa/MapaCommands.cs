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
    public struct MapaCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int MAP_ID { get; set; }
        public string PON_ID { get; set; }
        public string PON_ID_VIZINHO { get; set; }
        public Decimal MAP_DISTANCIA { get; set; }
        public Decimal? MAP_CUSTO_PEDAGIO_POR_EIXO { get; set; }
        public int? ROD_ID { get; set; }
        public Decimal? MAP_ALTURA_ROD { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration