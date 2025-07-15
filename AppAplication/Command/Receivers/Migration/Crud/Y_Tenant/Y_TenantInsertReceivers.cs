using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_TenantReceiver : ReciverBase <IY_TenantEntity>
    {
        private readonly IY_TenantWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertY_TenantReceiver(IY_TenantWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_TenantEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_TenantCrudCommand c) 
             {    
                 var y_tenant = new Y_TenantFactory(_logger).Create(c.Id, c.CnpjCpf, c.Nome, c.UserIDAdmin);
                 if (!y_tenant.isValidInsert())
                     return ValidationError(y_tenant.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_tenant);
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