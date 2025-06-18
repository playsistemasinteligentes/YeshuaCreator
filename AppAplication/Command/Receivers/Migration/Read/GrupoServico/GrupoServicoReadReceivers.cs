using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.GrupoServico;
using Repositorio.Outputs.DTOs.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;

using RepositoryInterfaces.Patterns.Repository;

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
            if (comand is Command.Commands.Read.GrupoServicoReadCommand c)
            {
                var GrupoServicoReadRepository = _repository.getGrupoServico(c);
                var paginacao = new DataPagination<GrupoServicoDTO>(
           items: GrupoServicoReadRepository,
           page: 1,
           pageSize: 3,
           totalItems: 4
       );
                return Success("OK", paginacao);
            }
            else
            {
                return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration