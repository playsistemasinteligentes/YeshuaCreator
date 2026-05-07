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
    public partial class yUserReadRepository : IyUserReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyUserQueryRead _query;

        public yUserReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyUserQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<yUserDTO> getyUser(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.yUserReadCommand c)
                return getyUser(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<yUserDTO> getyUser(Command.Read.yUserReadCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.yUserQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters);
                return new DataPagination<yUserDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yUserTenantIDDTO> getyUserReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            List<yUserTenantIDDTO> lista;
            var query = _query.yUserTenantIDQuery(command , TakeOffTenantID);

                lista = _unitOfWork.Query<yUserTenantIDDTO>(query.Query,query.Parameters) as List<yUserTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yUserTenantIDDTO> getyUserReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByNomeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmail(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByEmailQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySenha(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsBySenhaQuery(value , TakeOffTenantID);

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

        public yUserDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserDTO FirstByNome(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByNomeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserDTO FirstByEmail(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEmailQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserDTO FirstBySenha(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySenhaQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yUserDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yUserDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

        public IEnumerable<yUserDTO> GetAllByNome(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByNomeQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

        public IEnumerable<yUserDTO> GetAllByEmail(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByEmailQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

        public IEnumerable<yUserDTO> GetAllBySenha(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstBySenhaQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

        public IEnumerable<yUserDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

        public IEnumerable<yUserDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

        public IEnumerable<yUserDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yUserDTO>(query.Query,query.Parameters) as List<yUserDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration