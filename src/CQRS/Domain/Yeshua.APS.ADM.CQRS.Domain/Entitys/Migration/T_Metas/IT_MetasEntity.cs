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
                    public interface IT_MetasEntity
{
    int MET_ID { get; set; }
    string MET_DTINICIO { get; set; }
    string MET_DTFIM { get; set; }
    string MET_ALVO { get; set; }
    int MET_TIPOALVO { get; set; }
    int IND_ID { get; set; }
    Decimal? MET_RANGE01 { get; set; }
    Decimal? MET_RANGE02 { get; set; }
    Decimal? MET_RANGE03 { get; set; }
    int? DIM_ID { get; set; }
    string FAT_ID { get; set; }
    string DIM_SUBDIMENSAO_ID { get; set; }
    string PER_ID { get; set; }
    string DOM_EMPRESA { get; set; }
    string DOM_FILIAL { get; set; }
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