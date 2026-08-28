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
    public struct MunicipioCrudCommand : ICommand
    {
        public string MUN_ID { get; set; }
        public string MUN_NOME { get; set; }
        public string UF_COD { get; set; }
        public string MUN_CODIGO_IBGE { get; set; }
        public Decimal? MUN_LATITUDE { get; set; }
        public Decimal? MUN_LONGITUDE { get; set; }
        public string MUN_ID_INTEGRACAO_ERP { get; set; }
        public string MUN_CODIGO_SIAFI { get; set; }
        public string MUN_CODIGO_CNPJ { get; set; }
        public Decimal? MUN_DISTANCIA_KM { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration