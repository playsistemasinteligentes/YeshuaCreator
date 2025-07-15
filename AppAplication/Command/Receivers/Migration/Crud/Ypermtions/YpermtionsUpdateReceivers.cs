using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Ypermtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateYpermtionsReceiver : ReciverBase <IYpermtionsEntity>
    {
        private readonly IYpermtionsWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateYpermtionsReceiver(IYpermtionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYpermtionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.YpermtionsCrudCommand c) 
             {    
                 var ypermtions = new YpermtionsFactory(_logger).Create(c.Id, c.Description);
                 if (!ypermtions.isValidUpdate())
                     return ValidationError(ypermtions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(ypermtions);
                     return Success("OK", ypermtions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ypermtions);
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