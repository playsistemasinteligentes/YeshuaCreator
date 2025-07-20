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
    public class DeleteYperfilReceiver : ReciverBase <IYperfilEntity>
    {
        private readonly IYperfilWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYperfilReceiver(IYperfilWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYperfilEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YperfilCrudCommand c) 
             {    
                 var yperfil = new YperfilFactory(_logger).Create(c.Id, c.Description);
                 if (!yperfil.isValidDelete())
                     return ValidationError(yperfil.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(yperfil);
                     return Success("OK", yperfil);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfil);
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