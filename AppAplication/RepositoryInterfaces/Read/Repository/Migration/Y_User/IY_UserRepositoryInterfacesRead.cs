using Repositorio.Outputs.DTOs.Y_User;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_User
{
    public interface IY_UserReadRepository
    {
        public DataPagination<Y_UserDTO> getY_User(ICommandRead command);
        public Y_UserDTO getById();
        public IEnumerable<Y_UserTenantIDDTO> getY_UserReadFKTenantID(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration