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
    public interface IYperfilReadRepository
    {
        public DataPagination<YperfilDTO> getYperfil(ICommandRead command);
        public YperfilDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByDescription(string value);
        public YperfilDTO FirstById(int value);
        public YperfilDTO FirstByDescription(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration