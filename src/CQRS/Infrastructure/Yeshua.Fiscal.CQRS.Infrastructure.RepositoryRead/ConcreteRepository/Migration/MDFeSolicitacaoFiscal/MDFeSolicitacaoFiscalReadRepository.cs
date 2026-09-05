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
    public partial class MDFeSolicitacaoFiscalReadRepository : IMDFeSolicitacaoFiscalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeSolicitacaoFiscalQueryRead _query;

        public MDFeSolicitacaoFiscalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeSolicitacaoFiscalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMDFeSolicitacaoFiscalCustom(Command.Read.MDFeSolicitacaoFiscalReadCommand command, ref DataPagination<MDFeSolicitacaoFiscalDTO> result, ref bool handled);

        public DataPagination<MDFeSolicitacaoFiscalDTO> getMDFeSolicitacaoFiscal(ICommandRead command )
         {
            if (command is Command.Read.MDFeSolicitacaoFiscalReadCommand c)
                return getMDFeSolicitacaoFiscal(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeSolicitacaoFiscalDTO> getMDFeSolicitacaoFiscal(Command.Read.MDFeSolicitacaoFiscalReadCommand command )
        {
            DataPagination<MDFeSolicitacaoFiscalDTO> customResult = null;
            var customHandled = false;
            TryGetMDFeSolicitacaoFiscalCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MDFeSolicitacaoFiscalQuery(command );

                var itens = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeSolicitacaoFiscalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeSolicitacaoFiscalTenantIDDTO> getMDFeSolicitacaoFiscalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeSolicitacaoFiscalTenantIDDTO> lista;
            var query = _query.MDFeSolicitacaoFiscalTenantIDQuery(command );

                lista = _unitOfWork.Query<MDFeSolicitacaoFiscalTenantIDDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MDFeSolicitacaoFiscalTenantIDDTO> getMDFeSolicitacaoFiscalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeSolicitacaoFiscalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeSolicitacaoFiscalUserIdDTO> getMDFeSolicitacaoFiscalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeSolicitacaoFiscalUserIdDTO> lista;
            var query = _query.MDFeSolicitacaoFiscalUserIdQuery(command );

                lista = _unitOfWork.Query<MDFeSolicitacaoFiscalUserIdDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalUserIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeSolicitacaoFiscalUserIdDTO> getMDFeSolicitacaoFiscalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeSolicitacaoFiscalReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCargaId(string value )
        {
            var query = _query.ExistsByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAmbiente(int value )
        {
            var query = _query.ExistsByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFCarregamento(string value )
        {
            var query = _query.ExistsByUFCarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFDescarregamento(string value )
        {
            var query = _query.ExistsByUFDescarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPlacaVeiculo(string value )
        {
            var query = _query.ExistsByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCondutorDocumento(string value )
        {
            var query = _query.ExistsByCondutorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumentosOriginariosJson(string value )
        {
            var query = _query.ExistsByDocumentosOriginariosJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTransporteSnapshotJson(string value )
        {
            var query = _query.ExistsByTransporteSnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public MDFeSolicitacaoFiscalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByUFCarregamento(string value )
        {
            var query = _query.FirstByUFCarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByUFDescarregamento(string value )
        {
            var query = _query.FirstByUFDescarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByCondutorDocumento(string value )
        {
            var query = _query.FirstByCondutorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByDocumentosOriginariosJson(string value )
        {
            var query = _query.FirstByDocumentosOriginariosJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByTransporteSnapshotJson(string value )
        {
            var query = _query.FirstByTransporteSnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeSolicitacaoFiscalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByUFCarregamento(string value )
        {
            var query = _query.FirstByUFCarregamentoQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByUFDescarregamento(string value )
        {
            var query = _query.FirstByUFDescarregamentoQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByCondutorDocumento(string value )
        {
            var query = _query.FirstByCondutorDocumentoQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByDocumentosOriginariosJson(string value )
        {
            var query = _query.FirstByDocumentosOriginariosJsonQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByTransporteSnapshotJson(string value )
        {
            var query = _query.FirstByTransporteSnapshotJsonQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<MDFeSolicitacaoFiscalDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration