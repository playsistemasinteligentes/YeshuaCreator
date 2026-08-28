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
    public partial class AuditoriaReadRepository : IAuditoriaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IAuditoriaQueryRead _query;

        public AuditoriaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IAuditoriaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<AuditoriaDTO> getAuditoria(ICommandRead command )
         {
            if (command is Command.Read.AuditoriaReadCommand c)
                return getAuditoria(c );
            throw new NotImplementedException();
        }
        private DataPagination<AuditoriaDTO> getAuditoria(Command.Read.AuditoriaReadCommand command )
        {
            var query = _query.AuditoriaQuery(command );

                var itens = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters);
                return new DataPagination<AuditoriaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<AuditoriaUSE_IDDTO> getAuditoriaReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<AuditoriaUSE_IDDTO> lista;
            var query = _query.AuditoriaUSE_IDQuery(command );

                lista = _unitOfWork.Query<AuditoriaUSE_IDDTO>(query.Query,query.Parameters) as List<AuditoriaUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<AuditoriaUSE_IDDTO> getAuditoriaReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAuditoriaReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<AuditoriaTenantIDDTO> getAuditoriaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<AuditoriaTenantIDDTO> lista;
            var query = _query.AuditoriaTenantIDQuery(command );

                lista = _unitOfWork.Query<AuditoriaTenantIDDTO>(query.Query,query.Parameters) as List<AuditoriaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<AuditoriaTenantIDDTO> getAuditoriaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAuditoriaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<AuditoriaUserIdDTO> getAuditoriaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<AuditoriaUserIdDTO> lista;
            var query = _query.AuditoriaUserIdQuery(command );

                lista = _unitOfWork.Query<AuditoriaUserIdDTO>(query.Query,query.Parameters) as List<AuditoriaUserIdDTO>;
            return lista;
        }

        public IEnumerable<AuditoriaUserIdDTO> getAuditoriaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAuditoriaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByID(int value )
        {
            var query = _query.ExistsByIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDATA(DateTime value )
        {
            var query = _query.ExistsByDATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROTINA(string value )
        {
            var query = _query.ExistsByROTINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHISTORICO(string value )
        {
            var query = _query.ExistsByHISTORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCHAVE(string value )
        {
            var query = _query.ExistsByCHAVEQuery(value );

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

        public AuditoriaDTO FirstByID(int value )
        {
            var query = _query.FirstByIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByDATA(DateTime value )
        {
            var query = _query.FirstByDATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByROTINA(string value )
        {
            var query = _query.FirstByROTINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByHISTORICO(string value )
        {
            var query = _query.FirstByHISTORICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByCHAVE(string value )
        {
            var query = _query.FirstByCHAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public AuditoriaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AuditoriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByID(int value )
        {
            var query = _query.FirstByIDQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByDATA(DateTime value )
        {
            var query = _query.FirstByDATAQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByROTINA(string value )
        {
            var query = _query.FirstByROTINAQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByHISTORICO(string value )
        {
            var query = _query.FirstByHISTORICOQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByCHAVE(string value )
        {
            var query = _query.FirstByCHAVEQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

        public IEnumerable<AuditoriaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<AuditoriaDTO>(query.Query,query.Parameters) as List<AuditoriaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration