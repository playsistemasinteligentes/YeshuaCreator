using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteFinanceiroParaAdministrador
{
    public partial class AgenteFinanceiroParaAdministradorHubAgentReceiver : ReciverBase<ICommand,AgenteFinanceiroParaAdministradorHubAgentReceiver>
    {

        public AgenteFinanceiroParaAdministradorHubAgentReceiver(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
        }


        protected override State<AgenteFinanceiroParaAdministradorHubAgentReceiver> Action(ICommand comand)
        {
            try
            {
                return Success("OK", null);
            }
            catch (ReceiverException<AgenteFinanceiroParaAdministradorHubAgentReceiver> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
           private List<string> MenuAdministrativoFinanceiro()
            {
                 return new List<string>() {
"VerificarSaldoTotalDaClínica","VerificarTransaçõesFinanceiras","EmitirRelatórioFinanceiro"
                
                 };
            }
    }
public enum MenuAdministrativoFinanceiro
{
    VerificarSaldoTotalDaClínica = 0,
    VerificarTransaçõesFinanceiras = 1,
    EmitirRelatórioFinanceiro = 2,
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents