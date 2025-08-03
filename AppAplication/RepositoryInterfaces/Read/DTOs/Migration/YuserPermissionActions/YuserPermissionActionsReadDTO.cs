using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record YuserPermissionActionsDTO
    {
    public int perfilid { get; set; }
    public string permissionactionsid { get; set; }
    public bool grant { get; set; }
    public bool create { get; set; }
    public bool read { get; set; }
    public bool update { get; set; }
    public bool delete { get; set; }
    public DateTime validuntil { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration