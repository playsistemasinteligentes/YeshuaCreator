using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class ServicoReadReceiver : ReciverBase<DataPagination<ServicoDTO>>
    {
        private readonly IServicoReadRepository _repository;
        private readonly ILogger _logger;

        public ServicoReadReceiver(IServicoReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<ServicoDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.ServicoReadCommand c) 
             {    
                var ServicoReadRepository = _repository.getServico(c);
                return Success("OK", ServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration