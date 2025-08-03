using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYpermissionModulesWriteRepository
    {
        void Insert(IYpermissionModulesEntity ypermissionmodules);
        void Update(IYpermissionModulesEntity ypermissionmodules);
        void Delete(IYpermissionModulesEntity ypermissionmodules);
        public void UpdateDescription(IYpermissionModulesEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration