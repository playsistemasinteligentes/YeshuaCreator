using Comandos.Pateners.Command;
using Dominio.Entitys.Y_User;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Read.Repository.Y_User;

namespace Command.Receivers.Read
{
    public class Y_UserReadReceiver : ReciverBase
    {
        private readonly IY_UserReadRepository _repository;

        public Y_UserReadReceiver(IY_UserReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_UserReadCommand c) 
             {    
                var Y_UserReadRepository = _repository.getY_User(c);
                return new State(200, "OK", Y_UserReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration