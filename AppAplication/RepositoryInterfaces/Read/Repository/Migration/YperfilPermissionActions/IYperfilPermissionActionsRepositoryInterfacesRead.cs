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
    public interface IYperfilPermissionActionsReadRepository
    {
        public DataPagination<YperfilPermissionActionsDTO> getYperfilPermissionActions(ICommandRead command);
        public YperfilPermissionActionsDTO getById();
        public IEnumerable<YperfilPermissionActionsPerfilIdDTO> getYperfilPermissionActionsReadFKPerfilId(object command);
        public IEnumerable<YperfilPermissionActionspermissionActionsIdDTO> getYperfilPermissionActionsReadFKpermissionActionsId(object command);
        public bool ExistsByPerfilId(int value);
        public bool ExistsBypermissionActionsId(string value);
        public bool ExistsByGrant(bool value);
        public bool ExistsByCreate(bool value);
        public bool ExistsByRead(bool value);
        public bool ExistsByUpdate(bool value);
        public bool ExistsByDelete(bool value);
        public bool ExistsByValidUntil(DateTime value);
        public YperfilPermissionActionsDTO FirstByPerfilId(int value);
        public YperfilPermissionActionsDTO FirstBypermissionActionsId(string value);
        public YperfilPermissionActionsDTO FirstByGrant(bool value);
        public YperfilPermissionActionsDTO FirstByCreate(bool value);
        public YperfilPermissionActionsDTO FirstByRead(bool value);
        public YperfilPermissionActionsDTO FirstByUpdate(bool value);
        public YperfilPermissionActionsDTO FirstByDelete(bool value);
        public YperfilPermissionActionsDTO FirstByValidUntil(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration