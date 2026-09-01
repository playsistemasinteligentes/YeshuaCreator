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
    public partial interface IVariavelReadRepository
    {
        public DataPagination<VariavelDTO> getVariavel(ICommandRead command );
        public IEnumerable<VariavelTenantIDDTO> getVariavelReadFKTenantID(object command );
        public IEnumerable<VariavelUserIdDTO> getVariavelReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByVAR_ID(int value );
        public bool ExistsByVAR_DESCRICAO(string value );
        public bool ExistsByCON_ID(int value );
        public bool ExistsByVAR_MODO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VariavelDTO FirstById(int value );
        public VariavelDTO FirstByVAR_ID(int value );
        public VariavelDTO FirstByVAR_DESCRICAO(string value );
        public VariavelDTO FirstByCON_ID(int value );
        public VariavelDTO FirstByVAR_MODO(int value );
        public VariavelDTO FirstByTenantID(int value );
        public VariavelDTO FirstByDeleted(bool value );
        public VariavelDTO FirstByChanged(DateTime value );
        public VariavelDTO FirstByUserId(int value );
        public IEnumerable<VariavelDTO> GetAllById(int value );
        public IEnumerable<VariavelDTO> GetAllByVAR_ID(int value );
        public IEnumerable<VariavelDTO> GetAllByVAR_DESCRICAO(string value );
        public IEnumerable<VariavelDTO> GetAllByCON_ID(int value );
        public IEnumerable<VariavelDTO> GetAllByVAR_MODO(int value );
        public IEnumerable<VariavelDTO> GetAllByTenantID(int value );
        public IEnumerable<VariavelDTO> GetAllByDeleted(bool value );
        public IEnumerable<VariavelDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VariavelDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration