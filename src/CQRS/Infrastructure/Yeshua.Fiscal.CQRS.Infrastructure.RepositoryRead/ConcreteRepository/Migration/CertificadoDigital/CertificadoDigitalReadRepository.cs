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
    public partial class CertificadoDigitalReadRepository : ICertificadoDigitalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICertificadoDigitalQueryRead _query;

        public CertificadoDigitalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICertificadoDigitalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCertificadoDigitalCustom(Command.Read.CertificadoDigitalReadCommand command, ref DataPagination<CertificadoDigitalDTO> result, ref bool handled);

        public DataPagination<CertificadoDigitalDTO> getCertificadoDigital(ICommandRead command )
         {
            if (command is Command.Read.CertificadoDigitalReadCommand c)
                return getCertificadoDigital(c );
            throw new NotImplementedException();
        }
        private DataPagination<CertificadoDigitalDTO> getCertificadoDigital(Command.Read.CertificadoDigitalReadCommand command )
        {
            var customResult = new DataPagination<CertificadoDigitalDTO>();
            var customHandled = false;
            TryGetCertificadoDigitalCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CertificadoDigitalQuery(command );

                var itens = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters);
                return new DataPagination<CertificadoDigitalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CertificadoDigitalTenantIDDTO> getCertificadoDigitalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CertificadoDigitalTenantIDQuery(command );

                var lista = _unitOfWork.Query<CertificadoDigitalTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CertificadoDigitalTenantIDDTO> getCertificadoDigitalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCertificadoDigitalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CertificadoDigitalUserIdDTO> getCertificadoDigitalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CertificadoDigitalUserIdQuery(command );

                var lista = _unitOfWork.Query<CertificadoDigitalUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CertificadoDigitalUserIdDTO> getCertificadoDigitalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCertificadoDigitalReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByApelido(string value )
        {
            var query = _query.ExistsByApelidoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumentoTitular(string value )
        {
            var query = _query.ExistsByDocumentoTitularQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStorageKey(string value )
        {
            var query = _query.ExistsByStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByThumbprint(string value )
        {
            var query = _query.ExistsByThumbprintQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidoDe(DateTime value )
        {
            var query = _query.ExistsByValidoDeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidoAte(DateTime value )
        {
            var query = _query.ExistsByValidoAteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAtivo(int value )
        {
            var query = _query.ExistsByAtivoQuery(value );

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

        public CertificadoDigitalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByApelido(string value )
        {
            var query = _query.FirstByApelidoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByDocumentoTitular(string value )
        {
            var query = _query.FirstByDocumentoTitularQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByStorageKey(string value )
        {
            var query = _query.FirstByStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByThumbprint(string value )
        {
            var query = _query.FirstByThumbprintQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByValidoDe(DateTime value )
        {
            var query = _query.FirstByValidoDeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByValidoAte(DateTime value )
        {
            var query = _query.FirstByValidoAteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByAtivo(int value )
        {
            var query = _query.FirstByAtivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CertificadoDigitalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CertificadoDigitalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByApelido(string value )
        {
            var query = _query.FirstByApelidoQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByDocumentoTitular(string value )
        {
            var query = _query.FirstByDocumentoTitularQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByStorageKey(string value )
        {
            var query = _query.FirstByStorageKeyQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByThumbprint(string value )
        {
            var query = _query.FirstByThumbprintQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByValidoDe(DateTime value )
        {
            var query = _query.FirstByValidoDeQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByValidoAte(DateTime value )
        {
            var query = _query.FirstByValidoAteQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByAtivo(int value )
        {
            var query = _query.FirstByAtivoQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CertificadoDigitalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CertificadoDigitalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration