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
    public interface IY_PerfilReadRepository
    {
        public DataPagination<Y_PerfilDTO> getY_Perfil(ICommandRead command);
        public Y_PerfilDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByDescription(string value);
        public Y_PerfilDTO FirstById(int value);
        public Y_PerfilDTO FirstByDescription(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration