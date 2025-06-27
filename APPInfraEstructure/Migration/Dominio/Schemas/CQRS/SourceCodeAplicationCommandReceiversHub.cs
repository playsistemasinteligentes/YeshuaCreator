
using Migration.Dominio;
using static Dapper.SqlMapper;
using System.Text;
using Migration.Dominio.Schemas.CQRS;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandReceiversHub : SourceCodeBase
    {
        private Hub _hub;
        private CommandType _commandType;
        private Service _service;
        private Method _method;
        private string _nameSpace;
        private string _nameSpaceCommand;
        private string _classeReceiver;
        private string _classeCommand;

        public SourceCodeAplicationCommandReceiversHub(Hub hub)
            : base()
        {
            _hub = hub;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversHub;
            _commandType = CommandType.Hub;
        }
        public SourceCodeAplicationCommandReceiversHub(Method method)
            : base()
        {
            _hub = method.Hub;
            _service = method.Service;
            _commandType = CommandType.ServiceMethod;
            _method = method;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversHubServiceMethod;
            _nameSpaceCommand = CQRSParam.I.NameSpaceCommandCommandsHubServiceMethod;
            _classeReceiver = $"{_service.Name.SourceType()}{_method.Name.SourceType()}{_commandType}Receiver";
            _classeCommand = $"{_service.Name.SourceType()}{_method.Name.SourceType()}{_commandType}Command";
        }
        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();
            // Adiciona os usings
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommands};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
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
        protected override StringBuilder GenerateCustonCode()
        {
            StringBuilder sb = new StringBuilder();
            // Adiciona os usings
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommands};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");

            sb.AppendLine("using RepositoryInterfaces.Patterns.UnitOfWork;");
            foreach (var scope in _method.Scopes)
                sb.AppendLine($"//using using Repositorio.Inputs.Repositorio.{scope};");

            sb.AppendLine();

            // Adiciona o namespace e a classe
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_classeReceiver}");
            sb.AppendLine("    {");

            sb.AppendLine("/*");


            sb.AppendLine("private readonly IUnitOfWork _unitOfWork;");
            foreach (var scope in _method.Scopes)
                sb.AppendLine($"private readonly I{scope} _{scope};");

            sb.AppendLine("" +
                "partial void CustomActionHook(ref State<object> state, Command.Commands.ContasCreateContaServiceMethodCommand comand)\r\n        {\r\n            try\r\n            {\r\n                _unitOfWork.BeginTran();\r\n                State userState = new Command.Receivers.Write.InsertY_UserReceiver(_repositoryUserWrite).Execute(new Commands.Y_UserCrudCommand() { Nome = comand.email, Email = comand.email, Senha = comand.password });\r\n                var usuario = userState.Data as Dominio.Entitys.Y_User.Y_UserEntity;\r\n\r\n                Command.Commands.Y_CompanyCrudCommand companyCommand = new Commands.Y_CompanyCrudCommand() { Nome = comand.email, UserIDAdmin = usuario.Id };\r\n                new Command.Receivers.Write.InsertY_CompanyReceiver(_repositoryCompanyWrite).Execute(companyCommand);\r\n\r\n                _unitOfWork.Commit();\r\n            }\r\n            catch (ReceiverException rex)\r\n            {\r\n                _unitOfWork.Rollback();\r\n                state = rex.State;\r\n            }\r\n            catch (Exception e)\r\n            {\r\n                Error(e, comand);\r\n            }\r\n        }" +
                "");

            sb.AppendLine("*/");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }
    }
}