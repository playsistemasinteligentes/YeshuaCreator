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
    public interface IY_UserPermitionsReadRepository
    {
        public DataPagination<Y_UserPermitionsDTO> getY_UserPermitions(ICommandRead command);
        public Y_UserPermitionsDTO getById();
        public IEnumerable<Y_UserPermitionsUserIdDTO> getY_UserPermitionsReadFKUserId(object command);
        public IEnumerable<Y_UserPermitionsPermitionsIdDTO> getY_UserPermitionsReadFKPermitionsId(object command);
        public bool ExistsByUserId(int value);
        public bool ExistsByPermitionsId(string value);
        public Y_UserPermitionsDTO FirstByUserId(int value);
        public Y_UserPermitionsDTO FirstByPermitionsId(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration