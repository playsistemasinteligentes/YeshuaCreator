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
    public class UpdateYtenantPermissionMudulesReceiver : ReciverBase <IYtenantPermissionMudulesEntity>
    {
        private readonly IYtenantPermissionMudulesWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateYtenantPermissionMudulesReceiver(IYtenantPermissionMudulesWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYtenantPermissionMudulesEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YtenantPermissionMudulesCrudCommand c) 
             {    
                 var ytenantpermissionmudules = new YtenantPermissionMudulesFactory(_logger).Create(c.Id, c.permissionModulesId, c.TenantID, c.ValidUntil);
                 if (!ytenantpermissionmudules.isValidUpdate())
                     return ValidationError(ytenantpermissionmudules.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(ytenantpermissionmudules);
                     return Success("OK", ytenantpermissionmudules);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenantpermissionmudules);
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