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
    public partial class MensagemReadRepository : IMensagemReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMensagemQueryRead _query;

        public MensagemReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMensagemQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMensagemCustom(Command.Read.MensagemReadCommand command, ref DataPagination<MensagemDTO> result, ref bool handled);

        public DataPagination<MensagemDTO> getMensagem(ICommandRead command )
         {
            if (command is Command.Read.MensagemReadCommand c)
                return getMensagem(c );
            throw new NotImplementedException();
        }
        private DataPagination<MensagemDTO> getMensagem(Command.Read.MensagemReadCommand command )
        {
            DataPagination<MensagemDTO> customResult = null;
            var customHandled = false;
            TryGetMensagemCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MensagemQuery(command );

                var itens = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters);
                return new DataPagination<MensagemDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MensagemTenantIDDTO> getMensagemReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MensagemTenantIDDTO> lista;
            var query = _query.MensagemTenantIDQuery(command );

                lista = _unitOfWork.Query<MensagemTenantIDDTO>(query.Query,query.Parameters) as List<MensagemTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MensagemTenantIDDTO> getMensagemReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMensagemReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MensagemUserIdDTO> getMensagemReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MensagemUserIdDTO> lista;
            var query = _query.MensagemUserIdQuery(command );

                lista = _unitOfWork.Query<MensagemUserIdDTO>(query.Query,query.Parameters) as List<MensagemUserIdDTO>;
            return lista;
        }

        public IEnumerable<MensagemUserIdDTO> getMensagemReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMensagemReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMEN_ID(string value )
        {
            var query = _query.ExistsByMEN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_SEND(string value )
        {
            var query = _query.ExistsByMEN_SENDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_EMISSION(DateTime value )
        {
            var query = _query.ExistsByMEN_EMISSIONQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_STATUS(string value )
        {
            var query = _query.ExistsByMEN_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_RECEIVE(string value )
        {
            var query = _query.ExistsByMEN_RECEIVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_TYPE(string value )
        {
            var query = _query.ExistsByMEN_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_QTD_TRY_SEND(Decimal value )
        {
            var query = _query.ExistsByMEN_QTD_TRY_SENDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEN_DATE_TRY_SEND(DateTime value )
        {
            var query = _query.ExistsByMEN_DATE_TRY_SENDQuery(value );

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

        public MensagemDTO FirstByMEN_ID(string value )
        {
            var query = _query.FirstByMEN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_SEND(string value )
        {
            var query = _query.FirstByMEN_SENDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_EMISSION(DateTime value )
        {
            var query = _query.FirstByMEN_EMISSIONQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_STATUS(string value )
        {
            var query = _query.FirstByMEN_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_RECEIVE(string value )
        {
            var query = _query.FirstByMEN_RECEIVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_TYPE(string value )
        {
            var query = _query.FirstByMEN_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_QTD_TRY_SEND(Decimal value )
        {
            var query = _query.FirstByMEN_QTD_TRY_SENDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByMEN_DATE_TRY_SEND(DateTime value )
        {
            var query = _query.FirstByMEN_DATE_TRY_SENDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public MensagemDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MensagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_ID(string value )
        {
            var query = _query.FirstByMEN_IDQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_SEND(string value )
        {
            var query = _query.FirstByMEN_SENDQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_EMISSION(DateTime value )
        {
            var query = _query.FirstByMEN_EMISSIONQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_STATUS(string value )
        {
            var query = _query.FirstByMEN_STATUSQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_RECEIVE(string value )
        {
            var query = _query.FirstByMEN_RECEIVEQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_TYPE(string value )
        {
            var query = _query.FirstByMEN_TYPEQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_QTD_TRY_SEND(Decimal value )
        {
            var query = _query.FirstByMEN_QTD_TRY_SENDQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByMEN_DATE_TRY_SEND(DateTime value )
        {
            var query = _query.FirstByMEN_DATE_TRY_SENDQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

        public IEnumerable<MensagemDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MensagemDTO>(query.Query,query.Parameters) as List<MensagemDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration