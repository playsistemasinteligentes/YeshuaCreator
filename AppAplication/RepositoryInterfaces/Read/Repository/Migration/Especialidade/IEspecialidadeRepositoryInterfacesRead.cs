using Repositorio.Outputs.DTOs.Especialidade;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Especialidade
{
    public interface IEspecialidadeReadRepository
    {
        public DataPagination<EspecialidadeDTO> getEspecialidade(ICommandRead command);
        public EspecialidadeDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration