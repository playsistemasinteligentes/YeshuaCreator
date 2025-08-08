using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record PacienteDTO
    {
    public int id { get; set; }
    public string nome { get; set; }
    public string telefone { get; set; }
    public DateTime datanascimento { get; set; }
    public int genero { get; set; }
    public string escolaridade { get; set; }
    public string profissao { get; set; }
    public string endereco { get; set; }
    public string nomeresponsavel { get; set; }
    public string telefoneresponsavel { get; set; }
    public string principaisqueixas { get; set; }
    public string observacaoadicional { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration