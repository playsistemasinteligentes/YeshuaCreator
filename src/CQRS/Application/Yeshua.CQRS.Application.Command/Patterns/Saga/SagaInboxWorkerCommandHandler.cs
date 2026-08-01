using Command.Patterns;
using Command.Patterns.Command;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Collections.Generic;
namespace Command.Patterns
{

    public class SagaInboxWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        private readonly IyInboxReadRepository _yInboxReadRepository;
        private readonly IySagaStepReadRepository _ySagaStepReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public SagaInboxWorkerCommandHandler(
            IyInboxReadRepository yInboxReadRepository,
            IySagaStepReadRepository ySagaStepReadRepository,
            IUnitOfWork unitOfWork,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _yInboxReadRepository = yInboxReadRepository;
            _ySagaStepReadRepository = ySagaStepReadRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<OutputCommand> Action(InputCommand command)
        {
            try
            {
                try
                {
                    _ySagaStepReadRepository.SetPendingApply();
                }
                catch
                {
                    throw;
                }

                return Success("OK", null);
            }
            catch (ReceiverException<OutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
    } 
} 