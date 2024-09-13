
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Atendimento
                {
                    public partial class AtendimentoEntity
                    {
                public int Id { get; set; }
    public int Status { get; set; }
    public DateTime UltimaInteracao { get; set; }
 public AtendimentoEntity(int id, int status, DateTime ultimainteracao ){
 Id = id; 
 Status = status; 
 UltimaInteracao = ultimainteracao; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }