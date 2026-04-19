using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyUserModuleWriteRepository
    {
        void Insert(IyUserModuleEntity yusermodule);
        void Update(IyUserModuleEntity yusermodule);
        void Delete(IyUserModuleEntity yusermodule);
        public void UpdateModuleId(IyUserModuleEntity entity);
        public void UpdateUserId(IyUserModuleEntity entity);
        public void UpdateValidUntil(IyUserModuleEntity entity);
        public void UpdateTenantID(IyUserModuleEntity entity);
        public void UpdateDeleted(IyUserModuleEntity entity);
        public void UpdateChanged(IyUserModuleEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration