
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Clinica
                {
                    public partial class ClinicaEntity
                    {
                public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeReduzido { get; set; }
    public string Endereco { get; set; }
    public string Fone { get; set; }
 public ClinicaEntity(int id, string razaosocial, string nomereduzido, string endereco, string fone ){
 Id = id; 
 RazaoSocial = razaosocial; 
 NomeReduzido = nomereduzido; 
 Endereco = endereco; 
 Fone = fone; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }