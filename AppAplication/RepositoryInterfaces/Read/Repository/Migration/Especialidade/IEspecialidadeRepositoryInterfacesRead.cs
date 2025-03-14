using Repositorio.Outputs.DTOs.Especialidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Especialidade
{
    public interface IEspecialidadeReadRepository
    {
        public IEnumerable<EspecialidadeReadDTO> getEspecialidade(object command);
        public EspecialidadeDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration