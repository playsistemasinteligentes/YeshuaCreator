using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYperfilPermissionActionsWriteRepository
    {
        void Insert(IYperfilPermissionActionsEntity yperfilpermissionactions);
        void Update(IYperfilPermissionActionsEntity yperfilpermissionactions);
        void Delete(IYperfilPermissionActionsEntity yperfilpermissionactions);
        public void UpdatePerfilId(IYperfilPermissionActionsEntity entity);
        public void UpdatepermissionActionsId(IYperfilPermissionActionsEntity entity);
        public void UpdateGrant(IYperfilPermissionActionsEntity entity);
        public void UpdateCreate(IYperfilPermissionActionsEntity entity);
        public void UpdateRead(IYperfilPermissionActionsEntity entity);
        public void UpdateUpdate(IYperfilPermissionActionsEntity entity);
        public void UpdateDelete(IYperfilPermissionActionsEntity entity);
        public void UpdateValidUntil(IYperfilPermissionActionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration