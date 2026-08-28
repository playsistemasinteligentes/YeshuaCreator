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

namespace Input.Repository.InspecaoVisual
{
    public partial class InspecaoVisualWriteRepository : IInspecaoVisualWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IInspecaoVisualQueryWrite _query; 

        public InspecaoVisualWriteRepository(IUnitOfWork unitOfWork,IInspecaoVisualQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IInspecaoVisualEntity InspecaoVisual)
        {
            var query = _query.InserirInspecaoVisualQuery(InspecaoVisual);
        InspecaoVisual.IPV_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IInspecaoVisualEntity InspecaoVisual)
        {
            var query = _query.UpdateInspecaoVisualQuery(InspecaoVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IInspecaoVisualEntity InspecaoVisual)
        {
            var query = _query.DeleteInspecaoVisualQuery(InspecaoVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_VALOR(int ipv_id, string value)
        {
            var query = _query.UpdateIPV_VALOR(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_ID_OPERADOR(int ipv_id, int value)
        {
            var query = _query.UpdateIPV_ID_OPERADOR(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_ID_LIBERACAO(int ipv_id, int value)
        {
            var query = _query.UpdateIPV_ID_LIBERACAO(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_OBS(int ipv_id, string value)
        {
            var query = _query.UpdateIPV_OBS(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_DATA_COLETA(int ipv_id, DateTime value)
        {
            var query = _query.UpdateIPV_DATA_COLETA(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_DATA_AVAL(int ipv_id, DateTime value)
        {
            var query = _query.UpdateIPV_DATA_AVAL(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_ID(int ipv_id, int value)
        {
            var query = _query.UpdateTIV_ID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_ID(int ipv_id, string value)
        {
            var query = _query.UpdateTURN_ID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_ID(int ipv_id, string value)
        {
            var query = _query.UpdateTURM_ID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int ipv_id, string value)
        {
            var query = _query.UpdateORD_ID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PRO_ID(int ipv_id, string value)
        {
            var query = _query.UpdateROT_PRO_ID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_MAQ_ID(int ipv_id, string value)
        {
            var query = _query.UpdateROT_MAQ_ID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANSFORMACAO(int ipv_id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANSFORMACAO(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int ipv_id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_STATUS_LIBERACAO(int ipv_id, string value)
        {
            var query = _query.UpdateIPV_STATUS_LIBERACAO(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPV_VALOR_MEDIDA(int ipv_id, Decimal value)
        {
            var query = _query.UpdateIPV_VALOR_MEDIDA(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int ipv_id, int value)
        {
            var query = _query.UpdateTenantID(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int ipv_id, bool value)
        {
            var query = _query.UpdateDeleted(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int ipv_id, DateTime value)
        {
            var query = _query.UpdateChanged(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int ipv_id, int value)
        {
            var query = _query.UpdateUserId(ipv_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration