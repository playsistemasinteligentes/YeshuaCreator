using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYconfigArctetureWriteRepository
    {
        void Insert(IYconfigArctetureEntity yconfigarcteture);
        void Update(IYconfigArctetureEntity yconfigarcteture);
        void Delete(IYconfigArctetureEntity yconfigarcteture);
        public void UpdateAuditTrackerActived(IYconfigArctetureEntity entity);
        public void UpdateAuditCRUDActived(IYconfigArctetureEntity entity);
        public void UpdateTenantID(IYconfigArctetureEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration