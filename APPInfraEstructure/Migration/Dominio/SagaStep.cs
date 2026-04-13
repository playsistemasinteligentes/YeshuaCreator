
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class SagaStep
    {
        public SagaStep(string name)
        {
            Name = name;
        }

        public SagaStep(Saga saga, string name, string description)
        {
            Saga = saga;
            Name = name;
            Description = description;
        }

        public Saga Saga { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public List<SagaStepEvent> InternalEvent { get; set; } = new List<SagaStepEvent>();
        public List<SagaStepEvent> ExternalEvent { get; set; } = new List<SagaStepEvent>();
        public SagaStepEvent LastEvent { get; set; }

        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Strategy> Estrategys = new List<Strategy>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }
}