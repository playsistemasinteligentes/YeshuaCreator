
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Servico
                {
                    public partial class ServicoEntity
                    {
                public int? Id { get; set; }
    public int? GrupoServicoId { get; set; }
    public string Nome { get; set; }
    public Decimal? Valor { get; set; }
    private List<string> _erroMensagem = null;
 public ServicoEntity(int id, int gruposervicoid, string nome, Decimal valor ){
 Id = id; 
 GrupoServicoId = gruposervicoid; 
 Nome = nome; 
 Valor = valor; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Nome))
   this._erroMensagem.Add("Nome do Serviço deve ser informado.");
   if (Valor == null)
   this._erroMensagem.Add("Valor do Serviço deve ser informado.");
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