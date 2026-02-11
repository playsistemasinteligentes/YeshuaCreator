using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class PacienteReadQueryGeralReceiver : ReciverBase<ICommand, DataPagination<PacienteStandardDTO>>
    {
        private readonly IPacienteReadRepository _repository;
        private readonly ILogger _logger;

        public PacienteReadQueryGeralReceiver(IPacienteReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<PacienteStandardDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.PacienteGeralCommand c) 
             {    
                var PacienteReadRepository = _repository.GetPacienteGeral(c);
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