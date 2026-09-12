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
    public struct CTeSolicitacaoFiscalReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? EntradaOficialId { get; set; }
        public int? RomaneioConsolidadoId { get; set; }
        public string? CorrelationId { get; set; }
        public int? Ambiente { get; set; }
        public string? UFEmitente { get; set; }
        public string? EmitenteDocumento { get; set; }
        public int? ProdutoFiscal { get; set; }
        public int? TipoCTe { get; set; }
        public int? TipoServico { get; set; }
        public int? Modal { get; set; }
        public int? Globalizado { get; set; }
        public string? UFInicio { get; set; }
        public string? UFFim { get; set; }
        public string? MunicipioInicioCodigoIbge { get; set; }
        public string? MunicipioFimCodigoIbge { get; set; }
        public Decimal? ValorServico { get; set; }
        public Decimal? ValorCarga { get; set; }
        public string? PreferenciasManifestoJson { get; set; }
        public int? Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration