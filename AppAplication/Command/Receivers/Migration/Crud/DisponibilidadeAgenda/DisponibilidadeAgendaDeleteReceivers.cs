using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteDisponibilidadeAgendaReceiver : ReciverBase <IDisponibilidadeAgendaEntity>
    {
        private readonly IDisponibilidadeAgendaWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteDisponibilidadeAgendaReceiver(IDisponibilidadeAgendaWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IDisponibilidadeAgendaEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.DisponibilidadeAgendaCrudCommand c) 
             {    
                 var disponibilidadeagenda = new DisponibilidadeAgendaFactory(_logger).Create(c.Id, c.ProfissionalId, c.DataHora);
                 if (!disponibilidadeagenda.isValidDelete())
                     return ValidationError(disponibilidadeagenda.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(disponibilidadeagenda);
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