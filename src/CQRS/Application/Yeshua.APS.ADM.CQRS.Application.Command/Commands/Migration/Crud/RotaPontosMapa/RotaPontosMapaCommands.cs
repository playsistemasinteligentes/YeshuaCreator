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
    public struct RotaPontosMapaCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string ROT_ID { get; set; }
        public string PON_ID_DESTINO { get; set; }
        public string PON_ID_ORIGEM { get; set; }
        public Decimal? ROT_CUSTO_TOTAL { get; set; }
        public string PON_ID_ROTEIRO { get; set; }
        public int? ROT_ORDEM_ROTEIRO { get; set; }
        public string ROT_TIPO { get; set; }
        public Decimal? ROT_DISTANCIA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration