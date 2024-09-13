
                using System;
                using Dominio.TiposPrimitivos;
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
 public ExecoesCalendarioEntity(int id, DateTime de, DateTime ate ){
 Id = id; 
 De = de; 
 Ate = ate; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }