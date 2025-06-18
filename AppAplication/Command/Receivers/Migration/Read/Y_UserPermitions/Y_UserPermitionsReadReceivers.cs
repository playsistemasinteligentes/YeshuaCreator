using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using Repositorio.Outputs.DTOs.Y_UserPermitions;
using RepositoryInterfaces.Read.Repository.Y_UserPermitions;

namespace Command.Receivers.Read
{
    public class Y_UserPermitionsReadReceiver : ReciverBase<IEnumerable<Y_UserPermitionsDTO>>
    {
        private readonly IY_UserPermitionsReadRepository _repository;

        public Y_UserPermitionsReadReceiver(IY_UserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<Y_UserPermitionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_UserPermitionsReadCommand c) 
             {    
                var Y_UserPermitionsReadRepository = _repository.getY_UserPermitions(c);
                return Success("OK", Y_UserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration