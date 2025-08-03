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
    public class DeleteYpermissionActionsReceiver : ReciverBase <IYpermissionActionsEntity>
    {
        private readonly IYpermissionActionsWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYpermissionActionsReceiver(IYpermissionActionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYpermissionActionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YpermissionActionsCrudCommand c) 
             {    
                 var ypermissionactions = new YpermissionActionsFactory(_logger).Create(c.Id, c.Description);
                 if (!ypermissionactions.isValidDelete())
                     return ValidationError(ypermissionactions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(ypermissionactions);
                     return Success("OK", ypermissionactions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ypermissionactions);
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