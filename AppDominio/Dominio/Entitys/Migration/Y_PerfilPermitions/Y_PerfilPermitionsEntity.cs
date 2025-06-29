
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_PerfilPermitionsEntity : IY_PerfilPermitionsEntity
{
    public int? PerfilId { get; set; }
    public string PermitionsId { get; set; }
    private List<string> _erroMensagem = null;
 internal Y_PerfilPermitionsEntity(int? perfilid, string permitionsid ){
 PerfilId = perfilid; 
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