using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.GrupoServico;
using Repositorio.Outputs.DTOs.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;

namespace Command.Receivers.Read
{
    public class GrupoServicoReadReceiver : ReciverBase<DataPagination<GrupoServicoDTO>>
    {
        private readonly IGrupoServicoReadRepository _repository;
        private readonly ILogger _logger;

        public GrupoServicoReadReceiver(IGrupoServicoReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<GrupoServicoDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.GrupoServicoReadCommand c) 
             {    
                var GrupoServicoReadRepository = _repository.getGrupoServico(c);
                return Success("OK", GrupoServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration