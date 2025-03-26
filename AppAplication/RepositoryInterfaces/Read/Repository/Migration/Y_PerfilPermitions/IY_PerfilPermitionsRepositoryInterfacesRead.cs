using Repositorio.Outputs.DTOs.Y_PerfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_PerfilPermitions
{
    public interface IY_PerfilPermitionsReadRepository
    {
        public IEnumerable<Y_PerfilPermitionsDTO> getY_PerfilPermitions(object command);
        public Y_PerfilPermitionsDTO getById();
        public IEnumerable<Y_PerfilPermitionsPerfilIdDTO> getY_PerfilPermitionsReadFKPerfilId(object command);
        public IEnumerable<Y_PerfilPermitionsPermitionsIdDTO> getY_PerfilPermitionsReadFKPermitionsId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration