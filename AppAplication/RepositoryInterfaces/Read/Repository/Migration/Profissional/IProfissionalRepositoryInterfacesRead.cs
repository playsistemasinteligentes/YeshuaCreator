using Repositorio.Outputs.DTOs.Profissional;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Profissional
{
    public interface IProfissionalReadRepository
    {
        public DataPagination<ProfissionalDTO> getProfissional(ICommandRead command);
        public ProfissionalDTO getById();
        public IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration