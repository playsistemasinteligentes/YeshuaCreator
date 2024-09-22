using Repositorio.Outputs.DTOs.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Profissional
{
    public interface IProfissionalReadRepository
    {
        public IEnumerable<ProfissionalDTO> getAllProfissional();
        public ProfissionalDTO getById();
    }
}
