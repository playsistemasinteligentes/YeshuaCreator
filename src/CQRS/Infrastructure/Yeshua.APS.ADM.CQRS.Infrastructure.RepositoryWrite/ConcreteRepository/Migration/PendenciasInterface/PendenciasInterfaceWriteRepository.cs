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

namespace Input.Repository.PendenciasInterface
{
    public partial class PendenciasInterfaceWriteRepository : IPendenciasInterfaceWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPendenciasInterfaceQueryWrite _query; 

        public PendenciasInterfaceWriteRepository(IUnitOfWork unitOfWork,IPendenciasInterfaceQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPendenciasInterfaceEntity PendenciasInterface)
        {
            var query = _query.InserirPendenciasInterfaceQuery(PendenciasInterface);
        PendenciasInterface.PEN_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPendenciasInterfaceEntity PendenciasInterface)
        {
            var query = _query.UpdatePendenciasInterfaceQuery(PendenciasInterface);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPendenciasInterfaceEntity PendenciasInterface)
        {
            var query = _query.DeletePendenciasInterfaceQuery(PendenciasInterface);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEN_STATUS_OUT(int pen_id, string value)
        {
            var query = _query.UpdatePEN_STATUS_OUT(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEN_PROTOCOLO_OUT(int pen_id, string value)
        {
            var query = _query.UpdatePEN_PROTOCOLO_OUT(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEN_ID_PROTOCOLO_OUT(int pen_id, string value)
        {
            var query = _query.UpdatePEN_ID_PROTOCOLO_OUT(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEN_STATUS_IN(int pen_id, string value)
        {
            var query = _query.UpdatePEN_STATUS_IN(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEN_PROTOCOLO_IN(int pen_id, string value)
        {
            var query = _query.UpdatePEN_PROTOCOLO_IN(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePEN_ID_PROTOCOLO_IN(int pen_id, string value)
        {
            var query = _query.UpdatePEN_ID_PROTOCOLO_IN(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDATA_ENTRADA(int pen_id, DateTime value)
        {
            var query = _query.UpdateDATA_ENTRADA(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int pen_id, int value)
        {
            var query = _query.UpdateTenantID(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int pen_id, bool value)
        {
            var query = _query.UpdateDeleted(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int pen_id, DateTime value)
        {
            var query = _query.UpdateChanged(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int pen_id, int value)
        {
            var query = _query.UpdateUserId(pen_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration