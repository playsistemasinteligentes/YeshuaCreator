using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Especialidade;
using Repositorio.Outputs.DTOs.Especialidade;
using RepositoryInterfaces.Read.Repository.Especialidade;

namespace Command.Receivers.Read
{
    public class EspecialidadeReadReceiver : ReciverBase<IEnumerable<EspecialidadeDTO>>
    {
        private readonly IEspecialidadeReadRepository _repository;

        public EspecialidadeReadReceiver(IEspecialidadeReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<EspecialidadeDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.EspecialidadeReadCommand c) 
             {    
                var EspecialidadeReadRepository = _repository.getEspecialidade(c);
                return Success("OK", EspecialidadeReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration