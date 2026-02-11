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
    public class InsertyFileUploadReceiver : ReciverBase<ICommand, IyFileUploadEntity>
    {
        private readonly IyFileUploadWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertyFileUploadReceiver(IyFileUploadWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyFileUploadEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yFileUploadCrudCommand c) 
             {    
                 var yfileupload = new yFileUploadFactory(_logger).Create(c.Id, c.IdempotencyKey, c.Type, c.Status, c.FilePath, c.FileSize, c.ContentType, c.CreatedAt, c.CompletedAt);
                 if (!yfileupload.isValidInsert())
                     return ValidationError(yfileupload.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(yfileupload);
                     return Success("OK", yfileupload);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yfileupload);
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