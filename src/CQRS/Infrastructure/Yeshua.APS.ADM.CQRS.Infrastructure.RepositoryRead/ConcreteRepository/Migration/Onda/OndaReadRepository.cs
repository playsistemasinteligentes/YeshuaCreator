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
    public partial class OndaReadRepository : IOndaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOndaQueryRead _query;

        public OndaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOndaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetOndaCustom(Command.Read.OndaReadCommand command, ref DataPagination<OndaDTO> result, ref bool handled);

        public DataPagination<OndaDTO> getOnda(ICommandRead command )
         {
            if (command is Command.Read.OndaReadCommand c)
                return getOnda(c );
            throw new NotImplementedException();
        }
        private DataPagination<OndaDTO> getOnda(Command.Read.OndaReadCommand command )
        {
            DataPagination<OndaDTO> customResult = null;
            var customHandled = false;
            TryGetOndaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.OndaQuery(command );

                var itens = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters);
                return new DataPagination<OndaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OndaVIN_IDDTO> getOndaReadFKVIN_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OndaVIN_IDDTO> lista;
            var query = _query.OndaVIN_IDQuery(command );

                lista = _unitOfWork.Query<OndaVIN_IDDTO>(query.Query,query.Parameters) as List<OndaVIN_IDDTO>;
            return lista;
        }

        public IEnumerable<OndaVIN_IDDTO> getOndaReadFKVIN_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOndaReadFKVIN_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OndaTenantIDDTO> getOndaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OndaTenantIDDTO> lista;
            var query = _query.OndaTenantIDQuery(command );

                lista = _unitOfWork.Query<OndaTenantIDDTO>(query.Query,query.Parameters) as List<OndaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OndaTenantIDDTO> getOndaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOndaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OndaUserIdDTO> getOndaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OndaUserIdDTO> lista;
            var query = _query.OndaUserIdQuery(command );

                lista = _unitOfWork.Query<OndaUserIdDTO>(query.Query,query.Parameters) as List<OndaUserIdDTO>;
            return lista;
        }

        public IEnumerable<OndaUserIdDTO> getOndaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOndaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByOND_ID(string value )
        {
            var query = _query.ExistsByOND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_ESPESSURA(Decimal value )
        {
            var query = _query.ExistsByOND_ESPESSURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_PESO_COLA(Decimal value )
        {
            var query = _query.ExistsByOND_PESO_COLAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_RENDIMENTO_ONDA_1(Decimal value )
        {
            var query = _query.ExistsByOND_RENDIMENTO_ONDA_1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_RENDIMENTO_ONDA_2(Decimal value )
        {
            var query = _query.ExistsByOND_RENDIMENTO_ONDA_2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_PROFUNDIDADE_VINCO(int value )
        {
            var query = _query.ExistsByOND_PROFUNDIDADE_VINCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByOND_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIN_ID(int value )
        {
            var query = _query.ExistsByVIN_IDQuery(value );

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

        public OndaDTO FirstByOND_ID(string value )
        {
            var query = _query.FirstByOND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByOND_ESPESSURA(Decimal value )
        {
            var query = _query.FirstByOND_ESPESSURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByOND_PESO_COLA(Decimal value )
        {
            var query = _query.FirstByOND_PESO_COLAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByOND_RENDIMENTO_ONDA_1(Decimal value )
        {
            var query = _query.FirstByOND_RENDIMENTO_ONDA_1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByOND_RENDIMENTO_ONDA_2(Decimal value )
        {
            var query = _query.FirstByOND_RENDIMENTO_ONDA_2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByOND_PROFUNDIDADE_VINCO(int value )
        {
            var query = _query.FirstByOND_PROFUNDIDADE_VINCOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByOND_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByOND_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OndaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OndaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_ID(string value )
        {
            var query = _query.FirstByOND_IDQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_ESPESSURA(Decimal value )
        {
            var query = _query.FirstByOND_ESPESSURAQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_PESO_COLA(Decimal value )
        {
            var query = _query.FirstByOND_PESO_COLAQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_RENDIMENTO_ONDA_1(Decimal value )
        {
            var query = _query.FirstByOND_RENDIMENTO_ONDA_1Query(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_RENDIMENTO_ONDA_2(Decimal value )
        {
            var query = _query.FirstByOND_RENDIMENTO_ONDA_2Query(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_PROFUNDIDADE_VINCO(int value )
        {
            var query = _query.FirstByOND_PROFUNDIDADE_VINCOQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByOND_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByOND_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

        public IEnumerable<OndaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OndaDTO>(query.Query,query.Parameters) as List<OndaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration