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
    public partial interface IEspecialidadeReadRepository
    {
        public DataPagination<EspecialidadeDTO> getEspecialidade(ICommandRead command );
        public IEnumerable<EspecialidadeTenantIDDTO> getEspecialidadeReadFKTenantID(object command );
        public IEnumerable<EspecialidadeUserIdDTO> getEspecialidadeReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EspecialidadeDTO FirstById(int value );
        public EspecialidadeDTO FirstByDescricao(string value );
        public EspecialidadeDTO FirstByTenantID(int value );
        public EspecialidadeDTO FirstByDeleted(bool value );
        public EspecialidadeDTO FirstByChanged(DateTime value );
        public EspecialidadeDTO FirstByUserId(int value );
        public IEnumerable<EspecialidadeDTO> GetAllById(int value );
        public IEnumerable<EspecialidadeDTO> GetAllByDescricao(string value );
        public IEnumerable<EspecialidadeDTO> GetAllByTenantID(int value );
        public IEnumerable<EspecialidadeDTO> GetAllByDeleted(bool value );
        public IEnumerable<EspecialidadeDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EspecialidadeDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration