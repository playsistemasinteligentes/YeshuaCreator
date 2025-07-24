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
    public interface IYpserPermitionsReadRepository
    {
        public DataPagination<YpserPermitionsDTO> getYpserPermitions(ICommandRead command);
        public YpserPermitionsDTO getById();
        public IEnumerable<YpserPermitionsPermitionsIdDTO> getYpserPermitionsReadFKPermitionsId(object command);
        public bool ExistsByPermitionsId(string value);
        public YpserPermitionsDTO FirstByPermitionsId(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration