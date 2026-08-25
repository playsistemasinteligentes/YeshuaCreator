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

namespace Input.Repository.Roteiro
{
    public partial class RoteiroWriteRepository : IRoteiroWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRoteiroQueryWrite _query; 

        public RoteiroWriteRepository(IUnitOfWork unitOfWork,IRoteiroQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRoteiroEntity Roteiro)
        {
            var query = _query.InserirRoteiroQuery(Roteiro);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IRoteiroEntity Roteiro)
        {
            var query = _query.UpdateRoteiroQuery(Roteiro);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRoteiroEntity Roteiro)
        {
            var query = _query.DeleteRoteiroQuery(Roteiro);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGMA_ID(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            var query = _query.UpdateGMA_ID(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PECAS_POR_PULSO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_PECAS_POR_PULSO(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PRIORIDADE_INFORMADA(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_PRIORIDADE_INFORMADA(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_ACAO(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            var query = _query.UpdateROT_ACAO(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PERFORMANCE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_PERFORMANCE(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_TEMPO_SETUP(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_TEMPO_SETUP(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_TEMPO_SETUP_AJUSTE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_TEMPO_SETUP_AJUSTE(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_VA_PARA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            var query = _query.UpdateROT_VA_PARA_SEQ_TRANSFORMACAO(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_STATUS(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            var query = _query.UpdateROT_STATUS(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_HIERARQUIA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_HIERARQUIA_SEQ_TRANSFORMACAO(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_AVALIA_CUSTO(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            var query = _query.UpdateROT_AVALIA_CUSTO(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            var query = _query.UpdateROT_OPERACOES(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_EXCECAO_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            var query = _query.UpdateROT_EXCECAO_OPERACOES(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            var query = _query.UpdateROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_LINHA_DIRETA(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            var query = _query.UpdateROT_LINHA_DIRETA(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            var query = _query.UpdateTEM_ID(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            var query = _query.UpdateTenantID(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string maq_id, string pro_id, int rot_seq_tranformacao, bool value)
        {
            var query = _query.UpdateDeleted(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string maq_id, string pro_id, int rot_seq_tranformacao, DateTime value)
        {
            var query = _query.UpdateChanged(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            var query = _query.UpdateUserId(maq_id, pro_id, rot_seq_tranformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration