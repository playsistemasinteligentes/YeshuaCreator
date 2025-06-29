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
        void Insert(IY_TenantEntity y_tenant);
        void Update(IY_TenantEntity y_tenant);
        void Delete(IY_TenantEntity y_tenant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration