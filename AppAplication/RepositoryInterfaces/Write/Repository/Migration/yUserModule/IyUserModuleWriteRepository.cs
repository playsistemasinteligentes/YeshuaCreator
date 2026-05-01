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
        void UpdateModuleId(int id, string value);
        void UpdateUserId(int id, int value);
        void UpdateValidUntil(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration