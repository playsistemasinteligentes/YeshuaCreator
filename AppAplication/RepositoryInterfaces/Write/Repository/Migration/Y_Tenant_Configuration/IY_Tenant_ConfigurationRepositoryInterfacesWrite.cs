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
        void Insert(Y_Tenant_ConfigurationEntity y_tenant_configuration);
        void Update(Y_Tenant_ConfigurationEntity y_tenant_configuration);
        void Delete(Y_Tenant_ConfigurationEntity y_tenant_configuration);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration