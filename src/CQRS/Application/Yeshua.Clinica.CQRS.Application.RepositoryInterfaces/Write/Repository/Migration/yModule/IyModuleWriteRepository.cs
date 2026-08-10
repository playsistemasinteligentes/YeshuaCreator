using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyModuleWriteRepository
    {
        void Insert(IyModuleEntity ymodule);
        void Update(IyModuleEntity ymodule);
        void Delete(IyModuleEntity ymodule);
        void UpdateDescription(string id, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration