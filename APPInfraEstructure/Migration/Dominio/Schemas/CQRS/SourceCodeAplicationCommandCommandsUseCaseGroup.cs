
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using System.Text;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsUseCaseGroup : SourceCodeBase
    {
        private UseCaseGroup _hub;
        private CommandType _commandType;
        private UseCaseSubGroup _service;
        private UseCase _method;
        private string _classe;
        private string _nameSpace;

        public SourceCodeAplicationCommandCommandsUseCaseGroup(UseCaseGroup hub)
            : base()
        {
            _hub = hub;
            _commandType = CommandType.UseCaseGroup;
            _nameSpace = CQRSParam.I.NameSpaceCommandWrite;
        }
        public SourceCodeAplicationCommandCommandsUseCaseGroup(UseCase method)
                    : base()
        {
            _hub = method.UseCaseGroup;
            _service = method.UseCaseSubGroup;
            _commandType = CommandType.UseCase;
            _nameSpace = CQRSParam.I.NameSpaceCommandCommandsUseCases;
            _method = method;
            _classe = $"{_service.Name.SourceType()}{_method.Name.SourceType()}{_commandType}Command";
        }


        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceEnumStrategy};");



            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");

            if (_commandType == CommandType.UseCase)
            {
                foreach (var param in _method.Inputs)
                {
                    Type type = param.GetType();
                    if (type.IsClass || type.IsValueType)
                    {
                        sb.AppendLine($"    public partial record {_classe} : ICommand");
                        sb.AppendLine("    {");
                        foreach (PropertyInfo prop in type.GetProperties())
                        {
                            if (prop.PropertyType.IsEnum)
                                sb.AppendLine($"    public {prop.PropertyType.Name} {prop.Name} {{ get; set; }}");
                            else if (prop.PropertyType == typeof(Int32))
                                sb.AppendLine($"    public int {prop.Name} {{ get; set; }}");
                            else
                                sb.AppendLine($"    public {prop.PropertyType.Name.ToLower()} {prop.Name} {{ get; set; }}");

                        }
                        sb.AppendLine("    }");
                    }
                }
            }
            else if (_commandType == CommandType.UseCaseGroup)
            {
                sb.AppendLine($"    public partial class {_hub.Name.SourceType()}HubCommand : ICommand");
                sb.AppendLine("    {");
                sb.AppendLine("    }");
            }


            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            return sb;
        }
    }
}