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
                comand = getMenu();
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
        private List<string> MenuAdministrativoFinanceiro()
        {
            return new List<string>() {
                                "VerificarSaldoTotalDaClínica",
                                "VerificarTransaçõesFinanceiras",
                                "EmitirRelatórioFinanceiro"

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
