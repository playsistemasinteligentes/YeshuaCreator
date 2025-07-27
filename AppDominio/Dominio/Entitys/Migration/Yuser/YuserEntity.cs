
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YuserEntity : IYuserEntity
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public int? TenantID { get; set; }
    private List<string> _erroMensagem = null;
 internal YuserEntity(int? id, string nome, string email, string senha, int? tenantid ){
 Id = id; 
 Nome = nome; 
 Email = email; 
 Senha = senha; 
 TenantID = tenantid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome Usuario deve ser informado.");
   if(string.IsNullOrEmpty(Email))
   this._erroMensagem.Add("Email deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration