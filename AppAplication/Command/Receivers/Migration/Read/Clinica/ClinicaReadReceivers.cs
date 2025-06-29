using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Clinica;
using Repositorio.Outputs.DTOs.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;

namespace Command.Receivers.Read
{
    public class ClinicaReadReceiver : ReciverBase<DataPagination<ClinicaDTO>>
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
            if(comand is Command.Commands.Read.ClinicaReadCommand c) 
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