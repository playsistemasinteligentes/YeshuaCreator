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
    public interface IYtenantPermissionMudulesReadRepository
    {
        public DataPagination<YtenantPermissionMudulesDTO> getYtenantPermissionMudules(ICommandRead command);
        public YtenantPermissionMudulesDTO getById();
        public IEnumerable<YtenantPermissionMudulespermissionModulesIdDTO> getYtenantPermissionMudulesReadFKpermissionModulesId(object command);
        public IEnumerable<YtenantPermissionMudulesTenantIDDTO> getYtenantPermissionMudulesReadFKTenantID(object command);
        public bool ExistsById(int value);
        public bool ExistsBypermissionModulesId(string value);
        public bool ExistsByTenantID(int value);
        public bool ExistsByValidUntil(DateTime value);
        public YtenantPermissionMudulesDTO FirstById(int value);
        public YtenantPermissionMudulesDTO FirstBypermissionModulesId(string value);
        public YtenantPermissionMudulesDTO FirstByTenantID(int value);
        public YtenantPermissionMudulesDTO FirstByValidUntil(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration