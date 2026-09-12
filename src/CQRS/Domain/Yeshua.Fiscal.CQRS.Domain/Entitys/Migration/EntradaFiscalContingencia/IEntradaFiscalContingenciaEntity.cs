// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IEntradaFiscalContingenciaEntity
{
    int? Id { get; set; }
    string CorrelationId { get; set; }
    string CargaId { get; set; }
    int TipoSolicitante { get; set; }
    int Ambiente { get; set; }
    string SourceApplication { get; set; }
    string? SourceModule { get; set; }
    string SourceMessageId { get; set; }
    string? EmitenteFiscalDocumento { get; set; }
    string? TomadorDocumento { get; set; }
    string? TransportadorDocumento { get; set; }
    string? RemetenteDocumento { get; set; }
    string? DestinatarioDocumento { get; set; }
    string? UFInicio { get; set; }
    string? UFFim { get; set; }
    string? MunicipioInicioCodigoIbge { get; set; }
    string? MunicipioFimCodigoIbge { get; set; }
    string? RNTRC { get; set; }
    string? PlacaVeiculo { get; set; }
    string? UFVeiculo { get; set; }
    string? CondutorDocumento { get; set; }
    string? CondutorNome { get; set; }
    int? QuantidadeDocumentos { get; set; }
    Decimal? ValorCarga { get; set; }
    Decimal? PesoBruto { get; set; }
    Decimal? Volume { get; set; }
    string? PendenciasJson { get; set; }
    string? SnapshotJson { get; set; }
    string? EmissaoFiscalCorrelationId { get; set; }
    int? EmissaoFiscalSagaId { get; set; }
    DateTime CriadoEmUtc { get; set; }
    DateTime? AtualizadoEmUtc { get; set; }
    int Status { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration