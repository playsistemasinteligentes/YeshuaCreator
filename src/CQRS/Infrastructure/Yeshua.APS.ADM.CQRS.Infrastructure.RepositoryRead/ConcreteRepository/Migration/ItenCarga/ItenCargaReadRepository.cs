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
    public partial class ItenCargaReadRepository : IItenCargaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItenCargaQueryRead _query;

        public ItenCargaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItenCargaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetItenCargaCustom(Command.Read.ItenCargaReadCommand command, ref DataPagination<ItenCargaDTO> result, ref bool handled);

        public DataPagination<ItenCargaDTO> getItenCarga(ICommandRead command )
         {
            if (command is Command.Read.ItenCargaReadCommand c)
                return getItenCarga(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItenCargaDTO> getItenCarga(Command.Read.ItenCargaReadCommand command )
        {
            DataPagination<ItenCargaDTO> customResult = null;
            var customHandled = false;
            TryGetItenCargaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ItenCargaQuery(command );

                var itens = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters);
                return new DataPagination<ItenCargaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItenCargaORD_IDDTO> getItenCargaReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItenCargaORD_IDDTO> lista;
            var query = _query.ItenCargaORD_IDQuery(command );

                lista = _unitOfWork.Query<ItenCargaORD_IDDTO>(query.Query,query.Parameters) as List<ItenCargaORD_IDDTO>;
            return lista;
        }

        public IEnumerable<ItenCargaORD_IDDTO> getItenCargaReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItenCargaReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItenCargaTenantIDDTO> getItenCargaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItenCargaTenantIDDTO> lista;
            var query = _query.ItenCargaTenantIDQuery(command );

                lista = _unitOfWork.Query<ItenCargaTenantIDDTO>(query.Query,query.Parameters) as List<ItenCargaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItenCargaTenantIDDTO> getItenCargaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItenCargaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItenCargaUserIdDTO> getItenCargaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItenCargaUserIdDTO> lista;
            var query = _query.ItenCargaUserIdQuery(command );

                lista = _unitOfWork.Query<ItenCargaUserIdDTO>(query.Query,query.Parameters) as List<ItenCargaUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItenCargaUserIdDTO> getItenCargaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItenCargaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITC_ENTREGA_PLANEJADA(DateTime value )
        {
            var query = _query.ExistsByITC_ENTREGA_PLANEJADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITC_ENTREGA_REALIZADA(DateTime value )
        {
            var query = _query.ExistsByITC_ENTREGA_REALIZADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITC_ORDEM_ENTREGA(int value )
        {
            var query = _query.ExistsByITC_ORDEM_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITC_QTD_PLANEJADA(Decimal value )
        {
            var query = _query.ExistsByITC_QTD_PLANEJADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITC_QTD_REALIZADA(Decimal value )
        {
            var query = _query.ExistsByITC_QTD_REALIZADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_HASH_KEY(string value )
        {
            var query = _query.ExistsByORD_HASH_KEYQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNOT_ID(string value )
        {
            var query = _query.ExistsByNOT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNOT_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByNOT_EMISSAOQuery(value );

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

        public ItenCargaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByITC_ENTREGA_PLANEJADA(DateTime value )
        {
            var query = _query.FirstByITC_ENTREGA_PLANEJADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByITC_ENTREGA_REALIZADA(DateTime value )
        {
            var query = _query.FirstByITC_ENTREGA_REALIZADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByITC_ORDEM_ENTREGA(int value )
        {
            var query = _query.FirstByITC_ORDEM_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByITC_QTD_PLANEJADA(Decimal value )
        {
            var query = _query.FirstByITC_QTD_PLANEJADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByITC_QTD_REALIZADA(Decimal value )
        {
            var query = _query.FirstByITC_QTD_REALIZADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByORD_HASH_KEY(string value )
        {
            var query = _query.FirstByORD_HASH_KEYQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByNOT_ID(string value )
        {
            var query = _query.FirstByNOT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByNOT_EMISSAO(DateTime value )
        {
            var query = _query.FirstByNOT_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCargaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByITC_ENTREGA_PLANEJADA(DateTime value )
        {
            var query = _query.FirstByITC_ENTREGA_PLANEJADAQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByITC_ENTREGA_REALIZADA(DateTime value )
        {
            var query = _query.FirstByITC_ENTREGA_REALIZADAQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByITC_ORDEM_ENTREGA(int value )
        {
            var query = _query.FirstByITC_ORDEM_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByITC_QTD_PLANEJADA(Decimal value )
        {
            var query = _query.FirstByITC_QTD_PLANEJADAQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByITC_QTD_REALIZADA(Decimal value )
        {
            var query = _query.FirstByITC_QTD_REALIZADAQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByORD_HASH_KEY(string value )
        {
            var query = _query.FirstByORD_HASH_KEYQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByNOT_ID(string value )
        {
            var query = _query.FirstByNOT_IDQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByNOT_EMISSAO(DateTime value )
        {
            var query = _query.FirstByNOT_EMISSAOQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

        public IEnumerable<ItenCargaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItenCargaDTO>(query.Query,query.Parameters) as List<ItenCargaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration