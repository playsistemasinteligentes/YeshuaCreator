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
    public partial interface IOrcamentoReadRepository
    {
        public DataPagination<OrcamentoDTO> getOrcamento(ICommandRead command );
        public IEnumerable<OrcamentoCLI_IDDTO> getOrcamentoReadFKCLI_ID(object command );
        public IEnumerable<OrcamentoTenantIDDTO> getOrcamentoReadFKTenantID(object command );
        public IEnumerable<OrcamentoUserIdDTO> getOrcamentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByORC_ID(int value );
        public bool ExistsByREP_ID(string value );
        public bool ExistsByCON_ID(string value );
        public bool ExistsByORC_TIPO_FRETE(string value );
        public bool ExistsByORC_EMISSAO(DateTime value );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByVER_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public OrcamentoDTO FirstById(int value );
        public OrcamentoDTO FirstByORC_ID(int value );
        public OrcamentoDTO FirstByREP_ID(string value );
        public OrcamentoDTO FirstByCON_ID(string value );
        public OrcamentoDTO FirstByORC_TIPO_FRETE(string value );
        public OrcamentoDTO FirstByORC_EMISSAO(DateTime value );
        public OrcamentoDTO FirstByCLI_ID(string value );
        public OrcamentoDTO FirstByVER_ID(int value );
        public OrcamentoDTO FirstByTenantID(int value );
        public OrcamentoDTO FirstByDeleted(bool value );
        public OrcamentoDTO FirstByChanged(DateTime value );
        public OrcamentoDTO FirstByUserId(int value );
        public IEnumerable<OrcamentoDTO> GetAllById(int value );
        public IEnumerable<OrcamentoDTO> GetAllByORC_ID(int value );
        public IEnumerable<OrcamentoDTO> GetAllByREP_ID(string value );
        public IEnumerable<OrcamentoDTO> GetAllByCON_ID(string value );
        public IEnumerable<OrcamentoDTO> GetAllByORC_TIPO_FRETE(string value );
        public IEnumerable<OrcamentoDTO> GetAllByORC_EMISSAO(DateTime value );
        public IEnumerable<OrcamentoDTO> GetAllByCLI_ID(string value );
        public IEnumerable<OrcamentoDTO> GetAllByVER_ID(int value );
        public IEnumerable<OrcamentoDTO> GetAllByTenantID(int value );
        public IEnumerable<OrcamentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<OrcamentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<OrcamentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration