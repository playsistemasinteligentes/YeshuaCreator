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

namespace Input.Repository.RotaRealizada
{
    public partial class RotaRealizadaWriteRepository : IRotaRealizadaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRotaRealizadaQueryWrite _query; 

        public RotaRealizadaWriteRepository(IUnitOfWork unitOfWork,IRotaRealizadaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRotaRealizadaEntity RotaRealizada)
        {
            var query = _query.InserirRotaRealizadaQuery(RotaRealizada);
        RotaRealizada.ROT_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRotaRealizadaEntity RotaRealizada)
        {
            var query = _query.UpdateRotaRealizadaQuery(RotaRealizada);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRotaRealizadaEntity RotaRealizada)
        {
            var query = _query.DeleteRotaRealizadaQuery(RotaRealizada);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID(int rot_id, string value)
        {
            var query = _query.UpdateCAR_ID(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_DATA_HORA(int rot_id, DateTime value)
        {
            var query = _query.UpdateROT_DATA_HORA(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_LAT(int rot_id, Decimal value)
        {
            var query = _query.UpdateROT_LAT(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_LONG(int rot_id, Decimal value)
        {
            var query = _query.UpdateROT_LONG(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int rot_id, int value)
        {
            var query = _query.UpdateTenantID(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int rot_id, bool value)
        {
            var query = _query.UpdateDeleted(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int rot_id, DateTime value)
        {
            var query = _query.UpdateChanged(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int rot_id, int value)
        {
            var query = _query.UpdateUserId(rot_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration