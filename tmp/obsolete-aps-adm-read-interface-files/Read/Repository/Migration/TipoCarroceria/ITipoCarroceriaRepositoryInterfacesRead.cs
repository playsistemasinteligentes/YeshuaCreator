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
    public partial interface ITipoCarroceriaReadRepository
    {
        public DataPagination<TipoCarroceriaDTO> getTipoCarroceria(ICommandRead command );
        public IEnumerable<TipoCarroceriaTenantIDDTO> getTipoCarroceriaReadFKTenantID(object command );
        public IEnumerable<TipoCarroceriaUserIdDTO> getTipoCarroceriaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTCA_ID(string value );
        public bool ExistsByTCA_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoCarroceriaDTO FirstById(int value );
        public TipoCarroceriaDTO FirstByTCA_ID(string value );
        public TipoCarroceriaDTO FirstByTCA_DESCRICAO(string value );
        public TipoCarroceriaDTO FirstByTenantID(int value );
        public TipoCarroceriaDTO FirstByDeleted(bool value );
        public TipoCarroceriaDTO FirstByChanged(DateTime value );
        public TipoCarroceriaDTO FirstByUserId(int value );
        public IEnumerable<TipoCarroceriaDTO> GetAllById(int value );
        public IEnumerable<TipoCarroceriaDTO> GetAllByTCA_ID(string value );
        public IEnumerable<TipoCarroceriaDTO> GetAllByTCA_DESCRICAO(string value );
        public IEnumerable<TipoCarroceriaDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoCarroceriaDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoCarroceriaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoCarroceriaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration