using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_Company;
using RepositoryInterfaces.Read.Repository.Y_Company;
using Repositorio.Outputs.DTOs.Y_Company;

namespace Command.Receivers.Read
{
    public class Y_CompanyReadFKUserIDAdminReceiver : ReciverBase<IEnumerable<Y_CompanyUserIDAdminDTO>>
    {
        private readonly IY_CompanyReadRepository _repository;

        public Y_CompanyReadFKUserIDAdminReceiver(IY_CompanyReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_CompanyUserIDAdminDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_CompanyReadRepository = _repository.getY_CompanyReadFKUserIDAdmin(c);
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