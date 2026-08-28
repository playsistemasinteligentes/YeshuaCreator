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
                    public partial class MovimentoEstoqueEntity : IMovimentoEstoqueEntity
{
    public int Id { get; set; }
    public string ProdutoId { get; set; }
    public string OrderId { get; set; }
    public string Tipo { get; set; }
    public string TurnoId { get; set; }
    public string TurmaId { get; set; }
    public Decimal Quantidade { get; set; }
    public Decimal MOV_PESO_UNITARIO { get; set; }
    public DateTime DataHoraCriacao { get; set; }
    public DateTime? DataHoraEmissao { get; set; }
    public string DiaTurma { get; set; }
    public string Lote { get; set; }
    public string SubLote { get; set; }
    public string MaquinaId { get; set; }
    public int? USE_ID { get; set; }
    public string Observacao { get; set; }
    public string OcorrenciaId { get; set; }
    public string Armazem { get; set; }
    public string Endereco { get; set; }
    public string Estorno { get; set; }
    public int? SequenciaTransformacao { get; set; }
    public int? SequenciaRepeticao { get; set; }
    public string ObsOpParcial { get; set; }
    public string OcoIdOpParcial { get; set; }
    public string MOV_ID_INTEGRACAO { get; set; }
    public string MOV_ID_INTEGRACAO_ERP { get; set; }
    public string CAR_ID { get; set; }
    public int? MOV_ID_DESTINO { get; set; }
    public string PRO_ID_DESTINO { get; set; }
    public string MOV_LOTE_DESTINO { get; set; }
    public string MOV_SUB_LOTE_DESTINO { get; set; }
    public int? MOV_ID_ORIGEM { get; set; }
    public string PRO_ID_ORIGEM { get; set; }
    public string MOV_LOTE_ORIGEM { get; set; }
    public string MOV_SUB_LOTE_ORIGEM { get; set; }
    public int? MOV_TYPE { get; set; }
    public string MOV_DOC { get; set; }
    public string MOV_APROVEITAMENTO { get; set; }
    public string MOV_RETIDO { get; set; }
    public string MOV_VINCOS_ONDULADEIRA { get; set; }
    public string BOL_ID { get; set; }
    public string ORD_ID_ORIGEM { get; set; }
    public int? COR_SEQUENCIA { get; set; }
    public int? VER_ID { get; set; }
    public string MOV_TIPO_CUSTO { get; set; }
    public string MOV_GRUPO_CONTABIL { get; set; }
    public string FOR_ID { get; set; }
    public string CLI_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MovimentoEstoqueEntity(int id, string produtoid, string orderid, string tipo, string turnoid, string turmaid, Decimal quantidade, Decimal mov_peso_unitario, DateTime datahoracriacao, DateTime? datahoraemissao, string diaturma, string lote, string sublote, string maquinaid, int? use_id, string observacao, string ocorrenciaid, string armazem, string endereco, string estorno, int? sequenciatransformacao, int? sequenciarepeticao, string obsopparcial, string ocoidopparcial, string mov_id_integracao, string mov_id_integracao_erp, string car_id, int? mov_id_destino, string pro_id_destino, string mov_lote_destino, string mov_sub_lote_destino, int? mov_id_origem, string pro_id_origem, string mov_lote_origem, string mov_sub_lote_origem, int? mov_type, string mov_doc, string mov_aproveitamento, string mov_retido, string mov_vincos_onduladeira, string bol_id, string ord_id_origem, int? cor_sequencia, int? ver_id, string mov_tipo_custo, string mov_grupo_contabil, string for_id, string cli_id ){
 Id = id; 
 ProdutoId = produtoid; 
 OrderId = orderid; 
 Tipo = tipo; 
 TurnoId = turnoid; 
 TurmaId = turmaid; 
 Quantidade = quantidade; 
 MOV_PESO_UNITARIO = mov_peso_unitario; 
 DataHoraCriacao = (datahoracriacao < (new DateTime(1800, 1, 1))) ? DateTime.Now : datahoracriacao; 
 DataHoraEmissao = (datahoraemissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : datahoraemissao; 
 DiaTurma = diaturma; 
 Lote = lote; 
 SubLote = sublote; 
 MaquinaId = maquinaid; 
 USE_ID = use_id; 
 Observacao = observacao; 
 OcorrenciaId = ocorrenciaid; 
 Armazem = armazem; 
 Endereco = endereco; 
 Estorno = estorno; 
 SequenciaTransformacao = sequenciatransformacao; 
 SequenciaRepeticao = sequenciarepeticao; 
 ObsOpParcial = obsopparcial; 
 OcoIdOpParcial = ocoidopparcial; 
 MOV_ID_INTEGRACAO = mov_id_integracao; 
 MOV_ID_INTEGRACAO_ERP = mov_id_integracao_erp; 
 CAR_ID = car_id; 
 MOV_ID_DESTINO = mov_id_destino; 
 PRO_ID_DESTINO = pro_id_destino; 
 MOV_LOTE_DESTINO = mov_lote_destino; 
 MOV_SUB_LOTE_DESTINO = mov_sub_lote_destino; 
 MOV_ID_ORIGEM = mov_id_origem; 
 PRO_ID_ORIGEM = pro_id_origem; 
 MOV_LOTE_ORIGEM = mov_lote_origem; 
 MOV_SUB_LOTE_ORIGEM = mov_sub_lote_origem; 
 MOV_TYPE = mov_type; 
 MOV_DOC = mov_doc; 
 MOV_APROVEITAMENTO = mov_aproveitamento; 
 MOV_RETIDO = mov_retido; 
 MOV_VINCOS_ONDULADEIRA = mov_vincos_onduladeira; 
 BOL_ID = bol_id; 
 ORD_ID_ORIGEM = ord_id_origem; 
 COR_SEQUENCIA = cor_sequencia; 
 VER_ID = ver_id; 
 MOV_TIPO_CUSTO = mov_tipo_custo; 
 MOV_GRUPO_CONTABIL = mov_grupo_contabil; 
 FOR_ID = for_id; 
 CLI_ID = cli_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (Id == null)
   this._erroMensagem.Add("Id deve ser informado.");
   if(string.IsNullOrEmpty(ProdutoId))
   this._erroMensagem.Add("ProdutoId deve ser informado.");
   if(string.IsNullOrEmpty(Tipo))
   this._erroMensagem.Add("Tipo deve ser informado.");
   if (Quantidade == null)
   this._erroMensagem.Add("Quantidade deve ser informado.");
   if (MOV_PESO_UNITARIO == null)
   this._erroMensagem.Add("MOV PESO UNITARIO deve ser informado.");
   if (DataHoraCriacao == null || DataHoraCriacao < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DataHoraCriacao deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration