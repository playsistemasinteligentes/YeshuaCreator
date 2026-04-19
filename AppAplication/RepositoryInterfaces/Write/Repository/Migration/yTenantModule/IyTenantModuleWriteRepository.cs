using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyTenantModuleWriteRepository
    {
        void Insert(IyTenantModuleEntity ytenantmodule);
        void Update(IyTenantModuleEntity ytenantmodule);
        void Delete(IyTenantModuleEntity ytenantmodule);
        public void UpdateModuleId(IyTenantModuleEntity entity);
        public void UpdateTenantID(IyTenantModuleEntity entity);
        public void UpdateValidUntil(IyTenantModuleEntity entity);
        public void UpdateDeleted(IyTenantModuleEntity entity);
        public void UpdateChanged(IyTenantModuleEntity entity);
        public void UpdateUserId(IyTenantModuleEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration