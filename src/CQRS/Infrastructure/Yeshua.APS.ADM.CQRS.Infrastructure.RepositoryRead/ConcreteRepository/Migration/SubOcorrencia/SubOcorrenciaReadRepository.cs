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
    public partial class SubOcorrenciaReadRepository : ISubOcorrenciaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ISubOcorrenciaQueryRead _query;

        public SubOcorrenciaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ISubOcorrenciaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<SubOcorrenciaDTO> getSubOcorrencia(ICommandRead command )
         {
            if (command is Command.Read.SubOcorrenciaReadCommand c)
                return getSubOcorrencia(c );
            throw new NotImplementedException();
        }
        private DataPagination<SubOcorrenciaDTO> getSubOcorrencia(Command.Read.SubOcorrenciaReadCommand command )
        {
            var query = _query.SubOcorrenciaQuery(command );

                var itens = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters);
                return new DataPagination<SubOcorrenciaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SubOcorrenciaTenantIDDTO> getSubOcorrenciaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SubOcorrenciaTenantIDDTO> lista;
            var query = _query.SubOcorrenciaTenantIDQuery(command );

                lista = _unitOfWork.Query<SubOcorrenciaTenantIDDTO>(query.Query,query.Parameters) as List<SubOcorrenciaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<SubOcorrenciaTenantIDDTO> getSubOcorrenciaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSubOcorrenciaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SubOcorrenciaUserIdDTO> getSubOcorrenciaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SubOcorrenciaUserIdDTO> lista;
            var query = _query.SubOcorrenciaUserIdQuery(command );

                lista = _unitOfWork.Query<SubOcorrenciaUserIdDTO>(query.Query,query.Parameters) as List<SubOcorrenciaUserIdDTO>;
            return lista;
        }

        public IEnumerable<SubOcorrenciaUserIdDTO> getSubOcorrenciaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSubOcorrenciaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySUB_ID(string value )
        {
            var query = _query.ExistsBySUB_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySUB_DESCRICAO(string value )
        {
            var query = _query.ExistsBySUB_DESCRICAOQuery(value );

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

        public SubOcorrenciaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public SubOcorrenciaDTO FirstBySUB_ID(string value )
        {
            var query = _query.FirstBySUB_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public SubOcorrenciaDTO FirstBySUB_DESCRICAO(string value )
        {
            var query = _query.FirstBySUB_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public SubOcorrenciaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public SubOcorrenciaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public SubOcorrenciaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public SubOcorrenciaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SubOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllBySUB_ID(string value )
        {
            var query = _query.FirstBySUB_IDQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllBySUB_DESCRICAO(string value )
        {
            var query = _query.FirstBySUB_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<SubOcorrenciaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<SubOcorrenciaDTO>(query.Query,query.Parameters) as List<SubOcorrenciaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration