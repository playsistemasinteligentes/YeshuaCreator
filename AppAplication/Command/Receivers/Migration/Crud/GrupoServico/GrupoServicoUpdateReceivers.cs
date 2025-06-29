using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.GrupoServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateGrupoServicoReceiver : ReciverBase <IGrupoServicoEntity>
    {
        private readonly IGrupoServicoWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateGrupoServicoReceiver(IGrupoServicoWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IGrupoServicoEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.GrupoServicoCrudCommand c) 
             {    
                 var gruposervico = new GrupoServicoFactory(_logger).Create(c.Id, c.Descricao);
                 if (!gruposervico.isValidUpdate())
                     return ValidationError(gruposervico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(gruposervico);
                     return Success("OK", gruposervico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, gruposervico);
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