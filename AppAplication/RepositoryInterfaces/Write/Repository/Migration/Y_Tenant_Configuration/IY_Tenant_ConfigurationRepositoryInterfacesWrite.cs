using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_Tenant_Configuration
{
    public partial interface IY_Tenant_ConfigurationWriteRepository
    {
        void Insert(IY_Tenant_ConfigurationEntity y_tenant_configuration);
        void Update(IY_Tenant_ConfigurationEntity y_tenant_configuration);
        void Delete(IY_Tenant_ConfigurationEntity y_tenant_configuration);
        public void UpdateAuditTrackerActived(IY_Tenant_ConfigurationEntity entity);
        public void UpdateAuditCRUDActived(IY_Tenant_ConfigurationEntity entity);
        public void UpdateTenantID(IY_Tenant_ConfigurationEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration