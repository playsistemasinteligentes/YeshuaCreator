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
    public class InsertTurnoReceiver : ReciverBase<ICommand, ITurnoEntity>
    {
        private readonly ITurnoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertTurnoReceiver(
            ITurnoWriteRepository repository,
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

        protected override async Task<State<ITurnoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TurnoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertTurno", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertTurnoReceiver), commandName: "Command.Write.TurnoCrudCommand");
                 var turno = new TurnoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Descricao, c.TURN_PRIORIDADE, c.TURN_HORA_INI_DIA1, c.TURN_HORA_FIM_DIA1, c.TURN_HORA_INI_DIA2, c.TURN_HORA_FIM_DIA2, c.TURN_HORA_INI_DIA3, c.TURN_HORA_FIM_DIA3, c.TURN_HORA_INI_DIA4, c.TURN_HORA_FIM_DIA4, c.TURN_HORA_INI_DIA5, c.TURN_HORA_FIM_DIA5, c.TURN_HORA_INI_DIA6, c.TURN_HORA_FIM_DIA6, c.TURN_HORA_INI_DIA7, c.TURN_HORA_FIM_DIA7);
                 var domainResult = TurnoDomainBehavior.Apply(turno, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(turno);
                     return Success("OK", turno);
                 }
                 catch (Exception e)
                 {
                    return Error(e, turno);
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