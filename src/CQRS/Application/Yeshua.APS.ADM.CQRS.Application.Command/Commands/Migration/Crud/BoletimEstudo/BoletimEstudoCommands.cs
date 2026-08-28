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
    public struct BoletimEstudoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public string BOL_SOLVER { get; set; }
        public string BOL_INTEGRACAO { get; set; }
        public Decimal? BOL_SEQUENCIA { get; set; }
        public Decimal GRP_PAP_GRAMATURA_PROGRAMADO { get; set; }
        public string GRP_ID_PROGRAMADO { get; set; }
        public string GRP_PAPEL1_PROGRAMADO { get; set; }
        public string GRP_PAPEL2_PROGRAMADO { get; set; }
        public string GRP_PAPEL3_PROGRAMADO { get; set; }
        public string GRP_PAPEL4_PROGRAMADO { get; set; }
        public string GRP_PAPEL5_PROGRAMADO { get; set; }
        public string BOL_STATUS_INTERFACE { get; set; }
        public string BOL_TIPO { get; set; }
        public int? BOL_FORMATO { get; set; }
        public Decimal? BOL_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? BOL_GRAMATURA_PAPEIS_REALIZADO { get; set; }
        public Decimal? BOL_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? BOL_CUSTO_PAPEIS_REALIZADO { get; set; }
        public Decimal? BOL_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? BOL_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public int? BOL_REFILE_OBRIGATORIO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration