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
    public class InsertYuserPermissionActionsReceiver : ReciverBase <IYuserPermissionActionsEntity>
    {
        private readonly IYuserPermissionActionsWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertYuserPermissionActionsReceiver(IYuserPermissionActionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYuserPermissionActionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YuserPermissionActionsCrudCommand c) 
             {    
                 var yuserpermissionactions = new YuserPermissionActionsFactory(_logger).Create(c.PerfilId, c.permissionActionsId, c.Grant, c.Create, c.Read, c.Update, c.Delete, c.ValidUntil);
                 if (!yuserpermissionactions.isValidInsert())
                     return ValidationError(yuserpermissionactions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(yuserpermissionactions);
                     return Success("OK", yuserpermissionactions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yuserpermissionactions);
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