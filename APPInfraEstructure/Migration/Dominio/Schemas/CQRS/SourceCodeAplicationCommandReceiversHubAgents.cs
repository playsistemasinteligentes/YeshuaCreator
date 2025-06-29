
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Migration.Dominio.Schemas.CQRS;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversHubAgents : SourceCodeBase
    {
        private Agent _agent;
        public SourceCodeAplicationCommandReceiversHubAgents(Agent agent)
            : base()
        {
            _agent = agent;
        }

        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommands};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");

            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a classe
            sb.AppendLine($"namespace Comandos.Receivers.{_agent.Name.SourceType()}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_agent.Name.SourceType()}HubAgentReceiver : ReciverBase<ICommand>");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine($"        private readonly object _menssage;");
            sb.AppendLine();
            sb.AppendLine($"        public {_agent.Name.SourceType()}HubAgentReceiver(object menssage)");
            sb.AppendLine("        {");
            sb.AppendLine("            _menssage = menssage;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        protected override State<ICommand> Action(ICommand comand)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            //sb.AppendLine("                comand = getMenu();");
            sb.AppendLine("                return Success(\"OK\", comand);");
            sb.AppendLine("            }");
            CQRSParam.I.AddExeptionReceiver(sb, "ICommand");
            sb.AppendLine("        }");
            foreach (var menu in _agent.Menus)
            {
                sb.AppendLine($"           private List<string> {menu.Name.SourceType()}()");
                sb.AppendLine("            {");
                sb.AppendLine("                 return new List<string>() {");

                List<string> lista = new List<string>();
                lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
                lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));
                sb.AppendLine($"{string.Join(",", lista.Select(m => "\"" + m + "\""))}");
                sb.AppendLine("                ");
                sb.AppendLine("                 };");
                sb.AppendLine("            }");
            }
            sb.AppendLine("    }");




            foreach (var menu in _agent.Menus)
            {
                // Nome do enum baseado no menu
                string enumName = $"{menu.Name.SourceType()}";
                sb.AppendLine($"public enum {enumName}");
                sb.AppendLine("{");

                int id = 0; // Inicia um contador para os IDs

                // Adiciona submenus e opções ao enum
                List<string> lista = new List<string>();
                lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
                lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));

                foreach (var item in lista)
                {
                    sb.AppendLine($"    {item} = {id},"); // Atribui um ID a cada item
                    id++; // Incrementa o ID
                }

                sb.AppendLine("}");
                sb.AppendLine(); // Adiciona uma linha em branco entre os enums
            }

            // name space
            sb.AppendLine("}");




            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            StringBuilder sb = new StringBuilder();
            //// Adiciona os usings
            //sb.AppendLine($"");
            //sb.AppendLine($"using Dominio.TiposPrimitivos;");
            //sb.AppendLine($"using System;");
            //sb.AppendLine($"using System.Collections.Generic;");
            //sb.AppendLine($"using System.Linq;");
            //sb.AppendLine($"using System.Text;");
            //sb.AppendLine($"using System.Threading.Tasks;");
            //sb.AppendLine();
            //
            //// Adiciona o namespace e a classe
            //sb.AppendLine($"namespace Comandos.Receivers.{_agent.Name.SourceType()}");
            //sb.AppendLine("{");
            //sb.AppendLine($"    public partial class {_agent.Name.SourceType()}HubAgentReceiver : ReciverBase");
            //sb.AppendLine("    {");
            //sb.AppendLine($"       protected List<string> GetMenu(ICommand comand)");
            //sb.AppendLine("        {");
            //sb.AppendLine("            try");
            //sb.AppendLine("            {");
            //
            //
            //sb.AppendLine("            }");
            //sb.AppendLine("            catch (Exception e)");
            //sb.AppendLine("            {");
            //
            //sb.AppendLine("            }");
            //sb.AppendLine("        }");
            //sb.AppendLine("    }");
            //sb.AppendLine("}");
            return sb;
        }
    }
}