using Comandos.Pateners.Command;
using Dominio.Entitys.MovimentacaoFinanceira;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
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
            var c = (Command.Commands.MovimentacaoFinanceiraCrudCommand)comand;

            var movimentacaofinanceira = new MovimentacaoFinanceiraEntity(c.Id, c.PacienteId, c.ServicoId, c.Valor, c.TipoMovimentacao, c.DataMovimentacao, c.SaldoAtual);
            if (!movimentacaofinanceira.isValidDelete())
                return new State(300, movimentacaofinanceira.getErroMensagens(), comand);

            try
            {
                _repository.Delete(movimentacaofinanceira);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, e, comand);
            }
        }
    }
}
