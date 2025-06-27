using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteY_TenantReceiver : ReciverBase <Y_TenantEntity>
    {
        private readonly IY_TenantWriteRepository _repository;

        public DeleteY_TenantReceiver(IY_TenantWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_TenantEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_TenantCrudCommand c) 
             {    
                 var y_tenant = new Y_TenantEntity(c.Id, c.Nome, c.ProxyServer, c.UserIDAdmin);
                 if (!y_tenant.isValidDelete())
                     return ValidationError(y_tenant.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_tenant);
                     return Success("OK", y_tenant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_tenant);
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