using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertServicoReceiver : ReciverBase <ServicoEntity>
    {
        private readonly IServicoWriteRepository _repository;

        public InsertServicoReceiver(IServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<ServicoEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.ServicoCrudCommand c) 
             {    
                 var servico = new ServicoEntity(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
                 if (!servico.isValidInsert())
                     return ValidationError(servico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(servico);
                     return Success("OK", servico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, servico);
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