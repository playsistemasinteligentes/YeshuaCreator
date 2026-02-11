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
    public class UpdateyConfigArctetureReceiver : ReciverBase<ICommand, IyConfigArctetureEntity>
    {
        private readonly IyConfigArctetureWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateyConfigArctetureReceiver(IyConfigArctetureWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyConfigArctetureEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yConfigArctetureCrudCommand c) 
             {    
                 var yconfigarcteture = new yConfigArctetureFactory(_logger).Create(c.Id, c.AuditTrackerActived, c.AuditCRUDActived);
                 if (!yconfigarcteture.isValidUpdate())
                     return ValidationError(yconfigarcteture.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(yconfigarcteture);
                     return Success("OK", yconfigarcteture);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yconfigarcteture);
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