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
    public partial interface ILogsReadRepository
    {
        public DataPagination<LogsDTO> getLogs(ICommandRead command );
        public IEnumerable<LogsTenantIDDTO> getLogsReadFKTenantID(object command );
        public IEnumerable<LogsUserIdDTO> getLogsReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByLOG_CHAVE(string value );
        public bool ExistsByLOG_CONTEXTO(string value );
        public bool ExistsByLOG_CONTEUDO(string value );
        public bool ExistsByLOG_ID(int value );
        public bool ExistsByLOG_EMISSAO(DateTime value );
        public bool ExistsByOperationalEntityId(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public LogsDTO FirstById(int value );
        public LogsDTO FirstByLOG_CHAVE(string value );
        public LogsDTO FirstByLOG_CONTEXTO(string value );
        public LogsDTO FirstByLOG_CONTEUDO(string value );
        public LogsDTO FirstByLOG_ID(int value );
        public LogsDTO FirstByLOG_EMISSAO(DateTime value );
        public LogsDTO FirstByOperationalEntityId(string value );
        public LogsDTO FirstByTenantID(int value );
        public LogsDTO FirstByDeleted(bool value );
        public LogsDTO FirstByChanged(DateTime value );
        public LogsDTO FirstByUserId(int value );
        public IEnumerable<LogsDTO> GetAllById(int value );
        public IEnumerable<LogsDTO> GetAllByLOG_CHAVE(string value );
        public IEnumerable<LogsDTO> GetAllByLOG_CONTEXTO(string value );
        public IEnumerable<LogsDTO> GetAllByLOG_CONTEUDO(string value );
        public IEnumerable<LogsDTO> GetAllByLOG_ID(int value );
        public IEnumerable<LogsDTO> GetAllByLOG_EMISSAO(DateTime value );
        public IEnumerable<LogsDTO> GetAllByOperationalEntityId(string value );
        public IEnumerable<LogsDTO> GetAllByTenantID(int value );
        public IEnumerable<LogsDTO> GetAllByDeleted(bool value );
        public IEnumerable<LogsDTO> GetAllByChanged(DateTime value );
        public IEnumerable<LogsDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration