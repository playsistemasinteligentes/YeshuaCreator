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
    public partial interface IPlanoAmostralTesteReadRepository
    {
        public DataPagination<PlanoAmostralTesteDTO> getPlanoAmostralTeste(ICommandRead command );
        public IEnumerable<PlanoAmostralTesteTenantIDDTO> getPlanoAmostralTesteReadFKTenantID(object command );
        public IEnumerable<PlanoAmostralTesteUserIdDTO> getPlanoAmostralTesteReadFKUserId(object command );
        public bool ExistsByGRP_TIPO(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByPAT_ID(int value );
        public bool ExistsByPAT_QTD_CAIXAS_DE(int value );
        public bool ExistsByPAT_QTD_CAIXAS_ATE(int value );
        public bool ExistsByPAT_N_AMOSTRAGEM(int value );
        public bool ExistsByPAT_PERCENT_ESPECIF(Decimal value );
        public PlanoAmostralTesteDTO FirstByGRP_TIPO(Decimal value );
        public PlanoAmostralTesteDTO FirstByTenantID(int value );
        public PlanoAmostralTesteDTO FirstByDeleted(bool value );
        public PlanoAmostralTesteDTO FirstByChanged(DateTime value );
        public PlanoAmostralTesteDTO FirstByUserId(int value );
        public PlanoAmostralTesteDTO FirstByPAT_ID(int value );
        public PlanoAmostralTesteDTO FirstByPAT_QTD_CAIXAS_DE(int value );
        public PlanoAmostralTesteDTO FirstByPAT_QTD_CAIXAS_ATE(int value );
        public PlanoAmostralTesteDTO FirstByPAT_N_AMOSTRAGEM(int value );
        public PlanoAmostralTesteDTO FirstByPAT_PERCENT_ESPECIF(Decimal value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByGRP_TIPO(Decimal value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByUserId(int value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_ID(int value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_QTD_CAIXAS_DE(int value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_QTD_CAIXAS_ATE(int value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_N_AMOSTRAGEM(int value );
        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_PERCENT_ESPECIF(Decimal value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration