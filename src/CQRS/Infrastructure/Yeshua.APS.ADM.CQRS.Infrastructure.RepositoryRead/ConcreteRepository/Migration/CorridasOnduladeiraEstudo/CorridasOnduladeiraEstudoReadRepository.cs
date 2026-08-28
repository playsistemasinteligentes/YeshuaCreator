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
    public partial class CorridasOnduladeiraEstudoReadRepository : ICorridasOnduladeiraEstudoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICorridasOnduladeiraEstudoQueryRead _query;

        public CorridasOnduladeiraEstudoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICorridasOnduladeiraEstudoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CorridasOnduladeiraEstudoDTO> getCorridasOnduladeiraEstudo(ICommandRead command )
         {
            if (command is Command.Read.CorridasOnduladeiraEstudoReadCommand c)
                return getCorridasOnduladeiraEstudo(c );
            throw new NotImplementedException();
        }
        private DataPagination<CorridasOnduladeiraEstudoDTO> getCorridasOnduladeiraEstudo(Command.Read.CorridasOnduladeiraEstudoReadCommand command )
        {
            var query = _query.CorridasOnduladeiraEstudoQuery(command );

                var itens = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters);
                return new DataPagination<CorridasOnduladeiraEstudoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CorridasOnduladeiraEstudoTenantIDDTO> getCorridasOnduladeiraEstudoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CorridasOnduladeiraEstudoTenantIDDTO> lista;
            var query = _query.CorridasOnduladeiraEstudoTenantIDQuery(command );

                lista = _unitOfWork.Query<CorridasOnduladeiraEstudoTenantIDDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CorridasOnduladeiraEstudoTenantIDDTO> getCorridasOnduladeiraEstudoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCorridasOnduladeiraEstudoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CorridasOnduladeiraEstudoUserIdDTO> getCorridasOnduladeiraEstudoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CorridasOnduladeiraEstudoUserIdDTO> lista;
            var query = _query.CorridasOnduladeiraEstudoUserIdQuery(command );

                lista = _unitOfWork.Query<CorridasOnduladeiraEstudoUserIdDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoUserIdDTO>;
            return lista;
        }

        public IEnumerable<CorridasOnduladeiraEstudoUserIdDTO> getCorridasOnduladeiraEstudoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCorridasOnduladeiraEstudoReadFKUserId(c );
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

        public bool ExistsByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_LARGURA_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.ExistsByPRO_LARGURA_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value )
        {
            var query = _query.ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_VINCOS_RECALCULADOS(string value )
        {
            var query = _query.ExistsByPRO_VINCOS_RECALCULADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SOLVER(string value )
        {
            var query = _query.ExistsByCOR_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.ExistsByCOR_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.ExistsByCOR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.ExistsByCOR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_PILHAS_POR_PALETE(int value )
        {
            var query = _query.ExistsByCOR_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_M_LINEAR_REALIZADO(Decimal value )
        {
            var query = _query.ExistsByCOR_M_LINEAR_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_PALETE(string value )
        {
            var query = _query.ExistsByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_STATUS_PALETE(string value )
        {
            var query = _query.ExistsByCOR_STATUS_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.ExistsByCOR_GRUPO_PRODUTIVOQuery(value );

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

        public CorridasOnduladeiraEstudoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_LARGURA_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value )
        {
            var query = _query.FirstByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_VINCOS_RECALCULADOS(string value )
        {
            var query = _query.FirstByPRO_VINCOS_RECALCULADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_SOLVER(string value )
        {
            var query = _query.FirstByCOR_SOLVERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_PILHAS_POR_PALETE(int value )
        {
            var query = _query.FirstByCOR_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_M_LINEAR_REALIZADO(Decimal value )
        {
            var query = _query.FirstByCOR_M_LINEAR_REALIZADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_STATUS_PALETE(string value )
        {
            var query = _query.FirstByCOR_STATUS_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByCOR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCOR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CorridasOnduladeiraEstudoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CorridasOnduladeiraEstudoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByBOL_ID_ORIGEM(string value )
        {
            var query = _query.FirstByBOL_ID_ORIGEMQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_LARGURA_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_LARGURA_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_LARGURA_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_COMPRIMENTO_PECA(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECAQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value )
        {
            var query = _query.FirstByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value )
        {
            var query = _query.FirstByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_VINCOS_RECALCULADOS(string value )
        {
            var query = _query.FirstByPRO_VINCOS_RECALCULADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_SOLVER(string value )
        {
            var query = _query.FirstByCOR_SOLVERQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value )
        {
            var query = _query.FirstByCOR_CUSTO_RESINA_PROGRAMADOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByCOR_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_PILHAS_POR_PALETE(int value )
        {
            var query = _query.FirstByCOR_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_M_LINEAR_REALIZADO(Decimal value )
        {
            var query = _query.FirstByCOR_M_LINEAR_REALIZADOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_STATUS_PALETE(string value )
        {
            var query = _query.FirstByCOR_STATUS_PALETEQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_GRUPO_PRODUTIVO(Decimal value )
        {
            var query = _query.FirstByCOR_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CorridasOnduladeiraEstudoDTO>(query.Query,query.Parameters) as List<CorridasOnduladeiraEstudoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration