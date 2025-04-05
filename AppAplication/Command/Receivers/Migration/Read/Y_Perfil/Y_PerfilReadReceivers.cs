using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Perfil;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using RepositoryInterfaces.Read.Repository.Y_Perfil;

namespace Command.Receivers.Read
{
    public class Y_PerfilReadReceiver : ReciverBase
    {
        private readonly IY_PerfilReadRepository _repository;

        public Y_PerfilReadReceiver(IY_PerfilReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_PerfilReadCommand c) 
             {    
                var Y_PerfilReadRepository = _repository.getY_Perfil(c);
                return Success("OK", Y_PerfilReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration