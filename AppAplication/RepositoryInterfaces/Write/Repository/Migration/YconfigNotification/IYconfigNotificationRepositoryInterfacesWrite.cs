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
        public void UpdateTenantID(IYconfigNotificationEntity entity);
        public void UpdateEmailSmtpClient(IYconfigNotificationEntity entity);
        public void UpdateEmailPort(IYconfigNotificationEntity entity);
        public void UpdateEmailUserName(IYconfigNotificationEntity entity);
        public void UpdateEmailPassword(IYconfigNotificationEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration