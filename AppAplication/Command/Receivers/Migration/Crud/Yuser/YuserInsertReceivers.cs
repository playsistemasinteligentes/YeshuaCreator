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
    public class InsertYuserReceiver : ReciverBase <IYuserEntity>
    {
        private readonly IYuserWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertYuserReceiver(IYuserWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYuserEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YuserCrudCommand c) 
             {    
                 var yuser = new YuserFactory(_logger).Create(c.Id, c.Nome, c.Email, c.Senha, c.TenantID);
                 if (!yuser.isValidInsert())
                     return ValidationError(yuser.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(yuser);
                     return Success("OK", yuser);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yuser);
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