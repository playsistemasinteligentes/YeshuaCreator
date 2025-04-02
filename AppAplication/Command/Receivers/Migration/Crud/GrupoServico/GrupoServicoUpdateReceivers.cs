using Comandos.Pateners.Command;
using Dominio.Entitys.GrupoServico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.GrupoServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateGrupoServicoReceiver : ReciverBase
    {
        private readonly IGrupoServicoWriteRepository _repository;

        public UpdateGrupoServicoReceiver(IGrupoServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.GrupoServicoCrudCommand c) 
             {    
                 var gruposervico = new GrupoServicoEntity(c.Id, c.Descricao);
                 if (!gruposervico.isValidUpdate())
                     return new State(300, gruposervico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(gruposervico);
                     return new State(200, "OK", gruposervico);
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