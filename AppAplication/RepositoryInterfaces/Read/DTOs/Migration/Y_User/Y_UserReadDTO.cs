using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record Y_UserDTO
    {
    public int id { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
    public int tenantid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration