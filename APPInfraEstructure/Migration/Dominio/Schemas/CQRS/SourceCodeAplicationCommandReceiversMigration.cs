using Azure.Core;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data;
using System.Text;
using CommandType = Migration.Dominio.Schemas.CQRS.CommandType;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly CommandType _commandType;

        public SourceCodeAplicationCommandReceiversMigration(Entity entity, CommandType commandType)
            : base()
        {
            _entity = entity;
            _commandType = commandType;
        }

        protected override string GenerateCode()
        {

            switch (_commandType)
            {
                case CommandType.Insert:
                    return CommandCrud(CommandType.Insert);
                    break;
                case CommandType.Update:
                    return CommandCrud(CommandType.Update);
                    break;
                case CommandType.Delete:
                    return CommandCrud(CommandType.Delete);
                    break;
                default:
                    break;
            }
            return string.Empty;
        }
        private string CommandCrud(CommandType action)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"using Comandos.Pateners.Command;");
            sb.AppendLine($"using Dominio.Entitys.{_entity.EntityName};");
            sb.AppendLine($"using Dominio.TiposPrimitivos;");
            sb.AppendLine($"using Repositorio.Inputs.Repositorio.{_entity.EntityName};");
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a classe
            sb.AppendLine($"namespace Comandos.Receivers.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {action.ToString()}{_entity.EntityName}Receiver : ReciverBase");
            sb.AppendLine("    {");
            sb.AppendLine($"        private readonly I{_entity.EntityName}WriteRepository _repository;");
            sb.AppendLine();
            sb.AppendLine($"        public {action.ToString()}{_entity.EntityName}Receiver(I{_entity.EntityName}WriteRepository repository)");
            sb.AppendLine("        {");
            sb.AppendLine("            _repository = repository;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        protected override State Action(ICommand comand)");
            sb.AppendLine("        {");
            sb.AppendLine($"            var c = (Comandos.Commands.{_entity.EntityName}Command)comand;");
            sb.AppendLine();
            sb.AppendLine($"            var {_entity.EntityName.ToLower()} = new {_entity.EntityName}Entity({string.Join(", ", _entity.AddColumns.Select(c => "c." + c.Name))});");
            sb.AppendLine($"            if (!{_entity.EntityName.ToLower()}.isValid())");
            sb.AppendLine("                return new State(300, \"Erro \", comand);");
            sb.AppendLine();
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine($"                _repository.{action.ToString()}({_entity.EntityName.ToLower()});");
            sb.AppendLine("                return new State(200, \"OK\", comand);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception e)");
            sb.AppendLine("            {");
            sb.AppendLine("                return new State(500, \"Erro\", comand);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }



        protected override string GenerateCustonCode()
        {
            var sb = new StringBuilder();

            // Adiciona o comentário de descrição da entidade
            sb.AppendLine("// " + _entity.EntityDescription);

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}");
            sb.AppendLine("{");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"    public {column.getCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("}");
            return "";
            return sb.ToString();
        }
    }

}