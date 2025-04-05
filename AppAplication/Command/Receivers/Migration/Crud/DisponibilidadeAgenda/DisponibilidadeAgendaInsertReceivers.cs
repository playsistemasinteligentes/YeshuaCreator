using Comandos.Pateners.Command;
using Dominio.Entitys.DisponibilidadeAgenda;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertDisponibilidadeAgendaReceiver : ReciverBase
    {
        private readonly IDisponibilidadeAgendaWriteRepository _repository;

        public InsertDisponibilidadeAgendaReceiver(IDisponibilidadeAgendaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.DisponibilidadeAgendaCrudCommand c) 
             {    
                 var disponibilidadeagenda = new DisponibilidadeAgendaEntity(c.Id, c.ProfissionalId, c.DataHora);
                 if (!disponibilidadeagenda.isValidInsert())
                     return ValidationError(disponibilidadeagenda.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(disponibilidadeagenda);
                     return Success("OK", disponibilidadeagenda);
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