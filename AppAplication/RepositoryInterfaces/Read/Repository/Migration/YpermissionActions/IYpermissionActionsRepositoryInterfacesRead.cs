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
    public interface IYpermissionActionsReadRepository
    {
        public DataPagination<YpermissionActionsDTO> getYpermissionActions(ICommandRead command);
        public YpermissionActionsDTO getById();
        public bool ExistsById(string value);
        public bool ExistsByDescription(string value);
        public YpermissionActionsDTO FirstById(string value);
        public YpermissionActionsDTO FirstByDescription(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration