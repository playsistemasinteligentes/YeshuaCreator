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
    public partial class InformacoesComplementaresReadRepository : IInformacoesComplementaresReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IInformacoesComplementaresQueryRead _query;

        public InformacoesComplementaresReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IInformacoesComplementaresQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<InformacoesComplementaresDTO> getInformacoesComplementares(ICommandRead command )
         {
            if (command is Command.Read.InformacoesComplementaresReadCommand c)
                return getInformacoesComplementares(c );
            throw new NotImplementedException();
        }
        private DataPagination<InformacoesComplementaresDTO> getInformacoesComplementares(Command.Read.InformacoesComplementaresReadCommand command )
        {
            var query = _query.InformacoesComplementaresQuery(command );

                var itens = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters);
                return new DataPagination<InformacoesComplementaresDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<InformacoesComplementaresMET_IDDTO> getInformacoesComplementaresReadFKMET_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InformacoesComplementaresMET_IDDTO> lista;
            var query = _query.InformacoesComplementaresMET_IDQuery(command );

                lista = _unitOfWork.Query<InformacoesComplementaresMET_IDDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresMET_IDDTO>;
            return lista;
        }

        public IEnumerable<InformacoesComplementaresMET_IDDTO> getInformacoesComplementaresReadFKMET_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInformacoesComplementaresReadFKMET_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<InformacoesComplementaresTenantIDDTO> getInformacoesComplementaresReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InformacoesComplementaresTenantIDDTO> lista;
            var query = _query.InformacoesComplementaresTenantIDQuery(command );

                lista = _unitOfWork.Query<InformacoesComplementaresTenantIDDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresTenantIDDTO>;
            return lista;
        }

        public IEnumerable<InformacoesComplementaresTenantIDDTO> getInformacoesComplementaresReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInformacoesComplementaresReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<InformacoesComplementaresUserIdDTO> getInformacoesComplementaresReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<InformacoesComplementaresUserIdDTO> lista;
            var query = _query.InformacoesComplementaresUserIdQuery(command );

                lista = _unitOfWork.Query<InformacoesComplementaresUserIdDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresUserIdDTO>;
            return lista;
        }

        public IEnumerable<InformacoesComplementaresUserIdDTO> getInformacoesComplementaresReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getInformacoesComplementaresReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByINF_ID(int value )
        {
            var query = _query.ExistsByINF_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByINF_DESCRICAO(string value )
        {
            var query = _query.ExistsByINF_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByINF_VALOR(Decimal value )
        {
            var query = _query.ExistsByINF_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_ID(int value )
        {
            var query = _query.ExistsByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByINF_DATA(string value )
        {
            var query = _query.ExistsByINF_DATAQuery(value );

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

        public InformacoesComplementaresDTO FirstByINF_ID(int value )
        {
            var query = _query.FirstByINF_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByINF_DESCRICAO(string value )
        {
            var query = _query.FirstByINF_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByINF_VALOR(Decimal value )
        {
            var query = _query.FirstByINF_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByINF_DATA(string value )
        {
            var query = _query.FirstByINF_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public InformacoesComplementaresDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<InformacoesComplementaresDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_ID(int value )
        {
            var query = _query.FirstByINF_IDQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_DESCRICAO(string value )
        {
            var query = _query.FirstByINF_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_VALOR(Decimal value )
        {
            var query = _query.FirstByINF_VALORQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_DATA(string value )
        {
            var query = _query.FirstByINF_DATAQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

        public IEnumerable<InformacoesComplementaresDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<InformacoesComplementaresDTO>(query.Query,query.Parameters) as List<InformacoesComplementaresDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration