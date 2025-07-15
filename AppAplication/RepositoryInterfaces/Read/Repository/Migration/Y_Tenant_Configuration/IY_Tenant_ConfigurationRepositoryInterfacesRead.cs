using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface IY_Tenant_ConfigurationReadRepository
    {
        public DataPagination<Y_Tenant_ConfigurationDTO> getY_Tenant_Configuration(ICommandRead command);
        public Y_Tenant_ConfigurationDTO getById();
        public IEnumerable<Y_Tenant_ConfigurationTenantIDDTO> getY_Tenant_ConfigurationReadFKTenantID(object command);
        public bool ExistsById(int value);
        public bool ExistsByAuditTrackerActived(int value);
        public bool ExistsByAuditCRUDActived(int value);
        public bool ExistsByTenantID(int value);
        public Y_Tenant_ConfigurationDTO FirstById(int value);
        public Y_Tenant_ConfigurationDTO FirstByAuditTrackerActived(int value);
        public Y_Tenant_ConfigurationDTO FirstByAuditCRUDActived(int value);
        public Y_Tenant_ConfigurationDTO FirstByTenantID(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration