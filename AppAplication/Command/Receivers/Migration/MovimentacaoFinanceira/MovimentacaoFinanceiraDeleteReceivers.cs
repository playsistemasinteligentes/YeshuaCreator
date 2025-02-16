using Comandos.Pateners.Command;
using Dominio.Entitys.MovimentacaoFinanceira;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.MovimentacaoFinanceira
{
    public class DeleteMovimentacaoFinanceiraReceiver : ReciverBase
    {
        private readonly IMovimentacaoFinanceiraWriteRepository _repository;

        public DeleteMovimentacaoFinanceiraReceiver(IMovimentacaoFinanceiraWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.MovimentacaoFinanceiraCommand)comand;

            var movimentacaofinanceira = new MovimentacaoFinanceiraEntity(c.Id, c.PacienteId, c.ServicoId, c.Valor, c.TipoMovimentacao, c.DataMovimentacao, c.SaldoAtual);
            if (!movimentacaofinanceira.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Delete(movimentacaofinanceira);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
