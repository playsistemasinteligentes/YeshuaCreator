using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using Repositorio.Outputs.DTOs.Y_PerfilPermitions;
using RepositoryInterfaces.Read.Repository.Y_PerfilPermitions;

namespace Command.Receivers.Read
{
    public class Y_PerfilPermitionsReadReceiver : ReciverBase<DataPagination<Y_PerfilPermitionsDTO>>
    {
        private readonly IY_PerfilPermitionsReadRepository _repository;

        public Y_PerfilPermitionsReadReceiver(IY_PerfilPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<DataPagination<Y_PerfilPermitionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_PerfilPermitionsReadCommand c) 
             {    
                var Y_PerfilPermitionsReadRepository = _repository.getY_PerfilPermitions(c);
                return Success("OK", Y_PerfilPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration