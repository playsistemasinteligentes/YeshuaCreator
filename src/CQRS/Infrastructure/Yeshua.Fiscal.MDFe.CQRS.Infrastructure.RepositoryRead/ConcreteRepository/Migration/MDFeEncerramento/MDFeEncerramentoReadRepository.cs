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
    public partial class MDFeEncerramentoReadRepository : IMDFeEncerramentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeEncerramentoQueryRead _query;

        public MDFeEncerramentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeEncerramentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MDFeEncerramentoDTO> getMDFeEncerramento(ICommandRead command )
         {
            if (command is Command.Read.MDFeEncerramentoReadCommand c)
                return getMDFeEncerramento(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeEncerramentoDTO> getMDFeEncerramento(Command.Read.MDFeEncerramentoReadCommand command )
        {
            var query = _query.MDFeEncerramentoQuery(command );

                var itens = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeEncerramentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeEncerramentoMDFeIdDTO> getMDFeEncerramentoReadFKMDFeId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeEncerramentoMDFeIdDTO> lista;
            var query = _query.MDFeEncerramentoMDFeIdQuery(command );

                lista = _unitOfWork.Query<MDFeEncerramentoMDFeIdDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoMDFeIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeEncerramentoMDFeIdDTO> getMDFeEncerramentoReadFKMDFeId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeEncerramentoReadFKMDFeId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeEncerramentoTenantIDDTO> getMDFeEncerramentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeEncerramentoTenantIDDTO> lista;
            var query = _query.MDFeEncerramentoTenantIDQuery(command );

                lista = _unitOfWork.Query<MDFeEncerramentoTenantIDDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MDFeEncerramentoTenantIDDTO> getMDFeEncerramentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeEncerramentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeEncerramentoUserIdDTO> getMDFeEncerramentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeEncerramentoUserIdDTO> lista;
            var query = _query.MDFeEncerramentoUserIdQuery(command );

                lista = _unitOfWork.Query<MDFeEncerramentoUserIdDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoUserIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeEncerramentoUserIdDTO> getMDFeEncerramentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeEncerramentoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDFeId(int value )
        {
            var query = _query.ExistsByMDFeIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

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

        public bool ExistsBySolicitadoEm(DateTime value )
        {
            var query = _query.ExistsBySolicitadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAutorizadoEm(DateTime value )
        {
            var query = _query.ExistsByAutorizadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProtocolo(string value )
        {
            var query = _query.ExistsByProtocoloQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCodigoRetorno(string value )
        {
            var query = _query.ExistsByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMensagemRetorno(string value )
        {
            var query = _query.ExistsByMensagemRetornoQuery(value );

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

        public MDFeEncerramentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByMDFeId(int value )
        {
            var query = _query.FirstByMDFeIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByUfCarregamento(string value )
        {
            var query = _query.FirstByUfCarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByUfDescarregamento(string value )
        {
            var query = _query.FirstByUfDescarregamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstBySolicitadoEm(DateTime value )
        {
            var query = _query.FirstBySolicitadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByAutorizadoEm(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByProtocolo(string value )
        {
            var query = _query.FirstByProtocoloQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeEncerramentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeEncerramentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByMDFeId(int value )
        {
            var query = _query.FirstByMDFeIdQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByUfCarregamento(string value )
        {
            var query = _query.FirstByUfCarregamentoQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByUfDescarregamento(string value )
        {
            var query = _query.FirstByUfDescarregamentoQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllBySolicitadoEm(DateTime value )
        {
            var query = _query.FirstBySolicitadoEmQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByAutorizadoEm(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByProtocolo(string value )
        {
            var query = _query.FirstByProtocoloQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

        public IEnumerable<MDFeEncerramentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeEncerramentoDTO>(query.Query,query.Parameters) as List<MDFeEncerramentoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration