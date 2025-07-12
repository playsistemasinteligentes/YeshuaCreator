
using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace Dominio
{
    public class UseCaseGroup
    {
        public UseCaseGroup(string name)
        {
            Name = name;
        }
        public List<Agent> Agents = new List<Agent>();

        public List<UseCaseSubGroup> UseCaseSubGroup = new List<UseCaseSubGroup>();

        public Descricao Name { get; set; }

        public UseCaseGroup AddAgents(string agente)
        {
            return AddAgent(agente);
        }
        public UseCaseGroup AddUseCaseSubGrup(string name)
        {
            this.UseCaseSubGroup.Add(new UseCaseSubGroup(name));
            return this;
        }
        public UseCaseGroup AddUseCase(string method, params object[] parametros)
        {
            UseCase _Method = new UseCase(method);
            _Method.UseCaseGroup = this;
            _Method.UseCaseSubGroup = this.UseCaseSubGroup.Last();
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
            this.UseCaseSubGroup.Last().UseCases.Add(_Method);
            return this;
        }

        public UseCaseGroup AddAgent(string name)
        {
            var col = new Agent(name, "", this);
            Agents.Add(col);
            return this;
        }

        public UseCaseGroup AddAgentMetod(string name, string description)
        {
            var method = new UseCase(this, name, description);
            return this.Agents.Last().AddMethod(method);
        }
        public UseCaseGroup AddMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().AddMenu(menu);
        }
        public UseCaseGroup AddSubMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().Menus.Last().AddSubMenu(menu).Hub;
        }
        public UseCaseGroup AddMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().AddOption(id, name).Hub;
        }
        public UseCaseGroup AddSubMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().SubMenus.Last().AddOption(id, name).Hub;
        }

        public UseCaseGroup Authorization(Authorization autorization)
        {
            this.UseCaseSubGroup.Last().UseCases.Last().Authorization = autorization;
            return this;
        }
        public UseCaseGroup AddScope(string scope)
        {
            this.UseCaseSubGroup.Last().UseCases.Last().AddScope(scope);
            return this;
        }

        public UseCaseGroup AddEntity(string entityName)
        {
            this.UseCaseSubGroup.Last().UseCases.Last().Entitys.Add(new Entity(entityName));
            return this;
        }

        public UseCaseGroup Strategy(Type type)
        {
            this.UseCaseSubGroup.Last().UseCases.Last().Estrategys.Add(new Dominio.Strategy(type));
            return this;
        }
        public UseCaseGroup AddAgregateStrategy(Type type)
        {
            this.UseCaseSubGroup.Last().UseCases.Last().Estrategys.Last().StrategyAgregate.Add(type);
            return this;
        }
    }
}