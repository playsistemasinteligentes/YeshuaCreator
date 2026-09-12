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
                    public interface IEmissaoFiscalTransporteEntity
{
    int? Id { get; set; }
    string CorrelationId { get; set; }
    int OrigemFluxo { get; set; }
    string? CargaId { get; set; }
    string? RomaneioId { get; set; }
    int Ambiente { get; set; }
    string? EmitenteDocumento { get; set; }
    string? TomadorDocumento { get; set; }
    string? TransportadorDocumento { get; set; }
    string? UFInicio { get; set; }
    string? UFFim { get; set; }
    string? MunicipioInicioCodigoIbge { get; set; }
    string? MunicipioFimCodigoIbge { get; set; }
    int? QuantidadeNFe { get; set; }
    int? QuantidadeCTe { get; set; }
    int? QuantidadeMDFe { get; set; }
    Decimal? ValorCarga { get; set; }
    Decimal? PesoBruto { get; set; }
    Decimal? Volume { get; set; }
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