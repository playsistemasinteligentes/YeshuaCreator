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
    public partial class MaquinaImpressoraReadRepository : IMaquinaImpressoraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMaquinaImpressoraQueryRead _query;

        public MaquinaImpressoraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMaquinaImpressoraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMaquinaImpressoraCustom(Command.Read.MaquinaImpressoraReadCommand command, ref DataPagination<MaquinaImpressoraDTO> result, ref bool handled);

        public DataPagination<MaquinaImpressoraDTO> getMaquinaImpressora(ICommandRead command )
         {
            if (command is Command.Read.MaquinaImpressoraReadCommand c)
                return getMaquinaImpressora(c );
            throw new NotImplementedException();
        }
        private DataPagination<MaquinaImpressoraDTO> getMaquinaImpressora(Command.Read.MaquinaImpressoraReadCommand command )
        {
            DataPagination<MaquinaImpressoraDTO> customResult = null;
            var customHandled = false;
            TryGetMaquinaImpressoraCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MaquinaImpressoraQuery(command );

                var itens = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters);
                return new DataPagination<MaquinaImpressoraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MaquinaImpressoraIMP_IDDTO> getMaquinaImpressoraReadFKIMP_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaImpressoraIMP_IDDTO> lista;
            var query = _query.MaquinaImpressoraIMP_IDQuery(command );

                lista = _unitOfWork.Query<MaquinaImpressoraIMP_IDDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraIMP_IDDTO>;
            return lista;
        }

        public IEnumerable<MaquinaImpressoraIMP_IDDTO> getMaquinaImpressoraReadFKIMP_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaImpressoraReadFKIMP_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MaquinaImpressoraTenantIDDTO> getMaquinaImpressoraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaImpressoraTenantIDDTO> lista;
            var query = _query.MaquinaImpressoraTenantIDQuery(command );

                lista = _unitOfWork.Query<MaquinaImpressoraTenantIDDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MaquinaImpressoraTenantIDDTO> getMaquinaImpressoraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaImpressoraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MaquinaImpressoraUserIdDTO> getMaquinaImpressoraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MaquinaImpressoraUserIdDTO> lista;
            var query = _query.MaquinaImpressoraUserIdQuery(command );

                lista = _unitOfWork.Query<MaquinaImpressoraUserIdDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraUserIdDTO>;
            return lista;
        }

        public IEnumerable<MaquinaImpressoraUserIdDTO> getMaquinaImpressoraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMaquinaImpressoraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMAQ_IMP_ID(int value )
        {
            var query = _query.ExistsByMAQ_IMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIMP_ID(int value )
        {
            var query = _query.ExistsByIMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAI_FACAO(int value )
        {
            var query = _query.ExistsByMAI_FACAOQuery(value );

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

        public MaquinaImpressoraDTO FirstByMAQ_IMP_ID(int value )
        {
            var query = _query.FirstByMAQ_IMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByIMP_ID(int value )
        {
            var query = _query.FirstByIMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByMAI_FACAO(int value )
        {
            var query = _query.FirstByMAI_FACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MaquinaImpressoraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MaquinaImpressoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByMAQ_IMP_ID(int value )
        {
            var query = _query.FirstByMAQ_IMP_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByIMP_ID(int value )
        {
            var query = _query.FirstByIMP_IDQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByMAI_FACAO(int value )
        {
            var query = _query.FirstByMAI_FACAOQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

        public IEnumerable<MaquinaImpressoraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MaquinaImpressoraDTO>(query.Query,query.Parameters) as List<MaquinaImpressoraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration