
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_PerfilEntity : IY_PerfilEntity
{
    public int? Id { get; set; }
    public string Description { get; set; }
    private List<string> _erroMensagem = null;
 internal Y_PerfilEntity(int? id, string description ){
 Id = id; 
 Description = description; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Description))
   this._erroMensagem.Add("Descrição deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration