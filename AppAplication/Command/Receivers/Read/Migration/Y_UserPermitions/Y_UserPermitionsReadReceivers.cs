using Comandos.Pateners.Command;
using Dominio.Entitys.Y_UserPermitions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using RepositoryInterfaces.Read.Repository.Y_UserPermitions;

namespace Command.Receivers.Read
{
    public class Y_UserPermitionsReadReceiver : ReciverBase
    {
        private readonly IY_UserPermitionsReadRepository _repository;

        public Y_UserPermitionsReadReceiver(IY_UserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_UserPermitionsReadCommand c) 
             {    
                var Y_UserPermitionsReadRepository = _repository.getY_UserPermitions(c);
                return new State(200, "OK", Y_UserPermitionsReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration