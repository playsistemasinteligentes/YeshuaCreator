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
    public class InsertyTenantModuleReceiver : ReciverBase <IyTenantModuleEntity>
    {
        private readonly IyTenantModuleWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertyTenantModuleReceiver(IyTenantModuleWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyTenantModuleEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yTenantModuleCrudCommand c) 
             {    
                 var ytenantmodule = new yTenantModuleFactory(_logger).Create(c.Id, c.ModuleId, c.ValidUntil);
                 if (!ytenantmodule.isValidInsert())
                     return ValidationError(ytenantmodule.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(ytenantmodule);
                     return Success("OK", ytenantmodule);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenantmodule);
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