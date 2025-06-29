using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteY_PerfilReceiver : ReciverBase <IY_PerfilEntity>
    {
        private readonly IY_PerfilWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteY_PerfilReceiver(IY_PerfilWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_PerfilEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilCrudCommand c) 
             {    
                 var y_perfil = new Y_PerfilFactory(_logger).Create(c.Id, c.Description);
                 if (!y_perfil.isValidDelete())
                     return ValidationError(y_perfil.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_perfil);
                     return Success("OK", y_perfil);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_perfil);
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