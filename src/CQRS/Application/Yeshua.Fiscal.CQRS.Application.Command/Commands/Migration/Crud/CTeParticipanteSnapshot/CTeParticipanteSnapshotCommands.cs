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
    public struct CTeParticipanteSnapshotCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int CTeSolicitacaoFiscalId { get; set; }
        public string Papel { get; set; }
        public string Documento { get; set; }
        public string? Nome { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? UF { get; set; }
        public string? MunicipioCodigoIbge { get; set; }
        public string? EnderecoJson { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration