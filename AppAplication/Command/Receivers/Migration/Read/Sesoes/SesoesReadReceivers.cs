using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Sesoes;
using Repositorio.Outputs.DTOs.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;

namespace Command.Receivers.Read
{
    public class SesoesReadReceiver : ReciverBase<DataPagination<SesoesDTO>>
    {
        private readonly ISesoesReadRepository _repository;

        public SesoesReadReceiver(ISesoesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<DataPagination<SesoesDTO>> Action(ICommand comand)
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