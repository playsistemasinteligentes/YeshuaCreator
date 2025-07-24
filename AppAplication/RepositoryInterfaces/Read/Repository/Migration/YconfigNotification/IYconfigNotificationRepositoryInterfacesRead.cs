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
    public interface IYconfigNotificationReadRepository
    {
        public DataPagination<YconfigNotificationDTO> getYconfigNotification(ICommandRead command);
        public YconfigNotificationDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByEmailAdress(string value);
        public bool ExistsByEmailPassword(string value);
        public YconfigNotificationDTO FirstById(int value);
        public YconfigNotificationDTO FirstByEmailAdress(string value);
        public YconfigNotificationDTO FirstByEmailPassword(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration