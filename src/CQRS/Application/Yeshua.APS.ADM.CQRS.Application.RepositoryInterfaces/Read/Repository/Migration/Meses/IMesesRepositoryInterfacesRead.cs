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
    public partial interface IMesesReadRepository
    {
        public DataPagination<MesesDTO> getMeses(ICommandRead command );
        public IEnumerable<MesesTenantIDDTO> getMesesReadFKTenantID(object command );
        public IEnumerable<MesesUserIdDTO> getMesesReadFKUserId(object command );
        public bool ExistsByMES(string value );
        public bool ExistsByfator(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MesesDTO FirstByMES(string value );
        public MesesDTO FirstByfator(int value );
        public MesesDTO FirstByTenantID(int value );
        public MesesDTO FirstByDeleted(bool value );
        public MesesDTO FirstByChanged(DateTime value );
        public MesesDTO FirstByUserId(int value );
        public IEnumerable<MesesDTO> GetAllByMES(string value );
        public IEnumerable<MesesDTO> GetAllByfator(int value );
        public IEnumerable<MesesDTO> GetAllByTenantID(int value );
        public IEnumerable<MesesDTO> GetAllByDeleted(bool value );
        public IEnumerable<MesesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MesesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration