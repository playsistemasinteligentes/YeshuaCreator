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
    public class InsertTurmaReceiver : ReciverBase<ICommand, ITurmaEntity>
    {
        private readonly ITurmaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertTurmaReceiver(
            ITurmaWriteRepository repository,
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

        protected override async Task<State<ITurmaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TurmaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertTurma", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertTurmaReceiver), commandName: "Command.Write.TurmaCrudCommand");
                 var turma = new TurmaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Descricao, c.TURM_HORA_INI_DIA1, c.TURM_HORA_FIM_DIA1, c.TURM_HORA_INI_DIA2, c.TURM_HORA_FIM_DIA2, c.TURM_HORA_INI_DIA3, c.TURM_HORA_FIM_DIA3, c.TURM_HORA_INI_DIA4, c.TURM_HORA_FIM_DIA4, c.TURM_HORA_INI_DIA5, c.TURM_HORA_FIM_DIA5, c.TURM_HORA_INI_DIA6, c.TURM_HORA_FIM_DIA6, c.TURM_HORA_INI_DIA7, c.TURM_HORA_FIM_DIA7);
                 var domainResult = TurmaDomainBehavior.Apply(turma, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(turma);
                     return Success("OK", turma);
                 }
                 catch (Exception e)
                 {
                    return Error(e, turma);
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