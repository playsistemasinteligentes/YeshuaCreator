using Comandos.Pateners.Command;
using Dominio.Entitys.Sesoes;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadReceiver : ReciverBase
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.SesoesReadCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoes(c);
                return Success("OK", SesoesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration