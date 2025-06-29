using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateServicoReceiver : ReciverBase <IServicoEntity>
    {
        private readonly IServicoWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateServicoReceiver(IServicoWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IServicoEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.ServicoCrudCommand c) 
             {    
                 var servico = new ServicoFactory(_logger).Create(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
                 if (!servico.isValidUpdate())
                     return ValidationError(servico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(servico);
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