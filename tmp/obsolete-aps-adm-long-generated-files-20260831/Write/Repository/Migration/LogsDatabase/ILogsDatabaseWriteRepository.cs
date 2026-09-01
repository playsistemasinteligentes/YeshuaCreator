// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface ILogsDatabaseWriteRepository
    {
        void Insert(ILogsDatabaseEntity logsdatabase);
        void Update(ILogsDatabaseEntity logsdatabase);
        void Delete(ILogsDatabaseEntity logsdatabase);
        void UpdateLOGS_TABLE(int logs_id, string value);
        void UpdateLOGS_KEY(int logs_id, string value);
        void UpdateLOGS_KEY1(int logs_id, string value);
        void UpdateLOGS_KEY2(int logs_id, string value);
        void UpdateLOGS_KEY3(int logs_id, string value);
        void UpdateLOGS_KEY4(int logs_id, string value);
        void UpdateLOGS_COLUMN(int logs_id, string value);
        void UpdateLOGS_BEFORE(int logs_id, string value);
        void UpdateLOGS_AFTER(int logs_id, string value);
        void UpdateLOGS_ACTION(int logs_id, string value);
        void UpdateLOGS_DATE(int logs_id, DateTime value);
        void UpdateUSE_ID(int logs_id, int value);
        void UpdateLOGS_ORIGEM(int logs_id, string value);
        void UpdateTenantID(int logs_id, int value);
        void UpdateDeleted(int logs_id, bool value);
        void UpdateChanged(int logs_id, DateTime value);
        void UpdateUserId(int logs_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration