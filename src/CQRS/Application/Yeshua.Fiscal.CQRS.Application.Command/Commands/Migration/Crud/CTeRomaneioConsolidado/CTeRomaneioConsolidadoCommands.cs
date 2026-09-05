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
    public struct CTeRomaneioConsolidadoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int EntradaOficialId { get; set; }
        public string CorrelationId { get; set; }
        public string RomaneioId { get; set; }
        public string CargaId { get; set; }
        public DateTime ConsolidadoEmUtc { get; set; }
        public string UFInicio { get; set; }
        public string UFFim { get; set; }
        public string MunicipioInicioCodigoIbge { get; set; }
        public string MunicipioFimCodigoIbge { get; set; }
        public string EmitenteDocumento { get; set; }
        public string TomadorDocumento { get; set; }
        public string RotaSnapshotJson { get; set; }
        public string CargaSnapshotJson { get; set; }
        public string PreferenciasFiscaisJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration