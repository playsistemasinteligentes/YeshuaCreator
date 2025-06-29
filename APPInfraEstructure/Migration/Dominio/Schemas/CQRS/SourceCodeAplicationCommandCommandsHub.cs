
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System.Collections.Generic;
using System.Text;
using Migration.Dominio.Schemas.CQRS;
using System.Reflection;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsHub : SourceCodeBase
    {
        private Hub _hub;
        private CommandType _commandType;
        private Service _service;
        private Method _method;
        private string _classe;
        private string _nameSpace;

        public SourceCodeAplicationCommandCommandsHub(Hub hub)
            : base()
        {
            _hub = hub;
            _commandType = CommandType.Hub;
            _nameSpace = CQRSParam.I.NameSpaceCommands;
        }
        public SourceCodeAplicationCommandCommandsHub(Method method)
                    : base()
        {
            _hub = method.Hub;
            _service = method.Service;
            _commandType = CommandType.ServiceMethod;
            _nameSpace = CQRSParam.I.NameSpaceCommandCommandsHubServiceMethod;
            _method = method;
            _classe = $"{_service.Name.SourceType()}{_method.Name.SourceType()}{_commandType}Command";
        }


        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");


            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");

            if (_commandType == CommandType.ServiceMethod)
            {
                foreach (var param in _method.Inputs)
                {
                    Type type = param.GetType();
                    if (type.IsClass || type.IsValueType)
                    {
                        sb.AppendLine($"    public partial struct {_classe} : ICommand");
                        sb.AppendLine("    {");
                        foreach (PropertyInfo prop in type.GetProperties())
                        {
                            sb.AppendLine($"    public {prop.PropertyType.Name.ToLower()} {prop.Name} {{ get; set; }}");
                        }
                        sb.AppendLine("    }");
                    }
                }
            }
            else if (_commandType == CommandType.Hub)
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