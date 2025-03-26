
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Y_PerfilPermitions
                {
                    public partial class Y_PerfilPermitionsEntity
                    {
                public int? PerfilId { get; set; }
    public string PermitionsId { get; set; }
    private List<string> _erroMensagem = null;
 public Y_PerfilPermitionsEntity(int? perfilid, string permitionsid ){
 PerfilId = perfilid; 
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