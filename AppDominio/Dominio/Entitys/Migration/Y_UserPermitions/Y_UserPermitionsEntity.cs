
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_UserPermitionsEntity : IY_UserPermitionsEntity
{
    public int? UserId { get; set; }
    public string PermitionsId { get; set; }
    private List<string> _erroMensagem = null;
 internal Y_UserPermitionsEntity(int? userid, string permitionsid ){
 UserId = userid; 
 PermitionsId = permitionsid; 
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