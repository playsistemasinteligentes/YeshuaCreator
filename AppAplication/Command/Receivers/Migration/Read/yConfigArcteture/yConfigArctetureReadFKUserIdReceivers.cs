using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yConfigArctetureReadFKUserIdReceiver : ReciverBase<IEnumerable<yConfigArctetureUserIdDTO>>
    {
        private readonly IyConfigArctetureReadRepository _repository;

        public yConfigArctetureReadFKUserIdReceiver(IyConfigArctetureReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yConfigArctetureUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yConfigArctetureReadRepository = _repository.getyConfigArctetureReadFKUserId(c);
                return Success("OK", yConfigArctetureReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration