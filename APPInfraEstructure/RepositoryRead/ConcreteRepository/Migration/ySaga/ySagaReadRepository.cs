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
    public partial class ySagaReadRepository : IySagaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICurrentUser _currentUser;
       protected readonly IySagaQueryRead _query;

        public ySagaReadRepository(IUnitOfWork unitOfWork, ICurrentUser currentUser,IySagaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<ySagaDTO> getySaga(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.ySagaReadCommand c)
                return getySaga(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<ySagaDTO> getySaga(Command.Read.ySagaReadCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.ySagaQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters);
                return new DataPagination<ySagaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ySagaTenantIDDTO> getySagaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<ySagaTenantIDDTO> lista;
            var query = _query.ySagaTenantIDQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<ySagaTenantIDDTO>(query.Query,query.Parameters) as List<ySagaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ySagaTenantIDDTO> getySagaReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ySagaUserIdDTO> getySagaReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<ySagaUserIdDTO> lista;
            var query = _query.ySagaUserIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<ySagaUserIdDTO>(query.Query,query.Parameters) as List<ySagaUserIdDTO>;
            return lista;
        }

        public IEnumerable<ySagaUserIdDTO> getySagaReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getySagaReadFKUserId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySagaId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByKeyCurrentStep(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByKeyCurrentStepQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNextExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByNextExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLockedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLockedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLockedBy(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLockedByQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ySagaDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstBySagaId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByKeyCurrentStep(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByKeyCurrentStepQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByNextExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByNextExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByLockedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByLockedBy(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedByQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ySagaDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<ySagaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllBySagaId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySagaIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByKeyCurrentStep(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByKeyCurrentStepQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByNextExecutionAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByNextExecutionAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByLockedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByLockedBy(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLockedByQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

        public IEnumerable<ySagaDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<ySagaDTO>(query.Query,query.Parameters) as List<ySagaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration