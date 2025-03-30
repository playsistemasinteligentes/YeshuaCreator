
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using System.Reflection;
using System.Text;

namespace Dominio
{
    public class Hub
    {
        public Hub(string name)
        {
            Name = name;
        }
        public List<Agent> Agents = new List<Agent>();

        public List<Service> Services = new List<Service>();

        public Descricao Name { get; set; }

        public Hub AddAgents(string agente)
        {
            return AddAgent(agente);
        }
        public Hub AddService(string serviceName)
        {
            this.Services.Add(new Service(serviceName));
            return this;
        }
        public Hub AddMethod(string method, params object[] parametros)
        {
            Method _Method = new Method(method);
            _Method.Hub = this;
            _Method.Service = this.Services.Last();
            foreach (var param in parametros)
            {
                if (_Method.Inputs == null)
                    _Method.Inputs = new object[] { param };
                else
                {
                    var imput = _Method.Inputs;
                    Array.Resize(ref imput, _Method.Inputs.Length + 1);
                    _Method.Inputs[_Method.Inputs.Length - 1] = param;
                }

                if (param == null) continue;
                Type type = param.GetType();
                if (type.IsClass || type.IsValueType)
                {
                    //codeBuilder.AppendLine($"// Classe/Struct/Record: {type.Name}");
                    //codeBuilder.AppendLine($"public class {type.Name} {{");

                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        //codeBuilder.AppendLine($"    public {prop.PropertyType.Name} {prop.Name} {{ get; set; }}");
                    }

                    //codeBuilder.AppendLine("}");
                }

            }
            this.Services.Last().Methods.Add(_Method);
            return this;
        }

        public Hub AddAgent(string name)
        {
            var col = new Agent(name, "", this);
            Agents.Add(col);
            return this;
        }

        public Hub AddAgentMetod(string name, string description)
        {
            var method = new Method(this, name, description);
            return this.Agents.Last().AddMethod(method);
        }
        public Hub AddMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().AddMenu(menu);
        }
        public Hub AddSubMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().Menus.Last().AddSubMenu(menu).Hub;
        }
        public Hub AddMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().AddOption(id, name).Hub;
        }
        public Hub AddSubMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().SubMenus.Last().AddOption(id, name).Hub;
        }
    }
}