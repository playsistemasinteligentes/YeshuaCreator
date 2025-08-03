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
    public class DeleteYperfilPermissionActionsReceiver : ReciverBase <IYperfilPermissionActionsEntity>
    {
        private readonly IYperfilPermissionActionsWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYperfilPermissionActionsReceiver(IYperfilPermissionActionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYperfilPermissionActionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YperfilPermissionActionsCrudCommand c) 
             {    
                 var yperfilpermissionactions = new YperfilPermissionActionsFactory(_logger).Create(c.PerfilId, c.permissionActionsId, c.Grant, c.Create, c.Read, c.Update, c.Delete, c.ValidUntil);
                 if (!yperfilpermissionactions.isValidDelete())
                     return ValidationError(yperfilpermissionactions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(yperfilpermissionactions);
                     return Success("OK", yperfilpermissionactions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfilpermissionactions);
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