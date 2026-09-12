using Dominio.Migration;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using CommandType = Migration.Dominio.Schemas.CQRS.CommandType;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly CommandType _commandType;
        private readonly string _nameSpace;
        private readonly string _column;
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
                case CommandType.Update:
                    return CommandCrud(CommandType.Update);
                case CommandType.Delete:
                    return CommandCrud(CommandType.Delete);
                case CommandType.Read:
                    return CommandCrud(CommandType.Read);
                case CommandType.ReadQuery:
                    return CommandCrud(CommandType.ReadQuery);
                case CommandType.ReadFK:
                    return CommandCrud(CommandType.ReadFK);
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
                sb.AppendLine("using Dominio.Behaviors;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");
                sb.AppendLine("using Dominio.Patterns.Domain;");

                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryWrite};");
                sb.AppendLine($"using System;");
                sb.AppendLine($"using System.Collections.Generic;");
                sb.AppendLine($"using System.Linq;");
                sb.AppendLine($"using System.Text;");
                sb.AppendLine($"using System.Threading;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();

                // Adiciona o namespace e a classe
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {action.ToString()}{_entity.EntityName}Receiver : ReciverBase<ICommand, I{_entity.EntityName}Entity>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}WriteRepository _repository;");
                sb.AppendLine($"        private readonly ILogger _logger;");
                sb.AppendLine("        private readonly IDomainTrackingPolicy _domainTrackingPolicy;");
                sb.AppendLine("        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;");
                sb.AppendLine();
                sb.AppendLine($"        public {action.ToString()}{_entity.EntityName}Receiver(");
                sb.AppendLine($"            I{_entity.EntityName}WriteRepository repository,");
                sb.AppendLine($"            Dominio.Interfaces.ILogger logger,");
                sb.AppendLine($"            Dominio.Interfaces.IDomainTrackingPolicy domainTrackingPolicy,");
                sb.AppendLine($"            Aplication.Interfaces.Services.IExecutionContext context)");
                sb.AppendLine($"            : base(logger, context)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("            _domainTrackingPolicy = domainTrackingPolicy;");
                sb.AppendLine("            _executionContext = context;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override Task<State<I{_entity.EntityName}Entity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)");
                sb.AppendLine("        {");

                sb.AppendLine($"             if(comand is {CQRSParam.I.NameSpaceCommandWrite}.{_entity.EntityName}CrudCommand c) ");
                sb.AppendLine("             {    ");
                var domainOperation = action switch
                {
                    CommandType.Insert => "DomainOperation.Registro",
                    CommandType.Update => "DomainOperation.Alteracao",
                    CommandType.Delete => "DomainOperation.Remocao",
                    _ => "DomainOperation.Alteracao"
                };
                var receiverName = $"{action}{_entity.EntityName}Receiver";
                var commandName = $"{CQRSParam.I.NameSpaceCommandWrite}.{_entity.EntityName}CrudCommand";
                var factoryArguments = string.Join(", ", _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsValueDefault).Select(c => "c." + c.Name));
                var factoryCallArguments = string.IsNullOrWhiteSpace(factoryArguments)
                    ? "context"
                    : $"context, {factoryArguments}";
                sb.AppendLine($"                 var context = DomainOperationContext.Create({domainOperation}, DomainEntryPoint.Crud, \"{action}{_entity.EntityName}\", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof({receiverName}), commandName: \"{commandName}\");");
                sb.AppendLine($"                 var {_entity.EntityName.ToLower()} = new {_entity.EntityName}Factory(_logger, _domainTrackingPolicy).Create({factoryCallArguments});");
                sb.AppendLine($"                 var domainResult = {_entity.EntityName}DomainBehavior.Apply({_entity.EntityName.ToLower()}, context);");
                sb.AppendLine("                 if (!domainResult.IsValid)");
                sb.AppendLine("                     return Task.FromResult(ValidationError(domainResult.Errors));");
                sb.AppendLine();
                sb.AppendLine("                 try");
                sb.AppendLine("                 {");
                sb.AppendLine($"                     _repository.{action.ToString()}({_entity.EntityName.ToLower()});");
                sb.AppendLine($"                     return Task.FromResult(Success(\"OK\", {_entity.EntityName.ToLower()}));");
                sb.AppendLine("                 }");
                sb.AppendLine("                 catch (Exception e)");
                sb.AppendLine("                 {");
                sb.AppendLine($"                    return Task.FromResult(Error(e, {_entity.EntityName.ToLower()}));");
                sb.AppendLine("                 }");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Task.FromResult(Error(\"ErroConversao\"));");
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
                sb.AppendLine($"using System.Threading;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}{action}{_column}Receiver : ReciverBase<ICommand, DataPagination<{_entity.EntityName}DTO>>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}ReadRepository _repository;");
                sb.AppendLine($"        private readonly ILogger _logger;");
                sb.AppendLine("        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;");

                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}{action}{_column}Receiver(");
                sb.AppendLine($"            I{_entity.EntityName}ReadRepository repository,");
                sb.AppendLine($"            Dominio.Interfaces.ILogger logger,");
                sb.AppendLine($"            Aplication.Interfaces.Services.IExecutionContext context)");
                sb.AppendLine($"            : base(logger, context)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("            _executionContext = context;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override Task<State<DataPagination<{_entity.EntityName}DTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)");
                sb.AppendLine("        {");
                sb.AppendLine($"            if(comand is {CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{_commandType}{_column}Command c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                var {_entity.EntityName}ReadRepository = _repository.get{_entity.EntityName}(c);");
                sb.AppendLine($"                return Task.FromResult(Success(\"OK\", {_entity.EntityName}ReadRepository));");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Task.FromResult(Error(\"ErroConversao\"));");
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
                sb.AppendLine($"using System.Threading;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}{action}{_whereName}Receiver : ReciverBase<ICommand, DataPagination<{_entity.EntityName}{_query.Meta.QueryName}DTO>>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}ReadRepository _repository;");
                sb.AppendLine($"        private readonly ILogger _logger;");
                sb.AppendLine("        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;");

                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}{action}{_whereName}Receiver(");
                sb.AppendLine($"            I{_entity.EntityName}ReadRepository repository,");
                sb.AppendLine($"            Dominio.Interfaces.ILogger logger,");
                sb.AppendLine($"            Aplication.Interfaces.Services.IExecutionContext context)");
                sb.AppendLine($"            : base(logger, context)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("            _executionContext = context;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override Task<State<DataPagination<{_entity.EntityName}{_query.Meta.QueryName}DTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)");
                sb.AppendLine("        {");
                sb.AppendLine($"            if(comand is {CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{_whereName}Command c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                var {_entity.EntityName}ReadRepository = _repository.Get{_entity.EntityName}{_whereName}(c);");
                sb.AppendLine($"                return Task.FromResult(Success(\"OK\", {_entity.EntityName}ReadRepository));");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Task.FromResult(Error(\"ErroConversao\"));");
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
                sb.AppendLine($"using System.Threading;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}{action}{_column}Receiver : ReciverBase<ICommand, IEnumerable<{_entity.EntityName}{_column}DTO>>");
                sb.AppendLine("    {");
                sb.AppendLine($"        private readonly I{_entity.EntityName}ReadRepository _repository;");
                sb.AppendLine("		   private readonly Dominio.Interfaces.ILogger _logger;");
                sb.AppendLine("        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;");

                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}{action}{_column}Receiver(");
                sb.AppendLine($"            I{_entity.EntityName}ReadRepository repository,");
                sb.AppendLine($"            Dominio.Interfaces.ILogger logger,");
                sb.AppendLine($"            Aplication.Interfaces.Services.IExecutionContext context)");
                sb.AppendLine($"            : base(logger, context)");
                sb.AppendLine("        {");
                sb.AppendLine("            _repository = repository;");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("            _executionContext = context;");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override Task<State<IEnumerable<{_entity.EntityName}{_column}DTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)");
                sb.AppendLine("        {");

                sb.AppendLine($"            if(comand is SearchFKCommand c) ");
                sb.AppendLine("             {    ");
                sb.AppendLine($"                var {_entity.EntityName}ReadRepository = _repository.get{_entity.EntityName}{action}{_column}(c);");
                sb.AppendLine($"                return Task.FromResult(Success(\"OK\", {_entity.EntityName}ReadRepository));");
                sb.AppendLine("            }");
                sb.AppendLine("            else ");
                sb.AppendLine("            {");
                sb.AppendLine("                 return Task.FromResult(Error(\"ErroConversao\"));");
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
            return new StringBuilder();
        }

    }

}
