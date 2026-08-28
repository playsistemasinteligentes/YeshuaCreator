// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Cliente
{
    public partial class ClienteWriteRepository : IClienteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IClienteQueryWrite _query; 

        public ClienteWriteRepository(IUnitOfWork unitOfWork,IClienteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IClienteEntity Cliente)
        {
            var query = _query.InserirClienteQuery(Cliente);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IClienteEntity Cliente)
        {
            var query = _query.UpdateClienteQuery(Cliente);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IClienteEntity Cliente)
        {
            var query = _query.DeleteClienteQuery(Cliente);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_NOME(string cli_id, string value)
        {
            var query = _query.UpdateCLI_NOME(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_FONE(string cli_id, string value)
        {
            var query = _query.UpdateCLI_FONE(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_OBS(string cli_id, string value)
        {
            var query = _query.UpdateCLI_OBS(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ENDERECO_ENTREGA(string cli_id, string value)
        {
            var query = _query.UpdateCLI_ENDERECO_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_CPF_CNPJ(string cli_id, string value)
        {
            var query = _query.UpdateCLI_CPF_CNPJ(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_BAIRRO_ENTREGA(string cli_id, string value)
        {
            var query = _query.UpdateCLI_BAIRRO_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_CEP_ENTREGA(string cli_id, string value)
        {
            var query = _query.UpdateCLI_CEP_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_EMAIL(string cli_id, string value)
        {
            var query = _query.UpdateCLI_EMAIL(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_INTEGRACAO(string cli_id, string value)
        {
            var query = _query.UpdateCLI_INTEGRACAO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_ID_ENTREGA(string cli_id, string value)
        {
            var query = _query.UpdateMUN_ID_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_TRANSLADO(string cli_id, Decimal value)
        {
            var query = _query.UpdateCLI_TRANSLADO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_REGIAO_ENTREGA(string cli_id, string value)
        {
            var query = _query.UpdateCLI_REGIAO_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_EXIGENTE_NA_IMPRESSAO(string cli_id, int value)
        {
            var query = _query.UpdateCLI_EXIGENTE_NA_IMPRESSAO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(string cli_id, Decimal value)
        {
            var query = _query.UpdateCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_TEMPO_DESCARREGAMENTO_UNITARIO(string cli_id, Decimal value)
        {
            var query = _query.UpdateCLI_TEMPO_DESCARREGAMENTO_UNITARIO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_PERCENTUAL_JANELA_EMBARQUE(string cli_id, Decimal value)
        {
            var query = _query.UpdateCLI_PERCENTUAL_JANELA_EMBARQUE(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREP_ID(string cli_id, string value)
        {
            var query = _query.UpdateREP_ID(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_RAZAO_SOCIAL(string cli_id, string value)
        {
            var query = _query.UpdateCLI_RAZAO_SOCIAL(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string cli_id, string value)
        {
            var query = _query.UpdateCLI_EMAIL_MONITORAMENTO_TRANSPORTE(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_CONTATO(string cli_id, string value)
        {
            var query = _query.UpdateCLI_CONTATO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_SETOR(string cli_id, string value)
        {
            var query = _query.UpdateCLI_SETOR(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSEG_ID(string cli_id, string value)
        {
            var query = _query.UpdateSEG_ID(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_TIPO(string cli_id, string value)
        {
            var query = _query.UpdateCLI_TIPO(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_INTEGRACAO_ERP(string cli_id, string value)
        {
            var query = _query.UpdateCLI_INTEGRACAO_ERP(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_LATITUDE_ENTREGA(string cli_id, Decimal value)
        {
            var query = _query.UpdateCLI_LATITUDE_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_LONGITUDE_ENTREGA(string cli_id, Decimal value)
        {
            var query = _query.UpdateCLI_LONGITUDE_ENTREGA(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string cli_id, int value)
        {
            var query = _query.UpdateTenantID(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string cli_id, bool value)
        {
            var query = _query.UpdateDeleted(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string cli_id, DateTime value)
        {
            var query = _query.UpdateChanged(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string cli_id, int value)
        {
            var query = _query.UpdateUserId(cli_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration