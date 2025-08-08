using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyConfigNotificationWriteRepository
    {
        void Insert(IyConfigNotificationEntity yconfignotification);
        void Update(IyConfigNotificationEntity yconfignotification);
        void Delete(IyConfigNotificationEntity yconfignotification);
        public void UpdateTenantID(IyConfigNotificationEntity entity);
        public void UpdateEmailSmtpClient(IyConfigNotificationEntity entity);
        public void UpdateEmailPort(IyConfigNotificationEntity entity);
        public void UpdateEmailUserName(IyConfigNotificationEntity entity);
        public void UpdateEmailPassword(IyConfigNotificationEntity entity);
        public void UpdateDeleted(IyConfigNotificationEntity entity);
        public void UpdateChanged(IyConfigNotificationEntity entity);
        public void UpdateUserId(IyConfigNotificationEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration