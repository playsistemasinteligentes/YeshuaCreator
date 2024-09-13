
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Paciente
                {
                    public partial class PacienteEntity
                    {
                public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeReduzido { get; set; }
 public PacienteEntity(int id, string razaosocial, string nomereduzido ){
 Id = id; 
 RazaoSocial = razaosocial; 
 NomeReduzido = nomereduzido; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }