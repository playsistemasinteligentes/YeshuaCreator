using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_Tenant
{
    public partial interface IY_TenantWriteRepository
    {
        void Insert(Y_TenantEntity y_tenant);
        void Update(Y_TenantEntity y_tenant);
        void Delete(Y_TenantEntity y_tenant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration