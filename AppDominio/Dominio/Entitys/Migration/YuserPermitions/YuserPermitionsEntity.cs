
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YuserPermitionsEntity : IYuserPermitionsEntity
{
    public string PermitionsId { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal YuserPermitionsEntity(string permitionsid, int? userid ){
 PermitionsId = permitionsid; 
 UserId = userid; 
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