
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
        private UseCaseCommand _method;
        private string _classe;
        private string _nameSpace;
        private HashSet<string> _generatedTypes = new HashSet<string>();

        public SourceCodeAplicationCommandCommandsUseCaseGroup(UseCaseGroup hub)
            : base()
        {
            _hub = hub;
            _commandType = CommandType.UseCaseGroup;
            _nameSpace = CQRSParam.I.NameSpaceCommandWrite;
        }
        public SourceCodeAplicationCommandCommandsUseCaseGroup(UseCaseCommand method)
                    : base()
        {
            _hub = method.UseCaseGroup;
            _service = method.UseCaseSubGroup;
            _commandType = CommandType.UseCase;
            _nameSpace = CQRSParam.I.NameSpaceCommandCommandsUseCases;
            _method = method;
            //_classe = $"{_service.Name.SourceType()}{_method.Name.SourceType()}{_commandType}Command";
            _generatedTypes = new HashSet<string>();
        }


        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceEnumStrategy};");
            sb.AppendLine($"using Microsoft.AspNetCore.Http;");
            


            // using Microsoft.AspNetCore.Http;


            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");

            if (_commandType == CommandType.UseCase)
            {
                //foreach (var param in _method.Inputs)
                //{
                //    Type type = param.GetType();
                //    if (type.IsClass || type.IsValueType)
                //    {
                //        sb.AppendLine($"    public partial record {_classe} : ICommand");
                //        sb.AppendLine("    {");
                //        foreach (PropertyInfo prop in type.GetProperties())
                //        {
                //            if (prop.PropertyType.IsEnum)
                //                sb.AppendLine($"    public {prop.PropertyType.Name} {prop.Name} {{ get; set; }}");
                //            else if (prop.PropertyType == typeof(Int32))
                //                sb.AppendLine($"    public int {prop.Name} {{ get; set; }}");
                //            else
                //                sb.AppendLine($"    public {prop.PropertyType.Name.ToLower()} {prop.Name} {{ get; set; }}");

                //        }
                //        sb.AppendLine("    }");
                //    }
                //}

                foreach (var param in _method.Inputs)
                {
                    _classe = $"{_method.Name.SourceType()}InputCommand";
                    if (param == null) continue;
                    GenerateClass(param.GetType(), sb, _classe);
                }

                foreach (var param in _method.Outputs)
                {
                    _classe = $"{_method.Name.SourceType()}OutputCommand";
                    if (param == null) continue;
                    GenerateClass(param.GetType(), sb, _classe);
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


        private void GenerateClass(Type type, StringBuilder sb, string className = "")
        {
            if (className == "")
                className = type.Name;

            // Evita gerar tipos repetidos
            if (_generatedTypes.Contains(className))
                return;

            // Ignorar tipos do .NET padrão, incluindo genéricos como List<>
            if (type.Namespace != null && type.Namespace.StartsWith("System"))
                return;

            _generatedTypes.Add(className);

            // Começa a geração da classe record
            sb.AppendLine($"public partial record {className} : ICommand");
            sb.AppendLine("{");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                string propTypeName = GetFriendlyTypeName(prop.PropertyType);
                sb.AppendLine($"    public {propTypeName} {prop.Name} {{ get; set; }}");
            }

            sb.AppendLine("}");
            sb.AppendLine();

            // Agora, fora da classe, geramos os tipos complexos das propriedades recursivamente
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Type propType = prop.PropertyType;

                // Se for um tipo complexo (classe customizada) e não string
                if (propType.IsClass && propType != typeof(string))
                {
                    if (!propType.Namespace.StartsWith("System"))
                        GenerateClass(propType, sb);

                    if (propType.IsGenericType)
                    {
                        foreach (var arg in propType.GetGenericArguments())
                        {
                            if (!arg.Namespace.StartsWith("System"))
                                GenerateClass(arg, sb);
                        }
                    }
                }
            }
        }

        // Função auxiliar para nome de tipos amigável permanece igual


    }
}