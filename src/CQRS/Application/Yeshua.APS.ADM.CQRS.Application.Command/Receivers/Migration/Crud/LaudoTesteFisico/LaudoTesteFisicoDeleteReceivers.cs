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
    public class DeleteLaudoTesteFisicoReceiver : ReciverBase<ICommand, ILaudoTesteFisicoEntity>
    {
        private readonly ILaudoTesteFisicoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteLaudoTesteFisicoReceiver(
            ILaudoTesteFisicoWriteRepository repository,
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

        protected override async Task<State<ILaudoTesteFisicoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.LaudoTesteFisicoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteLaudoTesteFisico", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteLaudoTesteFisicoReceiver), commandName: "Command.Write.LaudoTesteFisicoCrudCommand");
                 var laudotestefisico = new LaudoTesteFisicoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.LTF_ID, c.LTF_EMISSAO, c.LTF_VALOR, c.LTF_OBS, c.LTF_STATUS, c.ORD_ID, c.ROT_PRO_ID, c.FPR_SEQ_REPETICAO, c.USE_ID);
                 var domainResult = LaudoTesteFisicoDomainBehavior.Apply(laudotestefisico, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(laudotestefisico);
                     return Success("OK", laudotestefisico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, laudotestefisico);
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