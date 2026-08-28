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
                    public interface IMovimentoEstoqueEntity
{
    int Id { get; set; }
    string ProdutoId { get; set; }
    string OrderId { get; set; }
    string Tipo { get; set; }
    string TurnoId { get; set; }
    string TurmaId { get; set; }
    Decimal Quantidade { get; set; }
    Decimal MOV_PESO_UNITARIO { get; set; }
    DateTime DataHoraCriacao { get; set; }
    DateTime? DataHoraEmissao { get; set; }
    string DiaTurma { get; set; }
    string Lote { get; set; }
    string SubLote { get; set; }
    string MaquinaId { get; set; }
    int? USE_ID { get; set; }
    string Observacao { get; set; }
    string OcorrenciaId { get; set; }
    string Armazem { get; set; }
    string Endereco { get; set; }
    string Estorno { get; set; }
    int? SequenciaTransformacao { get; set; }
    int? SequenciaRepeticao { get; set; }
    string ObsOpParcial { get; set; }
    string OcoIdOpParcial { get; set; }
    string MOV_ID_INTEGRACAO { get; set; }
    string MOV_ID_INTEGRACAO_ERP { get; set; }
    string CAR_ID { get; set; }
    int? MOV_ID_DESTINO { get; set; }
    string PRO_ID_DESTINO { get; set; }
    string MOV_LOTE_DESTINO { get; set; }
    string MOV_SUB_LOTE_DESTINO { get; set; }
    int? MOV_ID_ORIGEM { get; set; }
    string PRO_ID_ORIGEM { get; set; }
    string MOV_LOTE_ORIGEM { get; set; }
    string MOV_SUB_LOTE_ORIGEM { get; set; }
    int? MOV_TYPE { get; set; }
    string MOV_DOC { get; set; }
    string MOV_APROVEITAMENTO { get; set; }
    string MOV_RETIDO { get; set; }
    string MOV_VINCOS_ONDULADEIRA { get; set; }
    string BOL_ID { get; set; }
    string ORD_ID_ORIGEM { get; set; }
    int? COR_SEQUENCIA { get; set; }
    int? VER_ID { get; set; }
    string MOV_TIPO_CUSTO { get; set; }
    string MOV_GRUPO_CONTABIL { get; set; }
    string FOR_ID { get; set; }
    string CLI_ID { get; set; }
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