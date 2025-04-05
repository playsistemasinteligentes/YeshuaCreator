using Comandos.Pateners.Command;
using Dominio.Entitys.Profissional;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;

namespace Command.Receivers.Read
{
    public class ProfissionalReadReceiver : ReciverBase
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadReceiver(IProfissionalReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.ProfissionalReadCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissional(c);
                return Success("OK", ProfissionalReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration