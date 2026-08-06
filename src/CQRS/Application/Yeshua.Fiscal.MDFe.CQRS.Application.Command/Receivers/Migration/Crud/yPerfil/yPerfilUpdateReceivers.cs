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
    public class UpdateyPerfilReceiver : ReciverBase<ICommand, IyPerfilEntity>
    {
        private readonly IyPerfilWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateyPerfilReceiver(
            IyPerfilWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IyPerfilEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yPerfilCrudCommand c) 
             {    
                 var yperfil = new yPerfilFactory(_logger).Create(c.Id, c.Description);
                 if (!yperfil.isValidUpdate())
                     return ValidationError(yperfil.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(yperfil);
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