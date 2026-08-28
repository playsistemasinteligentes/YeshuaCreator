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
    public class InsertCalendarioDisponibilidadeVeiculosReceiver : ReciverBase<ICommand, ICalendarioDisponibilidadeVeiculosEntity>
    {
        private readonly ICalendarioDisponibilidadeVeiculosWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertCalendarioDisponibilidadeVeiculosReceiver(
            ICalendarioDisponibilidadeVeiculosWriteRepository repository,
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

        protected override async Task<State<ICalendarioDisponibilidadeVeiculosEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CalendarioDisponibilidadeVeiculosCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCalendarioDisponibilidadeVeiculos", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertCalendarioDisponibilidadeVeiculosReceiver), commandName: "Command.Write.CalendarioDisponibilidadeVeiculosCrudCommand");
                 var calendariodisponibilidadeveiculos = new CalendarioDisponibilidadeVeiculosFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CDV_ID, c.CDV_DATA_DE, c.CDV_DATA_ATE, c.CDV_SEGUNDA, c.CDV_TERCA, c.CDV_QUARTA, c.CDV_QUINTA, c.CDV_SEXTA, c.CDV_SABADO, c.CDV_DOMINGO);
                 var domainResult = CalendarioDisponibilidadeVeiculosDomainBehavior.Apply(calendariodisponibilidadeveiculos, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(calendariodisponibilidadeveiculos);
                     return Success("OK", calendariodisponibilidadeveiculos);
                 }
                 catch (Exception e)
                 {
                    return Error(e, calendariodisponibilidadeveiculos);
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