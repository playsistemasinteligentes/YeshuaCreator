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
                    public interface IItensOrcamentoEntity
{
    int? Id { get; set; }
    int ITO_ID { get; set; }
    int? ORC_ID { get; set; }
    int? TIP_ID { get; set; }
    string PRO_ID { get; set; }
    string ITO_OBS { get; set; }
    Decimal? ITO_QUANTIDADE { get; set; }
    Decimal? ITO_CUSTO { get; set; }
    Decimal? ITO_MARGEM { get; set; }
    Decimal? ITO_VALOR_UNITARIO { get; set; }
    DateTime? ITO_VERSSAO_CUSTO { get; set; }
    string ITO_STATUS { get; set; }
    Decimal? ITO_ERP_CUSTOS_FIXOS { get; set; }
    Decimal? ITO_ERP_CUSTOS_VARIAVEIS { get; set; }
    Decimal? ITO_ERP_DESPESAS_VAR_VENDA { get; set; }
    Decimal? ITO_ERP_IMPOSTOS { get; set; }
    string GRP_ID_COMPOSICAO { get; set; }
    Decimal? ITO_LARGURA { get; set; }
    Decimal? ITO_COMPRIMENTO { get; set; }
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