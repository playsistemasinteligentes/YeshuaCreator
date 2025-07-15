using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.YperfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateYperfilPermitionsReceiver : ReciverBase <IYperfilPermitionsEntity>
    {
        private readonly IYperfilPermitionsWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateYperfilPermitionsReceiver(IYperfilPermitionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYperfilPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.YperfilPermitionsCrudCommand c) 
             {    
                 var yperfilpermitions = new YperfilPermitionsFactory(_logger).Create(c.PerfilId, c.PermitionsId);
                 if (!yperfilpermitions.isValidUpdate())
                     return ValidationError(yperfilpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(yperfilpermitions);
                     return Success("OK", yperfilpermitions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfilpermitions);
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