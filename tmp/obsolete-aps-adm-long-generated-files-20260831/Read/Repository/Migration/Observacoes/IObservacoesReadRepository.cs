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
    public partial interface IObservacoesReadRepository
    {
        public DataPagination<ObservacoesDTO> getObservacoes(ICommandRead command );
        public IEnumerable<ObservacoesCLI_IDDTO> getObservacoesReadFKCLI_ID(object command );
        public IEnumerable<ObservacoesTenantIDDTO> getObservacoesReadFKTenantID(object command );
        public IEnumerable<ObservacoesUserIdDTO> getObservacoesReadFKUserId(object command );
        public bool ExistsByOBS_ID(int value );
        public bool ExistsByOBS_TIPO(string value );
        public bool ExistsByOBS_DESCRICAO(string value );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByROT_SEQ_TRANFORMACAO(int value );
        public bool ExistsByOBS_INTEGRACAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ObservacoesDTO FirstByOBS_ID(int value );
        public ObservacoesDTO FirstByOBS_TIPO(string value );
        public ObservacoesDTO FirstByOBS_DESCRICAO(string value );
        public ObservacoesDTO FirstByCLI_ID(string value );
        public ObservacoesDTO FirstByMAQ_ID(string value );
        public ObservacoesDTO FirstByPRO_ID(string value );
        public ObservacoesDTO FirstByROT_SEQ_TRANFORMACAO(int value );
        public ObservacoesDTO FirstByOBS_INTEGRACAO(string value );
        public ObservacoesDTO FirstByTenantID(int value );
        public ObservacoesDTO FirstByDeleted(bool value );
        public ObservacoesDTO FirstByChanged(DateTime value );
        public ObservacoesDTO FirstByUserId(int value );
        public IEnumerable<ObservacoesDTO> GetAllByOBS_ID(int value );
        public IEnumerable<ObservacoesDTO> GetAllByOBS_TIPO(string value );
        public IEnumerable<ObservacoesDTO> GetAllByOBS_DESCRICAO(string value );
        public IEnumerable<ObservacoesDTO> GetAllByCLI_ID(string value );
        public IEnumerable<ObservacoesDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<ObservacoesDTO> GetAllByPRO_ID(string value );
        public IEnumerable<ObservacoesDTO> GetAllByROT_SEQ_TRANFORMACAO(int value );
        public IEnumerable<ObservacoesDTO> GetAllByOBS_INTEGRACAO(string value );
        public IEnumerable<ObservacoesDTO> GetAllByTenantID(int value );
        public IEnumerable<ObservacoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<ObservacoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ObservacoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration