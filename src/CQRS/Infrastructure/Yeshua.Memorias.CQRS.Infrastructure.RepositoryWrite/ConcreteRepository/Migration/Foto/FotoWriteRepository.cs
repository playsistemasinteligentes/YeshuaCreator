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

namespace Input.Repository.Foto
{
    public partial class FotoWriteRepository : IFotoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IFotoQueryWrite _query; 

        public FotoWriteRepository(IUnitOfWork unitOfWork,IFotoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IFotoEntity Foto)
        {
            var query = _query.InserirFotoQuery(Foto);
        Foto.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IFotoEntity Foto)
        {
            var query = _query.UpdateFotoQuery(Foto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IFotoEntity Foto)
        {
            var query = _query.DeleteFotoQuery(Foto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStorageKey(int id, string value)
        {
            var query = _query.UpdateStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNomeOriginal(int id, string value)
        {
            var query = _query.UpdateNomeOriginal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateContentType(int id, string value)
        {
            var query = _query.UpdateContentType(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHashArquivo(int id, string value)
        {
            var query = _query.UpdateHashArquivo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCapturadaEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateCapturadaEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLargura(int id, int value)
        {
            var query = _query.UpdateLargura(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAltura(int id, int value)
        {
            var query = _query.UpdateAltura(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperationalEntityId(int id, string value)
        {
            var query = _query.UpdateOperationalEntityId(id, value);
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