
using Migration.Dominio;
using System.Text;
using Migration.Dominio.Schemas.CQRS;
using static Dapper.SqlMapper;
using System.Reflection;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversUseCase : SourceCodeBase
    {
        private UseCaseGroup _useCaseGroup;
        private CommandType _commandType;
        private UseCaseSubGroup _useCaseSubGroup;
        private UseCase _useCase;
        private string _nameSpace;
        private string _nameSpaceCommand;
        private string _classeReceiver;
        private string _classeCommand;
        private Type _type;

        public SourceCodeAplicationCommandReceiversUseCase(UseCaseGroup hub)
            : base()
        {
            _useCaseGroup = hub;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversHub;
            _commandType = CommandType.UseCaseGroup;
        }
        public SourceCodeAplicationCommandReceiversUseCase(UseCase useCase)
            : base()
        {
            _useCaseGroup = useCase.UseCaseGroup;
            _useCaseSubGroup = useCase.UseCaseSubGroup;
            _commandType = CommandType.UseCase;
            _useCase = useCase;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversUseCase;
            _nameSpaceCommand = CQRSParam.I.NameSpaceCommandCommandsUseCases;
            _classeReceiver = $"{_useCaseSubGroup.Name.SourceType()}{_useCase.Name.SourceType()}{_commandType}Receiver";
            _classeCommand = $"{_useCaseSubGroup.Name.SourceType()}{_useCase.Name.SourceType()}{_commandType}Command";
        }
        public SourceCodeAplicationCommandReceiversUseCase(UseCase useCase, Type type)
            : base()
        {
            _type = type;
            _useCaseGroup = useCase.UseCaseGroup;
            _useCaseSubGroup = useCase.UseCaseSubGroup;
            _commandType = CommandType.UseCase;
            _useCase = useCase;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversUseCase;
            _nameSpaceCommand = CQRSParam.I.NameSpaceCommandCommandsUseCases;
            _classeReceiver = $"{_useCaseSubGroup.Name.SourceType()}{_useCase.Name.SourceType()}{_commandType}Receiver";
            _classeCommand = $"{_useCaseSubGroup.Name.SourceType()}{_useCase.Name.SourceType()}{_commandType}Command";



            var paths = new ExportPaths
            {
                EnumPath = "c:\\temp\\temp\\",
                InterfacePath = "c:\\temp\\temp\\",
                ClassPath = "c:\\temp\\temp\\",
                CustomClassPath = @"c:\\temp\\temp\\cu\\",
                FactoryInterfacePath = "c:\\temp\\temp\\",
                FactoryClassPath = "c:\\temp\\temp\\",
                DependencyInjectionPath = "c:\\temp\\temp\\"

            };

            TypeExporter.ExportFromRootInterface(_type, paths);


        }






        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            if (_type != null)
            {
                return sb;
            }
            else
            {
                // Adiciona os usings

                sb.AppendLine($"// Escopo: {string.Join(",", _useCase.Scopes)}");

                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommands};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceUnitOfWork};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");

                foreach (var entity in _useCase.Entitys)
                {
                    sb.AppendLine($"using {CQRSParam.I.NameSpaceRepositorioInputsRepositorio}.{entity.EntityName};");
                    sb.AppendLine($"using {CQRSParam.I.NameSpaceReadRepository}.{entity.EntityName};");
                }

                sb.AppendLine($"using System;");
                sb.AppendLine($"using System.Collections.Generic;");
                sb.AppendLine($"using System.Linq;");
                sb.AppendLine($"using System.Text;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();

                // Adiciona o namespace e a classe
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");

                sb.AppendLine($"    public partial class {_classeReceiver} : ReciverBase<object>");
                sb.AppendLine("    {");
                sb.AppendLine();

                if (_useCase != null && _useCase.Entitys.Count > 0)
                {
                    sb.AppendLine("        private readonly IUnitOfWork _unitOfWork;");
                    sb.AppendLine($"        private readonly ILogger _logger;");
                    foreach (var entity in _useCase.Entitys)
                    {
                        sb.AppendLine($"        private readonly I{entity.EntityName}ReadRepository _repRead{entity.EntityName};");
                        sb.AppendLine($"        private readonly I{entity.EntityName}WriteRepository _repWrite{entity.EntityName};");
                    }

                    sb.Append($"        public {_classeReceiver}(IUnitOfWork unitOfWork,ILogger logger");
                    for (int i = 0; i < _useCase.Entitys.Count; i++)
                    {
                        var entity = _useCase.Entitys[i];
                        sb.Append($",I{entity.EntityName}ReadRepository repRead{entity.EntityName}, I{entity.EntityName}WriteRepository repWrite{entity.EntityName}");
                    }
                    sb.AppendLine(")");
                    sb.AppendLine("        {");

                    sb.AppendLine($"           _unitOfWork = unitOfWork;");
                    sb.AppendLine($"           _logger = logger;");


                    foreach (var entity in _useCase.Entitys)
                    {
                        sb.AppendLine($"            _repRead{entity.EntityName} = repRead{entity.EntityName};");
                        sb.AppendLine($"            _repWrite{entity.EntityName} = repWrite{entity.EntityName};");
                    }
                    sb.AppendLine("        }");
                }



                //sb.AppendLine($"        private readonly object _menssage;");
                //sb.AppendLine();
                //sb.AppendLine($"        public {_classe}(object menssage)");
                //sb.AppendLine("        {");
                //sb.AppendLine("            _menssage = menssage;");
                //sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine($"        protected override State<object> Action(ICommand comand)");
                sb.AppendLine("        {");
                sb.AppendLine("            try");
                sb.AppendLine("            {");
                // chamar o custon receiver

                //sb.AppendLine("                 Agent = getAgent(comand);    ");
                //sb.AppendLine("                 comand = Agent.getMenu(comand);    ");

                sb.AppendLine($"                 State<object> retorno = Success(\"OK\", ({_classeCommand})comand);");

                sb.AppendLine($"                 if (comand is {_nameSpaceCommand}.{_classeCommand} specificCommand)");

                sb.AppendLine("                 CustomActionHook(ref retorno, specificCommand);");
                sb.AppendLine("                 return retorno;");

                sb.AppendLine("            }");

                CQRSParam.I.AddExeptionReceiver(sb, $"object");

                sb.AppendLine("        }");
                sb.AppendLine($"partial void CustomActionHook(ref State<object> state, {_nameSpaceCommand}.{_classeCommand} comand);");
                sb.AppendLine("}");
                //foreach (var menu in _agent.Menus)
                //{
                //    sb.AppendLine($"           private List<string> {menu.Name.SourceType()}()");
                //    sb.AppendLine("            {");
                //    sb.AppendLine("                 return new List<string>() {");

                //    List<string> lista = new List<string>();
                //    lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
                //    lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));
                //    sb.AppendLine($"{string.Join(",", lista.Select(m => "\"" + m + "\""))}");
                //    sb.AppendLine("                ");
                //    sb.AppendLine("                 };");
                //    sb.AppendLine("            }");
                //}
                //sb.AppendLine("    }");




                //foreach (var menu in _agent.Menus)
                //{
                //    // Nome do enum baseado no menu
                //    string enumName = $"{menu.Name.SourceType()}";
                //    sb.AppendLine($"public enum {enumName}");
                //    sb.AppendLine("{");

                //    int id = 0; // Inicia um contador para os IDs

                //    // Adiciona submenus e opções ao enum
                //    List<string> lista = new List<string>();
                //    lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
                //    lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));

                //    foreach (var item in lista)
                //    {
                //        sb.AppendLine($"    {item} = {id},"); // Atribui um ID a cada item
                //        id++; // Incrementa o ID
                //    }

                //    sb.AppendLine("}");
                //    sb.AppendLine(); // Adiciona uma linha em branco entre os enums
                //}

                // name space
                sb.AppendLine("}");




                return sb;
            }
        }
        protected override StringBuilder GenerateCustonCode()
        {
            StringBuilder sb = new StringBuilder();
            // Adiciona os usings
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommands};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceUnitOfWork};");

            foreach (var scope in _useCase.Scopes)
                sb.AppendLine($"//using using Repositorio.Inputs.Repositorio.{scope};");

            sb.AppendLine();

            // Adiciona o namespace e a classe
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_classeReceiver}");
            sb.AppendLine("    {");

            sb.AppendLine("/*");


            sb.AppendLine("private readonly IUnitOfWork _unitOfWork;");
            foreach (var scope in _useCase.Scopes)
                sb.AppendLine($"private readonly I{scope} _{scope};");

            sb.AppendLine("" +
                "partial void CustomActionHook(ref State<object> state, Command.Commands.ContasCreateContaServiceMethodCommand comand)\r\n        {\r\n            try\r\n            {\r\n                _unitOfWork.BeginTran();\r\n                State userState = new Command.Receivers.Write.InsertY_UserReceiver(_repositoryUserWrite).Execute(new Commands.Y_UserCrudCommand() { Nome = comand.email, Email = comand.email, Senha = comand.password });\r\n                var usuario = userState.Data as Dominio.Entitys.Y_User.Y_UserEntity;\r\n\r\n                Command.Commands.Y_CompanyCrudCommand companyCommand = new Commands.Y_CompanyCrudCommand() { Nome = comand.email, UserIDAdmin = usuario.Id };\r\n                new Command.Receivers.Write.InsertY_CompanyReceiver(_repositoryCompanyWrite).Execute(companyCommand);\r\n\r\n                _unitOfWork.Commit();\r\n            }\r\n            catch (ReceiverException rex)\r\n            {\r\n                _unitOfWork.Rollback();\r\n                state = rex.State;\r\n            }\r\n            catch (Exception e)\r\n            {\r\n                Error(e, comand);\r\n            }\r\n        }" +
                "");

            sb.AppendLine("*/");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }


        public class ExportPaths
        {
            public string EnumPath { get; set; } = "";
            public string InterfacePath { get; set; } = "";
            public string ClassPath { get; set; } = "";
            public string CustomClassPath { get; set; } = "";
            public string FactoryInterfacePath { get; set; } = "";
            public string FactoryClassPath { get; set; } = "";
            public string DependencyInjectionPath { get; set; } = ""; // Novo path para DI
        }

        public static class TypeExporter
        {
            private static readonly HashSet<Type> ProcessedTypes = new();

            public static void ExportFromRootInterface(Type rootInterface, ExportPaths paths)
            {
                if (!rootInterface.IsInterface)
                    throw new InvalidOperationException("O tipo inicial deve ser uma interface.");

                ExportTypeRecursive(rootInterface, paths);
            }

            private static void ExportTypeRecursive(Type type, ExportPaths paths)
            {
                if (ProcessedTypes.Contains(type) || type.Namespace?.StartsWith("System") == true)
                    return;

                ProcessedTypes.Add(type);

                string folderPath = type.IsEnum ? paths.EnumPath :
                                    type.IsInterface ? paths.InterfacePath :
                                    paths.ClassPath;

                Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, $"{type.Name}.cs");

                using var writer = new StreamWriter(filePath);
                if (type.IsEnum)
                {
                    writer.WriteLine($"public enum {type.Name}");
                    writer.WriteLine("{");
                    foreach (var name in Enum.GetNames(type))
                        writer.WriteLine($"    {name},");
                    writer.WriteLine("}");
                }
                else if (type.IsInterface)
                {
                    writer.WriteLine($"public interface {type.Name}");
                    writer.WriteLine("{");

                    foreach (var prop in type.GetProperties())
                    {
                        writer.WriteLine($"    {prop.PropertyType.Name} {prop.Name} {{ get; }}");
                        ExportTypeRecursive(prop.PropertyType, paths);
                    }

                    foreach (var method in type.GetMethods().Where(m => m.DeclaringType == type))
                    {
                        foreach (var param in method.GetParameters())
                            ExportTypeRecursive(param.ParameterType, paths);

                        ExportTypeRecursive(method.ReturnType, paths);

                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        writer.WriteLine($"    {method.ReturnType.Name} {method.Name}({parameters});");
                    }

                    writer.WriteLine("}");

                    GenerateConcreteClassesForEnum(type, paths);
                }
            }

            private static void GenerateConcreteClassesForEnum(Type interfaceType, ExportPaths paths)
            {
                var enumProp = interfaceType.GetProperties()
                    .FirstOrDefault(p => p.PropertyType.IsEnum);

                if (enumProp == null)
                    return;

                Type enumType = enumProp.PropertyType;
                List<string> classNames = new();

                foreach (var enumValue in Enum.GetNames(enumType))
                {
                    string className = $"{enumValue}Notification";
                    classNames.Add(className);

                    // Gera Classe Base (Sempre)
                    Directory.CreateDirectory(paths.ClassPath);
                    string basePath = Path.Combine(paths.ClassPath, $"{className}.cs");
                    using (var writer = new StreamWriter(basePath))
                    {
                        writer.WriteLine($"public partial class {className} : {interfaceType.Name}");
                        writer.WriteLine("{");
                        writer.WriteLine($"    public {enumType.Name} Type => {enumType.Name}.{enumValue};");
                        writer.WriteLine();

                        foreach (var method in interfaceType.GetMethods())
                        {
                            string parameters = string.Join(", ",
                                method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                            writer.WriteLine($"    public partial {method.ReturnType.Name} {method.Name}({parameters});");
                        }

                        writer.WriteLine("}");
                    }

                    // Gera Classe Custom (Somente 1x)
                    Directory.CreateDirectory(paths.CustomClassPath);
                    string customPath = Path.Combine(paths.CustomClassPath, $"{className}.cs");
                    if (!File.Exists(customPath))
                    {
                        using (var writer = new StreamWriter(customPath))
                        {
                            writer.WriteLine($"public partial class {className}");
                            writer.WriteLine("{");
                            foreach (var method in interfaceType.GetMethods())
                            {
                                string parameters = string.Join(", ",
                                    method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                                writer.WriteLine($"    public partial {method.ReturnType.Name} {method.Name}({parameters})");
                                writer.WriteLine("    {");
                                writer.WriteLine("        throw new NotImplementedException();");
                                writer.WriteLine("    }");
                            }
                            writer.WriteLine("}");
                        }
                    }
                }

                // Gera Factory Interface e Concreta
                GenerateFactory(interfaceType, enumType, classNames, paths);
            }

            private static void GenerateFactory(Type interfaceType, Type enumType, List<string> classNames, ExportPaths paths)
            {
                string factoryInterfaceName = $"I{interfaceType.Name}Factory";
                string factoryClassName = $"{interfaceType.Name.TrimStart('I')}Factory";

                // Interface da Factory
                Directory.CreateDirectory(paths.FactoryInterfacePath);
                string interfacePath = Path.Combine(paths.FactoryInterfacePath, $"{factoryInterfaceName}.cs");
                using (var writer = new StreamWriter(interfacePath))
                {
                    writer.WriteLine($"public interface {factoryInterfaceName}");
                    writer.WriteLine("{");
                    writer.WriteLine($"    {interfaceType.Name} GetType({enumType.Name} type);");
                    writer.WriteLine("}");
                }

                // Factory Concreta
                Directory.CreateDirectory(paths.FactoryClassPath);
                string classPath = Path.Combine(paths.FactoryClassPath, $"{factoryClassName}.cs");
                using (var writer = new StreamWriter(classPath))
                {
                    writer.WriteLine($"public class {factoryClassName} : {factoryInterfaceName}");
                    writer.WriteLine("{");
                    foreach (var className in classNames)
                        writer.WriteLine($"    private readonly {className} _{className.ToLower()};");
                    writer.WriteLine();
                    writer.WriteLine($"    public {factoryClassName}(");
                    writer.WriteLine(string.Join(",\n", classNames.Select(c => $"        {c} {c.ToLower()}")));
                    writer.WriteLine("    )");
                    writer.WriteLine("    {");
                    foreach (var className in classNames)
                        writer.WriteLine($"        _{className.ToLower()} = {className.ToLower()};");
                    writer.WriteLine("    }");
                    writer.WriteLine();
                    writer.WriteLine($"    public {interfaceType.Name} GetType({enumType.Name} type)");
                    writer.WriteLine("    {");
                    writer.WriteLine("        return type switch");
                    writer.WriteLine("        {");
                    foreach (var className in classNames)
                    {
                        string enumValue = className.Replace("Notification", "");
                        writer.WriteLine($"            {enumType.Name}.{enumValue} => _{className.ToLower()},");
                    }
                    writer.WriteLine("            _ => throw new ArgumentException(\"Invalid Type\")");
                    writer.WriteLine("        };");
                    writer.WriteLine("    }");
                    writer.WriteLine("}");
                }
                GenerateDependencyInjectionFile(interfaceType, classNames, paths);

            }

            private static void GenerateDependencyInjectionFile(Type interfaceType, List<string> classNames, ExportPaths paths)
            {
                string fileName = $"{interfaceType.Name.TrimStart('I')}DependencyInjection.cs";
                string filePath = Path.Combine(paths.DependencyInjectionPath, fileName);
                Directory.CreateDirectory(paths.DependencyInjectionPath);

                string factoryInterfaceName = $"I{interfaceType.Name}Factory";
                string factoryClassName = $"{interfaceType.Name.TrimStart('I')}Factory";

                using var writer = new StreamWriter(filePath);
                writer.WriteLine("using Microsoft.Extensions.DependencyInjection;");
                writer.WriteLine();
                writer.WriteLine($"public static class {interfaceType.Name.TrimStart('I')}DependencyInjection");
                writer.WriteLine("{");
                writer.WriteLine($"    public static IServiceCollection Add{interfaceType.Name.TrimStart('I')}Services(this IServiceCollection services)");
                writer.WriteLine("    {");

                foreach (var className in classNames)
                    writer.WriteLine($"        services.AddScoped<{className}>();");

                writer.WriteLine();
                writer.WriteLine($"        services.AddScoped<{factoryInterfaceName}, {factoryClassName}>();");
                writer.WriteLine();
                writer.WriteLine("        return services;");
                writer.WriteLine("    }");
                writer.WriteLine("}");
            }


        }







    }
}