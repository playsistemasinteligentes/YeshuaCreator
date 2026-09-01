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
    public partial interface ILogsDatabaseReadRepository
    {
        public DataPagination<LogsDatabaseDTO> getLogsDatabase(ICommandRead command );
        public IEnumerable<LogsDatabaseUSE_IDDTO> getLogsDatabaseReadFKUSE_ID(object command );
        public IEnumerable<LogsDatabaseTenantIDDTO> getLogsDatabaseReadFKTenantID(object command );
        public IEnumerable<LogsDatabaseUserIdDTO> getLogsDatabaseReadFKUserId(object command );
        public bool ExistsByLOGS_ID(int value );
        public bool ExistsByLOGS_TABLE(string value );
        public bool ExistsByLOGS_KEY(string value );
        public bool ExistsByLOGS_KEY1(string value );
        public bool ExistsByLOGS_KEY2(string value );
        public bool ExistsByLOGS_KEY3(string value );
        public bool ExistsByLOGS_KEY4(string value );
        public bool ExistsByLOGS_COLUMN(string value );
        public bool ExistsByLOGS_BEFORE(string value );
        public bool ExistsByLOGS_AFTER(string value );
        public bool ExistsByLOGS_ACTION(string value );
        public bool ExistsByLOGS_DATE(DateTime value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByLOGS_ORIGEM(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public LogsDatabaseDTO FirstByLOGS_ID(int value );
        public LogsDatabaseDTO FirstByLOGS_TABLE(string value );
        public LogsDatabaseDTO FirstByLOGS_KEY(string value );
        public LogsDatabaseDTO FirstByLOGS_KEY1(string value );
        public LogsDatabaseDTO FirstByLOGS_KEY2(string value );
        public LogsDatabaseDTO FirstByLOGS_KEY3(string value );
        public LogsDatabaseDTO FirstByLOGS_KEY4(string value );
        public LogsDatabaseDTO FirstByLOGS_COLUMN(string value );
        public LogsDatabaseDTO FirstByLOGS_BEFORE(string value );
        public LogsDatabaseDTO FirstByLOGS_AFTER(string value );
        public LogsDatabaseDTO FirstByLOGS_ACTION(string value );
        public LogsDatabaseDTO FirstByLOGS_DATE(DateTime value );
        public LogsDatabaseDTO FirstByUSE_ID(int value );
        public LogsDatabaseDTO FirstByLOGS_ORIGEM(string value );
        public LogsDatabaseDTO FirstByTenantID(int value );
        public LogsDatabaseDTO FirstByDeleted(bool value );
        public LogsDatabaseDTO FirstByChanged(DateTime value );
        public LogsDatabaseDTO FirstByUserId(int value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_ID(int value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_TABLE(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY1(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY2(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY3(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY4(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_COLUMN(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_BEFORE(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_AFTER(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_ACTION(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_DATE(DateTime value );
        public IEnumerable<LogsDatabaseDTO> GetAllByUSE_ID(int value );
        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_ORIGEM(string value );
        public IEnumerable<LogsDatabaseDTO> GetAllByTenantID(int value );
        public IEnumerable<LogsDatabaseDTO> GetAllByDeleted(bool value );
        public IEnumerable<LogsDatabaseDTO> GetAllByChanged(DateTime value );
        public IEnumerable<LogsDatabaseDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration