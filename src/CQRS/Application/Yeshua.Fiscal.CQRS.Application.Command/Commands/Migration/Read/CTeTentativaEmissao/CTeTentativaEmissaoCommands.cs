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
    public struct CTeTentativaEmissaoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? CTeSolicitacaoFiscalId { get; set; }
        public string? ChaveAcesso { get; set; }
        public int? Numero { get; set; }
        public int? Serie { get; set; }
        public int? Tentativa { get; set; }
        public string? XmlAssinadoStorageKey { get; set; }
        public string? XmlProcStorageKey { get; set; }
        public string? XmlHash { get; set; }
        public string? CodigoRetorno { get; set; }
        public string? MensagemRetorno { get; set; }
        public string? ProtocoloAutorizacao { get; set; }
        public DateTime? EnviadoEmUtc { get; set; }
        public DateTime? AutorizadoEmUtc { get; set; }
        public int? Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration