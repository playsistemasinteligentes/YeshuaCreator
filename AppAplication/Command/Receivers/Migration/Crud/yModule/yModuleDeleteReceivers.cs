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
    public class DeleteyModuleReceiver : ReciverBase<ICommand, IyModuleEntity>
    {
        private readonly IyModuleWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteyModuleReceiver(IyModuleWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyModuleEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yModuleCrudCommand c) 
             {    
                 var ymodule = new yModuleFactory(_logger).Create(c.Id, c.Description);
                 if (!ymodule.isValidDelete())
                     return ValidationError(ymodule.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(ymodule);
                     return Success("OK", ymodule);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ymodule);
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