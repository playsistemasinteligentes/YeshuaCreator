using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteFinanceiroParaAdministrador
{
    public partial class AgenteFinanceiroParaAdministradorHubAgentReceiver : ReciverBase
    {

        private readonly object _menssage;

        public AgenteFinanceiroParaAdministradorHubAgentReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State Action(ICommand comand)
        {
            try
            {
                return Success("OK", comand);
            }
            catch (ReceiverException e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, comand);
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