using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio.Schemas.CQRS
{
    public sealed class CQRSParam
    {
        private static readonly Lazy<CQRSParam> _instance = new(() => new CQRSParam());

        public static CQRSParam I => _instance.Value;

        public string NameSpaceCommandsRead { get; set; } = "Command.Commands.Read";
        public string NameSpaceCommands { get; internal set; } = "Command.Commands";
        public string NameSpaceCommandsPatterns { get; internal set; } = "Command.Patterns.Command";
        public string NameSpaceCommandCommandsUseCases { get; set; } = "Command.Commands";
        public string NameSpaceCommandReceiversHub { get; set; } = "Command.Receivers";
        public string NameSpaceCommandReceiversUseCase { get; set; } = "Command.Receivers.UseCase";
        public string NameSpaceCommandReceiversRead { get; set; } = "Command.Receivers.Read";
        public string NameSpaceCommandReceiversWrite { get; set; } = "Command.Receivers.Write";
        public List<string> ColumnsDescriptions { get; set; } = new List<string> { "nome", "descricao" };
        public object NameSpaceEntitys { get; set; } = "Dominio.Entitys";
        public object NameSpaceDominioInterface { get; set; } = "Dominio.Interfaces";
        public object NameSpaceCommandsPartners { get; set; } = "Command.Patterns.Command";
        public object NameSpaceInterfaceCommandsPartners { get; set; } = "RepositoryInterfaces.Patterns.Command";
        public object NameSpaceInterfaceRepositoryPartners { get; set; } = "RepositoryInterfaces.Patterns.Repository";
        public object NameSpaceRepositorioInputsRepositorio { get; set; } = "Repositorio.Inputs.Repositorio"; // trocar mais pra frente padronozar com o de baixo 
        public object NameSpaceReadRepository { get; set; } = "RepositoryInterfaces.Read.Repository";
        public object NameSpaceUnitOfWork { get; set; } = "RepositoryInterfaces.Patterns.UnitOfWork";
        public object NameSpaceEnumStrategy { get; set; } = "Dominio.Enum.Strategy";

        public void AddExeptionReceiver(StringBuilder sb, string classe)
        {
            sb.AppendLine($"            catch (ReceiverException<{classe}> e)");
            sb.AppendLine("            {");
            sb.AppendLine("                return e.State;");
            sb.AppendLine("            }");

            sb.AppendLine("            catch (Exception e)");
            sb.AppendLine("            {");
            sb.AppendLine("                return Error(e, default);");
            sb.AppendLine("            }");
        }
        private CQRSParam() { }
    }
}
