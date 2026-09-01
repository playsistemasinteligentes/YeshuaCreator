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
    public partial interface ISubOcorrenciaReadRepository
    {
        public DataPagination<SubOcorrenciaDTO> getSubOcorrencia(ICommandRead command );
        public IEnumerable<SubOcorrenciaTenantIDDTO> getSubOcorrenciaReadFKTenantID(object command );
        public IEnumerable<SubOcorrenciaUserIdDTO> getSubOcorrenciaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsBySUB_ID(string value );
        public bool ExistsBySUB_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public SubOcorrenciaDTO FirstById(int value );
        public SubOcorrenciaDTO FirstBySUB_ID(string value );
        public SubOcorrenciaDTO FirstBySUB_DESCRICAO(string value );
        public SubOcorrenciaDTO FirstByTenantID(int value );
        public SubOcorrenciaDTO FirstByDeleted(bool value );
        public SubOcorrenciaDTO FirstByChanged(DateTime value );
        public SubOcorrenciaDTO FirstByUserId(int value );
        public IEnumerable<SubOcorrenciaDTO> GetAllById(int value );
        public IEnumerable<SubOcorrenciaDTO> GetAllBySUB_ID(string value );
        public IEnumerable<SubOcorrenciaDTO> GetAllBySUB_DESCRICAO(string value );
        public IEnumerable<SubOcorrenciaDTO> GetAllByTenantID(int value );
        public IEnumerable<SubOcorrenciaDTO> GetAllByDeleted(bool value );
        public IEnumerable<SubOcorrenciaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<SubOcorrenciaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration