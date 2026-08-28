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
    public partial class BoletimReadRepository : IBoletimReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IBoletimQueryRead _query;

        public BoletimReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IBoletimQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<BoletimDTO> getBoletim(ICommandRead command )
         {
            if (command is Command.Read.BoletimReadCommand c)
                return getBoletim(c );
            throw new NotImplementedException();
        }
        private DataPagination<BoletimDTO> getBoletim(Command.Read.BoletimReadCommand command )
        {
            var query = _query.BoletimQuery(command );

                var itens = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters);
                return new DataPagination<BoletimDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<BoletimGRP_ID_PROGRAMADODTO> getBoletimReadFKGRP_ID_PROGRAMADO(Command.Patterns.Command.SearchFKCommand command )
        {
            List<BoletimGRP_ID_PROGRAMADODTO> lista;
            var query = _query.BoletimGRP_ID_PROGRAMADOQuery(command );

                lista = _unitOfWork.Query<BoletimGRP_ID_PROGRAMADODTO>(query.Query,query.Parameters) as List<BoletimGRP_ID_PROGRAMADODTO>;
            return lista;
        }

        public IEnumerable<BoletimGRP_ID_PROGRAMADODTO> getBoletimReadFKGRP_ID_PROGRAMADO(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getBoletimReadFKGRP_ID_PROGRAMADO(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<BoletimTenantIDDTO> getBoletimReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<BoletimTenantIDDTO> lista;
            var query = _query.BoletimTenantIDQuery(command );

                lista = _unitOfWork.Query<BoletimTenantIDDTO>(query.Query,query.Parameters) as List<BoletimTenantIDDTO>;
            return lista;
        }

        public IEnumerable<BoletimTenantIDDTO> getBoletimReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getBoletimReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<BoletimUserIdDTO> getBoletimReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<BoletimUserIdDTO> lista;
            var query = _query.BoletimUserIdQuery(command );

                lista = _unitOfWork.Query<BoletimUserIdDTO>(query.Query,query.Parameters) as List<BoletimUserIdDTO>;
            return lista;
        }

        public IEnumerable<BoletimUserIdDTO> getBoletimReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getBoletimReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID(string value )
        {
            var query = _query.ExistsByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID_ORIGEM(string value )
        {
            var query = _query.ExistsByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_SOLVER(string value )
        {
            var query = _query.ExistsByBOL_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_INTEGRACAO(string value )
        {
            var query = _query.ExistsByBOL_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_SEQUENCIA(Decimal value )
        {
            var query = _query.ExistsByBOL_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value )
        {
            var query = _query.ExistsByGRP_PAP_GRAMATURA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID_PROGRAMADO(string value )
        {
            var query = _query.ExistsByGRP_ID_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL1_PROGRAMADO(string value )
        {
            var query = _query.ExistsByGRP_PAPEL1_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL2_PROGRAMADO(string value )
        {
            var query = _query.ExistsByGRP_PAPEL2_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL3_PROGRAMADO(string value )
        {
            var query = _query.ExistsByGRP_PAPEL3_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL4_PROGRAMADO(string value )
        {
            var query = _query.ExistsByGRP_PAPEL4_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_PAPEL5_PROGRAMADO(string value )
        {
            var query = _query.ExistsByGRP_PAPEL5_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_STATUS_INTERFACE(string value )
        {
            var query = _query.ExistsByBOL_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_TIPO(string value )
        {
            var query = _query.ExistsByBOL_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_FORMATO(int value )
        {
            var query = _query.ExistsByBOL_FORMATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.ExistsByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.ExistsByBOL_CUSTO_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByBOL_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_REFILE_OBRIGATORIO(int value )
        {
            var query = _query.ExistsByBOL_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_OBS(string value )
        {
            var query = _query.ExistsByBOL_OBSQuery(value );

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

        public BoletimDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_SOLVER(string value )
        {
            var query = _query.FirstByBOL_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_INTEGRACAO(string value )
        {
            var query = _query.FirstByBOL_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_SEQUENCIA(Decimal value )
        {
            var query = _query.FirstByBOL_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_GRAMATURA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_ID_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_ID_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_PAPEL1_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL1_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_PAPEL2_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL2_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_PAPEL3_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL3_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_PAPEL4_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL4_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByGRP_PAPEL5_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL5_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_STATUS_INTERFACE(string value )
        {
            var query = _query.FirstByBOL_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_TIPO(string value )
        {
            var query = _query.FirstByBOL_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_FORMATO(int value )
        {
            var query = _query.FirstByBOL_FORMATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_REFILE_OBRIGATORIO(int value )
        {
            var query = _query.FirstByBOL_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByBOL_OBS(string value )
        {
            var query = _query.FirstByBOL_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_SOLVER(string value )
        {
            var query = _query.FirstByBOL_SOLVERQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_INTEGRACAO(string value )
        {
            var query = _query.FirstByBOL_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_SEQUENCIA(Decimal value )
        {
            var query = _query.FirstByBOL_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_GRAMATURA_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_ID_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_ID_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL1_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL1_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL2_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL2_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL3_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL3_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL4_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL4_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL5_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL5_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_STATUS_INTERFACE(string value )
        {
            var query = _query.FirstByBOL_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_TIPO(string value )
        {
            var query = _query.FirstByBOL_TIPOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_FORMATO(int value )
        {
            var query = _query.FirstByBOL_FORMATOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_REFILE_OBRIGATORIO(int value )
        {
            var query = _query.FirstByBOL_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByBOL_OBS(string value )
        {
            var query = _query.FirstByBOL_OBSQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

        public IEnumerable<BoletimDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<BoletimDTO>(query.Query,query.Parameters) as List<BoletimDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration