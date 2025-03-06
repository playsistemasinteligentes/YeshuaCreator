
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.DisponibilidadeAgenda
                {
                    public partial class DisponibilidadeAgendaEntity
                    {
                public int? Id { get; set; }
    public int? ProfissionalId { get; set; }
    public DateTime DataHora { get; set; }
    private List<string> _erroMensagem = null;
 public DisponibilidadeAgendaEntity(int id, int profissionalid, DateTime datahora ){
 Id = id; 
 ProfissionalId = profissionalid; 
 DataHora = (datahora < (new DateTime(1800, 1, 1))) ? DateTime.Now : datahora; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (DataHora == null || DataHora < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Horário Disponível deve ser informado.");
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