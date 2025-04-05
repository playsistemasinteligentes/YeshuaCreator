using Comandos.Pateners.Command;
using Dominio.Entitys.GrupoServico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;

namespace Command.Receivers.Read
{
    public class GrupoServicoReadReceiver : ReciverBase
    {
        private readonly IGrupoServicoReadRepository _repository;

        public GrupoServicoReadReceiver(IGrupoServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.GrupoServicoReadCommand c) 
             {    
                var GrupoServicoReadRepository = _repository.getGrupoServico(c);
                return Success("OK", GrupoServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration