using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_User;
using Repositorio.Outputs.DTOs.Y_User;
using RepositoryInterfaces.Read.Repository.Y_User;

namespace Command.Receivers.Read
{
    public class Y_UserReadReceiver : ReciverBase<DataPagination<Y_UserDTO>>
    {
        private readonly IY_UserReadRepository _repository;

        public Y_UserReadReceiver(IY_UserReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<DataPagination<Y_UserDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_UserReadCommand c) 
             {    
                var Y_UserReadRepository = _repository.getY_User(c);
                return Success("OK", Y_UserReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration