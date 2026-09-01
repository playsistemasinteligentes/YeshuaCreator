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
    public partial class TipoInspecaoVisualReadRepository : ITipoInspecaoVisualReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoInspecaoVisualQueryRead _query;

        public TipoInspecaoVisualReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoInspecaoVisualQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoInspecaoVisualCustom(Command.Read.TipoInspecaoVisualReadCommand command, ref DataPagination<TipoInspecaoVisualDTO> result, ref bool handled);

        public DataPagination<TipoInspecaoVisualDTO> getTipoInspecaoVisual(ICommandRead command )
         {
            if (command is Command.Read.TipoInspecaoVisualReadCommand c)
                return getTipoInspecaoVisual(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoInspecaoVisualDTO> getTipoInspecaoVisual(Command.Read.TipoInspecaoVisualReadCommand command )
        {
            DataPagination<TipoInspecaoVisualDTO> customResult = null;
            var customHandled = false;
            TryGetTipoInspecaoVisualCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoInspecaoVisualQuery(command );

                var itens = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoInspecaoVisualDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoInspecaoVisualTenantIDDTO> getTipoInspecaoVisualReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoInspecaoVisualTenantIDDTO> lista;
            var query = _query.TipoInspecaoVisualTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoInspecaoVisualTenantIDDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoInspecaoVisualTenantIDDTO> getTipoInspecaoVisualReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoInspecaoVisualReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoInspecaoVisualUserIdDTO> getTipoInspecaoVisualReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoInspecaoVisualUserIdDTO> lista;
            var query = _query.TipoInspecaoVisualUserIdQuery(command );

                lista = _unitOfWork.Query<TipoInspecaoVisualUserIdDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoInspecaoVisualUserIdDTO> getTipoInspecaoVisualReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoInspecaoVisualReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_ID(int value )
        {
            var query = _query.ExistsByTIV_IDQuery(value );

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

        public bool ExistsByTIV_NOME(string value )
        {
            var query = _query.ExistsByTIV_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_DESCRICAO(string value )
        {
            var query = _query.ExistsByTIV_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_FECHAMENTO(string value )
        {
            var query = _query.ExistsByTIV_FECHAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_AMOSTRA_ALEATORIA(string value )
        {
            var query = _query.ExistsByTIV_AMOSTRA_ALEATORIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_N_AMOSTRAS(int value )
        {
            var query = _query.ExistsByTIV_N_AMOSTRASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_MEDIDA(string value )
        {
            var query = _query.ExistsByTIV_MEDIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_ESPECIFICACAO(Decimal value )
        {
            var query = _query.ExistsByTIV_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_TOL_MAIS(Decimal value )
        {
            var query = _query.ExistsByTIV_TOL_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIV_TOL_MENOS(Decimal value )
        {
            var query = _query.ExistsByTIV_TOL_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public TipoInspecaoVisualDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_NOME(string value )
        {
            var query = _query.FirstByTIV_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_DESCRICAO(string value )
        {
            var query = _query.FirstByTIV_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_FECHAMENTO(string value )
        {
            var query = _query.FirstByTIV_FECHAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_AMOSTRA_ALEATORIA(string value )
        {
            var query = _query.FirstByTIV_AMOSTRA_ALEATORIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_N_AMOSTRAS(int value )
        {
            var query = _query.FirstByTIV_N_AMOSTRASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_MEDIDA(string value )
        {
            var query = _query.FirstByTIV_MEDIDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_ESPECIFICACAO(Decimal value )
        {
            var query = _query.FirstByTIV_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_TOL_MAIS(Decimal value )
        {
            var query = _query.FirstByTIV_TOL_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoInspecaoVisualDTO FirstByTIV_TOL_MENOS(Decimal value )
        {
            var query = _query.FirstByTIV_TOL_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoInspecaoVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_ID(int value )
        {
            var query = _query.FirstByTIV_IDQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_NOME(string value )
        {
            var query = _query.FirstByTIV_NOMEQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_DESCRICAO(string value )
        {
            var query = _query.FirstByTIV_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_FECHAMENTO(string value )
        {
            var query = _query.FirstByTIV_FECHAMENTOQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_AMOSTRA_ALEATORIA(string value )
        {
            var query = _query.FirstByTIV_AMOSTRA_ALEATORIAQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_N_AMOSTRAS(int value )
        {
            var query = _query.FirstByTIV_N_AMOSTRASQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_MEDIDA(string value )
        {
            var query = _query.FirstByTIV_MEDIDAQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_ESPECIFICACAO(Decimal value )
        {
            var query = _query.FirstByTIV_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_TOL_MAIS(Decimal value )
        {
            var query = _query.FirstByTIV_TOL_MAISQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_TOL_MENOS(Decimal value )
        {
            var query = _query.FirstByTIV_TOL_MENOSQuery(value );

                var result = _unitOfWork.Query<TipoInspecaoVisualDTO>(query.Query,query.Parameters) as List<TipoInspecaoVisualDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration