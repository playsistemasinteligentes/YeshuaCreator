using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;
using Repositorio.Outputs.DTOs.Profissional;

namespace Command.Receivers.Read
{
    public class ProfissionalReadFKEspecialidadeIdReceiver : ReciverBase<IEnumerable<ProfissionalEspecialidadeIdDTO>>
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadFKEspecialidadeIdReceiver(IProfissionalReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ProfissionalEspecialidadeIdDTO>> Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissionalReadFKEspecialidadeId(c);
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