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
    public class UpdateyPerfilGrantReceiver : ReciverBase<ICommand, IyPerfilGrantEntity>
    {
        private readonly IyPerfilGrantWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateyPerfilGrantReceiver(
            IyPerfilGrantWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IyPerfilGrantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yPerfilGrantCrudCommand c) 
             {    
                 var yperfilgrant = new yPerfilGrantFactory(_logger).Create(c.Id, c.PerfilId, c.GrantId, c.CanGrant, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete, c.ValidUntil);
                 if (!yperfilgrant.isValidUpdate())
                     return ValidationError(yperfilgrant.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(yperfilgrant);
                     return Success("OK", yperfilgrant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfilgrant);
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