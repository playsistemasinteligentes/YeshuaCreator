using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;
using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadFKPacienteIdReceiver : ReciverBase<IEnumerable<MovimentacaoFinanceiraPacienteIdDTO>>
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;

        public MovimentacaoFinanceiraReadFKPacienteIdReceiver(IMovimentacaoFinanceiraReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<MovimentacaoFinanceiraPacienteIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var MovimentacaoFinanceiraReadRepository = _repository.getMovimentacaoFinanceiraReadFKPacienteId(c);
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