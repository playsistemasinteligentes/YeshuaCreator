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
    public partial class VincoReadRepository : IVincoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVincoQueryRead _query;

        public VincoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVincoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetVincoCustom(Command.Read.VincoReadCommand command, ref DataPagination<VincoDTO> result, ref bool handled);

        public DataPagination<VincoDTO> getVinco(ICommandRead command )
         {
            if (command is Command.Read.VincoReadCommand c)
                return getVinco(c );
            throw new NotImplementedException();
        }
        private DataPagination<VincoDTO> getVinco(Command.Read.VincoReadCommand command )
        {
            DataPagination<VincoDTO> customResult = null;
            var customHandled = false;
            TryGetVincoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.VincoQuery(command );

                var itens = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters);
                return new DataPagination<VincoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VincoTenantIDDTO> getVincoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VincoTenantIDDTO> lista;
            var query = _query.VincoTenantIDQuery(command );

                lista = _unitOfWork.Query<VincoTenantIDDTO>(query.Query,query.Parameters) as List<VincoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VincoTenantIDDTO> getVincoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVincoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VincoUserIdDTO> getVincoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VincoUserIdDTO> lista;
            var query = _query.VincoUserIdQuery(command );

                lista = _unitOfWork.Query<VincoUserIdDTO>(query.Query,query.Parameters) as List<VincoUserIdDTO>;
            return lista;
        }

        public IEnumerable<VincoUserIdDTO> getVincoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVincoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByVIN_ID(int value )
        {
            var query = _query.ExistsByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIN_DESCRICAO(string value )
        {
            var query = _query.ExistsByVIN_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIN_ID_DESLOCAMENTO(string value )
        {
            var query = _query.ExistsByVIN_ID_DESLOCAMENTOQuery(value );

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

        public VincoDTO FirstByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VincoDTO FirstByVIN_DESCRICAO(string value )
        {
            var query = _query.FirstByVIN_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VincoDTO FirstByVIN_ID_DESLOCAMENTO(string value )
        {
            var query = _query.FirstByVIN_ID_DESLOCAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VincoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VincoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VincoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VincoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VincoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByVIN_ID(int value )
        {
            var query = _query.FirstByVIN_IDQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByVIN_DESCRICAO(string value )
        {
            var query = _query.FirstByVIN_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByVIN_ID_DESLOCAMENTO(string value )
        {
            var query = _query.FirstByVIN_ID_DESLOCAMENTOQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

        public IEnumerable<VincoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VincoDTO>(query.Query,query.Parameters) as List<VincoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration