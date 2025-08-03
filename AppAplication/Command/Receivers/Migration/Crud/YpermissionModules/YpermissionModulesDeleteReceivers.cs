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
    public class DeleteYpermissionModulesReceiver : ReciverBase <IYpermissionModulesEntity>
    {
        private readonly IYpermissionModulesWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYpermissionModulesReceiver(IYpermissionModulesWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYpermissionModulesEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YpermissionModulesCrudCommand c) 
             {    
                 var ypermissionmodules = new YpermissionModulesFactory(_logger).Create(c.Id, c.Description);
                 if (!ypermissionmodules.isValidDelete())
                     return ValidationError(ypermissionmodules.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(ypermissionmodules);
                     return Success("OK", ypermissionmodules);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ypermissionmodules);
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