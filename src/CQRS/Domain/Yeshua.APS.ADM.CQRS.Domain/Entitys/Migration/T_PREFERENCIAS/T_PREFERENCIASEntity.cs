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
                    public partial class T_PREFERENCIASEntity : IT_PREFERENCIASEntity
{
    public int? Id { get; set; }
    public int PRE_ID { get; set; }
    public string PRE_DESCRICAO { get; set; }
    public string PRE_NAMESPACE { get; set; }
    public string PRE_TIPO { get; set; }
    public string PRE_VALOR { get; set; }
    public int? USE_ID { get; set; }
    public int? PER_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_PREFERENCIASEntity(int? id, int pre_id, string pre_descricao, string pre_namespace, string pre_tipo, string pre_valor, int? use_id, int? per_id ){
 Id = id; 
 PRE_ID = pre_id; 
 PRE_DESCRICAO = pre_descricao; 
 PRE_NAMESPACE = pre_namespace; 
 PRE_TIPO = pre_tipo; 
 PRE_VALOR = pre_valor; 
 USE_ID = use_id; 
 PER_ID = per_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration