using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
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
            if(comand is SearchFKCommand c) 
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