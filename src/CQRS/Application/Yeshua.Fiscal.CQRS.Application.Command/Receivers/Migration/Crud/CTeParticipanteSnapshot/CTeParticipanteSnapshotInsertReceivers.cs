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
    public class InsertCTeParticipanteSnapshotReceiver : ReciverBase<ICommand, ICTeParticipanteSnapshotEntity>
    {
        private readonly ICTeParticipanteSnapshotWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertCTeParticipanteSnapshotReceiver(
            ICTeParticipanteSnapshotWriteRepository repository,
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

        protected override Task<State<ICTeParticipanteSnapshotEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeParticipanteSnapshotCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCTeParticipanteSnapshot", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertCTeParticipanteSnapshotReceiver), commandName: "Command.Write.CTeParticipanteSnapshotCrudCommand");
                 var cteparticipantesnapshot = new CTeParticipanteSnapshotFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CTeSolicitacaoFiscalId, c.Papel, c.Documento, c.Nome, c.InscricaoEstadual, c.UF, c.MunicipioCodigoIbge, c.EnderecoJson);
                 var domainResult = CTeParticipanteSnapshotDomainBehavior.Apply(cteparticipantesnapshot, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(cteparticipantesnapshot);
                     return Task.FromResult(Success("OK", cteparticipantesnapshot));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, cteparticipantesnapshot));
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