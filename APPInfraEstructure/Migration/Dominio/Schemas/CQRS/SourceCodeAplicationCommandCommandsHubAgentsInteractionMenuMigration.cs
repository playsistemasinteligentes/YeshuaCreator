
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using static Dapper.SqlMapper;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsHubAgentsInteractionMenuMigration : SourceCodeBase
    {
        private Descricao _OptionValue;
        private int _OptionKey;

        public SourceCodeAplicationCommandCommandsHubAgentsInteractionMenuMigration(int optionkey, Descricao optionValue)
            : base()
        {
            _OptionKey = optionkey;
            _OptionValue = optionValue;
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
            sb.AppendLine($"    public partial class {_OptionValue.SourceType()}Command : ICommand");
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
            sb.AppendLine($"    public partial class {_OptionValue.SourceType()}Command : ICommand");
            sb.AppendLine("    {");


            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }
    }
}