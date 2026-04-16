
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class SagaStepEvent
    {
        public SagaStepEvent(string name)
        {
            Name = name;
            NameInBoxPollingWorker = $"{name}InboxHandler"; 
            NameOutBoxPollingWorker = $"{name}InboxHandler";
            NameQueueListenerWorker = $"{name}QueueListenerHandler";
        }

        public SagaStepEvent(SagaStep sagaStep, string name, string description)
        {
            SagaStep = sagaStep;
            Name = name;
            Description = description;
        }

        public SagaStep SagaStep { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public Descricao NameSpace { get; set; }
        public Descricao NameOutBoxPollingWorker { get; set; }
        public Descricao NameInBoxPollingWorker { get; set; }
        public Descricao NameQueueListenerWorker { get; set; }

        public UseCaseCommand OutBoxPollingWorker { get; set; }

        public UseCaseCommand InBoxPollingWorker { get; set; }
        public UseCaseCommand QueueListenerWorker { get; set; }
        public QueueTopology queueTopologyConsumer { get; set; }
        public QueueTopology queueTopologyProducer { get; set; }

        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Strategy> Estrategys = new List<Strategy>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }

}