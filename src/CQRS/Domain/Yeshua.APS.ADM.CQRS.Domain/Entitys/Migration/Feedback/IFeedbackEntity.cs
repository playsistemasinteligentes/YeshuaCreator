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
                    public interface IFeedbackEntity
{
    int Id { get; set; }
    DateTime DataInicial { get; set; }
    DateTime Datafinal { get; set; }
    string MaquinaId { get; set; }
    string OcorrenciaId { get; set; }
    string TurnoId { get; set; }
    string TurmaId { get; set; }
    int UsuarioId { get; set; }
    string OrderId { get; set; }
    string ProdutoId { get; set; }
    string Observacoes { get; set; }
    Decimal Grupo { get; set; }
    string DiaTurma { get; set; }
    int? SequenciaTransformacao { get; set; }
    int? SequenciaRepeticao { get; set; }
    Decimal QuantidadePulsos { get; set; }
    Decimal? QuantidadePecasPorPulso { get; set; }
    Decimal? FEE_QTD_TOTAL_PRODUCAO_AJUSTADA { get; set; }
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