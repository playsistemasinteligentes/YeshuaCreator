using System.Threading;
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
    public class InsertyConfigNotificationReceiver : ReciverBase<ICommand, IyConfigNotificationEntity>
    {
        private readonly IyConfigNotificationWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertyConfigNotificationReceiver(
            IyConfigNotificationWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IyConfigNotificationEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yConfigNotificationCrudCommand c) 
             {    
                 var yconfignotification = new yConfigNotificationFactory(_logger).Create(c.Id, c.EmailSmtpClient, c.EmailPort, c.EmailUserName, c.EmailPassword);
                 if (!yconfignotification.isValidInsert())
                     return ValidationError(yconfignotification.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(yconfignotification);
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