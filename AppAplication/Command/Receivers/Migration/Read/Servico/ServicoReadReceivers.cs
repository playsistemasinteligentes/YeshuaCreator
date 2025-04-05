using Comandos.Pateners.Command;
using Dominio.Entitys.Servico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using RepositoryInterfaces.Read.Repository.Servico;

namespace Command.Receivers.Read
{
    public class ServicoReadReceiver : ReciverBase
    {
        private readonly IServicoReadRepository _repository;

        public ServicoReadReceiver(IServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.ServicoReadCommand c) 
             {    
                var ServicoReadRepository = _repository.getServico(c);
                return Success("OK", ServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration