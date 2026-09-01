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
    public partial class ItensPackedReadRepository : IItensPackedReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItensPackedQueryRead _query;

        public ItensPackedReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItensPackedQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetItensPackedCustom(Command.Read.ItensPackedReadCommand command, ref DataPagination<ItensPackedDTO> result, ref bool handled);

        public DataPagination<ItensPackedDTO> getItensPacked(ICommandRead command )
         {
            if (command is Command.Read.ItensPackedReadCommand c)
                return getItensPacked(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItensPackedDTO> getItensPacked(Command.Read.ItensPackedReadCommand command )
        {
            DataPagination<ItensPackedDTO> customResult = null;
            var customHandled = false;
            TryGetItensPackedCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ItensPackedQuery(command );

                var itens = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters);
                return new DataPagination<ItensPackedDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItensPackedORD_IDDTO> getItensPackedReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensPackedORD_IDDTO> lista;
            var query = _query.ItensPackedORD_IDQuery(command );

                lista = _unitOfWork.Query<ItensPackedORD_IDDTO>(query.Query,query.Parameters) as List<ItensPackedORD_IDDTO>;
            return lista;
        }

        public IEnumerable<ItensPackedORD_IDDTO> getItensPackedReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensPackedReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensPackedTenantIDDTO> getItensPackedReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensPackedTenantIDDTO> lista;
            var query = _query.ItensPackedTenantIDQuery(command );

                lista = _unitOfWork.Query<ItensPackedTenantIDDTO>(query.Query,query.Parameters) as List<ItensPackedTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItensPackedTenantIDDTO> getItensPackedReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensPackedReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensPackedUserIdDTO> getItensPackedReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensPackedUserIdDTO> lista;
            var query = _query.ItensPackedUserIdQuery(command );

                lista = _unitOfWork.Query<ItensPackedUserIdDTO>(query.Query,query.Parameters) as List<ItensPackedUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItensPackedUserIdDTO> getItensPackedReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensPackedReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_ID(int value )
        {
            var query = _query.ExistsByIPA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_COORDC(Decimal value )
        {
            var query = _query.ExistsByIPA_COORDCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_COORDL(Decimal value )
        {
            var query = _query.ExistsByIPA_COORDLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_COORDA(Decimal value )
        {
            var query = _query.ExistsByIPA_COORDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_DIMC(Decimal value )
        {
            var query = _query.ExistsByIPA_DIMCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_DIML(Decimal value )
        {
            var query = _query.ExistsByIPA_DIMLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_DIMA(Decimal value )
        {
            var query = _query.ExistsByIPA_DIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPA_QTD_POR_PALETE(Decimal value )
        {
            var query = _query.ExistsByIPA_QTD_POR_PALETEQuery(value );

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

        public ItensPackedDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_ID(int value )
        {
            var query = _query.FirstByIPA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_COORDC(Decimal value )
        {
            var query = _query.FirstByIPA_COORDCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_COORDL(Decimal value )
        {
            var query = _query.FirstByIPA_COORDLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_COORDA(Decimal value )
        {
            var query = _query.FirstByIPA_COORDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_DIMC(Decimal value )
        {
            var query = _query.FirstByIPA_DIMCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_DIML(Decimal value )
        {
            var query = _query.FirstByIPA_DIMLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_DIMA(Decimal value )
        {
            var query = _query.FirstByIPA_DIMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByIPA_QTD_POR_PALETE(Decimal value )
        {
            var query = _query.FirstByIPA_QTD_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensPackedDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensPackedDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_ID(int value )
        {
            var query = _query.FirstByIPA_IDQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_COORDC(Decimal value )
        {
            var query = _query.FirstByIPA_COORDCQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_COORDL(Decimal value )
        {
            var query = _query.FirstByIPA_COORDLQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_COORDA(Decimal value )
        {
            var query = _query.FirstByIPA_COORDAQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_DIMC(Decimal value )
        {
            var query = _query.FirstByIPA_DIMCQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_DIML(Decimal value )
        {
            var query = _query.FirstByIPA_DIMLQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_DIMA(Decimal value )
        {
            var query = _query.FirstByIPA_DIMAQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByIPA_QTD_POR_PALETE(Decimal value )
        {
            var query = _query.FirstByIPA_QTD_POR_PALETEQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

        public IEnumerable<ItensPackedDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItensPackedDTO>(query.Query,query.Parameters) as List<ItensPackedDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration