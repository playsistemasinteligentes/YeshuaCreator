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
    public struct SefazEndpointReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public List<int> ProdutoFiscal { get; set; }
        public string UF { get; set; }
        public List<int> Ambiente { get; set; }
        public string Servico { get; set; }
        public string Versao { get; set; }
        public string Url { get; set; }
        public List<int> Ativo { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration