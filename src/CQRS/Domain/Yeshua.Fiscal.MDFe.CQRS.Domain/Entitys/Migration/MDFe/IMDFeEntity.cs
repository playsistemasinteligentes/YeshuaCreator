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
                    public interface IMDFeEntity
{
    int? Id { get; set; }
    string ChaveAcesso { get; set; }
    int Serie { get; set; }
    int Numero { get; set; }
    string UfCarregamento { get; set; }
    string UfDescarregamento { get; set; }
    string PlacaVeiculo { get; set; }
    DateTime EmitidoEm { get; set; }
    DateTime? AutorizadoEm { get; set; }
    DateTime? IniciadoEm { get; set; }
    DateTime? EncerradoEm { get; set; }
    DateTime? CanceladoEm { get; set; }
    int Situacao { get; set; }
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