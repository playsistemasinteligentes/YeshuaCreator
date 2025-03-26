using Comandos.Pateners.Command;
using Dominio.Entitys.Yuser;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Yuser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertYuserReceiver : ReciverBase
    {
        private readonly IYuserWriteRepository _repository;

        public InsertYuserReceiver(IYuserWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.YuserCrudCommand c) 
             {    
                 var yuser = new YuserEntity(c.Id, c.Nome, c.Senha, c.Login);
                 if (!yuser.isValidInsert())
                     return new State(300, yuser.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(yuser);
                     return new State(200, "OK", comand);
                 }
                 catch (Exception e)
                 {
                     return new State(500, e, comand);
                 }
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration