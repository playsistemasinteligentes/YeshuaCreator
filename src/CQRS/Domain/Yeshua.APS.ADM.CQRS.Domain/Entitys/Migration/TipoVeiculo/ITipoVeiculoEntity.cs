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
                    public interface ITipoVeiculoEntity
{
    int? Id { get; set; }
    int TIP_ID { get; set; }
    string TIP_DESCRICAO { get; set; }
    int? TIP_QTD_DISPONIVEL { get; set; }
    Decimal? TIP_VALOR_KM { get; set; }
    Decimal? TIP_VALOR_DIARIA { get; set; }
    Decimal? TIP_VALOR_AJUDANTE { get; set; }
    Decimal? TIP_QTD_EIXOS { get; set; }
    Decimal? TIP_VELOCIDADE_MEDIA { get; set; }
    Decimal? TIP_CAPACIDADE_ALTURA { get; set; }
    Decimal? TIP_CAPACIDADE_COMPRIMENTO { get; set; }
    Decimal? TIP_CAPACIDADE_LARGURA { get; set; }
    Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_E { get; set; }
    Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E { get; set; }
    Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_E { get; set; }
    Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_D { get; set; }
    Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D { get; set; }
    Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_D { get; set; }
    Decimal? TIP_CAPACIDADE_M3 { get; set; }
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