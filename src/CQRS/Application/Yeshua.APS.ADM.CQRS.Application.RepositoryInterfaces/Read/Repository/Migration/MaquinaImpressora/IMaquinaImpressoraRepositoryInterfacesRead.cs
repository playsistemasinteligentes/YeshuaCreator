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
    public partial interface IMaquinaImpressoraReadRepository
    {
        public DataPagination<MaquinaImpressoraDTO> getMaquinaImpressora(ICommandRead command );
        public IEnumerable<MaquinaImpressoraIMP_IDDTO> getMaquinaImpressoraReadFKIMP_ID(object command );
        public IEnumerable<MaquinaImpressoraTenantIDDTO> getMaquinaImpressoraReadFKTenantID(object command );
        public IEnumerable<MaquinaImpressoraUserIdDTO> getMaquinaImpressoraReadFKUserId(object command );
        public bool ExistsByMAQ_IMP_ID(int value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByIMP_ID(int value );
        public bool ExistsByMAI_FACAO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MaquinaImpressoraDTO FirstByMAQ_IMP_ID(int value );
        public MaquinaImpressoraDTO FirstByMAQ_ID(string value );
        public MaquinaImpressoraDTO FirstByIMP_ID(int value );
        public MaquinaImpressoraDTO FirstByMAI_FACAO(int value );
        public MaquinaImpressoraDTO FirstByTenantID(int value );
        public MaquinaImpressoraDTO FirstByDeleted(bool value );
        public MaquinaImpressoraDTO FirstByChanged(DateTime value );
        public MaquinaImpressoraDTO FirstByUserId(int value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByMAQ_IMP_ID(int value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByIMP_ID(int value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByMAI_FACAO(int value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByTenantID(int value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByDeleted(bool value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MaquinaImpressoraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration