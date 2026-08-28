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
    public struct OcorrenciaReadCommand : ICommandRead
    {
        public string OCO_ID { get; set; }
        public string OCO_DESCRICAO { get; set; }
        public int? TIP_ID { get; set; }
        public string GMA_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? SPR { get; set; }
        public string OCO_SUB_TIPO { get; set; }
        public string SUB_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration