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
    public partial class MDFeVeiculoReadRepository : IMDFeVeiculoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeVeiculoQueryRead _query;

        public MDFeVeiculoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeVeiculoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMDFeVeiculoCustom(Command.Read.MDFeVeiculoReadCommand command, ref DataPagination<MDFeVeiculoDTO> result, ref bool handled);

        public DataPagination<MDFeVeiculoDTO> getMDFeVeiculo(ICommandRead command )
         {
            if (command is Command.Read.MDFeVeiculoReadCommand c)
                return getMDFeVeiculo(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeVeiculoDTO> getMDFeVeiculo(Command.Read.MDFeVeiculoReadCommand command )
        {
            DataPagination<MDFeVeiculoDTO> customResult = null;
            var customHandled = false;
            TryGetMDFeVeiculoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MDFeVeiculoQuery(command );

                var itens = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeVeiculoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeVeiculoMDFeSolicitacaoFiscalIdDTO> getMDFeVeiculoReadFKMDFeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeVeiculoMDFeSolicitacaoFiscalIdDTO> lista;
            var query = _query.MDFeVeiculoMDFeSolicitacaoFiscalIdQuery(command );

                lista = _unitOfWork.Query<MDFeVeiculoMDFeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters) as List<MDFeVeiculoMDFeSolicitacaoFiscalIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeVeiculoMDFeSolicitacaoFiscalIdDTO> getMDFeVeiculoReadFKMDFeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeVeiculoReadFKMDFeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeVeiculoTenantIDDTO> getMDFeVeiculoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeVeiculoTenantIDDTO> lista;
            var query = _query.MDFeVeiculoTenantIDQuery(command );

                lista = _unitOfWork.Query<MDFeVeiculoTenantIDDTO>(query.Query,query.Parameters) as List<MDFeVeiculoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MDFeVeiculoTenantIDDTO> getMDFeVeiculoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeVeiculoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeVeiculoUserIdDTO> getMDFeVeiculoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeVeiculoUserIdDTO> lista;
            var query = _query.MDFeVeiculoUserIdQuery(command );

                lista = _unitOfWork.Query<MDFeVeiculoUserIdDTO>(query.Query,query.Parameters) as List<MDFeVeiculoUserIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeVeiculoUserIdDTO> getMDFeVeiculoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeVeiculoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.ExistsByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPlaca(string value )
        {
            var query = _query.ExistsByPlacaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRenavam(string value )
        {
            var query = _query.ExistsByRenavamQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTara(Decimal value )
        {
            var query = _query.ExistsByTaraQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCapacidadeKg(Decimal value )
        {
            var query = _query.ExistsByCapacidadeKgQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCapacidadeM3(Decimal value )
        {
            var query = _query.ExistsByCapacidadeM3Query(value );

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

        public MDFeVeiculoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByPlaca(string value )
        {
            var query = _query.FirstByPlacaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByRenavam(string value )
        {
            var query = _query.FirstByRenavamQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByTara(Decimal value )
        {
            var query = _query.FirstByTaraQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByCapacidadeKg(Decimal value )
        {
            var query = _query.FirstByCapacidadeKgQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByCapacidadeM3(Decimal value )
        {
            var query = _query.FirstByCapacidadeM3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeVeiculoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByPlaca(string value )
        {
            var query = _query.FirstByPlacaQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByRenavam(string value )
        {
            var query = _query.FirstByRenavamQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByTara(Decimal value )
        {
            var query = _query.FirstByTaraQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByCapacidadeKg(Decimal value )
        {
            var query = _query.FirstByCapacidadeKgQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByCapacidadeM3(Decimal value )
        {
            var query = _query.FirstByCapacidadeM3Query(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

        public IEnumerable<MDFeVeiculoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeVeiculoDTO>(query.Query,query.Parameters) as List<MDFeVeiculoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration