using Comandos.Pateners.Command;
using Dominio.Entitys.MovimentacaoFinanceira;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadReceiver : ReciverBase
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;

        public MovimentacaoFinanceiraReadReceiver(IMovimentacaoFinanceiraReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var MovimentacaoFinanceiraReadRepository = _repository.getAllMovimentacaoFinanceira();
            return new State(200, "OK", MovimentacaoFinanceiraReadRepository);
        }
    }
}
