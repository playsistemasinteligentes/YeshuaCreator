using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public interface IProfissionalReadRepository
    {
        public DataPagination<ProfissionalDTO> getProfissional(ICommandRead command);
        public ProfissionalDTO getById();
        public IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(object command);
        public bool ExistsById(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByEspecialidadeId(int value);
        public bool ExistsByTelefone(string value);
        public ProfissionalDTO FirstById(int value);
        public ProfissionalDTO FirstByNome(string value);
        public ProfissionalDTO FirstByEspecialidadeId(int value);
        public ProfissionalDTO FirstByTelefone(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration