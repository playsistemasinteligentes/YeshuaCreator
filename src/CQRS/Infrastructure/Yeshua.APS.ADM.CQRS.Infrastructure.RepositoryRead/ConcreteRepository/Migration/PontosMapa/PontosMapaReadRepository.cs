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
    public partial class PontosMapaReadRepository : IPontosMapaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPontosMapaQueryRead _query;

        public PontosMapaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPontosMapaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PontosMapaDTO> getPontosMapa(ICommandRead command )
         {
            if (command is Command.Read.PontosMapaReadCommand c)
                return getPontosMapa(c );
            throw new NotImplementedException();
        }
        private DataPagination<PontosMapaDTO> getPontosMapa(Command.Read.PontosMapaReadCommand command )
        {
            var query = _query.PontosMapaQuery(command );

                var itens = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters);
                return new DataPagination<PontosMapaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PontosMapaTenantIDDTO> getPontosMapaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PontosMapaTenantIDDTO> lista;
            var query = _query.PontosMapaTenantIDQuery(command );

                lista = _unitOfWork.Query<PontosMapaTenantIDDTO>(query.Query,query.Parameters) as List<PontosMapaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PontosMapaTenantIDDTO> getPontosMapaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPontosMapaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PontosMapaUserIdDTO> getPontosMapaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PontosMapaUserIdDTO> lista;
            var query = _query.PontosMapaUserIdQuery(command );

                lista = _unitOfWork.Query<PontosMapaUserIdDTO>(query.Query,query.Parameters) as List<PontosMapaUserIdDTO>;
            return lista;
        }

        public IEnumerable<PontosMapaUserIdDTO> getPontosMapaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPontosMapaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPON_ID(string value )
        {
            var query = _query.ExistsByPON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_DESCRICAO(string value )
        {
            var query = _query.ExistsByPON_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_TIPO(string value )
        {
            var query = _query.ExistsByPON_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_LATITUDE(Decimal value )
        {
            var query = _query.ExistsByPON_LATITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_LONGITUDE(Decimal value )
        {
            var query = _query.ExistsByPON_LONGITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPON_DISTANCIA_KM(Decimal value )
        {
            var query = _query.ExistsByPON_DISTANCIA_KMQuery(value );

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

        public PontosMapaDTO FirstByPON_ID(string value )
        {
            var query = _query.FirstByPON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByPON_DESCRICAO(string value )
        {
            var query = _query.FirstByPON_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByPON_TIPO(string value )
        {
            var query = _query.FirstByPON_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByPON_LATITUDE(Decimal value )
        {
            var query = _query.FirstByPON_LATITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByPON_LONGITUDE(Decimal value )
        {
            var query = _query.FirstByPON_LONGITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByPON_DISTANCIA_KM(Decimal value )
        {
            var query = _query.FirstByPON_DISTANCIA_KMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public PontosMapaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PontosMapaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByPON_ID(string value )
        {
            var query = _query.FirstByPON_IDQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByPON_DESCRICAO(string value )
        {
            var query = _query.FirstByPON_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByPON_TIPO(string value )
        {
            var query = _query.FirstByPON_TIPOQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByPON_LATITUDE(Decimal value )
        {
            var query = _query.FirstByPON_LATITUDEQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByPON_LONGITUDE(Decimal value )
        {
            var query = _query.FirstByPON_LONGITUDEQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByPON_DISTANCIA_KM(Decimal value )
        {
            var query = _query.FirstByPON_DISTANCIA_KMQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

        public IEnumerable<PontosMapaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PontosMapaDTO>(query.Query,query.Parameters) as List<PontosMapaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration