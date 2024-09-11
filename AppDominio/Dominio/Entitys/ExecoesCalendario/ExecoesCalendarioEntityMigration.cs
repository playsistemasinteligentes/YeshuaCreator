
                using Dominio.TiposPrimitivos;
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.ExecoesCalendario
                {
                    public partial class ExecoesCalendarioEntity
                    {
                public int Id { get; set; }
    public DateTime De { get; set; }
    public DateTime Ate { get; set; }
 public ExecoesCalendarioEntity(int Id, DateTime De, DateTime Ate ){
 Id = Id; 
 De = De; 
 Ate = Ate; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }