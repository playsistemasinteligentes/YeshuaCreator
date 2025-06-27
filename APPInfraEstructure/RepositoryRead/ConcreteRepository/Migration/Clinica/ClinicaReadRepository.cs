using Dapper;
using Output.Querys.Clinica;
using Repositorio.Outputs.DTOs.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Clinica
{
    public class ClinicaReadRepository : IClinicaReadRepository
    {
        protected readonly IDbConnection _connection;

        public ClinicaReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<ClinicaDTO> getClinica(ICommandRead command)
         {
            if (command is Command.Commands.Read.ClinicaReadCommand c)
                return getClinica(c);
            throw new NotImplementedException();
        }
        private DataPagination<ClinicaDTO> getClinica(Command.Commands.Read.ClinicaReadCommand command)
        {
            var query = new ClinicaReadQuery().ClinicaQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<ClinicaDTO>(query.Query,query.Parameters);
                return new DataPagination<ClinicaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        public ClinicaDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration