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
    public partial interface ILoockReadRepository
    {
        public DataPagination<LoockDTO> getLoock(ICommandRead command );
        public IEnumerable<LoockTenantIDDTO> getLoockReadFKTenantID(object command );
        public IEnumerable<LoockUserIdDTO> getLoockReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByLOO_ID(string value );
        public bool ExistsByLOO_DESCRICAO(string value );
        public bool ExistsByLOO_CONTEUDO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public LoockDTO FirstById(int value );
        public LoockDTO FirstByLOO_ID(string value );
        public LoockDTO FirstByLOO_DESCRICAO(string value );
        public LoockDTO FirstByLOO_CONTEUDO(string value );
        public LoockDTO FirstByTenantID(int value );
        public LoockDTO FirstByDeleted(bool value );
        public LoockDTO FirstByChanged(DateTime value );
        public LoockDTO FirstByUserId(int value );
        public IEnumerable<LoockDTO> GetAllById(int value );
        public IEnumerable<LoockDTO> GetAllByLOO_ID(string value );
        public IEnumerable<LoockDTO> GetAllByLOO_DESCRICAO(string value );
        public IEnumerable<LoockDTO> GetAllByLOO_CONTEUDO(string value );
        public IEnumerable<LoockDTO> GetAllByTenantID(int value );
        public IEnumerable<LoockDTO> GetAllByDeleted(bool value );
        public IEnumerable<LoockDTO> GetAllByChanged(DateTime value );
        public IEnumerable<LoockDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration