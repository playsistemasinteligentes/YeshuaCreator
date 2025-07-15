using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record ProfissionalDTO
    {
    public int id { get; set; }
    public string nome { get; set; }
    public int especialidadeid { get; set; }
    public string telefone { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration