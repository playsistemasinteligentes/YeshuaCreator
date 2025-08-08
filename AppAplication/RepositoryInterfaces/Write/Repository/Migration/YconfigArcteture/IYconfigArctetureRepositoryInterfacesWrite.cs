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
        public void UpdateAuditTrackerActived(IyConfigArctetureEntity entity);
        public void UpdateAuditCRUDActived(IyConfigArctetureEntity entity);
        public void UpdateTenantID(IyConfigArctetureEntity entity);
        public void UpdateDeleted(IyConfigArctetureEntity entity);
        public void UpdateChanged(IyConfigArctetureEntity entity);
        public void UpdateUserId(IyConfigArctetureEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration