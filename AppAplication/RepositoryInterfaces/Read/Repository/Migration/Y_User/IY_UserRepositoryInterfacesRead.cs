using Repositorio.Outputs.DTOs.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_User
{
    public interface IY_UserReadRepository
    {
        public IEnumerable<Y_UserDTO> getY_User(object command);
        public Y_UserDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration