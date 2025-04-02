using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Company;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateY_CompanyReceiver : ReciverBase
    {
        private readonly IY_CompanyWriteRepository _repository;

        public UpdateY_CompanyReceiver(IY_CompanyWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_CompanyCrudCommand c) 
             {    
                 var y_company = new Y_CompanyEntity(c.Id, c.Nome, c.ProxyServer, c.UserIDAdmin);
                 if (!y_company.isValidUpdate())
                     return new State(300, y_company.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_company);
                     return new State(200, "OK", y_company);
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