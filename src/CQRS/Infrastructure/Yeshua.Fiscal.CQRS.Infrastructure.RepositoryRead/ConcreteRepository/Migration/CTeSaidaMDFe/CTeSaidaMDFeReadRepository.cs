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
    public partial class CTeSaidaMDFeReadRepository : ICTeSaidaMDFeReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeSaidaMDFeQueryRead _query;

        public CTeSaidaMDFeReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeSaidaMDFeQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeSaidaMDFeCustom(Command.Read.CTeSaidaMDFeReadCommand command, ref DataPagination<CTeSaidaMDFeDTO> result, ref bool handled);

        public DataPagination<CTeSaidaMDFeDTO> getCTeSaidaMDFe(ICommandRead command )
         {
            if (command is Command.Read.CTeSaidaMDFeReadCommand c)
                return getCTeSaidaMDFe(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeSaidaMDFeDTO> getCTeSaidaMDFe(Command.Read.CTeSaidaMDFeReadCommand command )
        {
            DataPagination<CTeSaidaMDFeDTO> customResult = null;
            var customHandled = false;
            TryGetCTeSaidaMDFeCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeSaidaMDFeQuery(command );

                var itens = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeSaidaMDFeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeSaidaMDFeCTeTentativaEmissaoIdDTO> getCTeSaidaMDFeReadFKCTeTentativaEmissaoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSaidaMDFeCTeTentativaEmissaoIdDTO> lista;
            var query = _query.CTeSaidaMDFeCTeTentativaEmissaoIdQuery(command );

                lista = _unitOfWork.Query<CTeSaidaMDFeCTeTentativaEmissaoIdDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeCTeTentativaEmissaoIdDTO>;
            return lista;
        }

        public IEnumerable<CTeSaidaMDFeCTeTentativaEmissaoIdDTO> getCTeSaidaMDFeReadFKCTeTentativaEmissaoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSaidaMDFeReadFKCTeTentativaEmissaoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeSaidaMDFeTenantIDDTO> getCTeSaidaMDFeReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSaidaMDFeTenantIDDTO> lista;
            var query = _query.CTeSaidaMDFeTenantIDQuery(command );

                lista = _unitOfWork.Query<CTeSaidaMDFeTenantIDDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CTeSaidaMDFeTenantIDDTO> getCTeSaidaMDFeReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSaidaMDFeReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeSaidaMDFeUserIdDTO> getCTeSaidaMDFeReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSaidaMDFeUserIdDTO> lista;
            var query = _query.CTeSaidaMDFeUserIdQuery(command );

                lista = _unitOfWork.Query<CTeSaidaMDFeUserIdDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeUserIdDTO>;
            return lista;
        }

        public IEnumerable<CTeSaidaMDFeUserIdDTO> getCTeSaidaMDFeReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSaidaMDFeReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCTeTentativaEmissaoId(int value )
        {
            var query = _query.ExistsByCTeTentativaEmissaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcessoCTe(string value )
        {
            var query = _query.ExistsByChaveAcessoCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySnapshotHash(string value )
        {
            var query = _query.ExistsBySnapshotHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOutboxMessageId(string value )
        {
            var query = _query.ExistsByOutboxMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPublicadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByPublicadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUltimoErro(string value )
        {
            var query = _query.ExistsByUltimoErroQuery(value );

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

        public CTeSaidaMDFeDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByCTeTentativaEmissaoId(int value )
        {
            var query = _query.FirstByCTeTentativaEmissaoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByChaveAcessoCTe(string value )
        {
            var query = _query.FirstByChaveAcessoCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstBySnapshotHash(string value )
        {
            var query = _query.FirstBySnapshotHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByOutboxMessageId(string value )
        {
            var query = _query.FirstByOutboxMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByPublicadoEmUtc(DateTime value )
        {
            var query = _query.FirstByPublicadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByUltimoErro(string value )
        {
            var query = _query.FirstByUltimoErroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSaidaMDFeDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSaidaMDFeDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByCTeTentativaEmissaoId(int value )
        {
            var query = _query.FirstByCTeTentativaEmissaoIdQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByChaveAcessoCTe(string value )
        {
            var query = _query.FirstByChaveAcessoCTeQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllBySnapshotHash(string value )
        {
            var query = _query.FirstBySnapshotHashQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByOutboxMessageId(string value )
        {
            var query = _query.FirstByOutboxMessageIdQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByPublicadoEmUtc(DateTime value )
        {
            var query = _query.FirstByPublicadoEmUtcQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByUltimoErro(string value )
        {
            var query = _query.FirstByUltimoErroQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

        public IEnumerable<CTeSaidaMDFeDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeSaidaMDFeDTO>(query.Query,query.Parameters) as List<CTeSaidaMDFeDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration