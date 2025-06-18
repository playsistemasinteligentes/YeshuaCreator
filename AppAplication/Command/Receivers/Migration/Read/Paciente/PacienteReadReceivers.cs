using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Paciente;
using Repositorio.Outputs.DTOs.Paciente;
using RepositoryInterfaces.Read.Repository.Paciente;

namespace Command.Receivers.Read
{
    public class PacienteReadReceiver : ReciverBase<IEnumerable<PacienteDTO>>
    {
        private readonly IPacienteReadRepository _repository;

        public PacienteReadReceiver(IPacienteReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<PacienteDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.PacienteReadCommand c) 
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