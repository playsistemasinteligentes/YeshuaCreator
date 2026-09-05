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
                    public partial class IndicadoresDimencoesEntity : IIndicadoresDimencoesEntity
{
    public int? Id { get; set; }
    public int DIM_ID { get; set; }
    public int IND_ID { get; set; }
    public string DIM_DESCRICAO { get; set; }
    public string DIM_SQL { get; set; }
    public string DIM_CONEXAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal IndicadoresDimencoesEntity(int? id, int dim_id, int ind_id, string dim_descricao, string dim_sql, string dim_conexao ){
 Id = id; 
 DIM_ID = dim_id; 
 IND_ID = ind_id; 
 DIM_DESCRICAO = dim_descricao; 
 DIM_SQL = dim_sql; 
 DIM_CONEXAO = dim_conexao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(DIM_DESCRICAO))
   this._erroMensagem.Add("DIM DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration