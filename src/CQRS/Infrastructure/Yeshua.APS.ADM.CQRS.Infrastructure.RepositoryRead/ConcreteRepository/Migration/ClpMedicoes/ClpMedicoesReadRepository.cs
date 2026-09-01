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
    public partial class ClpMedicoesReadRepository : IClpMedicoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IClpMedicoesQueryRead _query;

        public ClpMedicoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IClpMedicoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetClpMedicoesCustom(Command.Read.ClpMedicoesReadCommand command, ref DataPagination<ClpMedicoesDTO> result, ref bool handled);

        public DataPagination<ClpMedicoesDTO> getClpMedicoes(ICommandRead command )
         {
            if (command is Command.Read.ClpMedicoesReadCommand c)
                return getClpMedicoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<ClpMedicoesDTO> getClpMedicoes(Command.Read.ClpMedicoesReadCommand command )
        {
            DataPagination<ClpMedicoesDTO> customResult = null;
            var customHandled = false;
            TryGetClpMedicoesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ClpMedicoesQuery(command );

                var itens = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters);
                return new DataPagination<ClpMedicoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ClpMedicoesTenantIDDTO> getClpMedicoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClpMedicoesTenantIDDTO> lista;
            var query = _query.ClpMedicoesTenantIDQuery(command );

                lista = _unitOfWork.Query<ClpMedicoesTenantIDDTO>(query.Query,query.Parameters) as List<ClpMedicoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ClpMedicoesTenantIDDTO> getClpMedicoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClpMedicoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ClpMedicoesUserIdDTO> getClpMedicoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClpMedicoesUserIdDTO> lista;
            var query = _query.ClpMedicoesUserIdQuery(command );

                lista = _unitOfWork.Query<ClpMedicoesUserIdDTO>(query.Query,query.Parameters) as List<ClpMedicoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<ClpMedicoesUserIdDTO> getClpMedicoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClpMedicoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsById2(int value )
        {
            var query = _query.ExistsById2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMaquinaId(string value )
        {
            var query = _query.ExistsByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataInicio(DateTime value )
        {
            var query = _query.ExistsByDataInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataFim(DateTime value )
        {
            var query = _query.ExistsByDataFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmissao(DateTime value )
        {
            var query = _query.ExistsByEmissaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidade(Decimal value )
        {
            var query = _query.ExistsByQuantidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupo(Decimal value )
        {
            var query = _query.ExistsByGrupoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTurnoId(string value )
        {
            var query = _query.ExistsByTurnoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTurmaId(string value )
        {
            var query = _query.ExistsByTurmaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIdLoteClp(int value )
        {
            var query = _query.ExistsByIdLoteClpQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOcorrenciaId(string value )
        {
            var query = _query.ExistsByOcorrenciaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFase(int value )
        {
            var query = _query.ExistsByFaseQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByClpOrigem(string value )
        {
            var query = _query.ExistsByClpOrigemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLP_LOTE(int value )
        {
            var query = _query.ExistsByCLP_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOMPACTA(int value )
        {
            var query = _query.ExistsByCOMPACTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID(string value )
        {
            var query = _query.ExistsByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SEQUENCIA(int value )
        {
            var query = _query.ExistsByCOR_SEQUENCIAQuery(value );

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

        public ClpMedicoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByDataInicio(DateTime value )
        {
            var query = _query.FirstByDataInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByDataFim(DateTime value )
        {
            var query = _query.FirstByDataFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByEmissao(DateTime value )
        {
            var query = _query.FirstByEmissaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByQuantidade(Decimal value )
        {
            var query = _query.FirstByQuantidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByGrupo(Decimal value )
        {
            var query = _query.FirstByGrupoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByTurnoId(string value )
        {
            var query = _query.FirstByTurnoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByTurmaId(string value )
        {
            var query = _query.FirstByTurmaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByIdLoteClp(int value )
        {
            var query = _query.FirstByIdLoteClpQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByOcorrenciaId(string value )
        {
            var query = _query.FirstByOcorrenciaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByFase(int value )
        {
            var query = _query.FirstByFaseQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByClpOrigem(string value )
        {
            var query = _query.FirstByClpOrigemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByCLP_LOTE(int value )
        {
            var query = _query.FirstByCLP_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByCOMPACTA(int value )
        {
            var query = _query.FirstByCOMPACTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByMaquinaId(string value )
        {
            var query = _query.FirstByMaquinaIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByDataInicio(DateTime value )
        {
            var query = _query.FirstByDataInicioQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByDataFim(DateTime value )
        {
            var query = _query.FirstByDataFimQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByEmissao(DateTime value )
        {
            var query = _query.FirstByEmissaoQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByQuantidade(Decimal value )
        {
            var query = _query.FirstByQuantidadeQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByGrupo(Decimal value )
        {
            var query = _query.FirstByGrupoQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByTurnoId(string value )
        {
            var query = _query.FirstByTurnoIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByTurmaId(string value )
        {
            var query = _query.FirstByTurmaIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByIdLoteClp(int value )
        {
            var query = _query.FirstByIdLoteClpQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByOcorrenciaId(string value )
        {
            var query = _query.FirstByOcorrenciaIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByFase(int value )
        {
            var query = _query.FirstByFaseQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByClpOrigem(string value )
        {
            var query = _query.FirstByClpOrigemQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByCLP_LOTE(int value )
        {
            var query = _query.FirstByCLP_LOTEQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByCOMPACTA(int value )
        {
            var query = _query.FirstByCOMPACTAQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesDTO>(query.Query,query.Parameters) as List<ClpMedicoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration