using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using Repositorio.Outputs.DTOs.Y_Perfil;
using RepositoryInterfaces.Read.Repository.Y_Perfil;

namespace Command.Receivers.Read
{
    public class Y_PerfilReadReceiver : ReciverBase<IEnumerable<Y_PerfilDTO>>
    {
        private readonly IY_PerfilReadRepository _repository;

        public Y_PerfilReadReceiver(IY_PerfilReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<Y_PerfilDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_PerfilReadCommand c) 
             {    
                var Y_PerfilReadRepository = _repository.getY_Perfil(c);
                return Success("OK", Y_PerfilReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration