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
    public partial class CorConfiguracaoGraficoReadRepository : ICorConfiguracaoGraficoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICorConfiguracaoGraficoQueryRead _query;

        public CorConfiguracaoGraficoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICorConfiguracaoGraficoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCorConfiguracaoGraficoCustom(Command.Read.CorConfiguracaoGraficoReadCommand command, ref DataPagination<CorConfiguracaoGraficoDTO> result, ref bool handled);

        public DataPagination<CorConfiguracaoGraficoDTO> getCorConfiguracaoGrafico(ICommandRead command )
         {
            if (command is Command.Read.CorConfiguracaoGraficoReadCommand c)
                return getCorConfiguracaoGrafico(c );
            throw new NotImplementedException();
        }
        private DataPagination<CorConfiguracaoGraficoDTO> getCorConfiguracaoGrafico(Command.Read.CorConfiguracaoGraficoReadCommand command )
        {
            DataPagination<CorConfiguracaoGraficoDTO> customResult = null;
            var customHandled = false;
            TryGetCorConfiguracaoGraficoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CorConfiguracaoGraficoQuery(command );

                var itens = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters);
                return new DataPagination<CorConfiguracaoGraficoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CorConfiguracaoGraficoTenantIDDTO> getCorConfiguracaoGraficoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CorConfiguracaoGraficoTenantIDDTO> lista;
            var query = _query.CorConfiguracaoGraficoTenantIDQuery(command );

                lista = _unitOfWork.Query<CorConfiguracaoGraficoTenantIDDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CorConfiguracaoGraficoTenantIDDTO> getCorConfiguracaoGraficoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCorConfiguracaoGraficoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CorConfiguracaoGraficoUserIdDTO> getCorConfiguracaoGraficoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CorConfiguracaoGraficoUserIdDTO> lista;
            var query = _query.CorConfiguracaoGraficoUserIdQuery(command );

                lista = _unitOfWork.Query<CorConfiguracaoGraficoUserIdDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoUserIdDTO>;
            return lista;
        }

        public IEnumerable<CorConfiguracaoGraficoUserIdDTO> getCorConfiguracaoGraficoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCorConfiguracaoGraficoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByCOR_ID(string value )
        {
            var query = _query.ExistsByCOR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_PERCENTUAL_INI(Decimal value )
        {
            var query = _query.ExistsByCOR_PERCENTUAL_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_PERCENTUAL_FIM(Decimal value )
        {
            var query = _query.ExistsByCOR_PERCENTUAL_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_DESCRICAO(string value )
        {
            var query = _query.ExistsByCOR_DESCRICAOQuery(value );

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

        public CorConfiguracaoGraficoDTO FirstByCOR_ID(string value )
        {
            var query = _query.FirstByCOR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByCOR_PERCENTUAL_INI(Decimal value )
        {
            var query = _query.FirstByCOR_PERCENTUAL_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByCOR_PERCENTUAL_FIM(Decimal value )
        {
            var query = _query.FirstByCOR_PERCENTUAL_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByCOR_DESCRICAO(string value )
        {
            var query = _query.FirstByCOR_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorConfiguracaoGraficoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorConfiguracaoGraficoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_ID(string value )
        {
            var query = _query.FirstByCOR_IDQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_PERCENTUAL_INI(Decimal value )
        {
            var query = _query.FirstByCOR_PERCENTUAL_INIQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_PERCENTUAL_FIM(Decimal value )
        {
            var query = _query.FirstByCOR_PERCENTUAL_FIMQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_DESCRICAO(string value )
        {
            var query = _query.FirstByCOR_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CorConfiguracaoGraficoDTO>(query.Query,query.Parameters) as List<CorConfiguracaoGraficoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration