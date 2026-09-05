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

namespace Input.Repository.CertificadoDigital
{
    public partial class CertificadoDigitalWriteRepository : ICertificadoDigitalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICertificadoDigitalQueryWrite _query; 

        public CertificadoDigitalWriteRepository(IUnitOfWork unitOfWork,ICertificadoDigitalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICertificadoDigitalEntity CertificadoDigital)
        {
            var query = _query.InserirCertificadoDigitalQuery(CertificadoDigital);
        CertificadoDigital.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICertificadoDigitalEntity CertificadoDigital)
        {
            var query = _query.UpdateCertificadoDigitalQuery(CertificadoDigital);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICertificadoDigitalEntity CertificadoDigital)
        {
            var query = _query.DeleteCertificadoDigitalQuery(CertificadoDigital);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateApelido(int id, string value)
        {
            var query = _query.UpdateApelido(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumentoTitular(int id, string value)
        {
            var query = _query.UpdateDocumentoTitular(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStorageKey(int id, string value)
        {
            var query = _query.UpdateStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateThumbprint(int id, string value)
        {
            var query = _query.UpdateThumbprint(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidoDe(int id, DateTime value)
        {
            var query = _query.UpdateValidoDe(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidoAte(int id, DateTime value)
        {
            var query = _query.UpdateValidoAte(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAtivo(int id, int value)
        {
            var query = _query.UpdateAtivo(id, value);
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