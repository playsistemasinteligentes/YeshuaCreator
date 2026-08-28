using System.Threading.Tasks;
using System.Threading;
// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Command.Patterns.Command;
using Dominio.Behaviors;
using Dominio.Interfaces;
using Dominio.Entitys;
using Dominio.Patterns.Domain;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Aplication.Interfaces.Services;
using System;

namespace Command.Receivers.UseCase
{
    public partial class CadastrarRoteiroHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IRoteiroReadRepository _repReadRoteiro;
        private readonly IRoteiroWriteRepository _repWriteRoteiro;
        public CadastrarRoteiroHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IRoteiroReadRepository repReadRoteiro, IRoteiroWriteRepository repWriteRoteiro)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadRoteiro = repReadRoteiro;
            _repWriteRoteiro = repWriteRoteiro;
        }
protected partial async Task<State<CadastrarRoteiroOutputCommand>> CustomActionHookAsync(State<CadastrarRoteiroOutputCommand> state, CadastrarRoteiroInputCommand comand, CancellationToken cancellationToken)
{
            var transactionStarted = false;

            try
            {
                var context = DomainOperationContext.Create(
                    DomainOperation.Registro,
                    DomainEntryPoint.UseCase,
                    nameof(CadastrarRoteiroHandler),
                    _executionContext.TenantID,
                    _executionContext.UserId,
                    traceId: _executionContext.TraceId,
                    receiverName: nameof(CadastrarRoteiroHandler),
                    commandName: nameof(CadastrarRoteiroInputCommand));

                var roteiro = new RoteiroFactory(_logger, _domainTrackingPolicy).Create(
                    context,
                    comand.MAQ_ID,
                    comand.PRO_ID,
                    comand.ROT_SEQ_TRANFORMACAO,
                    comand.GMA_ID,
                    comand.ROT_PECAS_POR_PULSO,
                    null,
                    comand.ROT_ACAO,
                    comand.ROT_PERFORMANCE,
                    null,
                    comand.ROT_TEMPO_SETUP_AJUSTE,
                    null,
                    comand.ROT_STATUS,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null);

                var domainResult = RoteiroDomainBehavior.Apply(roteiro, context);
                if (!domainResult.IsValid)
                {
                    throw new ReceiverException<CadastrarRoteiroOutputCommand>(
                        ValidationError(domainResult.Errors, default));
                }

                _unitOfWork.BeginTran();
                transactionStarted = true;

                _repWriteRoteiro.Insert(roteiro);

                _unitOfWork.Commit();
                transactionStarted = false;

                state = Created(
                    "Roteiro cadastrado com sucesso.",
                    new CadastrarRoteiroOutputCommand
                    {
                        Cadastrado = true,
                        MAQ_ID = roteiro.MAQ_ID,
                        PRO_ID = roteiro.PRO_ID,
                        ROT_SEQ_TRANFORMACAO = roteiro.ROT_SEQ_TRANFORMACAO,
                        Mensagem = "Roteiro cadastrado com sucesso."
                    });
            }
            catch (ReceiverException<CadastrarRoteiroOutputCommand>)
            {
                if (transactionStarted)
                {
                    _unitOfWork.Rollback();
                }

                throw;
            }
            catch (Exception ex)
            {
                if (transactionStarted)
                {
                    _unitOfWork.Rollback();
                }

                throw new ReceiverException<CadastrarRoteiroOutputCommand>(
                    Error(ex, default));
            }
            return state;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
