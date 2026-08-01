
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class UseCaseSubGroup
    {
        public UseCaseSubGroup(string name)
        {
            Name = name;
        }
        public UseCaseGroup UseCaseGroup { get; set; }
        public string Description { get; set; }
        public Descricao Name { get; set; }
        public List<UseCaseCommand> UseCaseCommand = new List<UseCaseCommand>();
        public List<Dominio.Saga.Migration.Saga> Saga = new List<Dominio.Saga.Migration.Saga>();
    }
}