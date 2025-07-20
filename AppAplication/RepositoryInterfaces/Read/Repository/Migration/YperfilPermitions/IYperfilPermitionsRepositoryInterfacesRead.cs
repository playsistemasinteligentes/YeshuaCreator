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
    public interface IYperfilPermitionsReadRepository
    {
        public DataPagination<YperfilPermitionsDTO> getYperfilPermitions(ICommandRead command);
        public YperfilPermitionsDTO getById();
        public IEnumerable<YperfilPermitionsPerfilIdDTO> getYperfilPermitionsReadFKPerfilId(object command);
        public IEnumerable<YperfilPermitionsPermitionsIdDTO> getYperfilPermitionsReadFKPermitionsId(object command);
        public bool ExistsByPerfilId(int value);
        public bool ExistsByPermitionsId(string value);
        public YperfilPermitionsDTO FirstByPerfilId(int value);
        public YperfilPermitionsDTO FirstByPermitionsId(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration