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
                    public interface IMDFeEncerramentoEntity
{
    int? Id { get; set; }
    int MDFeId { get; set; }
    string ChaveAcesso { get; set; }
    string UfCarregamento { get; set; }
    string UfDescarregamento { get; set; }
    string PlacaVeiculo { get; set; }
    DateTime SolicitadoEm { get; set; }
    DateTime? AutorizadoEm { get; set; }
    string? Protocolo { get; set; }
    string? CodigoRetorno { get; set; }
    string? MensagemRetorno { get; set; }
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