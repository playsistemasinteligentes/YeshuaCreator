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
    public partial interface ITipoAvaliacaoReadRepository
    {
        public DataPagination<TipoAvaliacaoDTO> getTipoAvaliacao(ICommandRead command );
        public IEnumerable<TipoAvaliacaoTenantIDDTO> getTipoAvaliacaoReadFKTenantID(object command );
        public IEnumerable<TipoAvaliacaoUserIdDTO> getTipoAvaliacaoReadFKUserId(object command );
        public bool ExistsByTA_ID(int value );
        public bool ExistsByTA_DESC(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoAvaliacaoDTO FirstByTA_ID(int value );
        public TipoAvaliacaoDTO FirstByTA_DESC(string value );
        public TipoAvaliacaoDTO FirstByTenantID(int value );
        public TipoAvaliacaoDTO FirstByDeleted(bool value );
        public TipoAvaliacaoDTO FirstByChanged(DateTime value );
        public TipoAvaliacaoDTO FirstByUserId(int value );
        public IEnumerable<TipoAvaliacaoDTO> GetAllByTA_ID(int value );
        public IEnumerable<TipoAvaliacaoDTO> GetAllByTA_DESC(string value );
        public IEnumerable<TipoAvaliacaoDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoAvaliacaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoAvaliacaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoAvaliacaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration