using Comandos.Pateners.Command;
using Dominio.Entitys.MovimentacaoFinanceira;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadFKPacienteIdReceiver : ReciverBase
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;

        public MovimentacaoFinanceiraReadFKPacienteIdReceiver(IMovimentacaoFinanceiraReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var MovimentacaoFinanceiraReadRepository = _repository.getMovimentacaoFinanceiraReadFKPacienteId(c);
                return new State(200, "OK", MovimentacaoFinanceiraReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration