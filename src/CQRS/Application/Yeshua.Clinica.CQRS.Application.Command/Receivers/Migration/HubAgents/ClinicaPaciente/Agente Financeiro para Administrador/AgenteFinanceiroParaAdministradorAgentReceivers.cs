// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents
// </yeshua>

using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteFinanceiroParaAdministrador
{
    public partial class AgenteFinanceiroParaAdministradorHubAgentReceiver : ReciverBase<ICommand,AgenteFinanceiroParaAdministradorHubAgentReceiver>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public AgenteFinanceiroParaAdministradorHubAgentReceiver(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override Task<State<AgenteFinanceiroParaAdministradorHubAgentReceiver>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                return Task.FromResult(Success("OK"));
            }
            catch (ReceiverException<AgenteFinanceiroParaAdministradorHubAgentReceiver> e)
            {
                return Task.FromResult(e.State);
            }
            catch (Exception e)
            {
                return Task.FromResult(Error(e));
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