
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using static Dapper.SqlMapper;
using System.Text;
using Migration.Dominio.Schemas.CQRS;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsHubAgentsOptions : SourceCodeBase
    {
        private Descricao _OptionValue;
        private int _OptionKey;

        public SourceCodeAplicationCommandCommandsHubAgentsOptions(int optionkey, Descricao optionValue)
            : base()
        {
            _OptionKey = optionkey;
            _OptionValue = optionValue;
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
            sb.AppendLine($"    public partial class {_OptionValue.SourceType()}Command : ICommand");
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
            sb.AppendLine($"    public partial class {_OptionValue.SourceType()}Command : ICommand");
            sb.AppendLine("    {");


            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;

        }
    }
}