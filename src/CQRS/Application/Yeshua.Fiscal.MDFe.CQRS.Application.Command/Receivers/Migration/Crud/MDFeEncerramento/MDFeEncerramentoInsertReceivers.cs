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
    public class InsertMDFeEncerramentoReceiver : ReciverBase<ICommand, IMDFeEncerramentoEntity>
    {
        private readonly IMDFeEncerramentoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertMDFeEncerramentoReceiver(
            IMDFeEncerramentoWriteRepository repository,
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

        protected override async Task<State<IMDFeEncerramentoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MDFeEncerramentoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertMDFeEncerramento", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertMDFeEncerramentoReceiver), commandName: "Command.Write.MDFeEncerramentoCrudCommand");
                 var mdfeencerramento = new MDFeEncerramentoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MDFeId, c.ChaveAcesso, c.UfCarregamento, c.UfDescarregamento, c.PlacaVeiculo, c.SolicitadoEm, c.AutorizadoEm, c.Protocolo, c.CodigoRetorno, c.MensagemRetorno);
                 var domainResult = MDFeEncerramentoDomainBehavior.Apply(mdfeencerramento, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(mdfeencerramento);
                     return Success("OK", mdfeencerramento);
                 }
                 catch (Exception e)
                 {
                    return Error(e, mdfeencerramento);
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