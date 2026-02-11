using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class ClinicaReadReceiver : ReciverBase<ICommand, DataPagination<ClinicaDTO>>
    {
        private readonly IClinicaReadRepository _repository;
        private readonly ILogger _logger;

        public ClinicaReadReceiver(IClinicaReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<ClinicaDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.ClinicaReadCommand c) 
             {    
                var ClinicaReadRepository = _repository.getClinica(c);
                return Success("OK", ClinicaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration