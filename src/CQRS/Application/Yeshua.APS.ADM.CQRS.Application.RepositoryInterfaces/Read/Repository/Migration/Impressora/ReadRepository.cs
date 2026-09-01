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
    public partial interface IImpressoraReadRepository
    {
        public DataPagination<ImpressoraDTO> getImpressora(ICommandRead command );
        public IEnumerable<ImpressoraTenantIDDTO> getImpressoraReadFKTenantID(object command );
        public IEnumerable<ImpressoraUserIdDTO> getImpressoraReadFKUserId(object command );
        public bool ExistsByIMP_ID(int value );
        public bool ExistsByIMP_IP(string value );
        public bool ExistsByIMP_NOME(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ImpressoraDTO FirstByIMP_ID(int value );
        public ImpressoraDTO FirstByIMP_IP(string value );
        public ImpressoraDTO FirstByIMP_NOME(string value );
        public ImpressoraDTO FirstByTenantID(int value );
        public ImpressoraDTO FirstByDeleted(bool value );
        public ImpressoraDTO FirstByChanged(DateTime value );
        public ImpressoraDTO FirstByUserId(int value );
        public IEnumerable<ImpressoraDTO> GetAllByIMP_ID(int value );
        public IEnumerable<ImpressoraDTO> GetAllByIMP_IP(string value );
        public IEnumerable<ImpressoraDTO> GetAllByIMP_NOME(string value );
        public IEnumerable<ImpressoraDTO> GetAllByTenantID(int value );
        public IEnumerable<ImpressoraDTO> GetAllByDeleted(bool value );
        public IEnumerable<ImpressoraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ImpressoraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration