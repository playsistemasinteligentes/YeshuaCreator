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

namespace Input.Repository.TipoTeste
{
    public partial class TipoTesteWriteRepository : ITipoTesteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoTesteQueryWrite _query; 

        public TipoTesteWriteRepository(IUnitOfWork unitOfWork,ITipoTesteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoTesteEntity TipoTeste)
        {
            var query = _query.InserirTipoTesteQuery(TipoTeste);
        TipoTeste.TT_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoTesteEntity TipoTeste)
        {
            var query = _query.UpdateTipoTesteQuery(TipoTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoTesteEntity TipoTeste)
        {
            var query = _query.DeleteTipoTesteQuery(TipoTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_ESPECIFICACAO(int tt_id, Decimal value)
        {
            var query = _query.UpdateTT_ESPECIFICACAO(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_ORIGEM_ESPECIFICACAO(int tt_id, string value)
        {
            var query = _query.UpdateTT_ORIGEM_ESPECIFICACAO(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_IMPRIME_NO_LAUDO(int tt_id, string value)
        {
            var query = _query.UpdateTT_IMPRIME_NO_LAUDO(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int tt_id, int value)
        {
            var query = _query.UpdateTenantID(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int tt_id, bool value)
        {
            var query = _query.UpdateDeleted(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int tt_id, DateTime value)
        {
            var query = _query.UpdateChanged(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int tt_id, int value)
        {
            var query = _query.UpdateUserId(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_NOME(int tt_id, string value)
        {
            var query = _query.UpdateTT_NOME(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_DESC(int tt_id, string value)
        {
            var query = _query.UpdateTT_DESC(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_TOL_MAIS(int tt_id, Decimal value)
        {
            var query = _query.UpdateTT_TOL_MAIS(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_TOL_MENOS(int tt_id, Decimal value)
        {
            var query = _query.UpdateTT_TOL_MENOS(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_NORMA(int tt_id, string value)
        {
            var query = _query.UpdateTT_NORMA(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_INICIO_PROCESSO(int tt_id, string value)
        {
            var query = _query.UpdateTT_INICIO_PROCESSO(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTA_ID(int tt_id, int value)
        {
            var query = _query.UpdateTA_ID(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(int tt_id, string value)
        {
            var query = _query.UpdateUNI_ID(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_N_AMOSTRAS_P_TESTE(int tt_id, int value)
        {
            var query = _query.UpdateTT_N_AMOSTRAS_P_TESTE(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_MAX_DEF_CRITICO(int tt_id, int value)
        {
            var query = _query.UpdateTT_MAX_DEF_CRITICO(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_MAX_DEF_GRAVE(int tt_id, int value)
        {
            var query = _query.UpdateTT_MAX_DEF_GRAVE(tt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration