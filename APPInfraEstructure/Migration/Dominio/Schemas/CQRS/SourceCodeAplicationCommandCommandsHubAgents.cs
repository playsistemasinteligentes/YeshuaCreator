
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using System.Text;
using Migration.Dominio.Schemas.CQRS;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsHubAgents : SourceCodeBase
    {
        private Agent _agent;


        public SourceCodeAplicationCommandCommandsHubAgents(Agent agent)
            : base()
        {
            _agent = agent;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");

            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceCommands}");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"    public partial class {_agent.Name.SourceType()}HubAgentCommand : ICommand");
            sb.AppendLine("    {");


            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");

            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceCommands}");

            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"    public partial class {_agent.Name.SourceType()}HubAgentCommand : ICommand");
            sb.AppendLine("    {");


            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;

        }
    }
}