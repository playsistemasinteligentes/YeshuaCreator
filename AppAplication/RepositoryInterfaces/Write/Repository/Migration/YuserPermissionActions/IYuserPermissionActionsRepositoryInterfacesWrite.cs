using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYuserPermissionActionsWriteRepository
    {
        void Insert(IYuserPermissionActionsEntity yuserpermissionactions);
        void Update(IYuserPermissionActionsEntity yuserpermissionactions);
        void Delete(IYuserPermissionActionsEntity yuserpermissionactions);
        public void UpdatePerfilId(IYuserPermissionActionsEntity entity);
        public void UpdatepermissionActionsId(IYuserPermissionActionsEntity entity);
        public void UpdateGrant(IYuserPermissionActionsEntity entity);
        public void UpdateCreate(IYuserPermissionActionsEntity entity);
        public void UpdateRead(IYuserPermissionActionsEntity entity);
        public void UpdateUpdate(IYuserPermissionActionsEntity entity);
        public void UpdateDelete(IYuserPermissionActionsEntity entity);
        public void UpdateValidUntil(IYuserPermissionActionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration