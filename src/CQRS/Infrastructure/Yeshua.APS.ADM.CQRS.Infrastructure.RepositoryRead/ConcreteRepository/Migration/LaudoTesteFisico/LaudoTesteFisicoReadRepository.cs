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
    public partial class LaudoTesteFisicoReadRepository : ILaudoTesteFisicoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ILaudoTesteFisicoQueryRead _query;

        public LaudoTesteFisicoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ILaudoTesteFisicoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<LaudoTesteFisicoDTO> getLaudoTesteFisico(ICommandRead command )
         {
            if (command is Command.Read.LaudoTesteFisicoReadCommand c)
                return getLaudoTesteFisico(c );
            throw new NotImplementedException();
        }
        private DataPagination<LaudoTesteFisicoDTO> getLaudoTesteFisico(Command.Read.LaudoTesteFisicoReadCommand command )
        {
            var query = _query.LaudoTesteFisicoQuery(command );

                var itens = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters);
                return new DataPagination<LaudoTesteFisicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<LaudoTesteFisicoTenantIDDTO> getLaudoTesteFisicoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LaudoTesteFisicoTenantIDDTO> lista;
            var query = _query.LaudoTesteFisicoTenantIDQuery(command );

                lista = _unitOfWork.Query<LaudoTesteFisicoTenantIDDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<LaudoTesteFisicoTenantIDDTO> getLaudoTesteFisicoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLaudoTesteFisicoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LaudoTesteFisicoUserIdDTO> getLaudoTesteFisicoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LaudoTesteFisicoUserIdDTO> lista;
            var query = _query.LaudoTesteFisicoUserIdQuery(command );

                lista = _unitOfWork.Query<LaudoTesteFisicoUserIdDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoUserIdDTO>;
            return lista;
        }

        public IEnumerable<LaudoTesteFisicoUserIdDTO> getLaudoTesteFisicoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLaudoTesteFisicoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLTF_ID(int value )
        {
            var query = _query.ExistsByLTF_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLTF_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByLTF_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLTF_VALOR(Decimal value )
        {
            var query = _query.ExistsByLTF_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLTF_OBS(string value )
        {
            var query = _query.ExistsByLTF_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLTF_STATUS(string value )
        {
            var query = _query.ExistsByLTF_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PRO_ID(string value )
        {
            var query = _query.ExistsByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

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

        public LaudoTesteFisicoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByLTF_ID(int value )
        {
            var query = _query.FirstByLTF_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByLTF_EMISSAO(DateTime value )
        {
            var query = _query.FirstByLTF_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByLTF_VALOR(Decimal value )
        {
            var query = _query.FirstByLTF_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByLTF_OBS(string value )
        {
            var query = _query.FirstByLTF_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByLTF_STATUS(string value )
        {
            var query = _query.FirstByLTF_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public LaudoTesteFisicoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LaudoTesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_ID(int value )
        {
            var query = _query.FirstByLTF_IDQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_EMISSAO(DateTime value )
        {
            var query = _query.FirstByLTF_EMISSAOQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_VALOR(Decimal value )
        {
            var query = _query.FirstByLTF_VALORQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_OBS(string value )
        {
            var query = _query.FirstByLTF_OBSQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_STATUS(string value )
        {
            var query = _query.FirstByLTF_STATUSQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

        public IEnumerable<LaudoTesteFisicoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<LaudoTesteFisicoDTO>(query.Query,query.Parameters) as List<LaudoTesteFisicoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration