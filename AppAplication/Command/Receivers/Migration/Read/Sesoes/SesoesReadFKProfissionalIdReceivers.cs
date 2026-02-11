using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class SesoesReadFKProfissionalIdReceiver : ReciverBase<ICommand, IEnumerable<SesoesProfissionalIdDTO>>
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadFKProfissionalIdReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<SesoesProfissionalIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoesReadFKProfissionalId(c);
                return Success("OK", SesoesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration