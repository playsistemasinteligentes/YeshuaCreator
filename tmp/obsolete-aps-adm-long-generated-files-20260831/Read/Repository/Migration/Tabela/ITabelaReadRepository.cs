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
    public partial interface ITabelaReadRepository
    {
        public DataPagination<TabelaDTO> getTabela(ICommandRead command );
        public IEnumerable<TabelaTenantIDDTO> getTabelaReadFKTenantID(object command );
        public IEnumerable<TabelaUserIdDTO> getTabelaReadFKUserId(object command );
        public bool ExistsByID_TABELA(int value );
        public bool ExistsByCODIGO(string value );
        public bool ExistsByNOME(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TabelaDTO FirstByID_TABELA(int value );
        public TabelaDTO FirstByCODIGO(string value );
        public TabelaDTO FirstByNOME(string value );
        public TabelaDTO FirstByTenantID(int value );
        public TabelaDTO FirstByDeleted(bool value );
        public TabelaDTO FirstByChanged(DateTime value );
        public TabelaDTO FirstByUserId(int value );
        public IEnumerable<TabelaDTO> GetAllByID_TABELA(int value );
        public IEnumerable<TabelaDTO> GetAllByCODIGO(string value );
        public IEnumerable<TabelaDTO> GetAllByNOME(string value );
        public IEnumerable<TabelaDTO> GetAllByTenantID(int value );
        public IEnumerable<TabelaDTO> GetAllByDeleted(bool value );
        public IEnumerable<TabelaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TabelaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration