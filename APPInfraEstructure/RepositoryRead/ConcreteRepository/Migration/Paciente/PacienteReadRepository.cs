using Dapper;
using Output.Querys.Paciente;
using Repositorio.Outputs.DTOs.Paciente;
using RepositoryInterfaces.Read.Repository.Paciente;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Paciente
{
    public class PacienteReadRepository : IPacienteReadRepository
    {
        protected readonly IDbConnection _connection;

        public PacienteReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<PacienteDTO> getPaciente(ICommandRead command)
         {
            if (command is Command.Commands.Read.PacienteReadCommand c)
                return getPaciente(c);
            throw new NotImplementedException();
        }
        private DataPagination<PacienteDTO> getPaciente(Command.Commands.Read.PacienteReadCommand command)
        {
            var query = new PacienteReadQuery().PacienteQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<PacienteDTO>(query.Query,query.Parameters);
                return new DataPagination<PacienteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        public PacienteDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration