using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yPerfilGrantReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<yPerfilGrantUserIdDTO>>
    {
        private readonly IyPerfilGrantReadRepository _repository;

        public yPerfilGrantReadFKUserIdReceiver(
            IyPerfilGrantReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yPerfilGrantUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yPerfilGrantReadRepository = _repository.getyPerfilGrantReadFKUserId(c);
                return Success("OK", yPerfilGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration