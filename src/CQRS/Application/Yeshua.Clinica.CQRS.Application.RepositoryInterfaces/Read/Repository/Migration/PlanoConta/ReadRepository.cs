// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

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
    public partial interface IPlanoContaReadRepository
    {
        public DataPagination<PlanoContaDTO> getPlanoConta(ICommandRead command );
        public IEnumerable<PlanoContaTenantIDDTO> getPlanoContaReadFKTenantID(object command );
        public IEnumerable<PlanoContaUserIdDTO> getPlanoContaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCodigo(string value );
        public bool ExistsByNome(string value );
        public bool ExistsByTipo(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PlanoContaDTO FirstById(int value );
        public PlanoContaDTO FirstByCodigo(string value );
        public PlanoContaDTO FirstByNome(string value );
        public PlanoContaDTO FirstByTipo(int value );
        public PlanoContaDTO FirstByTenantID(int value );
        public PlanoContaDTO FirstByDeleted(bool value );
        public PlanoContaDTO FirstByChanged(DateTime value );
        public PlanoContaDTO FirstByUserId(int value );
        public IEnumerable<PlanoContaDTO> GetAllById(int value );
        public IEnumerable<PlanoContaDTO> GetAllByCodigo(string value );
        public IEnumerable<PlanoContaDTO> GetAllByNome(string value );
        public IEnumerable<PlanoContaDTO> GetAllByTipo(int value );
        public IEnumerable<PlanoContaDTO> GetAllByTenantID(int value );
        public IEnumerable<PlanoContaDTO> GetAllByDeleted(bool value );
        public IEnumerable<PlanoContaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PlanoContaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration