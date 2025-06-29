using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteY_UserPermitionsReceiver : ReciverBase <IY_UserPermitionsEntity>
    {
        private readonly IY_UserPermitionsWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteY_UserPermitionsReceiver(IY_UserPermitionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_UserPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserPermitionsCrudCommand c) 
             {    
                 var y_userpermitions = new Y_UserPermitionsFactory(_logger).Create(c.UserId, c.PermitionsId);
                 if (!y_userpermitions.isValidDelete())
                     return ValidationError(y_userpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_userpermitions);
                     return Success("OK", y_userpermitions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_userpermitions);
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