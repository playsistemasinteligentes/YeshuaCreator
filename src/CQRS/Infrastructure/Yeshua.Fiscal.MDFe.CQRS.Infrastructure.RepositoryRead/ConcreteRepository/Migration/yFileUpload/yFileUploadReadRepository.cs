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
    public partial class yFileUploadReadRepository : IyFileUploadReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyFileUploadQueryRead _query;

        public yFileUploadReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyFileUploadQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<yFileUploadDTO> getyFileUpload(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.yFileUploadReadCommand c)
                return getyFileUpload(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<yFileUploadDTO> getyFileUpload(Command.Read.yFileUploadReadCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.yFileUploadQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters);
                return new DataPagination<yFileUploadDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yFileUploadTenantIDDTO> getyFileUploadReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yFileUploadTenantIDDTO> lista;
            var query = _query.yFileUploadTenantIDQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yFileUploadTenantIDDTO>(query.Query,query.Parameters) as List<yFileUploadTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yFileUploadTenantIDDTO> getyFileUploadReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyFileUploadReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yFileUploadUserIdDTO> getyFileUploadReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yFileUploadUserIdDTO> lista;
            var query = _query.yFileUploadUserIdQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yFileUploadUserIdDTO>(query.Query,query.Parameters) as List<yFileUploadUserIdDTO>;
            return lista;
        }

        public IEnumerable<yFileUploadUserIdDTO> getyFileUploadReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyFileUploadReadFKUserId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

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

        public bool ExistsByFilePath(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByFilePathQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFileSize(long value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByFileSizeQuery(value , TakeOffTenantID);

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

        public yFileUploadDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByFilePath(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByFilePathQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByFileSize(long value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByFileSizeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public yFileUploadDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yFileUploadDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByStatus(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByStatusQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByFilePath(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByFilePathQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByFileSize(long value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByFileSizeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityTypeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEntityIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCompletedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

        public IEnumerable<yFileUploadDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yFileUploadDTO>(query.Query,query.Parameters) as List<yFileUploadDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration