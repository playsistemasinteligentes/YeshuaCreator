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
    public partial interface IOcorrenciaReadRepository
    {
        public DataPagination<OcorrenciaDTO> getOcorrencia(ICommandRead command );
        public IEnumerable<OcorrenciaTIP_IDDTO> getOcorrenciaReadFKTIP_ID(object command );
        public IEnumerable<OcorrenciaTenantIDDTO> getOcorrenciaReadFKTenantID(object command );
        public IEnumerable<OcorrenciaUserIdDTO> getOcorrenciaReadFKUserId(object command );
        public bool ExistsByOCO_ID(string value );
        public bool ExistsByOCO_DESCRICAO(string value );
        public bool ExistsByTIP_ID(int value );
        public bool ExistsByGMA_ID(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsBySPR(int value );
        public bool ExistsByOCO_SUB_TIPO(string value );
        public bool ExistsBySUB_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public OcorrenciaDTO FirstByOCO_ID(string value );
        public OcorrenciaDTO FirstByOCO_DESCRICAO(string value );
        public OcorrenciaDTO FirstByTIP_ID(int value );
        public OcorrenciaDTO FirstByGMA_ID(string value );
        public OcorrenciaDTO FirstByMAQ_ID(string value );
        public OcorrenciaDTO FirstBySPR(int value );
        public OcorrenciaDTO FirstByOCO_SUB_TIPO(string value );
        public OcorrenciaDTO FirstBySUB_ID(string value );
        public OcorrenciaDTO FirstByTenantID(int value );
        public OcorrenciaDTO FirstByDeleted(bool value );
        public OcorrenciaDTO FirstByChanged(DateTime value );
        public OcorrenciaDTO FirstByUserId(int value );
        public IEnumerable<OcorrenciaDTO> GetAllByOCO_ID(string value );
        public IEnumerable<OcorrenciaDTO> GetAllByOCO_DESCRICAO(string value );
        public IEnumerable<OcorrenciaDTO> GetAllByTIP_ID(int value );
        public IEnumerable<OcorrenciaDTO> GetAllByGMA_ID(string value );
        public IEnumerable<OcorrenciaDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<OcorrenciaDTO> GetAllBySPR(int value );
        public IEnumerable<OcorrenciaDTO> GetAllByOCO_SUB_TIPO(string value );
        public IEnumerable<OcorrenciaDTO> GetAllBySUB_ID(string value );
        public IEnumerable<OcorrenciaDTO> GetAllByTenantID(int value );
        public IEnumerable<OcorrenciaDTO> GetAllByDeleted(bool value );
        public IEnumerable<OcorrenciaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<OcorrenciaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration