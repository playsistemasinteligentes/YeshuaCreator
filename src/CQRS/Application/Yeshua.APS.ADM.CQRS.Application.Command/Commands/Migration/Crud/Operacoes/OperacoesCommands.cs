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
    public struct OperacoesCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string OPE_TIPO_REGISTRO { get; set; }
        public string OPE_ID { get; set; }
        public string GMA_ID { get; set; }
        public string MAQ_ID { get; set; }
        public string PRO_ID { get; set; }
        public string OPE_EXCECAO { get; set; }
        public int ROT_SEQ_TRANFORMACAO { get; set; }
        public string ORD_ID { get; set; }
        public int FPR_SEQ_REPETICAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration