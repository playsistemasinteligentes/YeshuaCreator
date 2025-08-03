using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYpermissionActionsWriteRepository
    {
        void Insert(IYpermissionActionsEntity ypermissionactions);
        void Update(IYpermissionActionsEntity ypermissionactions);
        void Delete(IYpermissionActionsEntity ypermissionactions);
        public void UpdateDescription(IYpermissionActionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration