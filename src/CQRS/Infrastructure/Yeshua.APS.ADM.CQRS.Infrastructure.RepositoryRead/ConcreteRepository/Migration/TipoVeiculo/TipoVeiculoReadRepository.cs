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
    public partial class TipoVeiculoReadRepository : ITipoVeiculoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoVeiculoQueryRead _query;

        public TipoVeiculoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoVeiculoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoVeiculoCustom(Command.Read.TipoVeiculoReadCommand command, ref DataPagination<TipoVeiculoDTO> result, ref bool handled);

        public DataPagination<TipoVeiculoDTO> getTipoVeiculo(ICommandRead command )
         {
            if (command is Command.Read.TipoVeiculoReadCommand c)
                return getTipoVeiculo(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoVeiculoDTO> getTipoVeiculo(Command.Read.TipoVeiculoReadCommand command )
        {
            DataPagination<TipoVeiculoDTO> customResult = null;
            var customHandled = false;
            TryGetTipoVeiculoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoVeiculoQuery(command );

                var itens = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoVeiculoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoVeiculoTenantIDDTO> getTipoVeiculoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoVeiculoTenantIDDTO> lista;
            var query = _query.TipoVeiculoTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoVeiculoTenantIDDTO>(query.Query,query.Parameters) as List<TipoVeiculoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoVeiculoTenantIDDTO> getTipoVeiculoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoVeiculoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoVeiculoUserIdDTO> getTipoVeiculoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoVeiculoUserIdDTO> lista;
            var query = _query.TipoVeiculoUserIdQuery(command );

                lista = _unitOfWork.Query<TipoVeiculoUserIdDTO>(query.Query,query.Parameters) as List<TipoVeiculoUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoVeiculoUserIdDTO> getTipoVeiculoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoVeiculoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_DESCRICAO(string value )
        {
            var query = _query.ExistsByTIP_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_QTD_DISPONIVEL(int value )
        {
            var query = _query.ExistsByTIP_QTD_DISPONIVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_VALOR_KM(Decimal value )
        {
            var query = _query.ExistsByTIP_VALOR_KMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_VALOR_DIARIA(Decimal value )
        {
            var query = _query.ExistsByTIP_VALOR_DIARIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_VALOR_AJUDANTE(Decimal value )
        {
            var query = _query.ExistsByTIP_VALOR_AJUDANTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_QTD_EIXOS(Decimal value )
        {
            var query = _query.ExistsByTIP_QTD_EIXOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_VELOCIDADE_MEDIA(Decimal value )
        {
            var query = _query.ExistsByTIP_VELOCIDADE_MEDIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_ALTURA(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_LARGURA(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_E(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_E(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_D(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_D(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_CAPACIDADE_M3(Decimal value )
        {
            var query = _query.ExistsByTIP_CAPACIDADE_M3Query(value );

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

        public TipoVeiculoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_DESCRICAO(string value )
        {
            var query = _query.FirstByTIP_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_QTD_DISPONIVEL(int value )
        {
            var query = _query.FirstByTIP_QTD_DISPONIVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_VALOR_KM(Decimal value )
        {
            var query = _query.FirstByTIP_VALOR_KMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_VALOR_DIARIA(Decimal value )
        {
            var query = _query.FirstByTIP_VALOR_DIARIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_VALOR_AJUDANTE(Decimal value )
        {
            var query = _query.FirstByTIP_VALOR_AJUDANTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_QTD_EIXOS(Decimal value )
        {
            var query = _query.FirstByTIP_QTD_EIXOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_VELOCIDADE_MEDIA(Decimal value )
        {
            var query = _query.FirstByTIP_VELOCIDADE_MEDIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_ALTURA(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_LARGURA(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_E(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_E(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_D(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_D(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_M3(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_M3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoVeiculoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoVeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_DESCRICAO(string value )
        {
            var query = _query.FirstByTIP_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_QTD_DISPONIVEL(int value )
        {
            var query = _query.FirstByTIP_QTD_DISPONIVELQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VALOR_KM(Decimal value )
        {
            var query = _query.FirstByTIP_VALOR_KMQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VALOR_DIARIA(Decimal value )
        {
            var query = _query.FirstByTIP_VALOR_DIARIAQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VALOR_AJUDANTE(Decimal value )
        {
            var query = _query.FirstByTIP_VALOR_AJUDANTEQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_QTD_EIXOS(Decimal value )
        {
            var query = _query.FirstByTIP_QTD_EIXOSQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VELOCIDADE_MEDIA(Decimal value )
        {
            var query = _query.FirstByTIP_VELOCIDADE_MEDIAQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_ALTURA(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_ALTURAQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_LARGURA(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_LARGURAQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_ALTURA_PESCOCO_E(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_LARGURA_PESCOCO_E(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_ALTURA_PESCOCO_D(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_LARGURA_PESCOCO_D(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_M3(Decimal value )
        {
            var query = _query.FirstByTIP_CAPACIDADE_M3Query(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

        public IEnumerable<TipoVeiculoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoVeiculoDTO>(query.Query,query.Parameters) as List<TipoVeiculoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration