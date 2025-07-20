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
    public class DeleteYpserPermitionsReceiver : ReciverBase <IYpserPermitionsEntity>
    {
        private readonly IYpserPermitionsWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYpserPermitionsReceiver(IYpserPermitionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYpserPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YpserPermitionsCrudCommand c) 
             {    
                 var ypserpermitions = new YpserPermitionsFactory(_logger).Create(c.UserId, c.PermitionsId);
                 if (!ypserpermitions.isValidDelete())
                     return ValidationError(ypserpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(ypserpermitions);
                     return Success("OK", ypserpermitions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ypserpermitions);
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