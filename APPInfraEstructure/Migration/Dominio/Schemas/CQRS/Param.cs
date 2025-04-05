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
        public string NameSpaceCommandCommandsHubServiceMethod { get; set; } = "Command.Commands";
        public string NameSpaceCommandReceiversHub { get; set; } = "Command.Receivers";
        public string NameSpaceCommandReceiversHubServiceMethod { get; set; } = "Command.Receivers.HubServiceMethod";
        public string NameSpaceCommandReceiversRead { get; set; } = "Command.Receivers.Read";
        public string NameSpaceCommandReceiversWrite { get; set; } = "Command.Receivers.Write";
        public List<string> ColumnsDescriptions { get; set; } = new List<string> { "nome", "descricao" };

        public void AddExeptionReceiver(StringBuilder sb)
        {
            sb.AppendLine("            catch (ReceiverException e)");
            sb.AppendLine("            {");
            sb.AppendLine("                return e.State;");
            sb.AppendLine("            }");

            sb.AppendLine("            catch (Exception e)");
            sb.AppendLine("            {");
            sb.AppendLine("                return Error(e, comand);");
            sb.AppendLine("            }");
        }
        private CQRSParam() { }
    }
}
