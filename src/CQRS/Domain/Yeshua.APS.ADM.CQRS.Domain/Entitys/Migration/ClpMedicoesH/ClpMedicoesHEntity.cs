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
                    public partial class ClpMedicoesHEntity : IClpMedicoesHEntity
{
    public int ID { get; set; }
    public string MAQUINA_ID { get; set; }
    public DateTime DATA_INI { get; set; }
    public DateTime DATA_FIM { get; set; }
    public DateTime? CLP_EMISSAO { get; set; }
    public Decimal QTD { get; set; }
    public Decimal? GRUPO { get; set; }
    public int? STATUS { get; set; }
    public string URN_ID { get; set; }
    public string URM_ID { get; set; }
    public int ID_LOTE_CLP { get; set; }
    public string OCO_ID { get; set; }
    public int? FASE { get; set; }
    public string CLP_ORIGEM { get; set; }
    public int? CLP_LOTE { get; set; }
    public int? COMPACTA { get; set; }
    public string BOL_ID { get; set; }
    public int? COR_SEQUENCIA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ClpMedicoesHEntity(int id, string maquina_id, DateTime data_ini, DateTime data_fim, DateTime? clp_emissao, Decimal qtd, Decimal? grupo, int? status, string urn_id, string urm_id, int id_lote_clp, string oco_id, int? fase, string clp_origem, int? clp_lote, int? compacta, string bol_id, int? cor_sequencia ){
 ID = id; 
 MAQUINA_ID = maquina_id; 
 DATA_INI = (data_ini < (new DateTime(1800, 1, 1))) ? DateTime.Now : data_ini; 
 DATA_FIM = (data_fim < (new DateTime(1800, 1, 1))) ? DateTime.Now : data_fim; 
 CLP_EMISSAO = (clp_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : clp_emissao; 
 QTD = qtd; 
 GRUPO = grupo; 
 STATUS = status; 
 URN_ID = urn_id; 
 URM_ID = urm_id; 
 ID_LOTE_CLP = id_lote_clp; 
 OCO_ID = oco_id; 
 FASE = fase; 
 CLP_ORIGEM = clp_origem; 
 CLP_LOTE = clp_lote; 
 COMPACTA = compacta; 
 BOL_ID = bol_id; 
 COR_SEQUENCIA = cor_sequencia; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MAQUINA_ID))
   this._erroMensagem.Add("MAQUINA ID deve ser informado.");
   if(DATA_INI == null || DATA_INI < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DATA INI deve ser informado.");
   if(DATA_FIM == null || DATA_FIM < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DATA FIM deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration