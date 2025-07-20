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
    public class InsertYperfilPermitionsReceiver : ReciverBase <IYperfilPermitionsEntity>
    {
        private readonly IYperfilPermitionsWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertYperfilPermitionsReceiver(IYperfilPermitionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYperfilPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YperfilPermitionsCrudCommand c) 
             {    
                 var yperfilpermitions = new YperfilPermitionsFactory(_logger).Create(c.PerfilId, c.PermitionsId);
                 if (!yperfilpermitions.isValidInsert())
                     return ValidationError(yperfilpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(yperfilpermitions);
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