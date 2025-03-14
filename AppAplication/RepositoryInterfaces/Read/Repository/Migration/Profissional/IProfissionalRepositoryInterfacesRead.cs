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
        public IEnumerable<ProfissionalReadDTO> getProfissional(object command);
        public ProfissionalDTO getById();
        public IEnumerable<ProfissionalDTO> getProfissionalReadFKEspecialidadeId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration