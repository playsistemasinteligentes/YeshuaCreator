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
    public partial class TipoTesteReadRepository : ITipoTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoTesteQueryRead _query;

        public TipoTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TipoTesteDTO> getTipoTeste(ICommandRead command )
         {
            if (command is Command.Read.TipoTesteReadCommand c)
                return getTipoTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoTesteDTO> getTipoTeste(Command.Read.TipoTesteReadCommand command )
        {
            var query = _query.TipoTesteQuery(command );

                var itens = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoTesteTenantIDDTO> getTipoTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoTesteTenantIDDTO> lista;
            var query = _query.TipoTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoTesteTenantIDDTO>(query.Query,query.Parameters) as List<TipoTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoTesteTenantIDDTO> getTipoTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoTesteUserIdDTO> getTipoTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoTesteUserIdDTO> lista;
            var query = _query.TipoTesteUserIdQuery(command );

                lista = _unitOfWork.Query<TipoTesteUserIdDTO>(query.Query,query.Parameters) as List<TipoTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoTesteUserIdDTO> getTipoTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoTesteTA_IDDTO> getTipoTesteReadFKTA_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoTesteTA_IDDTO> lista;
            var query = _query.TipoTesteTA_IDQuery(command );

                lista = _unitOfWork.Query<TipoTesteTA_IDDTO>(query.Query,query.Parameters) as List<TipoTesteTA_IDDTO>;
            return lista;
        }

        public IEnumerable<TipoTesteTA_IDDTO> getTipoTesteReadFKTA_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoTesteReadFKTA_ID(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTT_ESPECIFICACAO(Decimal value )
        {
            var query = _query.ExistsByTT_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_ORIGEM_ESPECIFICACAO(string value )
        {
            var query = _query.ExistsByTT_ORIGEM_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_IMPRIME_NO_LAUDO(string value )
        {
            var query = _query.ExistsByTT_IMPRIME_NO_LAUDOQuery(value );

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

        public bool ExistsByTT_ID(int value )
        {
            var query = _query.ExistsByTT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_NOME(string value )
        {
            var query = _query.ExistsByTT_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_DESC(string value )
        {
            var query = _query.ExistsByTT_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_TOL_MAIS(Decimal value )
        {
            var query = _query.ExistsByTT_TOL_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_TOL_MENOS(Decimal value )
        {
            var query = _query.ExistsByTT_TOL_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_NORMA(string value )
        {
            var query = _query.ExistsByTT_NORMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_INICIO_PROCESSO(string value )
        {
            var query = _query.ExistsByTT_INICIO_PROCESSOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTA_ID(int value )
        {
            var query = _query.ExistsByTA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(string value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_N_AMOSTRAS_P_TESTE(int value )
        {
            var query = _query.ExistsByTT_N_AMOSTRAS_P_TESTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_MAX_DEF_CRITICO(int value )
        {
            var query = _query.ExistsByTT_MAX_DEF_CRITICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTT_MAX_DEF_GRAVE(int value )
        {
            var query = _query.ExistsByTT_MAX_DEF_GRAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public TipoTesteDTO FirstByTT_ESPECIFICACAO(Decimal value )
        {
            var query = _query.FirstByTT_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_ORIGEM_ESPECIFICACAO(string value )
        {
            var query = _query.FirstByTT_ORIGEM_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_IMPRIME_NO_LAUDO(string value )
        {
            var query = _query.FirstByTT_IMPRIME_NO_LAUDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_ID(int value )
        {
            var query = _query.FirstByTT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_NOME(string value )
        {
            var query = _query.FirstByTT_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_DESC(string value )
        {
            var query = _query.FirstByTT_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_TOL_MAIS(Decimal value )
        {
            var query = _query.FirstByTT_TOL_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_TOL_MENOS(Decimal value )
        {
            var query = _query.FirstByTT_TOL_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_NORMA(string value )
        {
            var query = _query.FirstByTT_NORMAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_INICIO_PROCESSO(string value )
        {
            var query = _query.FirstByTT_INICIO_PROCESSOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTA_ID(int value )
        {
            var query = _query.FirstByTA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_N_AMOSTRAS_P_TESTE(int value )
        {
            var query = _query.FirstByTT_N_AMOSTRAS_P_TESTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_MAX_DEF_CRITICO(int value )
        {
            var query = _query.FirstByTT_MAX_DEF_CRITICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoTesteDTO FirstByTT_MAX_DEF_GRAVE(int value )
        {
            var query = _query.FirstByTT_MAX_DEF_GRAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_ESPECIFICACAO(Decimal value )
        {
            var query = _query.FirstByTT_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_ORIGEM_ESPECIFICACAO(string value )
        {
            var query = _query.FirstByTT_ORIGEM_ESPECIFICACAOQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_IMPRIME_NO_LAUDO(string value )
        {
            var query = _query.FirstByTT_IMPRIME_NO_LAUDOQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_ID(int value )
        {
            var query = _query.FirstByTT_IDQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_NOME(string value )
        {
            var query = _query.FirstByTT_NOMEQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_DESC(string value )
        {
            var query = _query.FirstByTT_DESCQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_TOL_MAIS(Decimal value )
        {
            var query = _query.FirstByTT_TOL_MAISQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_TOL_MENOS(Decimal value )
        {
            var query = _query.FirstByTT_TOL_MENOSQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_NORMA(string value )
        {
            var query = _query.FirstByTT_NORMAQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_INICIO_PROCESSO(string value )
        {
            var query = _query.FirstByTT_INICIO_PROCESSOQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTA_ID(int value )
        {
            var query = _query.FirstByTA_IDQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_N_AMOSTRAS_P_TESTE(int value )
        {
            var query = _query.FirstByTT_N_AMOSTRAS_P_TESTEQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_MAX_DEF_CRITICO(int value )
        {
            var query = _query.FirstByTT_MAX_DEF_CRITICOQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

        public IEnumerable<TipoTesteDTO> GetAllByTT_MAX_DEF_GRAVE(int value )
        {
            var query = _query.FirstByTT_MAX_DEF_GRAVEQuery(value );

                var result = _unitOfWork.Query<TipoTesteDTO>(query.Query,query.Parameters) as List<TipoTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration