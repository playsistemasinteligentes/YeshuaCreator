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

        public string NameSpaceCommandRead { get; set; } = "Command.Read";
        public string NameSpaceCommandWrite { get; internal set; } = "Command.Write";
        public string NameSpaceCommandPatterns { get; internal set; } = "Command.Patterns.Command";
        public string NameSpaceCommandCommandsUseCases { get; set; } = "Command.UseCase";
        public string NameSpaceCommandCommandsSaga { get; set; } = "Command.Saga";
        public string NameSpaceCommandReceiversHub { get; set; } = "Command.Receivers";
        public string NameSpaceCommandReceiversUseCase { get; set; } = "Command.Receivers.UseCase";
        public string NameSpaceCommandReceiversRead { get; set; } = "Command.Receivers.Read";
        public string NameSpaceCommandReceiversWrite { get; set; } = "Command.Receivers.Write";
        public List<string> ColumnsDescriptions { get; set; } = new List<string> { "nome", "descricao" };
        public object NameSpaceEntitys { get; set; } = "Dominio.Entitys";
        public object NameSpaceiEntitys { get; set; } = "Dominio.Entitys";  // DEBITO
        public object NameSpaceDominioInterface { get; set; } = "Dominio.Interfaces";
        public object NameSpaceCommandsPartners { get; set; } = "Command.Patterns.Command";
        public object NameSpaceInterfaceCommandsPartners { get; set; } = "RepositoryInterfaces.Patterns.Command";
        public object NameSpaceInterfaceRepositoryPartners { get; set; } = "RepositoryInterfaces.Patterns.Repository";
        public object NameSpaceIRepositoryRead { get; set; } = "IRepository.Read";
        public object NameSpaceIRepositoryWrite { get; set; } = "IRepository.Write";
        public object NameSpaceIQueryWrite { get; set; } = "IQuery.Write";
        public object NameSpaceQueryWrite { get; set; } = "Query.Write";
        public object NameSpaceIQueryRead { get; set; } = "IQuery.Read";
        public object NameSpaceQueryRead { get; set; } = "Query.Read";
        public object NameSpaceIterfaceAplicationServices { get; set; } = "Aplication.Interfaces.Services";
        public object NameSpaceUnitOfWork { get; set; } = "RepositoryInterfaces.Patterns.UnitOfWork";
        public object NameSpaceEnumStrategy { get; set; } = "Dominio.Enum.Strategy";
        public string NameSpaceClassesConcretasStrategy { get; set; } = "Shered.Patterns.Strategy";
        public object NameSpaceReadRepository { get; set; } = "Read.Repository";
        public object NameSpaceModules { get; set; } = "Modules";



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
