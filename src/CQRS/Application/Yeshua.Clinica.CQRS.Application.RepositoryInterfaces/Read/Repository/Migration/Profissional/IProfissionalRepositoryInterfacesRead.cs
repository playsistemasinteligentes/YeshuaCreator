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
    public partial interface IProfissionalReadRepository
    {
        public DataPagination<ProfissionalDTO> getProfissional(ICommandRead command );
        public IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(object command );
        public IEnumerable<ProfissionalTenantIDDTO> getProfissionalReadFKTenantID(object command );
        public IEnumerable<ProfissionalUserIdDTO> getProfissionalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByNome(string value );
        public bool ExistsByEspecialidadeId(int value );
        public bool ExistsByTelefone(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ProfissionalDTO FirstById(int value );
        public ProfissionalDTO FirstByNome(string value );
        public ProfissionalDTO FirstByEspecialidadeId(int value );
        public ProfissionalDTO FirstByTelefone(string value );
        public ProfissionalDTO FirstByTenantID(int value );
        public ProfissionalDTO FirstByDeleted(bool value );
        public ProfissionalDTO FirstByChanged(DateTime value );
        public ProfissionalDTO FirstByUserId(int value );
        public IEnumerable<ProfissionalDTO> GetAllById(int value );
        public IEnumerable<ProfissionalDTO> GetAllByNome(string value );
        public IEnumerable<ProfissionalDTO> GetAllByEspecialidadeId(int value );
        public IEnumerable<ProfissionalDTO> GetAllByTelefone(string value );
        public IEnumerable<ProfissionalDTO> GetAllByTenantID(int value );
        public IEnumerable<ProfissionalDTO> GetAllByDeleted(bool value );
        public IEnumerable<ProfissionalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ProfissionalDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration