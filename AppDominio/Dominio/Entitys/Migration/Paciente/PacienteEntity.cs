
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
    public string Nome { get; set; }
    public string Telefone { get; set; }
 public PacienteEntity(int id, string nome, string telefone ){
 Id = id; 
 Nome = nome; 
 Telefone = telefone; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }