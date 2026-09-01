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
    public partial class VeiculoReadRepository : IVeiculoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVeiculoQueryRead _query;

        public VeiculoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVeiculoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetVeiculoCustom(Command.Read.VeiculoReadCommand command, ref DataPagination<VeiculoDTO> result, ref bool handled);

        public DataPagination<VeiculoDTO> getVeiculo(ICommandRead command )
         {
            if (command is Command.Read.VeiculoReadCommand c)
                return getVeiculo(c );
            throw new NotImplementedException();
        }
        private DataPagination<VeiculoDTO> getVeiculo(Command.Read.VeiculoReadCommand command )
        {
            DataPagination<VeiculoDTO> customResult = null;
            var customHandled = false;
            TryGetVeiculoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.VeiculoQuery(command );

                var itens = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters);
                return new DataPagination<VeiculoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VeiculoTenantIDDTO> getVeiculoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VeiculoTenantIDDTO> lista;
            var query = _query.VeiculoTenantIDQuery(command );

                lista = _unitOfWork.Query<VeiculoTenantIDDTO>(query.Query,query.Parameters) as List<VeiculoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VeiculoTenantIDDTO> getVeiculoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVeiculoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VeiculoUserIdDTO> getVeiculoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VeiculoUserIdDTO> lista;
            var query = _query.VeiculoUserIdQuery(command );

                lista = _unitOfWork.Query<VeiculoUserIdDTO>(query.Query,query.Parameters) as List<VeiculoUserIdDTO>;
            return lista;
        }

        public IEnumerable<VeiculoUserIdDTO> getVeiculoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVeiculoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_PLACA(string value )
        {
            var query = _query.ExistsByVEI_PLACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_CAPACIDADE_M3(Decimal value )
        {
            var query = _query.ExistsByVEI_CAPACIDADE_M3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_CAPACIDADE_LARGURA(Decimal value )
        {
            var query = _query.ExistsByVEI_CAPACIDADE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_CAPACIDADE_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByVEI_CAPACIDADE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_CAPACIDADE_ALTURA(Decimal value )
        {
            var query = _query.ExistsByVEI_CAPACIDADE_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_MODELO(string value )
        {
            var query = _query.ExistsByVEI_MODELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_NOME_MOTORISTA(string value )
        {
            var query = _query.ExistsByVEI_NOME_MOTORISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_DADOS_CONTATO(string value )
        {
            var query = _query.ExistsByVEI_DADOS_CONTATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_CPF_MOTORISTA(string value )
        {
            var query = _query.ExistsByVEI_CPF_MOTORISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTCA_ID(string value )
        {
            var query = _query.ExistsByTCA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByVEI_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_VENCIMENTO(DateTime value )
        {
            var query = _query.ExistsByVEI_VENCIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVEI_STATUS(string value )
        {
            var query = _query.ExistsByVEI_STATUSQuery(value );

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

        public VeiculoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_PLACA(string value )
        {
            var query = _query.FirstByVEI_PLACAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_CAPACIDADE_M3(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_M3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_CAPACIDADE_LARGURA(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_CAPACIDADE_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_CAPACIDADE_ALTURA(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_ALTURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_MODELO(string value )
        {
            var query = _query.FirstByVEI_MODELOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_NOME_MOTORISTA(string value )
        {
            var query = _query.FirstByVEI_NOME_MOTORISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_DADOS_CONTATO(string value )
        {
            var query = _query.FirstByVEI_DADOS_CONTATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_CPF_MOTORISTA(string value )
        {
            var query = _query.FirstByVEI_CPF_MOTORISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByTCA_ID(string value )
        {
            var query = _query.FirstByTCA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_EMISSAO(DateTime value )
        {
            var query = _query.FirstByVEI_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_VENCIMENTO(DateTime value )
        {
            var query = _query.FirstByVEI_VENCIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByVEI_STATUS(string value )
        {
            var query = _query.FirstByVEI_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VeiculoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VeiculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_PLACA(string value )
        {
            var query = _query.FirstByVEI_PLACAQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_M3(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_M3Query(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_LARGURA(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_LARGURAQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_ALTURA(Decimal value )
        {
            var query = _query.FirstByVEI_CAPACIDADE_ALTURAQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_MODELO(string value )
        {
            var query = _query.FirstByVEI_MODELOQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_NOME_MOTORISTA(string value )
        {
            var query = _query.FirstByVEI_NOME_MOTORISTAQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_DADOS_CONTATO(string value )
        {
            var query = _query.FirstByVEI_DADOS_CONTATOQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_CPF_MOTORISTA(string value )
        {
            var query = _query.FirstByVEI_CPF_MOTORISTAQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByTCA_ID(string value )
        {
            var query = _query.FirstByTCA_IDQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_EMISSAO(DateTime value )
        {
            var query = _query.FirstByVEI_EMISSAOQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_VENCIMENTO(DateTime value )
        {
            var query = _query.FirstByVEI_VENCIMENTOQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByVEI_STATUS(string value )
        {
            var query = _query.FirstByVEI_STATUSQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

        public IEnumerable<VeiculoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VeiculoDTO>(query.Query,query.Parameters) as List<VeiculoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration