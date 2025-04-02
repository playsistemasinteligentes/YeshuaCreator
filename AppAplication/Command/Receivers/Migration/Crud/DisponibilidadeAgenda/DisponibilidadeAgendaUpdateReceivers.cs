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
    public class UpdateDisponibilidadeAgendaReceiver : ReciverBase
    {
        private readonly IDisponibilidadeAgendaWriteRepository _repository;

        public UpdateDisponibilidadeAgendaReceiver(IDisponibilidadeAgendaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.DisponibilidadeAgendaCrudCommand c) 
             {    
                 var disponibilidadeagenda = new DisponibilidadeAgendaEntity(c.Id, c.ProfissionalId, c.DataHora);
                 if (!disponibilidadeagenda.isValidUpdate())
                     return new State(300, disponibilidadeagenda.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(disponibilidadeagenda);
                     return new State(200, "OK", disponibilidadeagenda);
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