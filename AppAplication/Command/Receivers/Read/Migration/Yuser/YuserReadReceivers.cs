using Comandos.Pateners.Command;
using Dominio.Entitys.Yuser;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Yuser;
using RepositoryInterfaces.Read.Repository.Yuser;

namespace Command.Receivers.Read
{
    public class YuserReadReceiver : ReciverBase
    {
        private readonly IYuserReadRepository _repository;

        public YuserReadReceiver(IYuserReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.YuserReadCommand c) 
             {    
                var YuserReadRepository = _repository.getYuser(c);
                return new State(200, "OK", YuserReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration