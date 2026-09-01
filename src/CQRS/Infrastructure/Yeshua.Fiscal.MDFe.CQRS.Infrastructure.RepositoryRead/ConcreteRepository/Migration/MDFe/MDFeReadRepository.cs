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
    public partial class MDFeReadRepository : IMDFeReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeQueryRead _query;

        public MDFeReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MDFeDTO> getMDFe(ICommandRead command )
         {
            if (command is Command.Read.MDFeReadCommand c)
                return getMDFe(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeDTO> getMDFe(Command.Read.MDFeReadCommand command )
        {
            var query = _query.MDFeQuery(command );

                var itens = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeTenantIDDTO> getMDFeReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeTenantIDDTO> lista;
            var query = _query.MDFeTenantIDQuery(command );

                lista = _unitOfWork.Query<MDFeTenantIDDTO>(query.Query,query.Parameters) as List<MDFeTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MDFeTenantIDDTO> getMDFeReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeUserIdDTO> getMDFeReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeUserIdDTO> lista;
            var query = _query.MDFeUserIdQuery(command );

                lista = _unitOfWork.Query<MDFeUserIdDTO>(query.Query,query.Parameters) as List<MDFeUserIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeUserIdDTO> getMDFeReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySerie(int value )
        {
            var query = _query.ExistsBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNumero(int value )
        {
            var query = _query.ExistsByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUfCarregamento(string value )
        {
            var query = _query.ExistsByUfCarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUfDescarregamento(string value )
        {
            var query = _query.ExistsByUfDescarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPlacaVeiculo(string value )
        {
            var query = _query.ExistsByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmitidoEm(DateTime value )
        {
            var query = _query.ExistsByEmitidoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAutorizadoEm(DateTime value )
        {
            var query = _query.ExistsByAutorizadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIniciadoEm(DateTime value )
        {
            var query = _query.ExistsByIniciadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEncerradoEm(DateTime value )
        {
            var query = _query.ExistsByEncerradoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCanceladoEm(DateTime value )
        {
            var query = _query.ExistsByCanceladoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySituacao(int value )
        {
            var query = _query.ExistsBySituacaoQuery(value );

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

        public MDFeDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByUfCarregamento(string value )
        {
            var query = _query.FirstByUfCarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByUfDescarregamento(string value )
        {
            var query = _query.FirstByUfDescarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByEmitidoEm(DateTime value )
        {
            var query = _query.FirstByEmitidoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByAutorizadoEm(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByIniciadoEm(DateTime value )
        {
            var query = _query.FirstByIniciadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByEncerradoEm(DateTime value )
        {
            var query = _query.FirstByEncerradoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByCanceladoEm(DateTime value )
        {
            var query = _query.FirstByCanceladoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstBySituacao(int value )
        {
            var query = _query.FirstBySituacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByUfCarregamento(string value )
        {
            var query = _query.FirstByUfCarregamentoQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByUfDescarregamento(string value )
        {
            var query = _query.FirstByUfDescarregamentoQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByEmitidoEm(DateTime value )
        {
            var query = _query.FirstByEmitidoEmQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByAutorizadoEm(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByIniciadoEm(DateTime value )
        {
            var query = _query.FirstByIniciadoEmQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByEncerradoEm(DateTime value )
        {
            var query = _query.FirstByEncerradoEmQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByCanceladoEm(DateTime value )
        {
            var query = _query.FirstByCanceladoEmQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllBySituacao(int value )
        {
            var query = _query.FirstBySituacaoQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

        public IEnumerable<MDFeDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeDTO>(query.Query,query.Parameters) as List<MDFeDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration