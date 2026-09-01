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
    public partial interface ICargosReadRepository
    {
        public DataPagination<CargosDTO> getCargos(ICommandRead command );
        public IEnumerable<CargosTenantIDDTO> getCargosReadFKTenantID(object command );
        public IEnumerable<CargosUserIdDTO> getCargosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByRGO_ID(string value );
        public bool ExistsByRGO_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CargosDTO FirstById(int value );
        public CargosDTO FirstByRGO_ID(string value );
        public CargosDTO FirstByRGO_DESCRICAO(string value );
        public CargosDTO FirstByTenantID(int value );
        public CargosDTO FirstByDeleted(bool value );
        public CargosDTO FirstByChanged(DateTime value );
        public CargosDTO FirstByUserId(int value );
        public IEnumerable<CargosDTO> GetAllById(int value );
        public IEnumerable<CargosDTO> GetAllByRGO_ID(string value );
        public IEnumerable<CargosDTO> GetAllByRGO_DESCRICAO(string value );
        public IEnumerable<CargosDTO> GetAllByTenantID(int value );
        public IEnumerable<CargosDTO> GetAllByDeleted(bool value );
        public IEnumerable<CargosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CargosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration