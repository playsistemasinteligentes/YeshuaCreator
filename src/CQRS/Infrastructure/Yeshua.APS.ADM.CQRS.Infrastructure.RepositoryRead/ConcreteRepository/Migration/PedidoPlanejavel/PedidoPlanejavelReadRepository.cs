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
    public partial class PedidoPlanejavelReadRepository : IPedidoPlanejavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPedidoPlanejavelQueryRead _query;

        public PedidoPlanejavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPedidoPlanejavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetPedidoPlanejavelCustom(Command.Read.PedidoPlanejavelReadCommand command, ref DataPagination<PedidoPlanejavelDTO> result, ref bool handled);

        public DataPagination<PedidoPlanejavelDTO> getPedidoPlanejavel(ICommandRead command )
         {
            if (command is Command.Read.PedidoPlanejavelReadCommand c)
                return getPedidoPlanejavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<PedidoPlanejavelDTO> getPedidoPlanejavel(Command.Read.PedidoPlanejavelReadCommand command )
        {
            DataPagination<PedidoPlanejavelDTO> customResult = null;
            var customHandled = false;
            TryGetPedidoPlanejavelCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.PedidoPlanejavelQuery(command );

                var itens = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters);
                return new DataPagination<PedidoPlanejavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsByPedidoId(string value )
        {
            var query = _query.ExistsByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByClienteId(string value )
        {
            var query = _query.ExistsByClienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByClienteNome(string value )
        {
            var query = _query.ExistsByClienteNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEstado(string value )
        {
            var query = _query.ExistsByEstadoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipio(string value )
        {
            var query = _query.ExistsByMunicipioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRegiao(string value )
        {
            var query = _query.ExistsByRegiaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBairro(string value )
        {
            var query = _query.ExistsByBairroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRotaId(string value )
        {
            var query = _query.ExistsByRotaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmbarqueAlvo(DateTime value )
        {
            var query = _query.ExistsByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataEntregaDe(DateTime value )
        {
            var query = _query.ExistsByDataEntregaDeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataEntregaAte(DateTime value )
        {
            var query = _query.ExistsByDataEntregaAteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPeso(Decimal value )
        {
            var query = _query.ExistsByPesoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVolume(Decimal value )
        {
            var query = _query.ExistsByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySaldoAExpedir(Decimal value )
        {
            var query = _query.ExistsBySaldoAExpedirQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCargaAtualId(string value )
        {
            var query = _query.ExistsByCargaAtualIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVersaoPlanejamento(string value )
        {
            var query = _query.ExistsByVersaoPlanejamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAlertasResumo(string value )
        {
            var query = _query.ExistsByAlertasResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public PedidoPlanejavelDTO FirstByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByClienteId(string value )
        {
            var query = _query.FirstByClienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByClienteNome(string value )
        {
            var query = _query.FirstByClienteNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByEstado(string value )
        {
            var query = _query.FirstByEstadoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByMunicipio(string value )
        {
            var query = _query.FirstByMunicipioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByRegiao(string value )
        {
            var query = _query.FirstByRegiaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByBairro(string value )
        {
            var query = _query.FirstByBairroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByRotaId(string value )
        {
            var query = _query.FirstByRotaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByEmbarqueAlvo(DateTime value )
        {
            var query = _query.FirstByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByDataEntregaDe(DateTime value )
        {
            var query = _query.FirstByDataEntregaDeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByDataEntregaAte(DateTime value )
        {
            var query = _query.FirstByDataEntregaAteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByPeso(Decimal value )
        {
            var query = _query.FirstByPesoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstBySaldoAExpedir(Decimal value )
        {
            var query = _query.FirstBySaldoAExpedirQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByCargaAtualId(string value )
        {
            var query = _query.FirstByCargaAtualIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByVersaoPlanejamento(string value )
        {
            var query = _query.FirstByVersaoPlanejamentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public PedidoPlanejavelDTO FirstByAlertasResumo(string value )
        {
            var query = _query.FirstByAlertasResumoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PedidoPlanejavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByClienteId(string value )
        {
            var query = _query.FirstByClienteIdQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByClienteNome(string value )
        {
            var query = _query.FirstByClienteNomeQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByEstado(string value )
        {
            var query = _query.FirstByEstadoQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByMunicipio(string value )
        {
            var query = _query.FirstByMunicipioQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByRegiao(string value )
        {
            var query = _query.FirstByRegiaoQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByBairro(string value )
        {
            var query = _query.FirstByBairroQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByRotaId(string value )
        {
            var query = _query.FirstByRotaIdQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByEmbarqueAlvo(DateTime value )
        {
            var query = _query.FirstByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByDataEntregaDe(DateTime value )
        {
            var query = _query.FirstByDataEntregaDeQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByDataEntregaAte(DateTime value )
        {
            var query = _query.FirstByDataEntregaAteQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByPeso(Decimal value )
        {
            var query = _query.FirstByPesoQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllBySaldoAExpedir(Decimal value )
        {
            var query = _query.FirstBySaldoAExpedirQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByCargaAtualId(string value )
        {
            var query = _query.FirstByCargaAtualIdQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByVersaoPlanejamento(string value )
        {
            var query = _query.FirstByVersaoPlanejamentoQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

        public IEnumerable<PedidoPlanejavelDTO> GetAllByAlertasResumo(string value )
        {
            var query = _query.FirstByAlertasResumoQuery(value );

                var result = _unitOfWork.Query<PedidoPlanejavelDTO>(query.Query,query.Parameters) as List<PedidoPlanejavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration