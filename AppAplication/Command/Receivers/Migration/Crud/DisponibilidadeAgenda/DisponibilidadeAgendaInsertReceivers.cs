using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertDisponibilidadeAgendaReceiver : ReciverBase <DisponibilidadeAgendaEntity>
    {
        private readonly IDisponibilidadeAgendaWriteRepository _repository;

        public InsertDisponibilidadeAgendaReceiver(IDisponibilidadeAgendaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<DisponibilidadeAgendaEntity> Action(ICommand comand)
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
                    return Error(e, disponibilidadeagenda);
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