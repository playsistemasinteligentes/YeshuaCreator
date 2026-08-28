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
    public partial interface IClpMedicoesHReadRepository
    {
        public DataPagination<ClpMedicoesHDTO> getClpMedicoesH(ICommandRead command );
        public IEnumerable<ClpMedicoesHTenantIDDTO> getClpMedicoesHReadFKTenantID(object command );
        public IEnumerable<ClpMedicoesHUserIdDTO> getClpMedicoesHReadFKUserId(object command );
        public bool ExistsByID(int value );
        public bool ExistsByMAQUINA_ID(string value );
        public bool ExistsByDATA_INI(DateTime value );
        public bool ExistsByDATA_FIM(DateTime value );
        public bool ExistsByCLP_EMISSAO(DateTime value );
        public bool ExistsByQTD(Decimal value );
        public bool ExistsByGRUPO(Decimal value );
        public bool ExistsBySTATUS(int value );
        public bool ExistsByURN_ID(string value );
        public bool ExistsByURM_ID(string value );
        public bool ExistsByID_LOTE_CLP(int value );
        public bool ExistsByOCO_ID(string value );
        public bool ExistsByFASE(int value );
        public bool ExistsByCLP_ORIGEM(string value );
        public bool ExistsByCLP_LOTE(int value );
        public bool ExistsByCOMPACTA(int value );
        public bool ExistsByBOL_ID(string value );
        public bool ExistsByCOR_SEQUENCIA(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ClpMedicoesHDTO FirstByID(int value );
        public ClpMedicoesHDTO FirstByMAQUINA_ID(string value );
        public ClpMedicoesHDTO FirstByDATA_INI(DateTime value );
        public ClpMedicoesHDTO FirstByDATA_FIM(DateTime value );
        public ClpMedicoesHDTO FirstByCLP_EMISSAO(DateTime value );
        public ClpMedicoesHDTO FirstByQTD(Decimal value );
        public ClpMedicoesHDTO FirstByGRUPO(Decimal value );
        public ClpMedicoesHDTO FirstBySTATUS(int value );
        public ClpMedicoesHDTO FirstByURN_ID(string value );
        public ClpMedicoesHDTO FirstByURM_ID(string value );
        public ClpMedicoesHDTO FirstByID_LOTE_CLP(int value );
        public ClpMedicoesHDTO FirstByOCO_ID(string value );
        public ClpMedicoesHDTO FirstByFASE(int value );
        public ClpMedicoesHDTO FirstByCLP_ORIGEM(string value );
        public ClpMedicoesHDTO FirstByCLP_LOTE(int value );
        public ClpMedicoesHDTO FirstByCOMPACTA(int value );
        public ClpMedicoesHDTO FirstByBOL_ID(string value );
        public ClpMedicoesHDTO FirstByCOR_SEQUENCIA(int value );
        public ClpMedicoesHDTO FirstByTenantID(int value );
        public ClpMedicoesHDTO FirstByDeleted(bool value );
        public ClpMedicoesHDTO FirstByChanged(DateTime value );
        public ClpMedicoesHDTO FirstByUserId(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByID(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByMAQUINA_ID(string value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByDATA_INI(DateTime value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByDATA_FIM(DateTime value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByCLP_EMISSAO(DateTime value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByQTD(Decimal value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByGRUPO(Decimal value );
        public IEnumerable<ClpMedicoesHDTO> GetAllBySTATUS(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByURN_ID(string value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByURM_ID(string value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByID_LOTE_CLP(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByOCO_ID(string value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByFASE(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByCLP_ORIGEM(string value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByCLP_LOTE(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByCOMPACTA(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByBOL_ID(string value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByCOR_SEQUENCIA(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByTenantID(int value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByDeleted(bool value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ClpMedicoesHDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration