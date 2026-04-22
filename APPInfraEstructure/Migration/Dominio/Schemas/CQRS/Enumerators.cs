
namespace Migration.Dominio.Schemas.CQRS
{
    public enum CommandType
    {
        Crud = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        Read = 4,
        ReadFK = 5,
        UseCaseGroup = 6,
        UseCase = 7,
        Agent = 8,
        Entity = 9,
        IEntity = 10,
        EntityDecorator = 11,
        Factory = 12,
        DependencyIngection = 13,
        ReadQuery = 14,
        WorkerPollingHandler = 15,
        WorkerListenerHandler = 16,
        UseCaseCommandHandler = 17,
        SagaResolverRegistry=18,
        SagaHandlerResolver = 19,
        SagaStepHandler = 20,
        SagaBase = 21,
        SagaStepBase = 22,


    }


    public enum Authorization
    {
        Free = 0,
        User = 1
    }
    public enum InfraEstrutctureType
    {
        API = 0,
        Worker = 1
    }
    public enum WorkerType
    {
        Pooling = 0,
        Listener = 1
    }

}
