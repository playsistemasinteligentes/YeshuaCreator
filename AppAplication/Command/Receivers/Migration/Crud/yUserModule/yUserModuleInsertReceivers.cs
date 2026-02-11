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
    public class InsertyUserModuleReceiver : ReciverBase<ICommand, IyUserModuleEntity>
    {
        private readonly IyUserModuleWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertyUserModuleReceiver(IyUserModuleWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyUserModuleEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yUserModuleCrudCommand c) 
             {    
                 var yusermodule = new yUserModuleFactory(_logger).Create(c.Id, c.ModuleId, c.UserId, c.ValidUntil);
                 if (!yusermodule.isValidInsert())
                     return ValidationError(yusermodule.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(yusermodule);
                     return Success("OK", yusermodule);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yusermodule);
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