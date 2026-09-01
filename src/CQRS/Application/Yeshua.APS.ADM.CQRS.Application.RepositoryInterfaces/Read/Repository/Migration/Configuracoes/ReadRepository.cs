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
    public partial interface IConfiguracoesReadRepository
    {
        public DataPagination<ConfiguracoesDTO> getConfiguracoes(ICommandRead command );
        public IEnumerable<ConfiguracoesTenantIDDTO> getConfiguracoesReadFKTenantID(object command );
        public IEnumerable<ConfiguracoesUserIdDTO> getConfiguracoesReadFKUserId(object command );
        public bool ExistsByCON_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ConfiguracoesDTO FirstByCON_ID(int value );
        public ConfiguracoesDTO FirstByTenantID(int value );
        public ConfiguracoesDTO FirstByDeleted(bool value );
        public ConfiguracoesDTO FirstByChanged(DateTime value );
        public ConfiguracoesDTO FirstByUserId(int value );
        public IEnumerable<ConfiguracoesDTO> GetAllByCON_ID(int value );
        public IEnumerable<ConfiguracoesDTO> GetAllByTenantID(int value );
        public IEnumerable<ConfiguracoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<ConfiguracoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ConfiguracoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration