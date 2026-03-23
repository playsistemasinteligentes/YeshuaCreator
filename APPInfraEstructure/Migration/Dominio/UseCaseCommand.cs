
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class UseCaseCommand
    {
        public UseCaseCommand(string name)
        {
            Name = name;
        }

        public UseCaseCommand(UseCaseGroup group, string name, string description)
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
        public Authorization Authorization { get; set; } = Authorization.User;
        public bool IsWorker { get; internal set; } = false;
        public bool IsListener { get; internal set; } = false;

        public List<string> Scopes = new List<string>();
        public List<Entity> Entitys = new List<Entity>();
        public List<Strategy> Estrategys = new List<Strategy>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }
}