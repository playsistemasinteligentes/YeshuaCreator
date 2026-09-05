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
    public partial class CTeTentativaEmissaoReadRepository : ICTeTentativaEmissaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeTentativaEmissaoQueryRead _query;

        public CTeTentativaEmissaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeTentativaEmissaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeTentativaEmissaoCustom(Command.Read.CTeTentativaEmissaoReadCommand command, ref DataPagination<CTeTentativaEmissaoDTO> result, ref bool handled);

        public DataPagination<CTeTentativaEmissaoDTO> getCTeTentativaEmissao(ICommandRead command )
         {
            if (command is Command.Read.CTeTentativaEmissaoReadCommand c)
                return getCTeTentativaEmissao(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeTentativaEmissaoDTO> getCTeTentativaEmissao(Command.Read.CTeTentativaEmissaoReadCommand command )
        {
            DataPagination<CTeTentativaEmissaoDTO> customResult = null;
            var customHandled = false;
            TryGetCTeTentativaEmissaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeTentativaEmissaoQuery(command );

                var itens = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeTentativaEmissaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeTentativaEmissaoCTeSolicitacaoFiscalIdDTO> getCTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeTentativaEmissaoCTeSolicitacaoFiscalIdDTO> lista;
            var query = _query.CTeTentativaEmissaoCTeSolicitacaoFiscalIdQuery(command );

                lista = _unitOfWork.Query<CTeTentativaEmissaoCTeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoCTeSolicitacaoFiscalIdDTO>;
            return lista;
        }

        public IEnumerable<CTeTentativaEmissaoCTeSolicitacaoFiscalIdDTO> getCTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeTentativaEmissaoTenantIDDTO> getCTeTentativaEmissaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeTentativaEmissaoTenantIDDTO> lista;
            var query = _query.CTeTentativaEmissaoTenantIDQuery(command );

                lista = _unitOfWork.Query<CTeTentativaEmissaoTenantIDDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CTeTentativaEmissaoTenantIDDTO> getCTeTentativaEmissaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeTentativaEmissaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeTentativaEmissaoUserIdDTO> getCTeTentativaEmissaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeTentativaEmissaoUserIdDTO> lista;
            var query = _query.CTeTentativaEmissaoUserIdQuery(command );

                lista = _unitOfWork.Query<CTeTentativaEmissaoUserIdDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<CTeTentativaEmissaoUserIdDTO> getCTeTentativaEmissaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeTentativaEmissaoReadFKUserId(c );
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

        public CTeTentativaEmissaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByTentativa(int value )
        {
            var query = _query.FirstByTentativaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByXmlAssinadoStorageKey(string value )
        {
            var query = _query.FirstByXmlAssinadoStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByXmlProcStorageKey(string value )
        {
            var query = _query.FirstByXmlProcStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByXmlHash(string value )
        {
            var query = _query.FirstByXmlHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByProtocoloAutorizacao(string value )
        {
            var query = _query.FirstByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByEnviadoEmUtc(DateTime value )
        {
            var query = _query.FirstByEnviadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByAutorizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeTentativaEmissaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeTentativaEmissaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByTentativa(int value )
        {
            var query = _query.FirstByTentativaQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByXmlAssinadoStorageKey(string value )
        {
            var query = _query.FirstByXmlAssinadoStorageKeyQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByXmlProcStorageKey(string value )
        {
            var query = _query.FirstByXmlProcStorageKeyQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByXmlHash(string value )
        {
            var query = _query.FirstByXmlHashQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByProtocoloAutorizacao(string value )
        {
            var query = _query.FirstByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByEnviadoEmUtc(DateTime value )
        {
            var query = _query.FirstByEnviadoEmUtcQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByAutorizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAutorizadoEmUtcQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeTentativaEmissaoDTO>(query.Query,query.Parameters) as List<CTeTentativaEmissaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration