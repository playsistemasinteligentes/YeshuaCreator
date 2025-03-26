
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Y_Perfil
                {
                    public partial class Y_PerfilEntity
                    {
                public int? Id { get; set; }
    public string Description { get; set; }
    private List<string> _erroMensagem = null;
 public Y_PerfilEntity(int? id, string description ){
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