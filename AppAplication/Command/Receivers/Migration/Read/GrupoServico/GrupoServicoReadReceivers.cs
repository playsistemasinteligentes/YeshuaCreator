using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.GrupoServico;
using Repositorio.Outputs.DTOs.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;

namespace Command.Receivers.Read
{
    public class GrupoServicoReadReceiver : ReciverBase<DataPagination<GrupoServicoDTO>>
    {
        private readonly IGrupoServicoReadRepository _repository;

        public GrupoServicoReadReceiver(IGrupoServicoReadRepository repository)
        {
            _repository = repository;
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