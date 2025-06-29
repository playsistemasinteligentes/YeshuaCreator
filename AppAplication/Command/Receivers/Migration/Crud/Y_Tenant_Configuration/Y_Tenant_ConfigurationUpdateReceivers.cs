using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Tenant_Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateY_Tenant_ConfigurationReceiver : ReciverBase <IY_Tenant_ConfigurationEntity>
    {
        private readonly IY_Tenant_ConfigurationWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateY_Tenant_ConfigurationReceiver(IY_Tenant_ConfigurationWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_Tenant_ConfigurationEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_Tenant_ConfigurationCrudCommand c) 
             {    
                 var y_tenant_configuration = new Y_Tenant_ConfigurationFactory(_logger).Create(c.Id, c.AuditTrackerActived, c.AuditCRUDActived, c.TenantID);
                 if (!y_tenant_configuration.isValidUpdate())
                     return ValidationError(y_tenant_configuration.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_tenant_configuration);
                     return Success("OK", y_tenant_configuration);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_tenant_configuration);
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