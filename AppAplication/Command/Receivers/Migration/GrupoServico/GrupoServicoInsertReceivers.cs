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
    public class InsertGrupoServicoReceiver : ReciverBase
    {
        private readonly IGrupoServicoWriteRepository _repository;

        public InsertGrupoServicoReceiver(IGrupoServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Command.Commands.GrupoServicoCrudCommand)comand;

            var gruposervico = new GrupoServicoEntity(c.Id, c.Descricao);
            if (!gruposervico.isValidInsert())
                return new State(300, gruposervico.getErroMensagens(), comand);

            try
            {
                _repository.Insert(gruposervico);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, e, comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration