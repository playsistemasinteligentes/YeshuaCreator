using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using Repositorio.Outputs.DTOs.Y_Perfil;
using RepositoryInterfaces.Read.Repository.Y_Perfil;

namespace Command.Receivers.Read
{
    public class Y_PerfilReadReceiver : ReciverBase<DataPagination<Y_PerfilDTO>>
    {
        private readonly IY_PerfilReadRepository _repository;
        private readonly ILogger _logger;

        public Y_PerfilReadReceiver(IY_PerfilReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<Y_PerfilDTO>> Action(ICommand comand)
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