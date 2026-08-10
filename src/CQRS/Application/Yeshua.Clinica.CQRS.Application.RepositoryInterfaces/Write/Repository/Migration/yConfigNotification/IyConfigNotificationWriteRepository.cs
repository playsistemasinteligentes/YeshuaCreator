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
        void UpdateTenantID(int id, int value);
        void UpdateEmailSmtpClient(int id, string value);
        void UpdateEmailPort(int id, int value);
        void UpdateEmailUserName(int id, string value);
        void UpdateEmailPassword(int id, string value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration