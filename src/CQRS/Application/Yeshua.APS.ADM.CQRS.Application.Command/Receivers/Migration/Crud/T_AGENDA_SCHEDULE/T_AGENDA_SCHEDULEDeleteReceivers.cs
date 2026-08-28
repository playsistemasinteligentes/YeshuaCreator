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
    public class DeleteT_AGENDA_SCHEDULEReceiver : ReciverBase<ICommand, IT_AGENDA_SCHEDULEEntity>
    {
        private readonly IT_AGENDA_SCHEDULEWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteT_AGENDA_SCHEDULEReceiver(
            IT_AGENDA_SCHEDULEWriteRepository repository,
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

        protected override async Task<State<IT_AGENDA_SCHEDULEEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_AGENDA_SCHEDULECrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteT_AGENDA_SCHEDULE", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteT_AGENDA_SCHEDULEReceiver), commandName: "Command.Write.T_AGENDA_SCHEDULECrudCommand");
                 var t_agenda_schedule = new T_AGENDA_SCHEDULEFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.AGE_ID, c.AGE_DATA_ESPECIFICA, c.AGE_HORARIO_INICIO, c.AGE_HORARIO_FIM, c.AGE_SEGUNDA, c.AGE_TERCA, c.AGE_QUARTA, c.AGE_QUINTA, c.AGE_SEXTA, c.AGE_SABADO, c.AGE_DOMINGO, c.AGE_INTERVALO, c.AGE_ORDEM_EXECUCAO, c.AGE_PARAMETROS, c.AGE_EXCECAO, c.AGE_DESCRICAO);
                 var domainResult = T_AGENDA_SCHEDULEDomainBehavior.Apply(t_agenda_schedule, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(t_agenda_schedule);
                     return Success("OK", t_agenda_schedule);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_agenda_schedule);
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