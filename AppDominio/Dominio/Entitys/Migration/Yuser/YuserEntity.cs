
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Yuser
                {
                    public partial class YuserEntity
                    {
                public int? Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Login { get; set; }
    private List<string> _erroMensagem = null;
 public YuserEntity(int? id, string nome, string senha, string login ){
 Id = id; 
 Nome = nome; 
 Senha = senha; 
 Login = login; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome da Clínica deve ser informado.");
   if(string.IsNullOrEmpty(Senha))
   this._erroMensagem.Add("Senha deve ser informado.");
   if(string.IsNullOrEmpty(Login))
   this._erroMensagem.Add("Login deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                public bool isValidInsert()
                {
                    return isValidData();
                }
                public bool isValidUpdate()
                {
                    return isValidData();
                }
                public bool isValidDelete()
                {
                    return true;
                }
                public List<string> getErroMensagens()
                {
                    return this._erroMensagem;
                }
            }
        }//Dominio.Schemas.CQRS.SourceCodeEntityMigration