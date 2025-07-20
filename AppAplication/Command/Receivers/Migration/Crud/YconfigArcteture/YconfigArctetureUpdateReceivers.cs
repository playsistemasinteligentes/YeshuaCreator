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
    public class UpdateYconfigArctetureReceiver : ReciverBase <IYconfigArctetureEntity>
    {
        private readonly IYconfigArctetureWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateYconfigArctetureReceiver(IYconfigArctetureWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IYconfigArctetureEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.YconfigArctetureCrudCommand c) 
             {    
                 var yconfigarcteture = new YconfigArctetureFactory(_logger).Create(c.Id, c.AuditTrackerActived, c.AuditCRUDActived, c.TenantID);
                 if (!yconfigarcteture.isValidUpdate())
                     return ValidationError(yconfigarcteture.getErroMensagens(), comand);

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