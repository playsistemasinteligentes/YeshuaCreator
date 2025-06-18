
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class EspecialidadeEntity
                    {
                public int? Id { get; set; }
    public string Descricao { get; set; }
    private List<string> _erroMensagem = null;
 public EspecialidadeEntity(int? id, string descricao ){
 Id = id; 
 Descricao = descricao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Descricao))
   this._erroMensagem.Add("Descrição da Especialidade deve ser informado.");
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