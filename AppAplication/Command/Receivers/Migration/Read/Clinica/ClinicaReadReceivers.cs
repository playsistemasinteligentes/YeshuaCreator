using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Clinica;
using Repositorio.Outputs.DTOs.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;

namespace Command.Receivers.Read
{
    public class ClinicaReadReceiver : ReciverBase<IEnumerable<ClinicaDTO>>
    {
        private readonly IClinicaReadRepository _repository;

        public ClinicaReadReceiver(IClinicaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<ClinicaDTO>> Action(ICommand comand)
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