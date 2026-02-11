using Dominio.Migration;
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
        private readonly string _nameSpace;
        private readonly string _column;
        private readonly string _generiClass;
        private readonly string _whereName;
        private readonly IQueryWithMeta _query;

        public SourceCodeAplicationCommandReceiversMigration(Entity entity, CommandType commandType, string nameSpace, string column)
            : base()
        {
            _entity = entity;
            _commandType = commandType;
            _nameSpace = nameSpace;
            _column = column;
        }
        public SourceCodeAplicationCommandReceiversMigration(Entity entity, CommandType commandType, string nameSpace, IQueryWithMeta query, string whereName)
            : base()
        {
            _entity = entity;
            _commandType = commandType;
            _nameSpace = nameSpace;
            _query = query;
            _whereName = whereName;
        }


        protected override StringBuilder GenerateCode()
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
                case CommandType.Read:
                    return CommandCrud(CommandType.Read);
                    break;
                case CommandType.ReadQuery:
                    return CommandCrud(CommandType.ReadQuery);
                    break;
                case CommandType.ReadFK:
                    return CommandCrud(CommandType.ReadFK);
                    break;
                default:
                    break;
            }
            return new StringBuilder();
        }
        private StringBuilder CommandCrud(CommandType action)
        {
            StringBuilder sb = new StringBuilder();
            if (action == CommandType.Insert || action == CommandType.Update || action == CommandType.Delete)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");

                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryWrite};");
                sb.AppendLine($"using System;");
                sb.AppendLine($"using System.Collections.Generic;");
                sb.AppendLine($"using System.Linq;");
                sb.AppendLine($"using System.Text;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();

                // Adiciona o namespace e a classe
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {action.ToString()}{_entity.EntityName}Receiver : ReciverBase<ICommand, I{_entity.EntityName}Entity>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}WriteRepository _repository;");
                sb.AppendLine($"        private readonly ILogger _logger;");
                sb.AppendLine();
                sb.AppendLine($"        public {action.ToString()}{_entity.EntityName}Receiver(I{_entity.EntityName}WriteRepository repository,ILogger logger)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override State<I{_entity.EntityName}Entity> Action(ICommand comand)");
                sb.AppendLine("        {");

                sb.AppendLine($"             if(comand is {CQRSParam.I.NameSpaceCommandWrite}.{_entity.EntityName}CrudCommand c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                 var {_entity.EntityName.ToLower()} = new {_entity.EntityName}Factory(_logger).Create({string.Join(", ", _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsValueDefault).Select(c => "c." + c.Name))});");
                sb.AppendLine($"                 if (!{_entity.EntityName.ToLower()}.isValid{action}())");
                sb.AppendLine($"                     return ValidationError({_entity.EntityName.ToLower()}.getErroMensagens(), null);");
                sb.AppendLine();
                sb.AppendLine("                 try");
                sb.AppendLine("                 {");
                sb.AppendLine($"                     _repository.{action.ToString()}({_entity.EntityName.ToLower()});");
                sb.AppendLine($"                     return Success(\"OK\", {_entity.EntityName.ToLower()});");
                sb.AppendLine("                 }");
                sb.AppendLine("                 catch (Exception e)");
                sb.AppendLine("                 {");
                sb.AppendLine($"                    return Error(e, {_entity.EntityName.ToLower()});");
                sb.AppendLine("                 }");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Error(\"ErroConversao\", default);");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }
            else if (action == CommandType.Read)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");
                sb.AppendLine($"using Repositorio.Outputs;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
                sb.AppendLine();
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}{action}{_column}Receiver : ReciverBase<ICommand, DataPagination<{_entity.EntityName}DTO>>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}ReadRepository _repository;");
                sb.AppendLine($"        private readonly ILogger _logger;");

                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}{action}{_column}Receiver(I{_entity.EntityName}ReadRepository repository,ILogger logger)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override State<DataPagination<{_entity.EntityName}DTO>> Action(ICommand comand)");
                sb.AppendLine("        {");
                sb.AppendLine($"            if(comand is {CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{_commandType}{_column}Command c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                var {_entity.EntityName}ReadRepository = _repository.get{_entity.EntityName}(c);");
                sb.AppendLine($"                return Success(\"OK\", {_entity.EntityName}ReadRepository);");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Error(\"ErroConversao\", default);");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }
            else if (action == CommandType.ReadQuery)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");
                sb.AppendLine($"using Repositorio.Outputs;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
                sb.AppendLine();
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}{action}{_whereName}Receiver : ReciverBase<ICommand, DataPagination<{_entity.EntityName}{_query.Meta.QueryName}DTO>>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}ReadRepository _repository;");
                sb.AppendLine($"        private readonly ILogger _logger;");

                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}{action}{_whereName}Receiver(I{_entity.EntityName}ReadRepository repository,ILogger logger)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override State<DataPagination<{_entity.EntityName}{_query.Meta.QueryName}DTO>> Action(ICommand comand)");
                sb.AppendLine("        {");
                sb.AppendLine($"            if(comand is {CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{_whereName}Command c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                var {_entity.EntityName}ReadRepository = _repository.Get{_entity.EntityName}{_whereName}(c);");
                sb.AppendLine($"                return Success(\"OK\", {_entity.EntityName}ReadRepository);");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Error(\"ErroConversao\", default);");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }

            else if (action == CommandType.ReadFK)
            {

                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryWrite};");
                sb.AppendLine($"using Repositorio.Outputs;");
                sb.AppendLine();
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}{action}{_column}Receiver : ReciverBase<ICommand, IEnumerable<{_entity.EntityName}{_column}DTO>>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}ReadRepository _repository;");
                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}{action}{_column}Receiver(I{_entity.EntityName}ReadRepository repository)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override State <IEnumerable<{_entity.EntityName}{_column}DTO>> Action(ICommand comand)");
                sb.AppendLine("        {");

                sb.AppendLine($"            if(comand is SearchFKCommand c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                var {_entity.EntityName}ReadRepository = _repository.get{_entity.EntityName}{action}{_column}(c);");
                sb.AppendLine($"                return Success(\"OK\", {_entity.EntityName}ReadRepository);");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Error(\"ErroConversao\", default);");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }
            return new StringBuilder();
        }



        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            return new StringBuilder();
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

            return sb;
        }
    }

}