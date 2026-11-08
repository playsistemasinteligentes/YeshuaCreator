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
    public partial class CTeComplementoIcmsFiscalReadRepository : ICTeComplementoIcmsFiscalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeComplementoIcmsFiscalQueryRead _query;

        public CTeComplementoIcmsFiscalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeComplementoIcmsFiscalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeComplementoIcmsFiscalCustom(Command.Read.CTeComplementoIcmsFiscalReadCommand command, ref DataPagination<CTeComplementoIcmsFiscalDTO> result, ref bool handled);

        public DataPagination<CTeComplementoIcmsFiscalDTO> getCTeComplementoIcmsFiscal(ICommandRead command )
         {
            if (command is Command.Read.CTeComplementoIcmsFiscalReadCommand c)
                return getCTeComplementoIcmsFiscal(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeComplementoIcmsFiscalDTO> getCTeComplementoIcmsFiscal(Command.Read.CTeComplementoIcmsFiscalReadCommand command )
        {
            var customResult = new DataPagination<CTeComplementoIcmsFiscalDTO>();
            var customHandled = false;
            TryGetCTeComplementoIcmsFiscalCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeComplementoIcmsFiscalQuery(command );

                var itens = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeComplementoIcmsFiscalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeComplementoIcmsFiscalCTeSolicitacaoFiscalIdDTO> getCTeComplementoIcmsFiscalReadFKCTeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeComplementoIcmsFiscalCTeSolicitacaoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<CTeComplementoIcmsFiscalCTeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeComplementoIcmsFiscalCTeSolicitacaoFiscalIdDTO> getCTeComplementoIcmsFiscalReadFKCTeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeComplementoIcmsFiscalReadFKCTeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeComplementoIcmsFiscalTenantIDDTO> getCTeComplementoIcmsFiscalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeComplementoIcmsFiscalTenantIDQuery(command );

                var lista = _unitOfWork.Query<CTeComplementoIcmsFiscalTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeComplementoIcmsFiscalTenantIDDTO> getCTeComplementoIcmsFiscalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeComplementoIcmsFiscalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeComplementoIcmsFiscalUserIdDTO> getCTeComplementoIcmsFiscalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeComplementoIcmsFiscalUserIdQuery(command );

                var lista = _unitOfWork.Query<CTeComplementoIcmsFiscalUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeComplementoIcmsFiscalUserIdDTO> getCTeComplementoIcmsFiscalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeComplementoIcmsFiscalReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.ExistsByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorPrestacaoComplementar(Decimal value )
        {
            var query = _query.ExistsByValorPrestacaoComplementarQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCST(string value )
        {
            var query = _query.ExistsByCSTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorBaseCalculo(Decimal value )
        {
            var query = _query.ExistsByValorBaseCalculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAliquotaICMS(Decimal value )
        {
            var query = _query.ExistsByAliquotaICMSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorICMS(Decimal value )
        {
            var query = _query.ExistsByValorICMSQuery(value );

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

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public CTeComplementoIcmsFiscalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByValorPrestacaoComplementar(Decimal value )
        {
            var query = _query.FirstByValorPrestacaoComplementarQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByCST(string value )
        {
            var query = _query.FirstByCSTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByValorBaseCalculo(Decimal value )
        {
            var query = _query.FirstByValorBaseCalculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByAliquotaICMS(Decimal value )
        {
            var query = _query.FirstByAliquotaICMSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByValorICMS(Decimal value )
        {
            var query = _query.FirstByValorICMSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeComplementoIcmsFiscalDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeComplementoIcmsFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByValorPrestacaoComplementar(Decimal value )
        {
            var query = _query.FirstByValorPrestacaoComplementarQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByCST(string value )
        {
            var query = _query.FirstByCSTQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByValorBaseCalculo(Decimal value )
        {
            var query = _query.FirstByValorBaseCalculoQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByAliquotaICMS(Decimal value )
        {
            var query = _query.FirstByAliquotaICMSQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByValorICMS(Decimal value )
        {
            var query = _query.FirstByValorICMSQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<CTeComplementoIcmsFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration