
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class Service
    {
        public Service(string name)
        {
            Name = name;
        }
        public Hub Hub { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public List<Method> Methods = new List<Method>();
    }
}