
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class UseCase
    {
        public UseCase(string name)
        {
            Name = name;
        }

        public UseCase(UseCaseGroup group, string name, string description)
        {
            UseCaseGroup = group;
            Name = name;
            Description = description;
        }

        public UseCaseGroup UseCaseGroup { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public object[] Inputs { get; set; }
        public object[] Outputs { get; set; }
        public StringBuilder VersaoAtualCodigo { get; set; }
        public StringBuilder VersaoAlterada { get; set; }
        public UseCaseSubGroup UseCaseSubGroup { get; set; }
        public Authorization Authorization { get; set; }
        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Type> Estrategys = new List<Type>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }
}