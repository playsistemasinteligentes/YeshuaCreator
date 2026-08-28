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
    public struct ClpMedicoesHReadCommand : ICommandRead
    {
        public int? ID { get; set; }
        public string MAQUINA_ID { get; set; }
        public DateTime? DATA_INI { get; set; }
        public DateTime? DATA_FIM { get; set; }
        public DateTime? CLP_EMISSAO { get; set; }
        public Decimal? QTD { get; set; }
        public Decimal? GRUPO { get; set; }
        public int? STATUS { get; set; }
        public string URN_ID { get; set; }
        public string URM_ID { get; set; }
        public int? ID_LOTE_CLP { get; set; }
        public string OCO_ID { get; set; }
        public int? FASE { get; set; }
        public string CLP_ORIGEM { get; set; }
        public int? CLP_LOTE { get; set; }
        public int? COMPACTA { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration