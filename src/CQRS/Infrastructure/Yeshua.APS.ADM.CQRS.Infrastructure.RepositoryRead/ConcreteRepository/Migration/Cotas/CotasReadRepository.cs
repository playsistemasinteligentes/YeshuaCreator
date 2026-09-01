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
    public partial class CotasReadRepository : ICotasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICotasQueryRead _query;

        public CotasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICotasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCotasCustom(Command.Read.CotasReadCommand command, ref DataPagination<CotasDTO> result, ref bool handled);

        public DataPagination<CotasDTO> getCotas(ICommandRead command )
         {
            if (command is Command.Read.CotasReadCommand c)
                return getCotas(c );
            throw new NotImplementedException();
        }
        private DataPagination<CotasDTO> getCotas(Command.Read.CotasReadCommand command )
        {
            DataPagination<CotasDTO> customResult = null;
            var customHandled = false;
            TryGetCotasCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CotasQuery(command );

                var itens = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters);
                return new DataPagination<CotasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CotasTenantIDDTO> getCotasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CotasTenantIDDTO> lista;
            var query = _query.CotasTenantIDQuery(command );

                lista = _unitOfWork.Query<CotasTenantIDDTO>(query.Query,query.Parameters) as List<CotasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CotasTenantIDDTO> getCotasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCotasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CotasUserIdDTO> getCotasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CotasUserIdDTO> lista;
            var query = _query.CotasUserIdQuery(command );

                lista = _unitOfWork.Query<CotasUserIdDTO>(query.Query,query.Parameters) as List<CotasUserIdDTO>;
            return lista;
        }

        public IEnumerable<CotasUserIdDTO> getCotasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCotasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOT_ID(int value )
        {
            var query = _query.ExistsByCOT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOT_DATA_DE(DateTime value )
        {
            var query = _query.ExistsByCOT_DATA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOT_DATA_ATE(DateTime value )
        {
            var query = _query.ExistsByCOT_DATA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOT_VALOR(Decimal value )
        {
            var query = _query.ExistsByCOT_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOT_OCUPADO(Decimal value )
        {
            var query = _query.ExistsByCOT_OCUPADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREP_ID(int value )
        {
            var query = _query.ExistsByREP_IDQuery(value );

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

        public CotasDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByCOT_ID(int value )
        {
            var query = _query.FirstByCOT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByCOT_DATA_DE(DateTime value )
        {
            var query = _query.FirstByCOT_DATA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByCOT_DATA_ATE(DateTime value )
        {
            var query = _query.FirstByCOT_DATA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByCOT_VALOR(Decimal value )
        {
            var query = _query.FirstByCOT_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByCOT_OCUPADO(Decimal value )
        {
            var query = _query.FirstByCOT_OCUPADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByREP_ID(int value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public CotasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CotasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CotasDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByCOT_ID(int value )
        {
            var query = _query.FirstByCOT_IDQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByCOT_DATA_DE(DateTime value )
        {
            var query = _query.FirstByCOT_DATA_DEQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByCOT_DATA_ATE(DateTime value )
        {
            var query = _query.FirstByCOT_DATA_ATEQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByCOT_VALOR(Decimal value )
        {
            var query = _query.FirstByCOT_VALORQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByCOT_OCUPADO(Decimal value )
        {
            var query = _query.FirstByCOT_OCUPADOQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByREP_ID(int value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

        public IEnumerable<CotasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CotasDTO>(query.Query,query.Parameters) as List<CotasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration