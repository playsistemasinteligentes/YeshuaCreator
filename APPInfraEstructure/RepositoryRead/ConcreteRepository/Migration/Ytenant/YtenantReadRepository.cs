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
    public partial class yTenantReadRepository : IyTenantReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyTenantQueryRead _query;

        public yTenantReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyTenantQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<yTenantDTO> getyTenant(ICommandRead command , bool TakeOffId = false)
         {
            if (command is Command.Read.yTenantReadCommand c)
                return getyTenant(c , TakeOffId);
            throw new NotImplementedException();
        }
        private DataPagination<yTenantDTO> getyTenant(Command.Read.yTenantReadCommand command , bool TakeOffId = false)
        {
            var query = _query.yTenantQuery(command , TakeOffId);

                var itens = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters);
                return new DataPagination<yTenantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value , bool TakeOffId = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCnpjCpf(string value , bool TakeOffId = false)
        {
            var query = _query.ExistsByCnpjCpfQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value , bool TakeOffId = false)
        {
            var query = _query.ExistsByNomeQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value , bool TakeOffId = false)
        {
            var query = _query.ExistsByUserIdQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value , bool TakeOffId = false)
        {
            var query = _query.ExistsByDeletedQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value , bool TakeOffId = false)
        {
            var query = _query.ExistsByChangedQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public yTenantDTO FirstById(int value , bool TakeOffId = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<yTenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantDTO FirstByCnpjCpf(string value , bool TakeOffId = false)
        {
            var query = _query.FirstByCnpjCpfQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<yTenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantDTO FirstByNome(string value , bool TakeOffId = false)
        {
            var query = _query.FirstByNomeQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<yTenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantDTO FirstByUserId(int value , bool TakeOffId = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<yTenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantDTO FirstByDeleted(bool value , bool TakeOffId = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<yTenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantDTO FirstByChanged(DateTime value , bool TakeOffId = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffId);

                var result = _unitOfWork.QueryFirstOrDefault<yTenantDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yTenantDTO> GetAllById(int value , bool TakeOffId = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffId);

                var result = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters) as List<yTenantDTO>;
                return result;
        }

        public IEnumerable<yTenantDTO> GetAllByCnpjCpf(string value , bool TakeOffId = false)
        {
            var query = _query.FirstByCnpjCpfQuery(value , TakeOffId);

                var result = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters) as List<yTenantDTO>;
                return result;
        }

        public IEnumerable<yTenantDTO> GetAllByNome(string value , bool TakeOffId = false)
        {
            var query = _query.FirstByNomeQuery(value , TakeOffId);

                var result = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters) as List<yTenantDTO>;
                return result;
        }

        public IEnumerable<yTenantDTO> GetAllByUserId(int value , bool TakeOffId = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffId);

                var result = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters) as List<yTenantDTO>;
                return result;
        }

        public IEnumerable<yTenantDTO> GetAllByDeleted(bool value , bool TakeOffId = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffId);

                var result = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters) as List<yTenantDTO>;
                return result;
        }

        public IEnumerable<yTenantDTO> GetAllByChanged(DateTime value , bool TakeOffId = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffId);

                var result = _unitOfWork.Query<yTenantDTO>(query.Query,query.Parameters) as List<yTenantDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration