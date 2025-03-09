
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using static Dapper.SqlMapper;
using System.Text;

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

            sb.AppendLine("using Comandos.Pateners.Command;");
            sb.AppendLine("using Dominio.TiposPrimitivos;");

            // Adiciona a declaração do namespace
            sb.AppendLine("namespace Comandos.Commands");
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

            sb.AppendLine("using Comandos.Pateners.Command;");
            sb.AppendLine("using Dominio.TiposPrimitivos;");

            // Adiciona a declaração do namespace
            sb.AppendLine("namespace Comandos.Commands");
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