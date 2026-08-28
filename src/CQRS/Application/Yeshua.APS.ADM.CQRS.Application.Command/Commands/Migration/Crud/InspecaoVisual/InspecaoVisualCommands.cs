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
    public struct InspecaoVisualCrudCommand : ICommand
    {
        public int IPV_ID { get; set; }
        public string IPV_VALOR { get; set; }
        public int? IPV_ID_OPERADOR { get; set; }
        public int? IPV_ID_LIBERACAO { get; set; }
        public string IPV_OBS { get; set; }
        public DateTime? IPV_DATA_COLETA { get; set; }
        public DateTime? IPV_DATA_AVAL { get; set; }
        public int? TIV_ID { get; set; }
        public string TURN_ID { get; set; }
        public string TURM_ID { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public string ROT_MAQ_ID { get; set; }
        public int? ROT_SEQ_TRANSFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public string IPV_STATUS_LIBERACAO { get; set; }
        public Decimal? IPV_VALOR_MEDIDA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration