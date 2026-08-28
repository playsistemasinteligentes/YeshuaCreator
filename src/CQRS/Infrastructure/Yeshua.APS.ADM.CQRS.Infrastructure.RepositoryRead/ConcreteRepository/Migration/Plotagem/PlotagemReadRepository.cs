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
    public partial class PlotagemReadRepository : IPlotagemReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPlotagemQueryRead _query;

        public PlotagemReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPlotagemQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PlotagemDTO> getPlotagem(ICommandRead command )
         {
            if (command is Command.Read.PlotagemReadCommand c)
                return getPlotagem(c );
            throw new NotImplementedException();
        }
        private DataPagination<PlotagemDTO> getPlotagem(Command.Read.PlotagemReadCommand command )
        {
            var query = _query.PlotagemQuery(command );

                var itens = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters);
                return new DataPagination<PlotagemDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PlotagemTenantIDDTO> getPlotagemReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlotagemTenantIDDTO> lista;
            var query = _query.PlotagemTenantIDQuery(command );

                lista = _unitOfWork.Query<PlotagemTenantIDDTO>(query.Query,query.Parameters) as List<PlotagemTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PlotagemTenantIDDTO> getPlotagemReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlotagemReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlotagemUserIdDTO> getPlotagemReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlotagemUserIdDTO> lista;
            var query = _query.PlotagemUserIdQuery(command );

                lista = _unitOfWork.Query<PlotagemUserIdDTO>(query.Query,query.Parameters) as List<PlotagemUserIdDTO>;
            return lista;
        }

        public IEnumerable<PlotagemUserIdDTO> getPlotagemReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlotagemReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_ID(int value )
        {
            var query = _query.ExistsByPLO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_NOME(string value )
        {
            var query = _query.ExistsByPLO_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_DIMENSAO(string value )
        {
            var query = _query.ExistsByPLO_DIMENSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_X(string value )
        {
            var query = _query.ExistsByPLO_XQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_Y(string value )
        {
            var query = _query.ExistsByPLO_YQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_Z(string value )
        {
            var query = _query.ExistsByPLO_ZQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_GRAFICO(string value )
        {
            var query = _query.ExistsByPLO_GRAFICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_ID(int value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

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

        public PlotagemDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_ID(int value )
        {
            var query = _query.FirstByPLO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_NOME(string value )
        {
            var query = _query.FirstByPLO_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_DIMENSAO(string value )
        {
            var query = _query.FirstByPLO_DIMENSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_X(string value )
        {
            var query = _query.FirstByPLO_XQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_Y(string value )
        {
            var query = _query.FirstByPLO_YQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_Z(string value )
        {
            var query = _query.FirstByPLO_ZQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByPLO_GRAFICO(string value )
        {
            var query = _query.FirstByPLO_GRAFICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlotagemDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_ID(int value )
        {
            var query = _query.FirstByPLO_IDQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_NOME(string value )
        {
            var query = _query.FirstByPLO_NOMEQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_DIMENSAO(string value )
        {
            var query = _query.FirstByPLO_DIMENSAOQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_X(string value )
        {
            var query = _query.FirstByPLO_XQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_Y(string value )
        {
            var query = _query.FirstByPLO_YQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_Z(string value )
        {
            var query = _query.FirstByPLO_ZQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByPLO_GRAFICO(string value )
        {
            var query = _query.FirstByPLO_GRAFICOQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

        public IEnumerable<PlotagemDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PlotagemDTO>(query.Query,query.Parameters) as List<PlotagemDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration