using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Company;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Company;
using RepositoryInterfaces.Read.Repository.Y_Company;

namespace Command.Receivers.Read
{
    public class Y_CompanyReadFKUserIDAdminReceiver : ReciverBase
    {
        private readonly IY_CompanyReadRepository _repository;

        public Y_CompanyReadFKUserIDAdminReceiver(IY_CompanyReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var Y_CompanyReadRepository = _repository.getY_CompanyReadFKUserIDAdmin(c);
                return Success("OK", Y_CompanyReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration