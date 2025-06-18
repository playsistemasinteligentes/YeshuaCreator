using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using Repositorio.Outputs.DTOs.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;

namespace Command.Receivers.Read
{
    public class ProfissionalReadReceiver : ReciverBase<IEnumerable<ProfissionalDTO>>
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadReceiver(IProfissionalReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<ProfissionalDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.ProfissionalReadCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissional(c);
                return Success("OK", ProfissionalReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration