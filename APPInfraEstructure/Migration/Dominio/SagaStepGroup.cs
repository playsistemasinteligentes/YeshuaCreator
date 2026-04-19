
using Dominio.Saga.Migration;
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;


namespace Dominio
{
    public class SagaStepGroup
    {
        public SagaStepGroup(string name)
        {
            Name = name;
        }

        public SagaStepGroup(Dominio.Saga.Migration.Saga saga, string name, string description)
        {
            Saga = saga;
            Name = name;
            Description = description;
        }

        public Dominio.Saga.Migration.Saga Saga { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public List<SagaStep> Steps { get; set; } = new List<SagaStep>();
        public SagaStep LastStep { get; set; }

        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Strategy> Estrategys = new List<Strategy>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }
}