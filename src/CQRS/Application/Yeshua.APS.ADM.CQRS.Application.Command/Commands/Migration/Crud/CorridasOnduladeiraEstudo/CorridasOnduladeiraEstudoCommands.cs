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
    public struct CorridasOnduladeiraEstudoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public Decimal? PRO_LARGURA_PECA { get; set; }
        public Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
        public string PRO_VINCOS_RECALCULADOS { get; set; }
        public string COR_SOLVER { get; set; }
        public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_TOLERANCIA_MENOS { get; set; }
        public Decimal? COR_TOLERANCIA_MAIS { get; set; }
        public int? COR_PILHAS_POR_PALETE { get; set; }
        public Decimal? COR_M_LINEAR_REALIZADO { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string COR_STATUS_PALETE { get; set; }
        public Decimal? COR_GRUPO_PRODUTIVO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration