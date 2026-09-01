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
    public partial interface ILoteTesteReadRepository
    {
        public DataPagination<LoteTesteDTO> getLoteTeste(ICommandRead command );
        public IEnumerable<LoteTesteTenantIDDTO> getLoteTesteReadFKTenantID(object command );
        public IEnumerable<LoteTesteUserIdDTO> getLoteTesteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByLT_ID(int value );
        public bool ExistsByTES_ID(int value );
        public bool ExistsByRL_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public LoteTesteDTO FirstById(int value );
        public LoteTesteDTO FirstByLT_ID(int value );
        public LoteTesteDTO FirstByTES_ID(int value );
        public LoteTesteDTO FirstByRL_ID(int value );
        public LoteTesteDTO FirstByTenantID(int value );
        public LoteTesteDTO FirstByDeleted(bool value );
        public LoteTesteDTO FirstByChanged(DateTime value );
        public LoteTesteDTO FirstByUserId(int value );
        public IEnumerable<LoteTesteDTO> GetAllById(int value );
        public IEnumerable<LoteTesteDTO> GetAllByLT_ID(int value );
        public IEnumerable<LoteTesteDTO> GetAllByTES_ID(int value );
        public IEnumerable<LoteTesteDTO> GetAllByRL_ID(int value );
        public IEnumerable<LoteTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<LoteTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<LoteTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<LoteTesteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration