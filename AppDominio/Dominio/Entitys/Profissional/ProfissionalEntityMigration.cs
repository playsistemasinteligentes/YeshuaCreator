
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys.Profissional
                {
                    public partial class ProfissionalEntity
                    {
                public int Id { get; set; }
    public string Nome { get; set; }
    public int EspecialidadeId { get; set; }
    public string Telefone { get; set; }
 public ProfissionalEntity(int id, string nome, int especialidadeid, string telefone ){
 Id = id; 
 Nome = nome; 
 EspecialidadeId = especialidadeid; 
 Telefone = telefone; 
}

                public bool isValid()
                {
                    return true;
                }
            }
        }