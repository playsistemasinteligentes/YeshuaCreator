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
        public IEnumerable<EspecialidadeDTO> getAllEspecialidade();
        public EspecialidadeDTO getById();
    }
}
