using Repositorio.Outputs.DTOs.Y_Tenant;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_Tenant
{
    public interface IY_TenantReadRepository
    {
        public DataPagination<Y_TenantDTO> getY_Tenant(ICommandRead command);
        public Y_TenantDTO getById();
        public IEnumerable<Y_TenantUserIDAdminDTO> getY_TenantReadFKUserIDAdmin(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration