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
    public class InsertyUserGrantReceiver : ReciverBase <IyUserGrantEntity>
    {
        private readonly IyUserGrantWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertyUserGrantReceiver(IyUserGrantWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyUserGrantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yUserGrantCrudCommand c) 
             {    
                 var yusergrant = new yUserGrantFactory(_logger).Create(c.PerfilId, c.GrantId, c.Grant, c.Create, c.Read, c.Update, c.Delete, c.ValidUntil);
                 if (!yusergrant.isValidInsert())
                     return ValidationError(yusergrant.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(yusergrant);
                     return Success("OK", yusergrant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yusergrant);
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