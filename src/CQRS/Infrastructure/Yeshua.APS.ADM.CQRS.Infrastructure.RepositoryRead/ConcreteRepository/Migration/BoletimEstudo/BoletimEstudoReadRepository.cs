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
    public partial class BoletimEstudoReadRepository : IBoletimEstudoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IBoletimEstudoQueryRead _query;

        public BoletimEstudoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IBoletimEstudoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetBoletimEstudoCustom(Command.Read.BoletimEstudoReadCommand command, ref DataPagination<BoletimEstudoDTO> result, ref bool handled);

        public DataPagination<BoletimEstudoDTO> getBoletimEstudo(ICommandRead command )
         {
            if (command is Command.Read.BoletimEstudoReadCommand c)
                return getBoletimEstudo(c );
            throw new NotImplementedException();
        }
        private DataPagination<BoletimEstudoDTO> getBoletimEstudo(Command.Read.BoletimEstudoReadCommand command )
        {
            DataPagination<BoletimEstudoDTO> customResult = null;
            var customHandled = false;
            TryGetBoletimEstudoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.BoletimEstudoQuery(command );

                var itens = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters);
                return new DataPagination<BoletimEstudoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<BoletimEstudoTenantIDDTO> getBoletimEstudoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<BoletimEstudoTenantIDDTO> lista;
            var query = _query.BoletimEstudoTenantIDQuery(command );

                lista = _unitOfWork.Query<BoletimEstudoTenantIDDTO>(query.Query,query.Parameters) as List<BoletimEstudoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<BoletimEstudoTenantIDDTO> getBoletimEstudoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getBoletimEstudoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<BoletimEstudoUserIdDTO> getBoletimEstudoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<BoletimEstudoUserIdDTO> lista;
            var query = _query.BoletimEstudoUserIdQuery(command );

                lista = _unitOfWork.Query<BoletimEstudoUserIdDTO>(query.Query,query.Parameters) as List<BoletimEstudoUserIdDTO>;
            return lista;
        }

        public IEnumerable<BoletimEstudoUserIdDTO> getBoletimEstudoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getBoletimEstudoReadFKUserId(c );
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

        public BoletimEstudoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_SOLVER(string value )
        {
            var query = _query.FirstByBOL_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_INTEGRACAO(string value )
        {
            var query = _query.FirstByBOL_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_SEQUENCIA(Decimal value )
        {
            var query = _query.FirstByBOL_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_GRAMATURA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_ID_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_ID_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_PAPEL1_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL1_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_PAPEL2_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL2_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_PAPEL3_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL3_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_PAPEL4_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL4_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByGRP_PAPEL5_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL5_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_STATUS_INTERFACE(string value )
        {
            var query = _query.FirstByBOL_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_TIPO(string value )
        {
            var query = _query.FirstByBOL_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_FORMATO(int value )
        {
            var query = _query.FirstByBOL_FORMATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByBOL_REFILE_OBRIGATORIO(int value )
        {
            var query = _query.FirstByBOL_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public BoletimEstudoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<BoletimEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_SOLVER(string value )
        {
            var query = _query.FirstByBOL_SOLVERQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_INTEGRACAO(string value )
        {
            var query = _query.FirstByBOL_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_SEQUENCIA(Decimal value )
        {
            var query = _query.FirstByBOL_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByGRP_PAP_GRAMATURA_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_ID_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_ID_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL1_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL1_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL2_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL2_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL3_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL3_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL4_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL4_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL5_PROGRAMADO(string value )
        {
            var query = _query.FirstByGRP_PAPEL5_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_STATUS_INTERFACE(string value )
        {
            var query = _query.FirstByBOL_STATUS_INTERFACEQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_TIPO(string value )
        {
            var query = _query.FirstByBOL_TIPOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_FORMATO(int value )
        {
            var query = _query.FirstByBOL_FORMATOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_PAPEIS_REALIZADOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByBOL_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_REFILE_OBRIGATORIO(int value )
        {
            var query = _query.FirstByBOL_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

        public IEnumerable<BoletimEstudoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<BoletimEstudoDTO>(query.Query,query.Parameters) as List<BoletimEstudoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration