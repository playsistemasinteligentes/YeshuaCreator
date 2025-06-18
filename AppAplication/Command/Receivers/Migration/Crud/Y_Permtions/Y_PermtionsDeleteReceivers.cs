using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteY_PermtionsReceiver : ReciverBase <Y_PermtionsEntity>
    {
        private readonly IY_PermtionsWriteRepository _repository;

        public DeleteY_PermtionsReceiver(IY_PermtionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_PermtionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PermtionsCrudCommand c) 
             {    
                 var y_permtions = new Y_PermtionsEntity(c.Id, c.Description);
                 if (!y_permtions.isValidDelete())
                     return ValidationError(y_permtions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_permtions);
                     return Success("OK", y_permtions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_permtions);
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