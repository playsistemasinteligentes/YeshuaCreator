using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class PacienteReadReceiver : ReciverBase<DataPagination<PacienteDTO>>
    {
        private readonly IPacienteReadRepository _repository;
        private readonly ILogger _logger;

        public PacienteReadReceiver(IPacienteReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<PacienteDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.PacienteReadCommand c) 
             {    
                var PacienteReadRepository = _repository.getPaciente(c);
                return Success("OK", PacienteReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration