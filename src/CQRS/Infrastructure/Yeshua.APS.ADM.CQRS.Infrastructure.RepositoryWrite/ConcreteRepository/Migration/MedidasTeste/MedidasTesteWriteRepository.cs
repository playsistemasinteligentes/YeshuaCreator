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

namespace Input.Repository.MedidasTeste
{
    public partial class MedidasTesteWriteRepository : IMedidasTesteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMedidasTesteQueryWrite _query; 

        public MedidasTesteWriteRepository(IUnitOfWork unitOfWork,IMedidasTesteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMedidasTesteEntity MedidasTeste)
        {
            var query = _query.InserirMedidasTesteQuery(MedidasTeste);
        MedidasTeste.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMedidasTesteEntity MedidasTeste)
        {
            var query = _query.UpdateMedidasTesteQuery(MedidasTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMedidasTesteEntity MedidasTeste)
        {
            var query = _query.DeleteMedidasTesteQuery(MedidasTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDT_ID(int id, int value)
        {
            var query = _query.UpdateMDT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDT_DESC(int id, string value)
        {
            var query = _query.UpdateMDT_DESC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDT_VALOR_ESPERADO(int id, Decimal value)
        {
            var query = _query.UpdateMDT_VALOR_ESPERADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDT_ENCONTRADO(int id, Decimal value)
        {
            var query = _query.UpdateMDT_ENCONTRADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(int id, string value)
        {
            var query = _query.UpdateUNI_ID(id, value);
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