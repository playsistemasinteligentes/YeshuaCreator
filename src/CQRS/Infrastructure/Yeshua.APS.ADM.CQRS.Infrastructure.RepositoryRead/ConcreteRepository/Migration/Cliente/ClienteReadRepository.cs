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
    public partial class ClienteReadRepository : IClienteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IClienteQueryRead _query;

        public ClienteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IClienteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ClienteDTO> getCliente(ICommandRead command )
         {
            if (command is Command.Read.ClienteReadCommand c)
                return getCliente(c );
            throw new NotImplementedException();
        }
        private DataPagination<ClienteDTO> getCliente(Command.Read.ClienteReadCommand command )
        {
            var query = _query.ClienteQuery(command );

                var itens = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters);
                return new DataPagination<ClienteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ClienteMUN_ID_ENTREGADTO> getClienteReadFKMUN_ID_ENTREGA(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClienteMUN_ID_ENTREGADTO> lista;
            var query = _query.ClienteMUN_ID_ENTREGAQuery(command );

                lista = _unitOfWork.Query<ClienteMUN_ID_ENTREGADTO>(query.Query,query.Parameters) as List<ClienteMUN_ID_ENTREGADTO>;
            return lista;
        }

        public IEnumerable<ClienteMUN_ID_ENTREGADTO> getClienteReadFKMUN_ID_ENTREGA(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClienteReadFKMUN_ID_ENTREGA(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ClienteTenantIDDTO> getClienteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClienteTenantIDDTO> lista;
            var query = _query.ClienteTenantIDQuery(command );

                lista = _unitOfWork.Query<ClienteTenantIDDTO>(query.Query,query.Parameters) as List<ClienteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ClienteTenantIDDTO> getClienteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClienteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ClienteUserIdDTO> getClienteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClienteUserIdDTO> lista;
            var query = _query.ClienteUserIdQuery(command );

                lista = _unitOfWork.Query<ClienteUserIdDTO>(query.Query,query.Parameters) as List<ClienteUserIdDTO>;
            return lista;
        }

        public IEnumerable<ClienteUserIdDTO> getClienteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClienteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_NOME(string value )
        {
            var query = _query.ExistsByCLI_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_FONE(string value )
        {
            var query = _query.ExistsByCLI_FONEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_OBS(string value )
        {
            var query = _query.ExistsByCLI_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ENDERECO_ENTREGA(string value )
        {
            var query = _query.ExistsByCLI_ENDERECO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_CPF_CNPJ(string value )
        {
            var query = _query.ExistsByCLI_CPF_CNPJQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_BAIRRO_ENTREGA(string value )
        {
            var query = _query.ExistsByCLI_BAIRRO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_CEP_ENTREGA(string value )
        {
            var query = _query.ExistsByCLI_CEP_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_EMAIL(string value )
        {
            var query = _query.ExistsByCLI_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_INTEGRACAO(string value )
        {
            var query = _query.ExistsByCLI_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_ID_ENTREGA(string value )
        {
            var query = _query.ExistsByMUN_ID_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_TRANSLADO(Decimal value )
        {
            var query = _query.ExistsByCLI_TRANSLADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_REGIAO_ENTREGA(string value )
        {
            var query = _query.ExistsByCLI_REGIAO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_EXIGENTE_NA_IMPRESSAO(int value )
        {
            var query = _query.ExistsByCLI_EXIGENTE_NA_IMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(Decimal value )
        {
            var query = _query.ExistsByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_PERCENTUAL_JANELA_EMBARQUE(Decimal value )
        {
            var query = _query.ExistsByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREP_ID(string value )
        {
            var query = _query.ExistsByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_RAZAO_SOCIAL(string value )
        {
            var query = _query.ExistsByCLI_RAZAO_SOCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string value )
        {
            var query = _query.ExistsByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_CONTATO(string value )
        {
            var query = _query.ExistsByCLI_CONTATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_SETOR(string value )
        {
            var query = _query.ExistsByCLI_SETORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_ID(string value )
        {
            var query = _query.ExistsBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_TIPO(string value )
        {
            var query = _query.ExistsByCLI_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByCLI_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_LATITUDE_ENTREGA(Decimal value )
        {
            var query = _query.ExistsByCLI_LATITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_LONGITUDE_ENTREGA(Decimal value )
        {
            var query = _query.ExistsByCLI_LONGITUDE_ENTREGAQuery(value );

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

        public ClienteDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_NOME(string value )
        {
            var query = _query.FirstByCLI_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_FONE(string value )
        {
            var query = _query.FirstByCLI_FONEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_OBS(string value )
        {
            var query = _query.FirstByCLI_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_ENDERECO_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_ENDERECO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_CPF_CNPJ(string value )
        {
            var query = _query.FirstByCLI_CPF_CNPJQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_BAIRRO_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_BAIRRO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_CEP_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_CEP_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_EMAIL(string value )
        {
            var query = _query.FirstByCLI_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_INTEGRACAO(string value )
        {
            var query = _query.FirstByCLI_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByMUN_ID_ENTREGA(string value )
        {
            var query = _query.FirstByMUN_ID_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_TRANSLADO(Decimal value )
        {
            var query = _query.FirstByCLI_TRANSLADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_REGIAO_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_REGIAO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_EXIGENTE_NA_IMPRESSAO(int value )
        {
            var query = _query.FirstByCLI_EXIGENTE_NA_IMPRESSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(Decimal value )
        {
            var query = _query.FirstByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_PERCENTUAL_JANELA_EMBARQUE(Decimal value )
        {
            var query = _query.FirstByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByREP_ID(string value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_RAZAO_SOCIAL(string value )
        {
            var query = _query.FirstByCLI_RAZAO_SOCIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string value )
        {
            var query = _query.FirstByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_CONTATO(string value )
        {
            var query = _query.FirstByCLI_CONTATOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_SETOR(string value )
        {
            var query = _query.FirstByCLI_SETORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstBySEG_ID(string value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_TIPO(string value )
        {
            var query = _query.FirstByCLI_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByCLI_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_LATITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCLI_LATITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByCLI_LONGITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCLI_LONGITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClienteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_NOME(string value )
        {
            var query = _query.FirstByCLI_NOMEQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_FONE(string value )
        {
            var query = _query.FirstByCLI_FONEQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_OBS(string value )
        {
            var query = _query.FirstByCLI_OBSQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_ENDERECO_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_ENDERECO_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_CPF_CNPJ(string value )
        {
            var query = _query.FirstByCLI_CPF_CNPJQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_BAIRRO_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_BAIRRO_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_CEP_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_CEP_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_EMAIL(string value )
        {
            var query = _query.FirstByCLI_EMAILQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_INTEGRACAO(string value )
        {
            var query = _query.FirstByCLI_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByMUN_ID_ENTREGA(string value )
        {
            var query = _query.FirstByMUN_ID_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_TRANSLADO(Decimal value )
        {
            var query = _query.FirstByCLI_TRANSLADOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_REGIAO_ENTREGA(string value )
        {
            var query = _query.FirstByCLI_REGIAO_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_EXIGENTE_NA_IMPRESSAO(int value )
        {
            var query = _query.FirstByCLI_EXIGENTE_NA_IMPRESSAOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(Decimal value )
        {
            var query = _query.FirstByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_TEMPO_DESCARREGAMENTO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_PERCENTUAL_JANELA_EMBARQUE(Decimal value )
        {
            var query = _query.FirstByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByREP_ID(string value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_RAZAO_SOCIAL(string value )
        {
            var query = _query.FirstByCLI_RAZAO_SOCIALQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string value )
        {
            var query = _query.FirstByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_CONTATO(string value )
        {
            var query = _query.FirstByCLI_CONTATOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_SETOR(string value )
        {
            var query = _query.FirstByCLI_SETORQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllBySEG_ID(string value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_TIPO(string value )
        {
            var query = _query.FirstByCLI_TIPOQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByCLI_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_LATITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCLI_LATITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByCLI_LONGITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCLI_LONGITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

        public IEnumerable<ClienteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ClienteDTO>(query.Query,query.Parameters) as List<ClienteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration