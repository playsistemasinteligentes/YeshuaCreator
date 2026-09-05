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
                    public interface ICTeSolicitacaoFiscalEntity
{
    int? Id { get; set; }
    int? EntradaOficialId { get; set; }
    int? RomaneioConsolidadoId { get; set; }
    string CorrelationId { get; set; }
    int Ambiente { get; set; }
    string UFEmitente { get; set; }
    string EmitenteDocumento { get; set; }
    int ProdutoFiscal { get; set; }
    int TipoCTe { get; set; }
    int TipoServico { get; set; }
    int Modal { get; set; }
    int Globalizado { get; set; }
    string UFInicio { get; set; }
    string UFFim { get; set; }
    string MunicipioInicioCodigoIbge { get; set; }
    string MunicipioFimCodigoIbge { get; set; }
    Decimal? ValorServico { get; set; }
    Decimal? ValorCarga { get; set; }
    string PreferenciasManifestoJson { get; set; }
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