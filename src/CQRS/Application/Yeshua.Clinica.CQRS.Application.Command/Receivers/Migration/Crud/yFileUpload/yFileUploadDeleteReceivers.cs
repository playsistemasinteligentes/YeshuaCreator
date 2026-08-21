// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

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
    public class DeleteyFileUploadReceiver : ReciverBase<ICommand, IyFileUploadEntity>
    {
        private readonly IyFileUploadWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteyFileUploadReceiver(
            IyFileUploadWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IyFileUploadEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yFileUploadCrudCommand c) 
             {    
                 var yfileupload = new yFileUploadFactory(_logger).Create(c.Id, c.Type, c.Status, c.FilePath, c.FileSize, c.EntityType, c.EntityId, c.CreatedAt, c.CompletedAt);
                 if (!yfileupload.isValidDelete())
                     return ValidationError(yfileupload.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(yfileupload);
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