using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadReceiver : ReciverBase<IEnumerable<MovimentacaoFinanceiraDTO>>
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;

        public MovimentacaoFinanceiraReadReceiver(IMovimentacaoFinanceiraReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<MovimentacaoFinanceiraDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.MovimentacaoFinanceiraReadCommand c) 
             {    
                var MovimentacaoFinanceiraReadRepository = _repository.getMovimentacaoFinanceira(c);
                return Success("OK", MovimentacaoFinanceiraReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration