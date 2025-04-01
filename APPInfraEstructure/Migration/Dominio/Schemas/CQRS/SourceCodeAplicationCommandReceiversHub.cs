
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using static Dapper.SqlMapper;
using System.Text;
using System.Linq;
using Migration.Dominio.Schemas.CQRS;
using System.Xml.Linq;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversHub : SourceCodeBase
    {
        private Hub _hub;
        private CommandType _commandType;
        private Service _service;
        private Method _method;
        private string _nameSpace;
        private string _classe;

        public SourceCodeAplicationCommandReceiversHub(Hub hub)
            : base()
        {
            _hub = hub;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversHub;
            _commandType = CommandType.Hub;
        }
        public SourceCodeAplicationCommandReceiversHub(Method method)
            : base()
        {
            _hub = method.Hub;
            _service = method.Service;
            _commandType = CommandType.ServiceMethod;
            _method = method;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversHubServiceMethod;
            _classe = $"{_service.Name.SourceType()}{_method.Name.SourceType()}{_commandType}Receiver";
        }
        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings


            sb.AppendLine($"using Comandos.Pateners.Command;");
            sb.AppendLine($"using Dominio.TiposPrimitivos;");
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a classe
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_classe} : ReciverBase");
            sb.AppendLine("    {");
            sb.AppendLine();
            //sb.AppendLine($"        private readonly object _menssage;");
            //sb.AppendLine();
            //sb.AppendLine($"        public {_classe}(object menssage)");
            //sb.AppendLine("        {");
            //sb.AppendLine("            _menssage = menssage;");
            //sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        protected override State Action(ICommand comand)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            // chamar o custon receiver

            //sb.AppendLine("                 Agent = getAgent(comand);    ");
            //sb.AppendLine("                 comand = Agent.getMenu(comand);    ");


            sb.AppendLine("                return new State(200, \"OK\", comand);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception e)");
            sb.AppendLine("            {");
            sb.AppendLine("                return new State(500, e, comand);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("}");
            //foreach (var menu in _agent.Menus)
            //{
            //    sb.AppendLine($"           private List<string> {menu.Name.SourceType()}()");
            //    sb.AppendLine("            {");
            //    sb.AppendLine("                 return new List<string>() {");

            //    List<string> lista = new List<string>();
            //    lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
            //    lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));
            //    sb.AppendLine($"{string.Join(",", lista.Select(m => "\"" + m + "\""))}");
            //    sb.AppendLine("                ");
            //    sb.AppendLine("                 };");
            //    sb.AppendLine("            }");
            //}
            //sb.AppendLine("    }");




            //foreach (var menu in _agent.Menus)
            //{
            //    // Nome do enum baseado no menu
            //    string enumName = $"{menu.Name.SourceType()}";
            //    sb.AppendLine($"public enum {enumName}");
            //    sb.AppendLine("{");

            //    int id = 0; // Inicia um contador para os IDs

            //    // Adiciona submenus e opções ao enum
            //    List<string> lista = new List<string>();
            //    lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
            //    lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));

            //    foreach (var item in lista)
            //    {
            //        sb.AppendLine($"    {item} = {id},"); // Atribui um ID a cada item
            //        id++; // Incrementa o ID
            //    }

            //    sb.AppendLine("}");
            //    sb.AppendLine(); // Adiciona uma linha em branco entre os enums
            //}

            // name space
            sb.AppendLine("}");




            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            StringBuilder sb = new StringBuilder();
            // Adiciona os usings
            sb.AppendLine($"using Comandos.Pateners.Command;");
            sb.AppendLine($"using Dominio.TiposPrimitivos;");
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a classe
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_classe}HubReceiver");
            sb.AppendLine("    {");
            //sb.AppendLine($"       private Agent getAgent(ICommand comand)");
            //sb.AppendLine("        {");
            //sb.AppendLine("            try");
            //sb.AppendLine("            {");

            //sb.AppendLine("            }");
            //sb.AppendLine("            catch (Exception e)");
            //sb.AppendLine("            {");

            //sb.AppendLine("            }");
            //sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }
    }
}