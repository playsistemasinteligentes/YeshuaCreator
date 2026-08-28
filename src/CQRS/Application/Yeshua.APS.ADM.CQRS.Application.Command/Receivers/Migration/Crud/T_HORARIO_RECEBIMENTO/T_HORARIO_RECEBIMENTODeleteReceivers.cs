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
    public class DeleteT_HORARIO_RECEBIMENTOReceiver : ReciverBase<ICommand, IT_HORARIO_RECEBIMENTOEntity>
    {
        private readonly IT_HORARIO_RECEBIMENTOWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteT_HORARIO_RECEBIMENTOReceiver(
            IT_HORARIO_RECEBIMENTOWriteRepository repository,
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

        protected override async Task<State<IT_HORARIO_RECEBIMENTOEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_HORARIO_RECEBIMENTOCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteT_HORARIO_RECEBIMENTO", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteT_HORARIO_RECEBIMENTOReceiver), commandName: "Command.Write.T_HORARIO_RECEBIMENTOCrudCommand");
                 var t_horario_recebimento = new T_HORARIO_RECEBIMENTOFactory(_logger, _domainTrackingPolicy).Create(context, c.HRE_DIA_DA_SEMANA, c.HRE_HORA_INICIAL, c.HRE_HORA_FINAL, c.CLI_ID, c.HRE_ID);
                 var domainResult = T_HORARIO_RECEBIMENTODomainBehavior.Apply(t_horario_recebimento, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(t_horario_recebimento);
                     return Success("OK", t_horario_recebimento);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_horario_recebimento);
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