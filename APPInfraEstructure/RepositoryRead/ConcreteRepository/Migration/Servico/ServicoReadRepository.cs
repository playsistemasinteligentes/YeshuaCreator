using Dapper;
using Output.Querys.Servico;
using Repositorio.Outputs.DTOs.Servico;
using RepositoryInterfaces.Read.Repository.Servico;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Servico
{
    public class ServicoReadRepository : IServicoReadRepository
    {
        protected readonly IDbConnection _connection;

        public ServicoReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<ServicoDTO> getServico(ICommandRead command)
         {
            if (command is Command.Commands.Read.ServicoReadCommand c)
                return getServico(c);
            throw new NotImplementedException();
        }
        private DataPagination<ServicoDTO> getServico(Command.Commands.Read.ServicoReadCommand command)
        {
            var query = new ServicoReadQuery().ServicoQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<ServicoDTO>(query.Query,query.Parameters);
                return new DataPagination<ServicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        private IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<ServicoGrupoServicoIdDTO> lista;
            var query = new ServicoReadQuery().ServicoGrupoServicoIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<ServicoGrupoServicoIdDTO>(query.Query,query.Parameters) as List<ServicoGrupoServicoIdDTO>;
            }
            return lista;
        }

        public IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getServicoReadFKGrupoServicoId(c);
            }
            throw new NotImplementedException();
        }

        public ServicoDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration