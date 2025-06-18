using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Sesoes;
using Repositorio.Outputs.DTOs.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadReceiver : ReciverBase<IEnumerable<SesoesDTO>>
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<SesoesDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.SesoesReadCommand c) 
             {    
                var SesoesReadRepository = _repository.getSesoes(c);
                return Success("OK", SesoesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration