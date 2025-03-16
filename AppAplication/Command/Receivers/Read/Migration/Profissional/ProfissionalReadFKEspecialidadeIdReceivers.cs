using Comandos.Pateners.Command;
using Dominio.Entitys.Profissional;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;

namespace Command.Receivers.Read
{
    public class ProfissionalReadFKEspecialidadeIdReceiver : ReciverBase
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadFKEspecialidadeIdReceiver(IProfissionalReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissionalReadFKEspecialidadeId(c);
                return new State(200, "OK", ProfissionalReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration