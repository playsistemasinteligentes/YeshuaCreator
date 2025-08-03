using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYtenantPermissionMudulesWriteRepository
    {
        void Insert(IYtenantPermissionMudulesEntity ytenantpermissionmudules);
        void Update(IYtenantPermissionMudulesEntity ytenantpermissionmudules);
        void Delete(IYtenantPermissionMudulesEntity ytenantpermissionmudules);
        public void UpdatepermissionModulesId(IYtenantPermissionMudulesEntity entity);
        public void UpdateTenantID(IYtenantPermissionMudulesEntity entity);
        public void UpdateValidUntil(IYtenantPermissionMudulesEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration