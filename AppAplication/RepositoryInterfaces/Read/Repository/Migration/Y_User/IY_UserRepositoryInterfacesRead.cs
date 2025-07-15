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
    public interface IY_UserReadRepository
    {
        public DataPagination<Y_UserDTO> getY_User(ICommandRead command);
        public Y_UserDTO getById();
        public IEnumerable<Y_UserTenantIDDTO> getY_UserReadFKTenantID(object command);
        public bool ExistsById(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByEmail(string value);
        public bool ExistsBySenha(string value);
        public bool ExistsByTenantID(int value);
        public Y_UserDTO FirstById(int value);
        public Y_UserDTO FirstByNome(string value);
        public Y_UserDTO FirstByEmail(string value);
        public Y_UserDTO FirstBySenha(string value);
        public Y_UserDTO FirstByTenantID(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration