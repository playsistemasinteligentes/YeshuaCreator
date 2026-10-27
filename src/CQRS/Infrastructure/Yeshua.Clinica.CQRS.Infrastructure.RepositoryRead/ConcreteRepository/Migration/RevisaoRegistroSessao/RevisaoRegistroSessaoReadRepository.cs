// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

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
    public partial class RevisaoRegistroSessaoReadRepository : IRevisaoRegistroSessaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRevisaoRegistroSessaoQueryRead _query;

        public RevisaoRegistroSessaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRevisaoRegistroSessaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetRevisaoRegistroSessaoCustom(Command.Read.RevisaoRegistroSessaoReadCommand command, ref DataPagination<RevisaoRegistroSessaoDTO> result, ref bool handled);

        public DataPagination<RevisaoRegistroSessaoDTO> getRevisaoRegistroSessao(ICommandRead command )
         {
            if (command is Command.Read.RevisaoRegistroSessaoReadCommand c)
                return getRevisaoRegistroSessao(c );
            throw new NotImplementedException();
        }
        private DataPagination<RevisaoRegistroSessaoDTO> getRevisaoRegistroSessao(Command.Read.RevisaoRegistroSessaoReadCommand command )
        {
            var customResult = new DataPagination<RevisaoRegistroSessaoDTO>();
            var customHandled = false;
            TryGetRevisaoRegistroSessaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.RevisaoRegistroSessaoQuery(command );

                var itens = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters);
                return new DataPagination<RevisaoRegistroSessaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RevisaoRegistroSessaoSessaoIdDTO> getRevisaoRegistroSessaoReadFKSessaoId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.RevisaoRegistroSessaoSessaoIdQuery(command );

                var lista = _unitOfWork.Query<RevisaoRegistroSessaoSessaoIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<RevisaoRegistroSessaoSessaoIdDTO> getRevisaoRegistroSessaoReadFKSessaoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRevisaoRegistroSessaoReadFKSessaoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RevisaoRegistroSessaoAutorUserIdDTO> getRevisaoRegistroSessaoReadFKAutorUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.RevisaoRegistroSessaoAutorUserIdQuery(command );

                var lista = _unitOfWork.Query<RevisaoRegistroSessaoAutorUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<RevisaoRegistroSessaoAutorUserIdDTO> getRevisaoRegistroSessaoReadFKAutorUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRevisaoRegistroSessaoReadFKAutorUserId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RevisaoRegistroSessaoTenantIDDTO> getRevisaoRegistroSessaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.RevisaoRegistroSessaoTenantIDQuery(command );

                var lista = _unitOfWork.Query<RevisaoRegistroSessaoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<RevisaoRegistroSessaoTenantIDDTO> getRevisaoRegistroSessaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRevisaoRegistroSessaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RevisaoRegistroSessaoUserIdDTO> getRevisaoRegistroSessaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.RevisaoRegistroSessaoUserIdQuery(command );

                var lista = _unitOfWork.Query<RevisaoRegistroSessaoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<RevisaoRegistroSessaoUserIdDTO> getRevisaoRegistroSessaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRevisaoRegistroSessaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySessaoId(int value )
        {
            var query = _query.ExistsBySessaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVersao(int value )
        {
            var query = _query.ExistsByVersaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAutorUserId(int value )
        {
            var query = _query.ExistsByAutorUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRevisadoEm(DateTime value )
        {
            var query = _query.ExistsByRevisadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMotivo(string value )
        {
            var query = _query.ExistsByMotivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRegistro(string value )
        {
            var query = _query.ExistsByRegistroQuery(value );

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

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public RevisaoRegistroSessaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstBySessaoId(int value )
        {
            var query = _query.FirstBySessaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByVersao(int value )
        {
            var query = _query.FirstByVersaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByAutorUserId(int value )
        {
            var query = _query.FirstByAutorUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByRevisadoEm(DateTime value )
        {
            var query = _query.FirstByRevisadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByMotivo(string value )
        {
            var query = _query.FirstByMotivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByRegistro(string value )
        {
            var query = _query.FirstByRegistroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public RevisaoRegistroSessaoDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RevisaoRegistroSessaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllBySessaoId(int value )
        {
            var query = _query.FirstBySessaoIdQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByVersao(int value )
        {
            var query = _query.FirstByVersaoQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByAutorUserId(int value )
        {
            var query = _query.FirstByAutorUserIdQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByRevisadoEm(DateTime value )
        {
            var query = _query.FirstByRevisadoEmQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByMotivo(string value )
        {
            var query = _query.FirstByMotivoQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByRegistro(string value )
        {
            var query = _query.FirstByRegistroQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<RevisaoRegistroSessaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration