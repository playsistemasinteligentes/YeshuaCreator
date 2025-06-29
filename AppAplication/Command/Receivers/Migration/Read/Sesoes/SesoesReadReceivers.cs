using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Sesoes;
using Repositorio.Outputs.DTOs.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadReceiver : ReciverBase<DataPagination<SesoesDTO>>
    {
        private readonly ISesoesReadRepository _repository;
        private readonly ILogger _logger;

        public SesoesReadReceiver(ISesoesReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<SesoesDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.SesoesReadCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoes(c);
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