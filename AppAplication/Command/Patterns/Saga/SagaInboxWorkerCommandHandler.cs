using Command.Patterns;
using Command.Patterns.Command;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Collections.Generic;

public class SagaInboxWorkerCommandHandler: ReciverBase<InputCommand, OutputCommand>
{
    private readonly IyInboxReadRepository _yInboxReadRepository;
    private readonly ISagaResolverRegistry _sagaResolverRegistry;
    private readonly IySagaReadRepository _sagaReadRepository;
    private readonly IySagaWriteRepository _sagaWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SagaInboxWorkerCommandHandler(
        IyInboxReadRepository yInboxReadRepository,
        ISagaResolverRegistry sagaResolverRegistry,
        IySagaReadRepository sagaReadRepository,
        IySagaWriteRepository sagaWriteRepository,
        IUnitOfWork unitOfWork)
    {
        _yInboxReadRepository = yInboxReadRepository;
        _sagaResolverRegistry = sagaResolverRegistry;
        _sagaReadRepository = sagaReadRepository;
        _sagaWriteRepository = sagaWriteRepository;
        _unitOfWork = unitOfWork;
    }

    protected override State<OutputCommand> Action(InputCommand command)
    {
        try
        {
            var messages = _yInboxReadRepository.ClaimRunnableInbox(15, DateTime.UtcNow);

            foreach (var msg in messages)
            {
                try
                {
                    var sagaDto = _sagaReadRepository.GetAllById(msg.sagaid).FirstOrDefault();

                    if (sagaDto == null)
                        continue;

                    var saga = _sagaResolverRegistry.Map(sagaDto);

                    saga.Resume(msg.EventType, msg.Payload);
                    
                    _unitOfWork.BeginTran();
                    _sagaWriteRepository.Save(saga);
                    _yInboxReadRepository.MarkAsProcessed(msg.Id);
                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    // retry automático (não marca como processado)
                }
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