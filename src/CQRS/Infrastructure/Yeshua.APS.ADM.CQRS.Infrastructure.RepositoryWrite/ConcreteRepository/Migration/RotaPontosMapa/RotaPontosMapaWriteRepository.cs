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

namespace Input.Repository.RotaPontosMapa
{
    public partial class RotaPontosMapaWriteRepository : IRotaPontosMapaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRotaPontosMapaQueryWrite _query; 

        public RotaPontosMapaWriteRepository(IUnitOfWork unitOfWork,IRotaPontosMapaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRotaPontosMapaEntity RotaPontosMapa)
        {
            var query = _query.InserirRotaPontosMapaQuery(RotaPontosMapa);
        RotaPontosMapa.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRotaPontosMapaEntity RotaPontosMapa)
        {
            var query = _query.UpdateRotaPontosMapaQuery(RotaPontosMapa);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRotaPontosMapaEntity RotaPontosMapa)
        {
            var query = _query.DeleteRotaPontosMapaQuery(RotaPontosMapa);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_ID(int id, string value)
        {
            var query = _query.UpdateROT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_ID_DESTINO(int id, string value)
        {
            var query = _query.UpdatePON_ID_DESTINO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_ID_ORIGEM(int id, string value)
        {
            var query = _query.UpdatePON_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_CUSTO_TOTAL(int id, Decimal value)
        {
            var query = _query.UpdateROT_CUSTO_TOTAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_ID_ROTEIRO(int id, string value)
        {
            var query = _query.UpdatePON_ID_ROTEIRO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_ORDEM_ROTEIRO(int id, int value)
        {
            var query = _query.UpdateROT_ORDEM_ROTEIRO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_TIPO(int id, string value)
        {
            var query = _query.UpdateROT_TIPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_DISTANCIA(int id, Decimal value)
        {
            var query = _query.UpdateROT_DISTANCIA(id, value);
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