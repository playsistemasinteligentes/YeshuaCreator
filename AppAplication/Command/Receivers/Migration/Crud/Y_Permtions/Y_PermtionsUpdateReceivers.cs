using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateY_PermtionsReceiver : ReciverBase <IY_PermtionsEntity>
    {
        private readonly IY_PermtionsWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateY_PermtionsReceiver(IY_PermtionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_PermtionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PermtionsCrudCommand c) 
             {    
                 var y_permtions = new Y_PermtionsFactory(_logger).Create(c.Id, c.Description);
                 if (!y_permtions.isValidUpdate())
                     return ValidationError(y_permtions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_permtions);
                     return Success("OK", y_permtions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_permtions);
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