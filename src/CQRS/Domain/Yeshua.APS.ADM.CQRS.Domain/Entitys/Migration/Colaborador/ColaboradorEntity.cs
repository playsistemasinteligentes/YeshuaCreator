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
                    public partial class ColaboradorEntity : IColaboradorEntity
{
    public string COL_CPF { get; set; }
    public string COL_NOME { get; set; }
    public DateTime COL_NASCIMENTO { get; set; }
    public string COL_EMAIL { get; set; }
    public string COL_MATRICULA { get; set; }
    public string TURM_id { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ColaboradorEntity(string col_cpf, string col_nome, DateTime col_nascimento, string col_email, string col_matricula, string turm_id ){
 COL_CPF = col_cpf; 
 COL_NOME = col_nome; 
 COL_NASCIMENTO = (col_nascimento < (new DateTime(1800, 1, 1))) ? DateTime.Now : col_nascimento; 
 COL_EMAIL = col_email; 
 COL_MATRICULA = col_matricula; 
 TURM_id = turm_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(COL_CPF))
   this._erroMensagem.Add("COL CPF deve ser informado.");
   if(string.IsNullOrEmpty(COL_NOME))
   this._erroMensagem.Add("COL NOME deve ser informado.");
   if(COL_NASCIMENTO == null || COL_NASCIMENTO < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("COL NASCIMENTO deve ser informado.");
   if(string.IsNullOrEmpty(COL_EMAIL))
   this._erroMensagem.Add("COL EMAIL deve ser informado.");
   if(string.IsNullOrEmpty(COL_MATRICULA))
   this._erroMensagem.Add("COL MATRICULA deve ser informado.");
   if(string.IsNullOrEmpty(TURM_id))
   this._erroMensagem.Add("TURM id deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration