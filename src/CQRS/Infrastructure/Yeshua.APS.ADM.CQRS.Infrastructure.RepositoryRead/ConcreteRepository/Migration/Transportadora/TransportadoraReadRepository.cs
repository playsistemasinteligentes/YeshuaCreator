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
    public partial class TransportadoraReadRepository : ITransportadoraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITransportadoraQueryRead _query;

        public TransportadoraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITransportadoraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTransportadoraCustom(Command.Read.TransportadoraReadCommand command, ref DataPagination<TransportadoraDTO> result, ref bool handled);

        public DataPagination<TransportadoraDTO> getTransportadora(ICommandRead command )
         {
            if (command is Command.Read.TransportadoraReadCommand c)
                return getTransportadora(c );
            throw new NotImplementedException();
        }
        private DataPagination<TransportadoraDTO> getTransportadora(Command.Read.TransportadoraReadCommand command )
        {
            DataPagination<TransportadoraDTO> customResult = null;
            var customHandled = false;
            TryGetTransportadoraCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TransportadoraQuery(command );

                var itens = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters);
                return new DataPagination<TransportadoraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TransportadoraTenantIDDTO> getTransportadoraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TransportadoraTenantIDDTO> lista;
            var query = _query.TransportadoraTenantIDQuery(command );

                lista = _unitOfWork.Query<TransportadoraTenantIDDTO>(query.Query,query.Parameters) as List<TransportadoraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TransportadoraTenantIDDTO> getTransportadoraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTransportadoraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TransportadoraUserIdDTO> getTransportadoraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TransportadoraUserIdDTO> lista;
            var query = _query.TransportadoraUserIdQuery(command );

                lista = _unitOfWork.Query<TransportadoraUserIdDTO>(query.Query,query.Parameters) as List<TransportadoraUserIdDTO>;
            return lista;
        }

        public IEnumerable<TransportadoraUserIdDTO> getTransportadoraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTransportadoraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_ID(string value )
        {
            var query = _query.ExistsByTRA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_NOME(string value )
        {
            var query = _query.ExistsByTRA_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_CNPJ(string value )
        {
            var query = _query.ExistsByTRA_CNPJQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_INSCRICAO_ESTADUAL(string value )
        {
            var query = _query.ExistsByTRA_INSCRICAO_ESTADUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_RNTRC(string value )
        {
            var query = _query.ExistsByTRA_RNTRCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_EMAIL(string value )
        {
            var query = _query.ExistsByTRA_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_RESPONSAVEL(string value )
        {
            var query = _query.ExistsByTRA_RESPONSAVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_FONE(string value )
        {
            var query = _query.ExistsByTRA_FONEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByTRA_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTRA_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByTRA_ID_INTEGRACAO_ERPQuery(value );

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

        public TransportadoraDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_ID(string value )
        {
            var query = _query.FirstByTRA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_NOME(string value )
        {
            var query = _query.FirstByTRA_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_CNPJ(string value )
        {
            var query = _query.FirstByTRA_CNPJQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_INSCRICAO_ESTADUAL(string value )
        {
            var query = _query.FirstByTRA_INSCRICAO_ESTADUALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_RNTRC(string value )
        {
            var query = _query.FirstByTRA_RNTRCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_EMAIL(string value )
        {
            var query = _query.FirstByTRA_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_RESPONSAVEL(string value )
        {
            var query = _query.FirstByTRA_RESPONSAVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_FONE(string value )
        {
            var query = _query.FirstByTRA_FONEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByTRA_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTRA_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByTRA_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TransportadoraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TransportadoraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_ID(string value )
        {
            var query = _query.FirstByTRA_IDQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_NOME(string value )
        {
            var query = _query.FirstByTRA_NOMEQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_CNPJ(string value )
        {
            var query = _query.FirstByTRA_CNPJQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_INSCRICAO_ESTADUAL(string value )
        {
            var query = _query.FirstByTRA_INSCRICAO_ESTADUALQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_RNTRC(string value )
        {
            var query = _query.FirstByTRA_RNTRCQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_EMAIL(string value )
        {
            var query = _query.FirstByTRA_EMAILQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_RESPONSAVEL(string value )
        {
            var query = _query.FirstByTRA_RESPONSAVELQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_FONE(string value )
        {
            var query = _query.FirstByTRA_FONEQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByTRA_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTRA_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByTRA_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

        public IEnumerable<TransportadoraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TransportadoraDTO>(query.Query,query.Parameters) as List<TransportadoraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration