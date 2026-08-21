// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

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
    public class DeleteyUserModuleReceiver : ReciverBase<ICommand, IyUserModuleEntity>
    {
        private readonly IyUserModuleWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteyUserModuleReceiver(
            IyUserModuleWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IyUserModuleEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yUserModuleCrudCommand c) 
             {    
                 var yusermodule = new yUserModuleFactory(_logger).Create(c.Id, c.ModuleId, c.UserId, c.ValidUntil);
                 if (!yusermodule.isValidDelete())
                     return ValidationError(yusermodule.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(yusermodule);
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