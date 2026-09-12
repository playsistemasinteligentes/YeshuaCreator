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
                    public interface IContingenciaFiscalEntity
{
    int? Id { get; set; }
    int? EmissaoFiscalTransporteId { get; set; }
    int? EntradaFiscalContingenciaId { get; set; }
    string CorrelationId { get; set; }
    string CargaId { get; set; }
    int TipoSolicitante { get; set; }
    int Ambiente { get; set; }
    string? EmitenteDocumento { get; set; }
    string? TomadorDocumento { get; set; }
    string? TransportadorDocumento { get; set; }
    int? QuantidadeDocumentos { get; set; }
    int? QuantidadeCTe { get; set; }
    int? QuantidadeMDFe { get; set; }
    Decimal? ValorCarga { get; set; }
    Decimal? PesoBruto { get; set; }
    string? UltimaMensagem { get; set; }
    DateTime CriadoEmUtc { get; set; }
    DateTime? AtualizadoEmUtc { get; set; }
    DateTime? ConcluidoEmUtc { get; set; }
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