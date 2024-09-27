
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
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
 public ClinicaEntity(int id, string nome, string endereco, string telefone ){
 Id = id; 
 Nome = nome; 
 Endereco = endereco; 
 Telefone = telefone; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }