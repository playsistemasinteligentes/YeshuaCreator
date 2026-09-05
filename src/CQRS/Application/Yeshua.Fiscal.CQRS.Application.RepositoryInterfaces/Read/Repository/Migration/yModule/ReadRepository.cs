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
    public partial interface IyModuleReadRepository
    {
        public DataPagination<yModuleDTO> getyModule(ICommandRead command );
        public bool ExistsById(string value );
        public bool ExistsByDescription(string value );
        public yModuleDTO FirstById(string value );
        public yModuleDTO FirstByDescription(string value );
        public IEnumerable<yModuleDTO> GetAllById(string value );
        public IEnumerable<yModuleDTO> GetAllByDescription(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration