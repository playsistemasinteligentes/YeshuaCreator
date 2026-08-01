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
    public partial interface IyConfigNotificationReadRepository
    {
        public DataPagination<yConfigNotificationDTO> getyConfigNotification(ICommandRead command );
        public IEnumerable<yConfigNotificationTenantIDDTO> getyConfigNotificationReadFKTenantID(object command );
        public IEnumerable<yConfigNotificationUserIdDTO> getyConfigNotificationReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByEmailSmtpClient(string value );
        public bool ExistsByEmailPort(int value );
        public bool ExistsByEmailUserName(string value );
        public bool ExistsByEmailPassword(string value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yConfigNotificationDTO FirstById(int value );
        public yConfigNotificationDTO FirstByTenantID(int value );
        public yConfigNotificationDTO FirstByEmailSmtpClient(string value );
        public yConfigNotificationDTO FirstByEmailPort(int value );
        public yConfigNotificationDTO FirstByEmailUserName(string value );
        public yConfigNotificationDTO FirstByEmailPassword(string value );
        public yConfigNotificationDTO FirstByDeleted(bool value );
        public yConfigNotificationDTO FirstByChanged(DateTime value );
        public yConfigNotificationDTO FirstByUserId(int value );
        public IEnumerable<yConfigNotificationDTO> GetAllById(int value );
        public IEnumerable<yConfigNotificationDTO> GetAllByTenantID(int value );
        public IEnumerable<yConfigNotificationDTO> GetAllByEmailSmtpClient(string value );
        public IEnumerable<yConfigNotificationDTO> GetAllByEmailPort(int value );
        public IEnumerable<yConfigNotificationDTO> GetAllByEmailUserName(string value );
        public IEnumerable<yConfigNotificationDTO> GetAllByEmailPassword(string value );
        public IEnumerable<yConfigNotificationDTO> GetAllByDeleted(bool value );
        public IEnumerable<yConfigNotificationDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yConfigNotificationDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration