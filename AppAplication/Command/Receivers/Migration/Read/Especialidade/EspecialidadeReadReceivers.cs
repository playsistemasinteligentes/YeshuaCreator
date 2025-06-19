using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Especialidade;
using Repositorio.Outputs.DTOs.Especialidade;
using RepositoryInterfaces.Read.Repository.Especialidade;

namespace Command.Receivers.Read
{
    public class EspecialidadeReadReceiver : ReciverBase<DataPagination<EspecialidadeDTO>>
    {
        private readonly IEspecialidadeReadRepository _repository;

        public EspecialidadeReadReceiver(IEspecialidadeReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<DataPagination<EspecialidadeDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.EspecialidadeReadCommand c) 
             {    
                var EspecialidadeReadRepository = _repository.getEspecialidade(c);
                return Success("OK", EspecialidadeReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration