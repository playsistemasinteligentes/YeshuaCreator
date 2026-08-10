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
    public partial class ServicoReadRepository : IServicoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IServicoQueryRead _query;

        public ServicoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IServicoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ServicoDTO> getServico(ICommandRead command )
         {
            if (command is Command.Read.ServicoReadCommand c)
                return getServico(c );
            throw new NotImplementedException();
        }
        private DataPagination<ServicoDTO> getServico(Command.Read.ServicoReadCommand command )
        {
            var query = _query.ServicoQuery(command );

                var itens = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters);
                return new DataPagination<ServicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ServicoGrupoServicoIdDTO> lista;
            var query = _query.ServicoGrupoServicoIdQuery(command );

                lista = _unitOfWork.Query<ServicoGrupoServicoIdDTO>(query.Query,query.Parameters) as List<ServicoGrupoServicoIdDTO>;
            return lista;
        }

        public IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getServicoReadFKGrupoServicoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ServicoTenantIDDTO> getServicoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ServicoTenantIDDTO> lista;
            var query = _query.ServicoTenantIDQuery(command );

                lista = _unitOfWork.Query<ServicoTenantIDDTO>(query.Query,query.Parameters) as List<ServicoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ServicoTenantIDDTO> getServicoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getServicoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ServicoUserIdDTO> getServicoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ServicoUserIdDTO> lista;
            var query = _query.ServicoUserIdQuery(command );

                lista = _unitOfWork.Query<ServicoUserIdDTO>(query.Query,query.Parameters) as List<ServicoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ServicoUserIdDTO> getServicoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getServicoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupoServicoId(int value )
        {
            var query = _query.ExistsByGrupoServicoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value )
        {
            var query = _query.ExistsByValorQuery(value );

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

        public ServicoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByGrupoServicoId(int value )
        {
            var query = _query.FirstByGrupoServicoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByGrupoServicoId(int value )
        {
            var query = _query.FirstByGrupoServicoIdQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

        public IEnumerable<ServicoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ServicoDTO>(query.Query,query.Parameters) as List<ServicoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration