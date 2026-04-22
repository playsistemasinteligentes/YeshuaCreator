using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record yPerfilGrantDTO
    {
    public int perfilid { get; set; }
    public string grantid { get; set; }
    public bool grant { get; set; }
    public bool create { get; set; }
    public bool read { get; set; }
    public bool update { get; set; }
    public bool delete { get; set; }
    public DateTime validuntil { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration