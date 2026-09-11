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
    public struct VeiculoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string VEI_PLACA { get; set; }
        public string VEI_UF { get; set; }
        public int? TIP_ID { get; set; }
        public Decimal? VEI_CAPACIDADE_M3 { get; set; }
        public Decimal? VEI_CAPACIDADE_LARGURA { get; set; }
        public Decimal? VEI_CAPACIDADE_COMPRIMENTO { get; set; }
        public Decimal? VEI_CAPACIDADE_ALTURA { get; set; }
        public string VEI_MODELO { get; set; }
        public string VEI_NOME_MOTORISTA { get; set; }
        public string VEI_DADOS_CONTATO { get; set; }
        public string VEI_CPF_MOTORISTA { get; set; }
        public string TCA_ID { get; set; }
        public DateTime? VEI_EMISSAO { get; set; }
        public DateTime? VEI_VENCIMENTO { get; set; }
        public string VEI_STATUS { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration