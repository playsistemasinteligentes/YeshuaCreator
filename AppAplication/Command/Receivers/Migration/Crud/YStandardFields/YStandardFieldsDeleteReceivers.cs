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
    public class DeleteYStandardFieldsReceiver : ReciverBase <IYStandardFieldsEntity>
    {
        private readonly IYStandardFieldsWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteYStandardFieldsReceiver(IYStandardFieldsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYStandardFieldsEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YStandardFieldsCrudCommand c) 
             {    
                 var ystandardfields = new YStandardFieldsFactory(_logger).Create();
                 if (!ystandardfields.isValidDelete())
                     return ValidationError(ystandardfields.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(ystandardfields);
                     return Success("OK", ystandardfields);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ystandardfields);
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