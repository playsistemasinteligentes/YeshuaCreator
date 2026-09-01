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
    public partial interface IPlanoacaoReadRepository
    {
        public DataPagination<PlanoacaoDTO> getPlanoacao(ICommandRead command );
        public IEnumerable<PlanoacaoMET_IDDTO> getPlanoacaoReadFKMET_ID(object command );
        public IEnumerable<PlanoacaoUSE_IDDTO> getPlanoacaoReadFKUSE_ID(object command );
        public IEnumerable<PlanoacaoTenantIDDTO> getPlanoacaoReadFKTenantID(object command );
        public IEnumerable<PlanoacaoUserIdDTO> getPlanoacaoReadFKUserId(object command );
        public bool ExistsByPLA_ID(int value );
        public bool ExistsByPLA_DESCRICAO(string value );
        public bool ExistsByMET_ID(int value );
        public bool ExistsByPLA_STATUS(string value );
        public bool ExistsByPLA_DATA(DateTime value );
        public bool ExistsByPLA_METAPERIODO(string value );
        public bool ExistsByPLA_VLRPERIODO(string value );
        public bool ExistsByPLA_METACULADO(string value );
        public bool ExistsByPLA_VLRACUMULADO(string value );
        public bool ExistsByPLA_REFERENCIA(string value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PlanoacaoDTO FirstByPLA_ID(int value );
        public PlanoacaoDTO FirstByPLA_DESCRICAO(string value );
        public PlanoacaoDTO FirstByMET_ID(int value );
        public PlanoacaoDTO FirstByPLA_STATUS(string value );
        public PlanoacaoDTO FirstByPLA_DATA(DateTime value );
        public PlanoacaoDTO FirstByPLA_METAPERIODO(string value );
        public PlanoacaoDTO FirstByPLA_VLRPERIODO(string value );
        public PlanoacaoDTO FirstByPLA_METACULADO(string value );
        public PlanoacaoDTO FirstByPLA_VLRACUMULADO(string value );
        public PlanoacaoDTO FirstByPLA_REFERENCIA(string value );
        public PlanoacaoDTO FirstByUSE_ID(int value );
        public PlanoacaoDTO FirstByTenantID(int value );
        public PlanoacaoDTO FirstByDeleted(bool value );
        public PlanoacaoDTO FirstByChanged(DateTime value );
        public PlanoacaoDTO FirstByUserId(int value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_ID(int value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_DESCRICAO(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByMET_ID(int value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_STATUS(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_DATA(DateTime value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_METAPERIODO(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_VLRPERIODO(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_METACULADO(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_VLRACUMULADO(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByPLA_REFERENCIA(string value );
        public IEnumerable<PlanoacaoDTO> GetAllByUSE_ID(int value );
        public IEnumerable<PlanoacaoDTO> GetAllByTenantID(int value );
        public IEnumerable<PlanoacaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<PlanoacaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PlanoacaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration