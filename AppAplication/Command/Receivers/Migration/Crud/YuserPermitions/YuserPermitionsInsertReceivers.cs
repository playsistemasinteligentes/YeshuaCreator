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
    public class InsertYuserPermitionsReceiver : ReciverBase <IYuserPermitionsEntity>
    {
        private readonly IYuserPermitionsWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertYuserPermitionsReceiver(IYuserPermitionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYuserPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YuserPermitionsCrudCommand c) 
             {    
                 var yuserpermitions = new YuserPermitionsFactory(_logger).Create(c.PermitionsId, c.UserId);
                 if (!yuserpermitions.isValidInsert())
                     return ValidationError(yuserpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(yuserpermitions);
                     return Success("OK", yuserpermitions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yuserpermitions);
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