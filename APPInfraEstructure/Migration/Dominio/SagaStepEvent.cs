
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
        public bool IsOutBoxPollingWorker { get; set; }
        public bool IsInBoxPollingWorker { get; set; }
        public QueueTopology queueTopology { get; set; }
        public bool IsQueueListenerWorker { get; set; }

        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Strategy> Estrategys = new List<Strategy>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }

}