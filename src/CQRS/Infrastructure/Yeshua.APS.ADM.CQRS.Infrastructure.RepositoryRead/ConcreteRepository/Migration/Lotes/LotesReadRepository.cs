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
    public partial class LotesReadRepository : ILotesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ILotesQueryRead _query;

        public LotesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ILotesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<LotesDTO> getLotes(ICommandRead command )
         {
            if (command is Command.Read.LotesReadCommand c)
                return getLotes(c );
            throw new NotImplementedException();
        }
        private DataPagination<LotesDTO> getLotes(Command.Read.LotesReadCommand command )
        {
            var query = _query.LotesQuery(command );

                var itens = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters);
                return new DataPagination<LotesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<LotesTenantIDDTO> getLotesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LotesTenantIDDTO> lista;
            var query = _query.LotesTenantIDQuery(command );

                lista = _unitOfWork.Query<LotesTenantIDDTO>(query.Query,query.Parameters) as List<LotesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<LotesTenantIDDTO> getLotesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLotesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LotesUserIdDTO> getLotesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LotesUserIdDTO> lista;
            var query = _query.LotesUserIdQuery(command );

                lista = _unitOfWork.Query<LotesUserIdDTO>(query.Query,query.Parameters) as List<LotesUserIdDTO>;
            return lista;
        }

        public IEnumerable<LotesUserIdDTO> getLotesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLotesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_LOTE(string value )
        {
            var query = _query.ExistsByMOV_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_SUB_LOTE(string value )
        {
            var query = _query.ExistsByMOV_SUB_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOT_LARGURA(Decimal value )
        {
            var query = _query.ExistsByLOT_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOT_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByLOT_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOT_DIAMETRO(Decimal value )
        {
            var query = _query.ExistsByLOT_DIAMETROQuery(value );

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

        public LotesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByMOV_LOTE(string value )
        {
            var query = _query.FirstByMOV_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByMOV_SUB_LOTE(string value )
        {
            var query = _query.FirstByMOV_SUB_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByLOT_LARGURA(Decimal value )
        {
            var query = _query.FirstByLOT_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByLOT_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByLOT_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByLOT_DIAMETRO(Decimal value )
        {
            var query = _query.FirstByLOT_DIAMETROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public LotesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LotesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<LotesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByMOV_LOTE(string value )
        {
            var query = _query.FirstByMOV_LOTEQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByMOV_SUB_LOTE(string value )
        {
            var query = _query.FirstByMOV_SUB_LOTEQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByLOT_LARGURA(Decimal value )
        {
            var query = _query.FirstByLOT_LARGURAQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByLOT_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByLOT_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByLOT_DIAMETRO(Decimal value )
        {
            var query = _query.FirstByLOT_DIAMETROQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

        public IEnumerable<LotesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<LotesDTO>(query.Query,query.Parameters) as List<LotesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration