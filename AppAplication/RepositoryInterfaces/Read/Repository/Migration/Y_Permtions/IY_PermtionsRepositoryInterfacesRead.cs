using Repositorio.Outputs.DTOs.Y_Permtions;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_Permtions
{
    public interface IY_PermtionsReadRepository
    {
        public DataPagination<Y_PermtionsDTO> getY_Permtions(ICommandRead command);
        public Y_PermtionsDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration