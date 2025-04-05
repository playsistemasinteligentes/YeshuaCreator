using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Permtions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_PermtionsReceiver : ReciverBase
    {
        private readonly IY_PermtionsWriteRepository _repository;

        public InsertY_PermtionsReceiver(IY_PermtionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PermtionsCrudCommand c) 
             {    
                 var y_permtions = new Y_PermtionsEntity(c.Id, c.Description);
                 if (!y_permtions.isValidInsert())
                     return ValidationError(y_permtions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_permtions);
                     return Success("OK", y_permtions);
                 }
                 catch (Exception e)
                 {
                     return Error(e, comand);
                 }
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration