
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Especialidade
                {
                    public partial class EspecialidadeEntity
                    {
                public int Id { get; set; }
    public string Descricao { get; set; }
 public EspecialidadeEntity(int id, string descricao ){
 Id = id; 
 Descricao = descricao; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }