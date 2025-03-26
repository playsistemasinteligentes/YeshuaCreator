
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Y_Company
                {
                    public partial class Y_CompanyEntity
                    {
                public int? Id { get; set; }
    public string Nome { get; set; }
    public string ProxyServer { get; set; }
    public int? UserIDAdmin { get; set; }
    private List<string> _erroMensagem = null;
 public Y_CompanyEntity(int? id, string nome, string proxyserver, int? useridadmin ){
 Id = id; 
 Nome = nome; 
 ProxyServer = proxyserver; 
 UserIDAdmin = useridadmin; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome deve ser informado.");
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