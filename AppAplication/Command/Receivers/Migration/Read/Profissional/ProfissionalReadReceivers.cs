using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class ProfissionalReadReceiver : ReciverBase<DataPagination<ProfissionalDTO>>
    {
        private readonly IProfissionalReadRepository _repository;
        private readonly ILogger _logger;

        public ProfissionalReadReceiver(IProfissionalReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<ProfissionalDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.ProfissionalReadCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissional(c);
                return Success("OK", ProfissionalReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration