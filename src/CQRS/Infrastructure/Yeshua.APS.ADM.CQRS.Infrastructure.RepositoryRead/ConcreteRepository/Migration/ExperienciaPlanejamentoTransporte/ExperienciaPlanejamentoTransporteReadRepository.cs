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
    public partial class ExperienciaPlanejamentoTransporteReadRepository : IExperienciaPlanejamentoTransporteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IExperienciaPlanejamentoTransporteQueryRead _query;

        public ExperienciaPlanejamentoTransporteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IExperienciaPlanejamentoTransporteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetExperienciaPlanejamentoTransporteCustom(Command.Read.ExperienciaPlanejamentoTransporteReadCommand command, ref DataPagination<ExperienciaPlanejamentoTransporteDTO> result, ref bool handled);

        public DataPagination<ExperienciaPlanejamentoTransporteDTO> getExperienciaPlanejamentoTransporte(ICommandRead command )
         {
            if (command is Command.Read.ExperienciaPlanejamentoTransporteReadCommand c)
                return getExperienciaPlanejamentoTransporte(c );
            throw new NotImplementedException();
        }
        private DataPagination<ExperienciaPlanejamentoTransporteDTO> getExperienciaPlanejamentoTransporte(Command.Read.ExperienciaPlanejamentoTransporteReadCommand command )
        {
            DataPagination<ExperienciaPlanejamentoTransporteDTO> customResult = null;
            var customHandled = false;
            TryGetExperienciaPlanejamentoTransporteCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ExperienciaPlanejamentoTransporteQuery(command );

                var itens = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters);
                return new DataPagination<ExperienciaPlanejamentoTransporteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ExperienciaPlanejamentoTransporteTenantIDDTO> getExperienciaPlanejamentoTransporteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ExperienciaPlanejamentoTransporteTenantIDDTO> lista;
            var query = _query.ExperienciaPlanejamentoTransporteTenantIDQuery(command );

                lista = _unitOfWork.Query<ExperienciaPlanejamentoTransporteTenantIDDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteTenantIDDTO> getExperienciaPlanejamentoTransporteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getExperienciaPlanejamentoTransporteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ExperienciaPlanejamentoTransporteUserIdDTO> getExperienciaPlanejamentoTransporteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ExperienciaPlanejamentoTransporteUserIdDTO> lista;
            var query = _query.ExperienciaPlanejamentoTransporteUserIdQuery(command );

                lista = _unitOfWork.Query<ExperienciaPlanejamentoTransporteUserIdDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteUserIdDTO>;
            return lista;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteUserIdDTO> getExperienciaPlanejamentoTransporteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getExperienciaPlanejamentoTransporteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipo(int value )
        {
            var query = _query.ExistsByTipoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByReferencia(string value )
        {
            var query = _query.ExistsByReferenciaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
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

        public bool ExistsByRotaId(string value )
        {
            var query = _query.ExistsByRotaIdQuery(value );

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

        public bool ExistsByObservacao(string value )
        {
            var query = _query.ExistsByObservacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCriadoEm(DateTime value )
        {
            var query = _query.ExistsByCriadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCriadoPor(string value )
        {
            var query = _query.ExistsByCriadoPorQuery(value );

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

        public ExperienciaPlanejamentoTransporteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByTipo(int value )
        {
            var query = _query.FirstByTipoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByReferencia(string value )
        {
            var query = _query.FirstByReferenciaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByClienteId(string value )
        {
            var query = _query.FirstByClienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByMunicipio(string value )
        {
            var query = _query.FirstByMunicipioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByRegiao(string value )
        {
            var query = _query.FirstByRegiaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByRotaId(string value )
        {
            var query = _query.FirstByRotaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByPeso(Decimal value )
        {
            var query = _query.FirstByPesoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByObservacao(string value )
        {
            var query = _query.FirstByObservacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByCriadoEm(DateTime value )
        {
            var query = _query.FirstByCriadoEmQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByCriadoPor(string value )
        {
            var query = _query.FirstByCriadoPorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ExperienciaPlanejamentoTransporteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ExperienciaPlanejamentoTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByTipo(int value )
        {
            var query = _query.FirstByTipoQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByReferencia(string value )
        {
            var query = _query.FirstByReferenciaQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByClienteId(string value )
        {
            var query = _query.FirstByClienteIdQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByMunicipio(string value )
        {
            var query = _query.FirstByMunicipioQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByRegiao(string value )
        {
            var query = _query.FirstByRegiaoQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByRotaId(string value )
        {
            var query = _query.FirstByRotaIdQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByPeso(Decimal value )
        {
            var query = _query.FirstByPesoQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByObservacao(string value )
        {
            var query = _query.FirstByObservacaoQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByCriadoEm(DateTime value )
        {
            var query = _query.FirstByCriadoEmQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByCriadoPor(string value )
        {
            var query = _query.FirstByCriadoPorQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ExperienciaPlanejamentoTransporteDTO>(query.Query,query.Parameters) as List<ExperienciaPlanejamentoTransporteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration