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
    public partial interface IPlanocontasReadRepository
    {
        public DataPagination<PlanocontasDTO> getPlanocontas(ICommandRead command );
        public IEnumerable<PlanocontasTenantIDDTO> getPlanocontasReadFKTenantID(object command );
        public IEnumerable<PlanocontasUserIdDTO> getPlanocontasReadFKUserId(object command );
        public bool ExistsByPLA_ID(int value );
        public bool ExistsByPLA_CODIGO(string value );
        public bool ExistsByPLA_DESCRICAO(string value );
        public bool ExistsByPLA_TIPO(int value );
        public bool ExistsByPLA_NATUREZA(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PlanocontasDTO FirstByPLA_ID(int value );
        public PlanocontasDTO FirstByPLA_CODIGO(string value );
        public PlanocontasDTO FirstByPLA_DESCRICAO(string value );
        public PlanocontasDTO FirstByPLA_TIPO(int value );
        public PlanocontasDTO FirstByPLA_NATUREZA(string value );
        public PlanocontasDTO FirstByTenantID(int value );
        public PlanocontasDTO FirstByDeleted(bool value );
        public PlanocontasDTO FirstByChanged(DateTime value );
        public PlanocontasDTO FirstByUserId(int value );
        public IEnumerable<PlanocontasDTO> GetAllByPLA_ID(int value );
        public IEnumerable<PlanocontasDTO> GetAllByPLA_CODIGO(string value );
        public IEnumerable<PlanocontasDTO> GetAllByPLA_DESCRICAO(string value );
        public IEnumerable<PlanocontasDTO> GetAllByPLA_TIPO(int value );
        public IEnumerable<PlanocontasDTO> GetAllByPLA_NATUREZA(string value );
        public IEnumerable<PlanocontasDTO> GetAllByTenantID(int value );
        public IEnumerable<PlanocontasDTO> GetAllByDeleted(bool value );
        public IEnumerable<PlanocontasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PlanocontasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration