using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Company;
using Repositorio.Outputs.DTOs.Y_Company;
using RepositoryInterfaces.Read.Repository.Y_Company;

namespace Command.Receivers.Read
{
    public class Y_CompanyReadReceiver : ReciverBase<IEnumerable<Y_CompanyDTO>>
    {
        private readonly IY_CompanyReadRepository _repository;

        public Y_CompanyReadReceiver(IY_CompanyReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<Y_CompanyDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_CompanyReadCommand c) 
             {    
                var Y_CompanyReadRepository = _repository.getY_Company(c);
                return Success("OK", Y_CompanyReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration