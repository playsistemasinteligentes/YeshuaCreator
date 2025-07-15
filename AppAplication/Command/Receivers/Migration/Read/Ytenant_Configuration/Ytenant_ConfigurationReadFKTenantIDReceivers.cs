using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Read.RepositoryInterfaces;
using Repositorio.Inputs.Repositorio.Ytenant_Configuration;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class Ytenant_ConfigurationReadFKTenantIDReceiver : ReciverBase<IEnumerable<Ytenant_ConfigurationTenantIDDTO>>
    {
        private readonly IYtenant_ConfigurationReadRepository _repository;

        public Ytenant_ConfigurationReadFKTenantIDReceiver(IYtenant_ConfigurationReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Ytenant_ConfigurationTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Ytenant_ConfigurationReadRepository = _repository.getYtenant_ConfigurationReadFKTenantID(c);
                return Success("OK", Ytenant_ConfigurationReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration