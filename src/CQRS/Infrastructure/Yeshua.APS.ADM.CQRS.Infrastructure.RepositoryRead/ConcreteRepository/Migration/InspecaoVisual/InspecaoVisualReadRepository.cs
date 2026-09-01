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
    public partial class InspecaoVisualReadRepository : IInspecaoVisualReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IInspecaoVisualQueryRead _query;

        public InspecaoVisualReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IInspecaoVisualQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetInspecaoVisualCustom(Command.Read.InspecaoVisualReadCommand command, ref DataPagination<InspecaoVisualDTO> result, ref bool handled);

        public DataPagination<InspecaoVisualDTO> getInspecaoVisual(ICommandRead command )
         {
            if (command is Command.Read.InspecaoVisualReadCommand c)
                return getInspecaoVisual(c );
            throw new NotImplementedException();
        }
        private DataPagination<InspecaoVisualDTO> getInspecaoVisual(Command.Read.InspecaoVisualReadCommand command )
        {
            DataPagination<InspecaoVisualDTO> customResult = null;
            var customHandled = false;
            TryGetInspecaoVisualCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.InspecaoVisualQuery(command );

                var itens = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters);
                return new DataPagination<InspecaoVisualDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<InspecaoVisualTURN_IDDTO> getInspecaoVisualReadFKTURN_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InspecaoVisualTURN_IDDTO> lista;
            var query = _query.InspecaoVisualTURN_IDQuery(command );

                lista = _unitOfWork.Query<InspecaoVisualTURN_IDDTO>(query.Query,query.Parameters) as List<InspecaoVisualTURN_IDDTO>;
            return lista;
        }

        public IEnumerable<InspecaoVisualTURN_IDDTO> getInspecaoVisualReadFKTURN_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInspecaoVisualReadFKTURN_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<InspecaoVisualTURM_IDDTO> getInspecaoVisualReadFKTURM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InspecaoVisualTURM_IDDTO> lista;
            var query = _query.InspecaoVisualTURM_IDQuery(command );

                lista = _unitOfWork.Query<InspecaoVisualTURM_IDDTO>(query.Query,query.Parameters) as List<InspecaoVisualTURM_IDDTO>;
            return lista;
        }

        public IEnumerable<InspecaoVisualTURM_IDDTO> getInspecaoVisualReadFKTURM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInspecaoVisualReadFKTURM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<InspecaoVisualTenantIDDTO> getInspecaoVisualReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InspecaoVisualTenantIDDTO> lista;
            var query = _query.InspecaoVisualTenantIDQuery(command );

                lista = _unitOfWork.Query<InspecaoVisualTenantIDDTO>(query.Query,query.Parameters) as List<InspecaoVisualTenantIDDTO>;
            return lista;
        }

        public IEnumerable<InspecaoVisualTenantIDDTO> getInspecaoVisualReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInspecaoVisualReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<InspecaoVisualUserIdDTO> getInspecaoVisualReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InspecaoVisualUserIdDTO> lista;
            var query = _query.InspecaoVisualUserIdQuery(command );

                lista = _unitOfWork.Query<InspecaoVisualUserIdDTO>(query.Query,query.Parameters) as List<InspecaoVisualUserIdDTO>;
            return lista;
        }

        public IEnumerable<InspecaoVisualUserIdDTO> getInspecaoVisualReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInspecaoVisualReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByIPV_ID(int value )
        {
            var query = _query.ExistsByIPV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_VALOR(string value )
        {
            var query = _query.ExistsByIPV_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_ID_OPERADOR(int value )
        {
            var query = _query.ExistsByIPV_ID_OPERADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_ID_LIBERACAO(int value )
        {
            var query = _query.ExistsByIPV_ID_LIBERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_OBS(string value )
        {
            var query = _query.ExistsByIPV_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_DATA_COLETA(DateTime value )
        {
            var query = _query.ExistsByIPV_DATA_COLETAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_DATA_AVAL(DateTime value )
        {
            var query = _query.ExistsByIPV_DATA_AVALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_ID(int value )
        {
            var query = _query.ExistsByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_ID(string value )
        {
            var query = _query.ExistsByTURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_ID(string value )
        {
            var query = _query.ExistsByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PRO_ID(string value )
        {
            var query = _query.ExistsByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_MAQ_ID(string value )
        {
            var query = _query.ExistsByROT_MAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_STATUS_LIBERACAO(string value )
        {
            var query = _query.ExistsByIPV_STATUS_LIBERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_VALOR_MEDIDA(Decimal value )
        {
            var query = _query.ExistsByIPV_VALOR_MEDIDAQuery(value );

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

        public InspecaoVisualDTO FirstByIPV_ID(int value )
        {
            var query = _query.FirstByIPV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_VALOR(string value )
        {
            var query = _query.FirstByIPV_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_ID_OPERADOR(int value )
        {
            var query = _query.FirstByIPV_ID_OPERADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_ID_LIBERACAO(int value )
        {
            var query = _query.FirstByIPV_ID_LIBERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_OBS(string value )
        {
            var query = _query.FirstByIPV_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_DATA_COLETA(DateTime value )
        {
            var query = _query.FirstByIPV_DATA_COLETAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_DATA_AVAL(DateTime value )
        {
            var query = _query.FirstByIPV_DATA_AVALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByTURN_ID(string value )
        {
            var query = _query.FirstByTURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByROT_MAQ_ID(string value )
        {
            var query = _query.FirstByROT_MAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByROT_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_STATUS_LIBERACAO(string value )
        {
            var query = _query.FirstByIPV_STATUS_LIBERACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByIPV_VALOR_MEDIDA(Decimal value )
        {
            var query = _query.FirstByIPV_VALOR_MEDIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public InspecaoVisualDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_ID(int value )
        {
            var query = _query.FirstByIPV_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_VALOR(string value )
        {
            var query = _query.FirstByIPV_VALORQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_ID_OPERADOR(int value )
        {
            var query = _query.FirstByIPV_ID_OPERADORQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_ID_LIBERACAO(int value )
        {
            var query = _query.FirstByIPV_ID_LIBERACAOQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_OBS(string value )
        {
            var query = _query.FirstByIPV_OBSQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_DATA_COLETA(DateTime value )
        {
            var query = _query.FirstByIPV_DATA_COLETAQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_DATA_AVAL(DateTime value )
        {
            var query = _query.FirstByIPV_DATA_AVALQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByTURN_ID(string value )
        {
            var query = _query.FirstByTURN_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByROT_MAQ_ID(string value )
        {
            var query = _query.FirstByROT_MAQ_IDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByROT_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_STATUS_LIBERACAO(string value )
        {
            var query = _query.FirstByIPV_STATUS_LIBERACAOQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_VALOR_MEDIDA(Decimal value )
        {
            var query = _query.FirstByIPV_VALOR_MEDIDAQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<InspecaoVisualDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<InspecaoVisualDTO>(query.Query,query.Parameters) as List<InspecaoVisualDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration