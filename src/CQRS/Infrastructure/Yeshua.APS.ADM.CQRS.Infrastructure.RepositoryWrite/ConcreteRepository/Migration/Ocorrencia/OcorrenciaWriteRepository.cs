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

namespace Input.Repository.Ocorrencia
{
    public partial class OcorrenciaWriteRepository : IOcorrenciaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOcorrenciaQueryWrite _query; 

        public OcorrenciaWriteRepository(IUnitOfWork unitOfWork,IOcorrenciaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOcorrenciaEntity Ocorrencia)
        {
            var query = _query.InserirOcorrenciaQuery(Ocorrencia);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IOcorrenciaEntity Ocorrencia)
        {
            var query = _query.UpdateOcorrenciaQuery(Ocorrencia);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOcorrenciaEntity Ocorrencia)
        {
            var query = _query.DeleteOcorrenciaQuery(Ocorrencia);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_DESCRICAO(string oco_id, string value)
        {
            var query = _query.UpdateOCO_DESCRICAO(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(string oco_id, int value)
        {
            var query = _query.UpdateTIP_ID(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGMA_ID(string oco_id, string value)
        {
            var query = _query.UpdateGMA_ID(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(string oco_id, string value)
        {
            var query = _query.UpdateMAQ_ID(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSPR(string oco_id, int value)
        {
            var query = _query.UpdateSPR(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_SUB_TIPO(string oco_id, string value)
        {
            var query = _query.UpdateOCO_SUB_TIPO(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSUB_ID(string oco_id, string value)
        {
            var query = _query.UpdateSUB_ID(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string oco_id, int value)
        {
            var query = _query.UpdateTenantID(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string oco_id, bool value)
        {
            var query = _query.UpdateDeleted(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string oco_id, DateTime value)
        {
            var query = _query.UpdateChanged(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string oco_id, int value)
        {
            var query = _query.UpdateUserId(oco_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration