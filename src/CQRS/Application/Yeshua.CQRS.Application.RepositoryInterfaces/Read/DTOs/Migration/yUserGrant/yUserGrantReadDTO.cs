using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record yUserGrantDTO
    {
    public int id { get; set; }
    public int perfilid { get; set; }
    public string grantid { get; set; }
    public bool cangrant { get; set; }
    public bool cancreate { get; set; }
    public bool canread { get; set; }
    public bool canupdate { get; set; }
    public bool candelete { get; set; }
    public DateTime validuntil { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration