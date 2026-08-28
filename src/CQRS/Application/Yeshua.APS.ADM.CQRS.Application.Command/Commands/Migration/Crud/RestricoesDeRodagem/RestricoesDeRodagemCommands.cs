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
    public struct RestricoesDeRodagemCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int RES_ID { get; set; }
        public string RES_TIPO { get; set; }
        public string RES_HORA_INI { get; set; }
        public string RES_HORA_FIM { get; set; }
        public Decimal? RES_VELOCIDADE_HORA_RUSH { get; set; }
        public int? TVE_ID { get; set; }
        public int? MAP_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration