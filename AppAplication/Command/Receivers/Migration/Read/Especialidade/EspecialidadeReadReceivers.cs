using Comandos.Pateners.Command;
using Dominio.Entitys.Especialidade;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Especialidade;
using RepositoryInterfaces.Read.Repository.Especialidade;

namespace Command.Receivers.Read
{
    public class EspecialidadeReadReceiver : ReciverBase
    {
        private readonly IEspecialidadeReadRepository _repository;

        public EspecialidadeReadReceiver(IEspecialidadeReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.EspecialidadeReadCommand c) 
             {    
                var EspecialidadeReadRepository = _repository.getEspecialidade(c);
                return Success("OK", EspecialidadeReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration