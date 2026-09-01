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
    public partial interface ITipoDispositivoReadRepository
    {
        public DataPagination<TipoDispositivoDTO> getTipoDispositivo(ICommandRead command );
        public IEnumerable<TipoDispositivoTenantIDDTO> getTipoDispositivoReadFKTenantID(object command );
        public IEnumerable<TipoDispositivoUserIdDTO> getTipoDispositivoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTDI_ID(string value );
        public bool ExistsByTDI_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoDispositivoDTO FirstById(int value );
        public TipoDispositivoDTO FirstByTDI_ID(string value );
        public TipoDispositivoDTO FirstByTDI_DESCRICAO(string value );
        public TipoDispositivoDTO FirstByTenantID(int value );
        public TipoDispositivoDTO FirstByDeleted(bool value );
        public TipoDispositivoDTO FirstByChanged(DateTime value );
        public TipoDispositivoDTO FirstByUserId(int value );
        public IEnumerable<TipoDispositivoDTO> GetAllById(int value );
        public IEnumerable<TipoDispositivoDTO> GetAllByTDI_ID(string value );
        public IEnumerable<TipoDispositivoDTO> GetAllByTDI_DESCRICAO(string value );
        public IEnumerable<TipoDispositivoDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoDispositivoDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoDispositivoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoDispositivoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration