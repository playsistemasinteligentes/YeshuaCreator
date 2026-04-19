using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yOutboxReadFKSagaStepIdReceiver : ReciverBase<ICommand, IEnumerable<yOutboxSagaStepIdDTO>>
    {
        private readonly IyOutboxReadRepository _repository;

        public yOutboxReadFKSagaStepIdReceiver(IyOutboxReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yOutboxSagaStepIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yOutboxReadRepository = _repository.getyOutboxReadFKSagaStepId(c);
                return Success("OK", yOutboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration