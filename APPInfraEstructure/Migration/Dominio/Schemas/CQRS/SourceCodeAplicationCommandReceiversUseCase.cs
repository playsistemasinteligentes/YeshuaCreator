
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
        private ExportPathsSourceCodeAplicationCommandReceiversUseCase _exportPath;

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
        public SourceCodeAplicationCommandReceiversUseCase(UseCase useCase, Type type, ExportPathsSourceCodeAplicationCommandReceiversUseCase exportPath, ref List<CodigoGerado> CodigoGerado)
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
            _exportPath = exportPath;

            CodigoGerado = TypeExporter.ExportFromRootInterface(_type, _exportPath);
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






        public class ExportPathsSourceCodeAplicationCommandReceiversUseCase
        {
            public string EnumPath { get; set; } = "";
            public string InterfacePath { get; set; } = "";
            public string ClassPath { get; set; } = "";
            public string CustomClassPath { get; set; } = "";
            public string FactoryInterfacePath { get; set; } = "";
            public string FactoryClassPath { get; set; } = "";
            public string DependencyInjectionPath { get; set; } = "";

            public string EnumNamespace { get; set; } = "MyProject.Enums";
            public string InterfaceNamespace { get; set; } = "MyProject.Interfaces";
            public string ClassNamespace { get; set; } = "MyProject.Classes";
            public string CustomClassNamespace { get; set; } = "MyProject.CustomClasses";
            public string FactoryInterfaceNamespace { get; set; } = "MyProject.Factories.Interfaces";
            public string FactoryClassNamespace { get; set; } = "MyProject.Factories";
            public string DependencyInjectionNamespace { get; set; } = "MyProject.DependencyInjection";
        }

        public class CodigoGerado
        {
            public string CaminhoArquivo { get; set; } = string.Empty;
            public StringBuilder Conteudo { get; set; } = new StringBuilder();
            public bool Custom { get; set; } = false;
        }

        public static class TypeExporter
        {
            private static readonly HashSet<Type> ProcessedTypes = new();

            public static List<CodigoGerado> ExportFromRootInterface(Type rootInterface, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                if (!rootInterface.IsInterface)
                    throw new InvalidOperationException("O tipo inicial deve ser uma interface.");

                List<CodigoGerado> codigos = new();
                ExportTypeRecursive(rootInterface, paths, codigos);
                return codigos;
            }

            private static void ExportTypeRecursive(Type type, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths, List<CodigoGerado> codigos)
            {
                if (ProcessedTypes.Contains(type) || type.Namespace?.StartsWith("System") == true)
                    return;

                ProcessedTypes.Add(type);

                string folderPath = type.IsEnum ? paths.EnumPath :
                                    type.IsInterface ? paths.InterfacePath :
                                    paths.ClassPath;
                string filePath = Path.Combine(folderPath, $"{type.Name}.cs");

                StringBuilder sb = new();

                HashSet<string> dependencies = CollectDependencies(type, paths);
                foreach (var dep in dependencies)
                {
                    sb.AppendLine($"using {dep};");
                }

                sb.AppendLine();
                string ns = type.IsEnum ? paths.EnumNamespace :
                             type.IsInterface ? paths.InterfaceNamespace :
                             paths.ClassNamespace;

                if (type.IsEnum)
                {
                    sb.AppendLine($"namespace {ns};");
                    sb.AppendLine();

                    sb.AppendLine($"public enum {type.Name}");
                    sb.AppendLine("{");
                    foreach (var value in Enum.GetValues(type))
                    {
                        int intValue = (int)value!;
                        string name = Enum.GetName(type, value)!;
                        sb.AppendLine($"    {name} = {intValue},");
                    }
                    sb.AppendLine("}");
                    codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });

                }
                else if (type.IsInterface)
                {
                    sb.AppendLine($"using {paths.EnumNamespace};");
                    sb.AppendLine($"namespace {ns};");
                    sb.AppendLine();

                    sb.AppendLine($"public interface {type.Name}");
                    sb.AppendLine("{");

                    foreach (var prop in type.GetProperties())
                    {
                        sb.AppendLine($"    {prop.PropertyType.Name} {prop.Name} {{ get; }}");
                        ExportTypeRecursive(prop.PropertyType, paths, codigos);
                    }

                    foreach (var method in type.GetMethods().Where(m => m.DeclaringType == type && !m.IsSpecialName))
                    {
                        foreach (var param in method.GetParameters())
                            ExportTypeRecursive(param.ParameterType, paths, codigos);

                        ExportTypeRecursive(method.ReturnType, paths, codigos);

                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        string returnType = method.ReturnType == typeof(void) ? "void" : method.ReturnType.Name;
                        sb.AppendLine($"    {returnType} {method.Name}({parameters});");
                    }

                    sb.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });
                    codigos.AddRange(GenerateConcreteClassesForEnum(type, paths));
                }
                else
                {
                    codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });
                }
            }

            private static HashSet<string> CollectDependencies(Type type, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                HashSet<string> namespaces = new();

                void AddNamespace(Type t)
                {
                    if (t.Namespace != null &&
                        !t.Namespace.StartsWith("System") &&
                        t.Namespace != type.Namespace)
                    {
                        namespaces.Add(t.Namespace);
                    }
                }

                if (type.IsEnum) return namespaces;

                foreach (var prop in type.GetProperties())
                    AddNamespace(prop.PropertyType);

                foreach (var method in type.GetMethods().Where(m => m.DeclaringType == type && !m.IsSpecialName))
                {
                    AddNamespace(method.ReturnType);
                    foreach (var param in method.GetParameters())
                        AddNamespace(param.ParameterType);
                }

                return namespaces;
            }

            private static List<CodigoGerado> GenerateConcreteClassesForEnum(Type interfaceType, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                List<CodigoGerado> codigos = new();
                var enumProp = interfaceType.GetProperties()
                    .FirstOrDefault(p => p.PropertyType.IsEnum);

                if (enumProp == null)
                    return codigos;

                Type enumType = enumProp.PropertyType;
                List<string> classNames = new();

                foreach (var enumValue in Enum.GetNames(enumType))
                {
                    string className = $"{enumValue}Notification";
                    classNames.Add(className);

                    string classFilePath = Path.Combine(paths.ClassPath, $"{className}.cs");
                    StringBuilder sbClass = new();
                    sbClass.AppendLine($"using {paths.InterfaceNamespace};");
                    sbClass.AppendLine($"using {paths.EnumNamespace};");
                    sbClass.AppendLine();
                    sbClass.AppendLine($"namespace {paths.ClassNamespace};");
                    sbClass.AppendLine();
                    sbClass.AppendLine($"public partial class {className} : {interfaceType.Name}");
                    sbClass.AppendLine("{");
                    sbClass.AppendLine($"    public {enumType.Name} Type => {enumType.Name}.{enumValue};");
                    sbClass.AppendLine();

                    foreach (var method in interfaceType.GetMethods().Where(m => !m.IsSpecialName))
                    {
                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        string returnType = method.ReturnType == typeof(void) ? "void" : method.ReturnType.Name;

                        sbClass.AppendLine($"    public partial {returnType} {method.Name}({parameters});");
                    }

                    sbClass.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = classFilePath, Conteudo = sbClass });

                    string customFilePath = Path.Combine(paths.CustomClassPath, $"{className}.cs");
                    StringBuilder sbCustom = new();
                    sbCustom.AppendLine($"using {paths.InterfaceNamespace};");
                    sbCustom.AppendLine($"using {paths.EnumNamespace};");

                    sbCustom.AppendLine($"namespace {paths.CustomClassNamespace};");
                    sbCustom.AppendLine();
                    sbCustom.AppendLine($"public partial class {className}");
                    sbCustom.AppendLine("{");
                    foreach (var method in interfaceType.GetMethods().Where(m => !m.IsSpecialName))
                    {
                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        string returnType = method.ReturnType == typeof(void) ? "void" : method.ReturnType.Name;

                        sbCustom.AppendLine($"    public partial {returnType} {method.Name}({parameters})");
                        sbCustom.AppendLine("    {");
                        sbCustom.AppendLine("        throw new NotImplementedException();");
                        sbCustom.AppendLine("    }");
                    }
                    sbCustom.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = customFilePath, Conteudo = sbCustom, Custom = true });
                }

                codigos.AddRange(GenerateFactory(interfaceType, enumType, classNames, paths));
                return codigos;
            }

            private static List<CodigoGerado> GenerateFactory(Type interfaceType, Type enumType, List<string> classNames, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                List<CodigoGerado> codigos = new();

                string factoryInterfaceName = $"I{interfaceType.Name}Factory";
                string factoryClassName = $"{interfaceType.Name.TrimStart('I')}Factory";

                string interfaceFilePath = Path.Combine(paths.FactoryInterfacePath, $"{factoryInterfaceName}.cs");
                StringBuilder sbInterface = new();
                sbInterface.AppendLine($"using {paths.InterfaceNamespace};");
                sbInterface.AppendLine($"using {paths.EnumNamespace};");
                sbInterface.AppendLine();
                sbInterface.AppendLine($"namespace {paths.FactoryInterfaceNamespace};");
                sbInterface.AppendLine();
                sbInterface.AppendLine($"public interface {factoryInterfaceName}");
                sbInterface.AppendLine("{");
                sbInterface.AppendLine($"    {interfaceType.Name} GetType({enumType.Name} type);");
                sbInterface.AppendLine("}");

                codigos.Add(new CodigoGerado { CaminhoArquivo = interfaceFilePath, Conteudo = sbInterface });

                string classFilePath = Path.Combine(paths.FactoryClassPath, $"{factoryClassName}.cs");
                StringBuilder sbClass = new();
                sbClass.AppendLine($"using {paths.InterfaceNamespace};");
                sbClass.AppendLine($"using {paths.EnumNamespace};");
                sbClass.AppendLine($"using {paths.ClassNamespace};");
                sbClass.AppendLine();
                sbClass.AppendLine($"namespace {paths.FactoryClassNamespace};");
                sbClass.AppendLine();
                sbClass.AppendLine($"public class {factoryClassName} : {factoryInterfaceName}");
                sbClass.AppendLine("{");
                foreach (var className in classNames)
                    sbClass.AppendLine($"    private readonly {className} _{className.ToLower()};");
                sbClass.AppendLine();
                sbClass.AppendLine($"    public {factoryClassName}(");
                sbClass.AppendLine(string.Join(",\n", classNames.Select(c => $"        {c} {c.ToLower()}")));
                sbClass.AppendLine("    )");
                sbClass.AppendLine("    {");
                foreach (var className in classNames)
                    sbClass.AppendLine($"        _{className.ToLower()} = {className.ToLower()};");
                sbClass.AppendLine("    }");
                sbClass.AppendLine();
                sbClass.AppendLine($"    public {interfaceType.Name} GetType({enumType.Name} type)");
                sbClass.AppendLine("    {");
                sbClass.AppendLine("        return type switch");
                sbClass.AppendLine("        {");
                foreach (var className in classNames)
                {
                    string enumValue = className.Replace("Notification", "");
                    sbClass.AppendLine($"            {enumType.Name}.{enumValue} => _{className.ToLower()},");
                }
                sbClass.AppendLine("            _ => throw new ArgumentException(\"Invalid Type\")");
                sbClass.AppendLine("        };\n    }\n}");

                codigos.Add(new CodigoGerado { CaminhoArquivo = classFilePath, Conteudo = sbClass });

                codigos.AddRange(GenerateDependencyInjectionFile(interfaceType, classNames, paths));
                return codigos;
            }

            private static List<CodigoGerado> GenerateDependencyInjectionFile(Type interfaceType, List<string> classNames, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                List<CodigoGerado> codigos = new();

                string fileName = $"{interfaceType.Name.TrimStart('I')}DependencyInjection.cs";
                string filePath = Path.Combine(paths.DependencyInjectionPath, fileName);

                string factoryInterfaceName = $"I{interfaceType.Name}Factory";
                string factoryClassName = $"{interfaceType.Name.TrimStart('I')}Factory";

                StringBuilder sb = new();
                sb.AppendLine($"/*");

                foreach (var className in classNames)
                    sb.AppendLine($"        services.AddScoped<{className}>();");

                sb.AppendLine($"        services.AddScoped<{factoryInterfaceName}, {factoryClassName}>();");
                sb.AppendLine($"*/");

                codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });
                return codigos;
            }
        }






    }
}