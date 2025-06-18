using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using Repositorio.Outputs.DTOs.Servico;
using RepositoryInterfaces.Read.Repository.Servico;

namespace Command.Receivers.Read
{
    public class ServicoReadReceiver : ReciverBase<IEnumerable<ServicoDTO>>
    {
        private readonly IServicoReadRepository _repository;

        public ServicoReadReceiver(IServicoReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<ServicoDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.ServicoReadCommand c) 
             {    
                var ServicoReadRepository = _repository.getServico(c);
                return Success("OK", ServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration