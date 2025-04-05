using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Permtions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using RepositoryInterfaces.Read.Repository.Y_Permtions;

namespace Command.Receivers.Read
{
    public class Y_PermtionsReadReceiver : ReciverBase
    {
        private readonly IY_PermtionsReadRepository _repository;

        public Y_PermtionsReadReceiver(IY_PermtionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_PermtionsReadCommand c) 
             {    
                var Y_PermtionsReadRepository = _repository.getY_Permtions(c);
                return Success("OK", Y_PermtionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration