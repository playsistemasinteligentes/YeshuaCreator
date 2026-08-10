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
        void UpdateModuleId(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateValidUntil(int id, DateTime value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration