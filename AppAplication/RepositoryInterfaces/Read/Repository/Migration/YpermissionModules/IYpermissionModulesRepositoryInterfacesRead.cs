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
    public interface IYpermissionModulesReadRepository
    {
        public DataPagination<YpermissionModulesDTO> getYpermissionModules(ICommandRead command);
        public YpermissionModulesDTO getById();
        public bool ExistsById(string value);
        public bool ExistsByDescription(string value);
        public YpermissionModulesDTO FirstById(string value);
        public YpermissionModulesDTO FirstByDescription(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration