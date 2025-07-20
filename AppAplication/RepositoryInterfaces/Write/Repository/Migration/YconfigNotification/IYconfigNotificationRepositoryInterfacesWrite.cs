using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYconfigNotificationWriteRepository
    {
        void Insert(IYconfigNotificationEntity yconfignotification);
        void Update(IYconfigNotificationEntity yconfignotification);
        void Delete(IYconfigNotificationEntity yconfignotification);
        public void UpdateEmailAdress(IYconfigNotificationEntity entity);
        public void UpdateEmailPassword(IYconfigNotificationEntity entity);
        public void UpdateTenantID(IYconfigNotificationEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration