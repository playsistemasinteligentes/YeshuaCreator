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
    public partial interface IGrupoSegmentoReadRepository
    {
        public DataPagination<GrupoSegmentoDTO> getGrupoSegmento(ICommandRead command );
        public IEnumerable<GrupoSegmentoTenantIDDTO> getGrupoSegmentoReadFKTenantID(object command );
        public IEnumerable<GrupoSegmentoUserIdDTO> getGrupoSegmentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByGRS_ID(string value );
        public bool ExistsByGRS_DESCRICAO(string value );
        public bool ExistsByGRS_INTEGRACAO_ERP(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public GrupoSegmentoDTO FirstById(int value );
        public GrupoSegmentoDTO FirstByGRS_ID(string value );
        public GrupoSegmentoDTO FirstByGRS_DESCRICAO(string value );
        public GrupoSegmentoDTO FirstByGRS_INTEGRACAO_ERP(string value );
        public GrupoSegmentoDTO FirstByTenantID(int value );
        public GrupoSegmentoDTO FirstByDeleted(bool value );
        public GrupoSegmentoDTO FirstByChanged(DateTime value );
        public GrupoSegmentoDTO FirstByUserId(int value );
        public IEnumerable<GrupoSegmentoDTO> GetAllById(int value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByGRS_ID(string value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByGRS_DESCRICAO(string value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByGRS_INTEGRACAO_ERP(string value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByTenantID(int value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<GrupoSegmentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration