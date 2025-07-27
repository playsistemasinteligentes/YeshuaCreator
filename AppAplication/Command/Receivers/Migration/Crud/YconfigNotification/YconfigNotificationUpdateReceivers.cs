using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateYconfigNotificationReceiver : ReciverBase <IYconfigNotificationEntity>
    {
        private readonly IYconfigNotificationWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateYconfigNotificationReceiver(IYconfigNotificationWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYconfigNotificationEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YconfigNotificationCrudCommand c) 
             {    
                 var yconfignotification = new YconfigNotificationFactory(_logger).Create(c.Id, c.TenantID, c.EmailSmtpClient, c.EmailPort, c.EmailUserName, c.EmailPassword);
                 if (!yconfignotification.isValidUpdate())
                     return ValidationError(yconfignotification.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(yconfignotification);
                     return Success("OK", yconfignotification);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yconfignotification);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration