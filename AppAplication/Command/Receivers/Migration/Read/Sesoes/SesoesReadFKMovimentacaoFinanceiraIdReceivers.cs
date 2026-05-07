using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class SesoesReadFKMovimentacaoFinanceiraIdReceiver : ReciverBase<ICommand, IEnumerable<SesoesMovimentacaoFinanceiraIdDTO>>
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadFKMovimentacaoFinanceiraIdReceiver(
            ISesoesReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<SesoesMovimentacaoFinanceiraIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoesReadFKMovimentacaoFinanceiraId(c);
                return Success("OK", SesoesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration