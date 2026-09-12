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
    public partial class MDFeTentativaEmissaoReadRepository : IMDFeTentativaEmissaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeTentativaEmissaoQueryRead _query;

        public MDFeTentativaEmissaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeTentativaEmissaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMDFeTentativaEmissaoCustom(Command.Read.MDFeTentativaEmissaoReadCommand command, ref DataPagination<MDFeTentativaEmissaoDTO> result, ref bool handled);

        public DataPagination<MDFeTentativaEmissaoDTO> getMDFeTentativaEmissao(ICommandRead command )
         {
            if (command is Command.Read.MDFeTentativaEmissaoReadCommand c)
                return getMDFeTentativaEmissao(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeTentativaEmissaoDTO> getMDFeTentativaEmissao(Command.Read.MDFeTentativaEmissaoReadCommand command )
        {
            var customResult = new DataPagination<MDFeTentativaEmissaoDTO>();
            var customHandled = false;
            TryGetMDFeTentativaEmissaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MDFeTentativaEmissaoQuery(command );

                var itens = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeTentativaEmissaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeTentativaEmissaoMDFeSolicitacaoFiscalIdDTO> getMDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFeTentativaEmissaoMDFeSolicitacaoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<MDFeTentativaEmissaoMDFeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFeTentativaEmissaoMDFeSolicitacaoFiscalIdDTO> getMDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeTentativaEmissaoTenantIDDTO> getMDFeTentativaEmissaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFeTentativaEmissaoTenantIDQuery(command );

                var lista = _unitOfWork.Query<MDFeTentativaEmissaoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFeTentativaEmissaoTenantIDDTO> getMDFeTentativaEmissaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeTentativaEmissaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeTentativaEmissaoUserIdDTO> getMDFeTentativaEmissaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFeTentativaEmissaoUserIdQuery(command );

                var lista = _unitOfWork.Query<MDFeTentativaEmissaoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFeTentativaEmissaoUserIdDTO> getMDFeTentativaEmissaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeTentativaEmissaoReadFKUserId(c );
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

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNumero(int value )
        {
            var query = _query.ExistsByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySerie(int value )
        {
            var query = _query.ExistsBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTentativa(int value )
        {
            var query = _query.ExistsByTentativaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByXmlAssinadoStorageKey(string value )
        {
            var query = _query.ExistsByXmlAssinadoStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByXmlProcStorageKey(string value )
        {
            var query = _query.ExistsByXmlProcStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByXmlHash(string value )
        {
            var query = _query.ExistsByXmlHashQuery(value );

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

        public bool ExistsByProtocoloAutorizacao(string value )
        {
            var query = _query.ExistsByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEnviadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByEnviadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAutorizadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByAutorizadoEmUtcQuery(value );

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

        public MDFeTentativaEmissaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByTentativa(int value )
        {
            var query = _query.FirstByTentativaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByXmlAssinadoStorageKey(string value )
        {
            var query = _query.FirstByXmlAssinadoStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByXmlProcStorageKey(string value )
        {
            var query = _query.FirstByXmlProcStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByXmlHash(string value )
        {
            var query = _query.FirstByXmlHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByProtocoloAutorizacao(string value )
        {
            var query = _query.FirstByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByEnviadoEmUtc(DateTime value )
        {
            var query = _query.FirstByEnviadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByAutorizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeTentativaEmissaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByTentativa(int value )
        {
            var query = _query.FirstByTentativaQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByXmlAssinadoStorageKey(string value )
        {
            var query = _query.FirstByXmlAssinadoStorageKeyQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByXmlProcStorageKey(string value )
        {
            var query = _query.FirstByXmlProcStorageKeyQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByXmlHash(string value )
        {
            var query = _query.FirstByXmlHashQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByProtocoloAutorizacao(string value )
        {
            var query = _query.FirstByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByEnviadoEmUtc(DateTime value )
        {
            var query = _query.FirstByEnviadoEmUtcQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByAutorizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmUtcQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeTentativaEmissaoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration