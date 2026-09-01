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
    public partial interface ITipoABNTReadRepository
    {
        public DataPagination<TipoABNTDTO> getTipoABNT(ICommandRead command );
        public IEnumerable<TipoABNTTenantIDDTO> getTipoABNTReadFKTenantID(object command );
        public IEnumerable<TipoABNTUserIdDTO> getTipoABNTReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByABN_ID(string value );
        public bool ExistsByABN_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoABNTDTO FirstById(int value );
        public TipoABNTDTO FirstByABN_ID(string value );
        public TipoABNTDTO FirstByABN_DESCRICAO(string value );
        public TipoABNTDTO FirstByTenantID(int value );
        public TipoABNTDTO FirstByDeleted(bool value );
        public TipoABNTDTO FirstByChanged(DateTime value );
        public TipoABNTDTO FirstByUserId(int value );
        public IEnumerable<TipoABNTDTO> GetAllById(int value );
        public IEnumerable<TipoABNTDTO> GetAllByABN_ID(string value );
        public IEnumerable<TipoABNTDTO> GetAllByABN_DESCRICAO(string value );
        public IEnumerable<TipoABNTDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoABNTDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoABNTDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoABNTDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration