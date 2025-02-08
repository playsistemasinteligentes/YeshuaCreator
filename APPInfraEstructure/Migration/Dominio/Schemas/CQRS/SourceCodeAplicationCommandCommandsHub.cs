
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using static Dapper.SqlMapper;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsHub : SourceCodeBase
    {
        private Hub _hub;


        public SourceCodeAplicationCommandCommandsHub(Hub hub)
            : base()
        {
            _hub = hub;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Comandos.Pateners.Command;");
            sb.AppendLine("using Dominio.TiposPrimitivos;");

            // Adiciona a declaração do namespace
            sb.AppendLine("namespace Comandos.Commands");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"    public partial class {_hub.Name.SourceType()}HubCommand : ICommand");
            sb.AppendLine("    {");


            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
        protected override string GenerateCustonCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Comandos.Pateners.Command;");
            sb.AppendLine("using Dominio.TiposPrimitivos;");

            // Adiciona a declaração do namespace
            sb.AppendLine("namespace Comandos.Commands");
            sb.AppendLine("{");

            // Define a classe
            sb.AppendLine($"    public partial class {_hub.Name.SourceType()}HubCommand : ICommand");
            sb.AppendLine("    {");


            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }
    }
}