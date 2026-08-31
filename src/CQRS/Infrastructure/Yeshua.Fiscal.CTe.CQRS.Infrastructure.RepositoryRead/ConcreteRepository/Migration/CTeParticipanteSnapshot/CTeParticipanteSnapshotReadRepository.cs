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
    public partial class CTeParticipanteSnapshotReadRepository : ICTeParticipanteSnapshotReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeParticipanteSnapshotQueryRead _query;

        public CTeParticipanteSnapshotReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeParticipanteSnapshotQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CTeParticipanteSnapshotDTO> getCTeParticipanteSnapshot(ICommandRead command )
         {
            if (command is Command.Read.CTeParticipanteSnapshotReadCommand c)
                return getCTeParticipanteSnapshot(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeParticipanteSnapshotDTO> getCTeParticipanteSnapshot(Command.Read.CTeParticipanteSnapshotReadCommand command )
        {
            var query = _query.CTeParticipanteSnapshotQuery(command );

                var itens = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeParticipanteSnapshotDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeParticipanteSnapshotCTeSolicitacaoFiscalIdDTO> getCTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeParticipanteSnapshotCTeSolicitacaoFiscalIdDTO> lista;
            var query = _query.CTeParticipanteSnapshotCTeSolicitacaoFiscalIdQuery(command );

                lista = _unitOfWork.Query<CTeParticipanteSnapshotCTeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotCTeSolicitacaoFiscalIdDTO>;
            return lista;
        }

        public IEnumerable<CTeParticipanteSnapshotCTeSolicitacaoFiscalIdDTO> getCTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeParticipanteSnapshotTenantIDDTO> getCTeParticipanteSnapshotReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeParticipanteSnapshotTenantIDDTO> lista;
            var query = _query.CTeParticipanteSnapshotTenantIDQuery(command );

                lista = _unitOfWork.Query<CTeParticipanteSnapshotTenantIDDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CTeParticipanteSnapshotTenantIDDTO> getCTeParticipanteSnapshotReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeParticipanteSnapshotReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeParticipanteSnapshotUserIdDTO> getCTeParticipanteSnapshotReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeParticipanteSnapshotUserIdDTO> lista;
            var query = _query.CTeParticipanteSnapshotUserIdQuery(command );

                lista = _unitOfWork.Query<CTeParticipanteSnapshotUserIdDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotUserIdDTO>;
            return lista;
        }

        public IEnumerable<CTeParticipanteSnapshotUserIdDTO> getCTeParticipanteSnapshotReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeParticipanteSnapshotReadFKUserId(c );
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

        public bool ExistsByPapel(string value )
        {
            var query = _query.ExistsByPapelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumento(string value )
        {
            var query = _query.ExistsByDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByInscricaoEstadual(string value )
        {
            var query = _query.ExistsByInscricaoEstadualQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUF(string value )
        {
            var query = _query.ExistsByUFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEnderecoJson(string value )
        {
            var query = _query.ExistsByEnderecoJsonQuery(value );

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

        public CTeParticipanteSnapshotDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByPapel(string value )
        {
            var query = _query.FirstByPapelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByDocumento(string value )
        {
            var query = _query.FirstByDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByInscricaoEstadual(string value )
        {
            var query = _query.FirstByInscricaoEstadualQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByUF(string value )
        {
            var query = _query.FirstByUFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByMunicipioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByEnderecoJson(string value )
        {
            var query = _query.FirstByEnderecoJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeParticipanteSnapshotDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeParticipanteSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByPapel(string value )
        {
            var query = _query.FirstByPapelQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByDocumento(string value )
        {
            var query = _query.FirstByDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByInscricaoEstadual(string value )
        {
            var query = _query.FirstByInscricaoEstadualQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByUF(string value )
        {
            var query = _query.FirstByUFQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByMunicipioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByEnderecoJson(string value )
        {
            var query = _query.FirstByEnderecoJsonQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeParticipanteSnapshotDTO>(query.Query,query.Parameters) as List<CTeParticipanteSnapshotDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration