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
    public struct OrderTrackReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? OTK_ID { get; set; }
        public Decimal? OTK_SEQUENCIA { get; set; }
        public int? OTK_VERSSAO { get; set; }
        public string ORD_ID { get; set; }
        public string OTK_EVENTO { get; set; }
        public DateTime? OTK_DATA_NECESSIDADE_DE { get; set; }
        public DateTime? OTK_DATA_NECESSIDADE_ATE { get; set; }
        public DateTime? OTK_DATA_PREVISTA { get; set; }
        public DateTime? OTK_DATA_REALIZADA { get; set; }
        public int? FPR_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration