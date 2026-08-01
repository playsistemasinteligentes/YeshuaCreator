
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;

namespace Dominio.Saga.Migration
{
    public class Saga
    {
        public Saga(string name)
        {
            Name = name;
        }

        public Saga(UseCaseGroup group, string name, string description)
        {
            UseCaseGroup = group;
            Name = name;
            Description = description;
        }

        public UseCaseCommand SagaResolverRegistry { get; set; }
        public UseCaseGroup UseCaseGroup { get; set; }
        public UseCaseSubGroup UseCaseSubGroup { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }

        public List<SagaStepGroup> SagaStepGroup { get; set; } = new List<SagaStepGroup>();


        //public object[] Inputs { get; set; }
        //public object[] Outputs { get; set; }

        public StringBuilder VersaoAtualCodigo { get; set; }
        public StringBuilder VersaoAlterada { get; set; }

        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Strategy> Estrategys = new List<Strategy>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }
}