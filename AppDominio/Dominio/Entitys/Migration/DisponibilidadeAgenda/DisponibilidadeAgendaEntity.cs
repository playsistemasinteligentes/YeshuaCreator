
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
                public int Id { get; set; }
    public int ProfissionalId { get; set; }
    public DateTime DataHora { get; set; }
 public DisponibilidadeAgendaEntity(int id, int profissionalid, DateTime datahora ){
 Id = id; 
 ProfissionalId = profissionalid; 
 DataHora = datahora; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }