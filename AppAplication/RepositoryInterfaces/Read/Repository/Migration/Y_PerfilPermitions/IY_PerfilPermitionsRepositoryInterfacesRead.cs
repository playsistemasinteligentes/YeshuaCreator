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
    public interface IY_PerfilPermitionsReadRepository
    {
        public DataPagination<Y_PerfilPermitionsDTO> getY_PerfilPermitions(ICommandRead command);
        public Y_PerfilPermitionsDTO getById();
        public IEnumerable<Y_PerfilPermitionsPerfilIdDTO> getY_PerfilPermitionsReadFKPerfilId(object command);
        public IEnumerable<Y_PerfilPermitionsPermitionsIdDTO> getY_PerfilPermitionsReadFKPermitionsId(object command);
        public bool ExistsByPerfilId(int value);
        public bool ExistsByPermitionsId(string value);
        public Y_PerfilPermitionsDTO FirstByPerfilId(int value);
        public Y_PerfilPermitionsDTO FirstByPermitionsId(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration