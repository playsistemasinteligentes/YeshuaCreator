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
    public partial interface ITenantCatalogoReadRepository
    {
        public DataPagination<TenantCatalogoDTO> getTenantCatalogo(ICommandRead command );
        public IEnumerable<TenantCatalogoTenantIDDTO> getTenantCatalogoReadFKTenantID(object command );
        public IEnumerable<TenantCatalogoUserIdDTO> getTenantCatalogoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCatalogo(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByValidUntil(DateTime value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TenantCatalogoDTO FirstById(int value );
        public TenantCatalogoDTO FirstByCatalogo(string value );
        public TenantCatalogoDTO FirstByTenantID(int value );
        public TenantCatalogoDTO FirstByValidUntil(DateTime value );
        public TenantCatalogoDTO FirstByDeleted(bool value );
        public TenantCatalogoDTO FirstByChanged(DateTime value );
        public TenantCatalogoDTO FirstByUserId(int value );
        public IEnumerable<TenantCatalogoDTO> GetAllById(int value );
        public IEnumerable<TenantCatalogoDTO> GetAllByCatalogo(string value );
        public IEnumerable<TenantCatalogoDTO> GetAllByTenantID(int value );
        public IEnumerable<TenantCatalogoDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<TenantCatalogoDTO> GetAllByDeleted(bool value );
        public IEnumerable<TenantCatalogoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TenantCatalogoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration