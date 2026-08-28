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
    public class InsertFeedbackReceiver : ReciverBase<ICommand, IFeedbackEntity>
    {
        private readonly IFeedbackWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertFeedbackReceiver(
            IFeedbackWriteRepository repository,
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

        protected override async Task<State<IFeedbackEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.FeedbackCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertFeedback", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertFeedbackReceiver), commandName: "Command.Write.FeedbackCrudCommand");
                 var feedback = new FeedbackFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.DataInicial, c.Datafinal, c.MaquinaId, c.OcorrenciaId, c.TurnoId, c.TurmaId, c.UsuarioId, c.OrderId, c.ProdutoId, c.Observacoes, c.Grupo, c.DiaTurma, c.SequenciaTransformacao, c.SequenciaRepeticao, c.QuantidadePulsos, c.QuantidadePecasPorPulso, c.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA, c.BOL_ID, c.COR_SEQUENCIA);
                 var domainResult = FeedbackDomainBehavior.Apply(feedback, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(feedback);
                     return Success("OK", feedback);
                 }
                 catch (Exception e)
                 {
                    return Error(e, feedback);
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