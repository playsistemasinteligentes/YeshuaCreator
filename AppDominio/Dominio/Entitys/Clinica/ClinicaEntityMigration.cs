
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
 public ClinicaEntity(int Id, string RazaoSocial, string NomeReduzido ){
 Id = Id; 
 RazaoSocial = RazaoSocial; 
 NomeReduzido = NomeReduzido; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }