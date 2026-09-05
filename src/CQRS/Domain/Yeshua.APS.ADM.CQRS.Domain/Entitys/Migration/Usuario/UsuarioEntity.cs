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
                    public partial class UsuarioEntity : IUsuarioEntity
{
    public int USE_ID { get; set; }
    public string USE_NOME { get; set; }
    public string USE_EMAIL { get; set; }
    public string USE_SENHA { get; set; }
    public string TURM_ID { get; set; }
    public int USE_ATIVO { get; set; }
    public string USE_CODERP { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal UsuarioEntity(int use_id, string use_nome, string use_email, string use_senha, string turm_id, int use_ativo, string use_coderp ){
 USE_ID = use_id; 
 USE_NOME = use_nome; 
 USE_EMAIL = use_email; 
 USE_SENHA = use_senha; 
 TURM_ID = turm_id; 
 USE_ATIVO = use_ativo; 
 USE_CODERP = use_coderp; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(USE_NOME))
   this._erroMensagem.Add("USE NOME deve ser informado.");
   if(string.IsNullOrEmpty(USE_EMAIL))
   this._erroMensagem.Add("USE EMAIL deve ser informado.");
   if(string.IsNullOrEmpty(USE_SENHA))
   this._erroMensagem.Add("USE SENHA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration