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
    public interface IY_PermtionsReadRepository
    {
        public DataPagination<Y_PermtionsDTO> getY_Permtions(ICommandRead command);
        public Y_PermtionsDTO getById();
        public bool ExistsById(string value);
        public bool ExistsByDescription(string value);
        public Y_PermtionsDTO FirstById(string value);
        public Y_PermtionsDTO FirstByDescription(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration