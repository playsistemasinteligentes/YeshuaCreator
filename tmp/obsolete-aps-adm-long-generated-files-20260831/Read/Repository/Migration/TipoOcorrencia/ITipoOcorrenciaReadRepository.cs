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
    public partial interface ITipoOcorrenciaReadRepository
    {
        public DataPagination<TipoOcorrenciaDTO> getTipoOcorrencia(ICommandRead command );
        public IEnumerable<TipoOcorrenciaTenantIDDTO> getTipoOcorrenciaReadFKTenantID(object command );
        public IEnumerable<TipoOcorrenciaUserIdDTO> getTipoOcorrenciaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDescricao(string value );
        public bool ExistsBySpr(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoOcorrenciaDTO FirstById(int value );
        public TipoOcorrenciaDTO FirstByDescricao(string value );
        public TipoOcorrenciaDTO FirstBySpr(int value );
        public TipoOcorrenciaDTO FirstByTenantID(int value );
        public TipoOcorrenciaDTO FirstByDeleted(bool value );
        public TipoOcorrenciaDTO FirstByChanged(DateTime value );
        public TipoOcorrenciaDTO FirstByUserId(int value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllById(int value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllByDescricao(string value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllBySpr(int value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoOcorrenciaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration