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
                    public partial class T_MetasEntity : IT_MetasEntity
{
    public int MET_ID { get; set; }
    public string MET_DTINICIO { get; set; }
    public string MET_DTFIM { get; set; }
    public string MET_ALVO { get; set; }
    public int MET_TIPOALVO { get; set; }
    public int IND_ID { get; set; }
    public Decimal? MET_RANGE01 { get; set; }
    public Decimal? MET_RANGE02 { get; set; }
    public Decimal? MET_RANGE03 { get; set; }
    public int? DIM_ID { get; set; }
    public string FAT_ID { get; set; }
    public string DIM_SUBDIMENSAO_ID { get; set; }
    public string PER_ID { get; set; }
    public string DOM_EMPRESA { get; set; }
    public string DOM_FILIAL { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_MetasEntity(int met_id, string met_dtinicio, string met_dtfim, string met_alvo, int met_tipoalvo, int ind_id, Decimal? met_range01, Decimal? met_range02, Decimal? met_range03, int? dim_id, string fat_id, string dim_subdimensao_id, string per_id, string dom_empresa, string dom_filial ){
 MET_ID = met_id; 
 MET_DTINICIO = met_dtinicio; 
 MET_DTFIM = met_dtfim; 
 MET_ALVO = met_alvo; 
 MET_TIPOALVO = met_tipoalvo; 
 IND_ID = ind_id; 
 MET_RANGE01 = met_range01; 
 MET_RANGE02 = met_range02; 
 MET_RANGE03 = met_range03; 
 DIM_ID = dim_id; 
 FAT_ID = fat_id; 
 DIM_SUBDIMENSAO_ID = dim_subdimensao_id; 
 PER_ID = per_id; 
 DOM_EMPRESA = dom_empresa; 
 DOM_FILIAL = dom_filial; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (MET_ID == null)
   this._erroMensagem.Add("MET ID deve ser informado.");
   if(string.IsNullOrEmpty(MET_DTINICIO))
   this._erroMensagem.Add("MET DTINICIO deve ser informado.");
   if(string.IsNullOrEmpty(MET_DTFIM))
   this._erroMensagem.Add("MET DTFIM deve ser informado.");
   if(string.IsNullOrEmpty(MET_ALVO))
   this._erroMensagem.Add("MET ALVO deve ser informado.");
   if (MET_TIPOALVO == null)
   this._erroMensagem.Add("MET TIPOALVO deve ser informado.");
   if (IND_ID == null)
   this._erroMensagem.Add("IND ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration