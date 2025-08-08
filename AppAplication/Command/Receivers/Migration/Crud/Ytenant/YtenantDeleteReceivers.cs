using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteyTenantReceiver : ReciverBase <IyTenantEntity>
    {
        private readonly IyTenantWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteyTenantReceiver(IyTenantWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyTenantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yTenantCrudCommand c) 
             {    
                 var ytenant = new yTenantFactory(_logger).Create(c.CnpjCpf, c.Nome, c.UserId);
                 if (!ytenant.isValidDelete())
                     return ValidationError(ytenant.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(ytenant);
                     return Success("OK", ytenant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenant);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration