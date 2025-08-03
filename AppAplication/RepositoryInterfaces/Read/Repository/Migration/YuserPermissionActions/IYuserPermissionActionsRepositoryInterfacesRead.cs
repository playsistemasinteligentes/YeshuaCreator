using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public interface IYuserPermissionActionsReadRepository
    {
        public DataPagination<YuserPermissionActionsDTO> getYuserPermissionActions(ICommandRead command);
        public YuserPermissionActionsDTO getById();
        public IEnumerable<YuserPermissionActionsPerfilIdDTO> getYuserPermissionActionsReadFKPerfilId(object command);
        public IEnumerable<YuserPermissionActionspermissionActionsIdDTO> getYuserPermissionActionsReadFKpermissionActionsId(object command);
        public bool ExistsByPerfilId(int value);
        public bool ExistsBypermissionActionsId(string value);
        public bool ExistsByGrant(bool value);
        public bool ExistsByCreate(bool value);
        public bool ExistsByRead(bool value);
        public bool ExistsByUpdate(bool value);
        public bool ExistsByDelete(bool value);
        public bool ExistsByValidUntil(DateTime value);
        public YuserPermissionActionsDTO FirstByPerfilId(int value);
        public YuserPermissionActionsDTO FirstBypermissionActionsId(string value);
        public YuserPermissionActionsDTO FirstByGrant(bool value);
        public YuserPermissionActionsDTO FirstByCreate(bool value);
        public YuserPermissionActionsDTO FirstByRead(bool value);
        public YuserPermissionActionsDTO FirstByUpdate(bool value);
        public YuserPermissionActionsDTO FirstByDelete(bool value);
        public YuserPermissionActionsDTO FirstByValidUntil(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration