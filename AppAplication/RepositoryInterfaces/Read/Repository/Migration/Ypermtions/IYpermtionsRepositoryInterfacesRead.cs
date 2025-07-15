using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface IYpermtionsReadRepository
    {
        public DataPagination<YpermtionsDTO> getYpermtions(ICommandRead command);
        public YpermtionsDTO getById();
        public bool ExistsById(string value);
        public bool ExistsByDescription(string value);
        public YpermtionsDTO FirstById(string value);
        public YpermtionsDTO FirstByDescription(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration