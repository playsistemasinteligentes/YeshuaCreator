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
    public partial interface IUnidade_UnidadeReadRepository
    {
        public DataPagination<Unidade_UnidadeDTO> getUnidade_Unidade(ICommandRead command );
        public IEnumerable<Unidade_UnidadeTenantIDDTO> getUnidade_UnidadeReadFKTenantID(object command );
        public IEnumerable<Unidade_UnidadeUserIdDTO> getUnidade_UnidadeReadFKUserId(object command );
        public bool ExistsByUNI_ID(int value );
        public bool ExistsByUNI_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public Unidade_UnidadeDTO FirstByUNI_ID(int value );
        public Unidade_UnidadeDTO FirstByUNI_DESCRICAO(string value );
        public Unidade_UnidadeDTO FirstByTenantID(int value );
        public Unidade_UnidadeDTO FirstByDeleted(bool value );
        public Unidade_UnidadeDTO FirstByChanged(DateTime value );
        public Unidade_UnidadeDTO FirstByUserId(int value );
        public IEnumerable<Unidade_UnidadeDTO> GetAllByUNI_ID(int value );
        public IEnumerable<Unidade_UnidadeDTO> GetAllByUNI_DESCRICAO(string value );
        public IEnumerable<Unidade_UnidadeDTO> GetAllByTenantID(int value );
        public IEnumerable<Unidade_UnidadeDTO> GetAllByDeleted(bool value );
        public IEnumerable<Unidade_UnidadeDTO> GetAllByChanged(DateTime value );
        public IEnumerable<Unidade_UnidadeDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration