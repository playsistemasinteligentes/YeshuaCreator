using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class PacienteReadRepository : IPacienteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPacienteQueryRead _query;

        public PacienteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPacienteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PacienteDTO> getPaciente(ICommandRead command )
         {
            if (command is Command.Read.PacienteReadCommand c)
                return getPaciente(c );
            throw new NotImplementedException();
        }
        private DataPagination<PacienteDTO> getPaciente(Command.Read.PacienteReadCommand command )
        {
            var query = _query.PacienteQuery(command );

                var itens = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters);
                return new DataPagination<PacienteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PacienteTenantIDDTO> getPacienteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PacienteTenantIDDTO> lista;
            var query = _query.PacienteTenantIDQuery(command );

                lista = _unitOfWork.Query<PacienteTenantIDDTO>(query.Query,query.Parameters) as List<PacienteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PacienteTenantIDDTO> getPacienteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPacienteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PacienteUserIdDTO> getPacienteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PacienteUserIdDTO> lista;
            var query = _query.PacienteUserIdQuery(command );

                lista = _unitOfWork.Query<PacienteUserIdDTO>(query.Query,query.Parameters) as List<PacienteUserIdDTO>;
            return lista;
        }

        public IEnumerable<PacienteUserIdDTO> getPacienteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPacienteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value )
        {
            var query = _query.ExistsByTelefoneQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataNascimento(DateTime value )
        {
            var query = _query.ExistsByDataNascimentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGenero(int value )
        {
            var query = _query.ExistsByGeneroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEscolaridade(string value )
        {
            var query = _query.ExistsByEscolaridadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissao(string value )
        {
            var query = _query.ExistsByProfissaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value )
        {
            var query = _query.ExistsByEnderecoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNomeResponsavel(string value )
        {
            var query = _query.ExistsByNomeResponsavelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefoneResponsavel(string value )
        {
            var query = _query.ExistsByTelefoneResponsavelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObservacao(string value )
        {
            var query = _query.ExistsByObservacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public PacienteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTelefone(string value )
        {
            var query = _query.FirstByTelefoneQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByDataNascimento(DateTime value )
        {
            var query = _query.FirstByDataNascimentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByGenero(int value )
        {
            var query = _query.FirstByGeneroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByEscolaridade(string value )
        {
            var query = _query.FirstByEscolaridadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByProfissao(string value )
        {
            var query = _query.FirstByProfissaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByEndereco(string value )
        {
            var query = _query.FirstByEnderecoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByNomeResponsavel(string value )
        {
            var query = _query.FirstByNomeResponsavelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTelefoneResponsavel(string value )
        {
            var query = _query.FirstByTelefoneResponsavelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByObservacao(string value )
        {
            var query = _query.FirstByObservacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByTelefone(string value )
        {
            var query = _query.FirstByTelefoneQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByDataNascimento(DateTime value )
        {
            var query = _query.FirstByDataNascimentoQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByGenero(int value )
        {
            var query = _query.FirstByGeneroQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByEscolaridade(string value )
        {
            var query = _query.FirstByEscolaridadeQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByProfissao(string value )
        {
            var query = _query.FirstByProfissaoQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByEndereco(string value )
        {
            var query = _query.FirstByEnderecoQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByNomeResponsavel(string value )
        {
            var query = _query.FirstByNomeResponsavelQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByTelefoneResponsavel(string value )
        {
            var query = _query.FirstByTelefoneResponsavelQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByObservacao(string value )
        {
            var query = _query.FirstByObservacaoQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

        public IEnumerable<PacienteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PacienteDTO>(query.Query,query.Parameters) as List<PacienteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration