using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class EspecialidadeReadReceiver : ReciverBase<ICommand, DataPagination<EspecialidadeDTO>>
    {
        private readonly IEspecialidadeReadRepository _repository;
        private readonly ILogger _logger;

        public EspecialidadeReadReceiver(IEspecialidadeReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<EspecialidadeDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.EspecialidadeReadCommand c) 
             {    
                var EspecialidadeReadRepository = _repository.getEspecialidade(c);
                return Success("OK", EspecialidadeReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration