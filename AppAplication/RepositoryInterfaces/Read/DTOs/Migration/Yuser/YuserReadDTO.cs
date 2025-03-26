using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs.DTOs.Yuser
{
    public struct YuserDTO
    {
    public int id { get; set; }
    public string nome { get; set; }
    public string senha { get; set; }
    public string login { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration