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
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Domain;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertProfissionalReceiver : ReciverBase<ICommand, IProfissionalEntity>
    {
        private readonly IProfissionalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertProfissionalReceiver(
            IProfissionalWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Dominio.Interfaces.IDomainTrackingPolicy domainTrackingPolicy,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _domainTrackingPolicy = domainTrackingPolicy;
            _executionContext = context;
        }

        protected override Task<State<IProfissionalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ProfissionalCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertProfissional", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertProfissionalReceiver), commandName: "Command.Write.ProfissionalCrudCommand");
                 var profissional = new ProfissionalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", profissional.OperationalEntityId);
                 var domainResult = ProfissionalDomainBehavior.Apply(profissional, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(profissional);
                     return Task.FromResult(Success("OK", profissional));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, profissional));
                 }
            }
            else 
            {
                 return Task.FromResult(Error("ErroConversao"));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration