using Repositorio.Outputs.DTOs.Y_Tenant_Configuration;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_Tenant_Configuration
{
    public interface IY_Tenant_ConfigurationReadRepository
    {
        public DataPagination<Y_Tenant_ConfigurationDTO> getY_Tenant_Configuration(ICommandRead command);
        public Y_Tenant_ConfigurationDTO getById();
        public IEnumerable<Y_Tenant_ConfigurationTenantIDDTO> getY_Tenant_ConfigurationReadFKTenantID(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration