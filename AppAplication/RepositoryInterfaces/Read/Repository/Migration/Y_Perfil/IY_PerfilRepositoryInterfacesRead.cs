using Repositorio.Outputs.DTOs.Y_Perfil;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_Perfil
{
    public interface IY_PerfilReadRepository
    {
        public DataPagination<Y_PerfilDTO> getY_Perfil(ICommandRead command);
        public Y_PerfilDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration