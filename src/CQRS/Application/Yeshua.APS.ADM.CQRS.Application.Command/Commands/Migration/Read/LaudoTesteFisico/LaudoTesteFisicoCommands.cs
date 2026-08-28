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
    public struct LaudoTesteFisicoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? LTF_ID { get; set; }
        public DateTime? LTF_EMISSAO { get; set; }
        public Decimal? LTF_VALOR { get; set; }
        public string LTF_OBS { get; set; }
        public string LTF_STATUS { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? USE_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration