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
    public partial interface ITipoDispositivoMaquinaReadRepository
    {
        public DataPagination<TipoDispositivoMaquinaDTO> getTipoDispositivoMaquina(ICommandRead command );
        public IEnumerable<TipoDispositivoMaquinaTenantIDDTO> getTipoDispositivoMaquinaReadFKTenantID(object command );
        public IEnumerable<TipoDispositivoMaquinaUserIdDTO> getTipoDispositivoMaquinaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTDI_ID(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoDispositivoMaquinaDTO FirstById(int value );
        public TipoDispositivoMaquinaDTO FirstByTDI_ID(string value );
        public TipoDispositivoMaquinaDTO FirstByMAQ_ID(string value );
        public TipoDispositivoMaquinaDTO FirstByTenantID(int value );
        public TipoDispositivoMaquinaDTO FirstByDeleted(bool value );
        public TipoDispositivoMaquinaDTO FirstByChanged(DateTime value );
        public TipoDispositivoMaquinaDTO FirstByUserId(int value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllById(int value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByTDI_ID(string value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration