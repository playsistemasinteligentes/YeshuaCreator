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
                    public interface IClpMedicoesEntity
{
    int? Id { get; set; }
    int Id2 { get; set; }
    string MaquinaId { get; set; }
    DateTime DataInicio { get; set; }
    DateTime DataFim { get; set; }
    DateTime? Emissao { get; set; }
    Decimal Quantidade { get; set; }
    Decimal? Grupo { get; set; }
    int? Status { get; set; }
    string TurnoId { get; set; }
    string TurmaId { get; set; }
    int IdLoteClp { get; set; }
    string OcorrenciaId { get; set; }
    int? Fase { get; set; }
    string ClpOrigem { get; set; }
    int? CLP_LOTE { get; set; }
    int? COMPACTA { get; set; }
    string BOL_ID { get; set; }
    int? COR_SEQUENCIA { get; set; }
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