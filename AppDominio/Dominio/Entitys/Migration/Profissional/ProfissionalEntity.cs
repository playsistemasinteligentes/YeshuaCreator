
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Profissional
                {
                    public partial class ProfissionalEntity
                    {
                public int? Id { get; set; }
    public string Nome { get; set; }
    public int? EspecialidadeId { get; set; }
    public string Telefone { get; set; }
    private List<string> _erroMensagem = null;
 public ProfissionalEntity(int id, string nome, int especialidadeid, string telefone ){
 Id = id; 
 Nome = nome; 
 EspecialidadeId = especialidadeid; 
 Telefone = telefone; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome do Profissional deve ser informado.");
   if(string.IsNullOrEmpty(Telefone))
   this._erroMensagem.Add("Telefone do Profissional deve ser informado.");
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