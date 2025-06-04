
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class Method
    {
        public Method(string name)
        {
            Name = name;
        }

        public Method(Hub hub, string name, string description)
        {
            Hub = hub;
            Name = name;
            Description = description;
        }

        public Hub Hub { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public object[] Inputs { get; set; }
        public object[] Outputs { get; set; }
        public StringBuilder VersaoAtualCodigo { get; set; }
        public StringBuilder VersaoAlterada { get; set; }
        public Service Service { get; set; }
        public Authorization Authorization { get; set; }
        public List<string> Scopes = new List<string>();

        public void AddScope(string scope)
        {
            Scopes.Add(scope);
        }
    }
}