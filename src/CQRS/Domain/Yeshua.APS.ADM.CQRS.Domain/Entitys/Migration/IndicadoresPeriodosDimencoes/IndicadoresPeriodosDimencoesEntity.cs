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
                    public partial class IndicadoresPeriodosDimencoesEntity : IIndicadoresPeriodosDimencoesEntity
{
    public int? Id { get; set; }
    public string PER_ID { get; set; }
    public int IND_ID { get; set; }
    public int DIM_ID { get; set; }
    public string PER_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal IndicadoresPeriodosDimencoesEntity(int? id, string per_id, int ind_id, int dim_id, string per_descricao ){
 Id = id; 
 PER_ID = per_id; 
 IND_ID = ind_id; 
 DIM_ID = dim_id; 
 PER_DESCRICAO = per_descricao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PER_ID))
   this._erroMensagem.Add("PER ID deve ser informado.");
   if(string.IsNullOrEmpty(PER_DESCRICAO))
   this._erroMensagem.Add("PER DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration