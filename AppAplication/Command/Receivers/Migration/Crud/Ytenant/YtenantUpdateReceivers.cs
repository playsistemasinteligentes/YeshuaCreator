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
    public class UpdateYtenantReceiver : ReciverBase <IYtenantEntity>
    {
        private readonly IYtenantWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateYtenantReceiver(IYtenantWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYtenantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YtenantCrudCommand c) 
             {    
                 var ytenant = new YtenantFactory(_logger).Create(c.Id, c.CnpjCpf, c.Nome, c.UserId);
                 if (!ytenant.isValidUpdate())
                     return ValidationError(ytenant.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(ytenant);
                     return Success("OK", ytenant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenant);
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