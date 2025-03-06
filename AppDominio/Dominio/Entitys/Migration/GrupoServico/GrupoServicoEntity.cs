
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.GrupoServico
                {
                    public partial class GrupoServicoEntity
                    {
                public int? Id { get; set; }
    public string Descricao { get; set; }
    private List<string> _erroMensagem = null;
 public GrupoServicoEntity(int id, string descricao ){
 Id = id; 
 Descricao = descricao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Descricao))
   this._erroMensagem.Add("Descrição do Grupo de Serviços deve ser informado.");
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
        }