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

namespace Input.Repository.MDFeTentativaEmissao
{
    public partial class MDFeTentativaEmissaoWriteRepository : IMDFeTentativaEmissaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMDFeTentativaEmissaoQueryWrite _query; 

        public MDFeTentativaEmissaoWriteRepository(IUnitOfWork unitOfWork,IMDFeTentativaEmissaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMDFeTentativaEmissaoEntity MDFeTentativaEmissao)
        {
            var query = _query.InserirMDFeTentativaEmissaoQuery(MDFeTentativaEmissao);
        MDFeTentativaEmissao.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMDFeTentativaEmissaoEntity MDFeTentativaEmissao)
        {
            var query = _query.UpdateMDFeTentativaEmissaoQuery(MDFeTentativaEmissao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMDFeTentativaEmissaoEntity MDFeTentativaEmissao)
        {
            var query = _query.DeleteMDFeTentativaEmissaoQuery(MDFeTentativaEmissao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            var query = _query.UpdateMDFeSolicitacaoFiscalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNumero(int id, int value)
        {
            var query = _query.UpdateNumero(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSerie(int id, int value)
        {
            var query = _query.UpdateSerie(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTentativa(int id, int value)
        {
            var query = _query.UpdateTentativa(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlAssinadoStorageKey(int id, string value)
        {
            var query = _query.UpdateXmlAssinadoStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlProcStorageKey(int id, string value)
        {
            var query = _query.UpdateXmlProcStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlHash(int id, string value)
        {
            var query = _query.UpdateXmlHash(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCodigoRetorno(int id, string value)
        {
            var query = _query.UpdateCodigoRetorno(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMensagemRetorno(int id, string value)
        {
            var query = _query.UpdateMensagemRetorno(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProtocoloAutorizacao(int id, string value)
        {
            var query = _query.UpdateProtocoloAutorizacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEnviadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateEnviadoEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAutorizadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateAutorizadoEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration