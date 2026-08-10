using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyConfigArctetureWriteRepository
    {
        void Insert(IyConfigArctetureEntity yconfigarcteture);
        void Update(IyConfigArctetureEntity yconfigarcteture);
        void Delete(IyConfigArctetureEntity yconfigarcteture);
        void UpdateAuditTrackerActived(int id, int value);
        void UpdateAuditCRUDActived(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration