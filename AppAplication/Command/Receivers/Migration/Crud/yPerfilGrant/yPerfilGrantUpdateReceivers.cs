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
    public class UpdateyPerfilGrantReceiver : ReciverBase<ICommand, IyPerfilGrantEntity>
    {
        private readonly IyPerfilGrantWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateyPerfilGrantReceiver(IyPerfilGrantWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyPerfilGrantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yPerfilGrantCrudCommand c) 
             {    
                 var yperfilgrant = new yPerfilGrantFactory(_logger).Create(c.PerfilId, c.GrantId, c.Grant, c.Create, c.Read, c.Update, c.Delete, c.ValidUntil);
                 if (!yperfilgrant.isValidUpdate())
                     return ValidationError(yperfilgrant.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(yperfilgrant);
                     return Success("OK", yperfilgrant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfilgrant);
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