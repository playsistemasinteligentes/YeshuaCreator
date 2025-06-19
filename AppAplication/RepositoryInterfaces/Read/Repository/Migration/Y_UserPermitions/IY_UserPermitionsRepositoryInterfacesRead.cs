using Repositorio.Outputs.DTOs.Y_UserPermitions;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_UserPermitions
{
    public interface IY_UserPermitionsReadRepository
    {
        public DataPagination<Y_UserPermitionsDTO> getY_UserPermitions(ICommandRead command);
        public Y_UserPermitionsDTO getById();
        public IEnumerable<Y_UserPermitionsUserIdDTO> getY_UserPermitionsReadFKUserId(object command);
        public IEnumerable<Y_UserPermitionsPermitionsIdDTO> getY_UserPermitionsReadFKPermitionsId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration