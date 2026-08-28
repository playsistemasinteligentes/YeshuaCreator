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
    public class InsertItenCalendarioDisponibilidadeVeiculosReceiver : ReciverBase<ICommand, IItenCalendarioDisponibilidadeVeiculosEntity>
    {
        private readonly IItenCalendarioDisponibilidadeVeiculosWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertItenCalendarioDisponibilidadeVeiculosReceiver(
            IItenCalendarioDisponibilidadeVeiculosWriteRepository repository,
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

        protected override async Task<State<IItenCalendarioDisponibilidadeVeiculosEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ItenCalendarioDisponibilidadeVeiculosCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertItenCalendarioDisponibilidadeVeiculos", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertItenCalendarioDisponibilidadeVeiculosReceiver), commandName: "Command.Write.ItenCalendarioDisponibilidadeVeiculosCrudCommand");
                 var itencalendariodisponibilidadeveiculos = new ItenCalendarioDisponibilidadeVeiculosFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CDV_ID, c.TIP_ID, c.IDV_QTD);
                 var domainResult = ItenCalendarioDisponibilidadeVeiculosDomainBehavior.Apply(itencalendariodisponibilidadeveiculos, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(itencalendariodisponibilidadeveiculos);
                     return Success("OK", itencalendariodisponibilidadeveiculos);
                 }
                 catch (Exception e)
                 {
                    return Error(e, itencalendariodisponibilidadeveiculos);
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