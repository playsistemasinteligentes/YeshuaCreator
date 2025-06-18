
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_UserPermitionsEntity
                    {
                public int? UserId { get; set; }
    public string PermitionsId { get; set; }
    private List<string> _erroMensagem = null;
 public Y_UserPermitionsEntity(int? userid, string permitionsid ){
 UserId = userid; 
 PermitionsId = permitionsid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
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