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
                    public interface IItemTestavelEntity
{
    int? Id { get; set; }
    int ITE_ID { get; set; }
    string ITE_DESCRICAO { get; set; }
    string ITE_OBS { get; set; }
    int? ITE_NUMERO_DE_TESTES { get; set; }
    string ITE_CONDICIONAL_DE_AVALIACAO { get; set; }
    Decimal? ITE_VALOR_DA_CONDICIONAL { get; set; }
    string ITE_VALOR_CALCULADO_DA_CONDICIONAL { get; set; }
    string ITE_TIPO_AVALIACAO_FINAL { get; set; }
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