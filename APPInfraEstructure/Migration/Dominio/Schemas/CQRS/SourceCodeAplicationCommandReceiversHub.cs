
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using static Dapper.SqlMapper;
using System.Text;
using System.Linq;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversHub : SourceCodeBase
    {
        private Hub _hub;
        public SourceCodeAplicationCommandReceiversHub(Hub hub)
            : base()
        {
            _hub = hub;
        }

        protected override string GenerateCode()
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
            sb.AppendLine($"namespace Comandos.Receivers.{_hub.Name.SourceType()}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_hub.Name.SourceType()}HubReceiver : ReciverBase");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine($"        private readonly object _menssage;");
            sb.AppendLine();
            sb.AppendLine($"        public {_hub.Name.SourceType()}HubReceiver(object menssage)");
            sb.AppendLine("        {");
            sb.AppendLine("            _menssage = menssage;");
            sb.AppendLine("        }");
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




            return sb.ToString();
        }
        protected override string GenerateCustonCode()
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
            sb.AppendLine($"namespace Comandos.Receivers.{_hub.Name.SourceType()}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_hub.Name.SourceType()}HubReceiver : ReciverBase");
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
            return sb.ToString();
        }
    }
}