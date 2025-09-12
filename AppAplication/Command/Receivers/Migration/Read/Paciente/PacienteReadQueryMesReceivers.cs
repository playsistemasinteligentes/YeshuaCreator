using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class PacienteReadQueryMesReceiver : ReciverBase<DataPagination<PacienteStandardDTO>>
    {
        private readonly IPacienteReadRepository _repository;
        private readonly ILogger _logger;

        public PacienteReadQueryMesReceiver(IPacienteReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<PacienteStandardDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.PacienteMesCommand c) 
             {    
                var PacienteReadRepository = _repository.GetPacienteMes(c);
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