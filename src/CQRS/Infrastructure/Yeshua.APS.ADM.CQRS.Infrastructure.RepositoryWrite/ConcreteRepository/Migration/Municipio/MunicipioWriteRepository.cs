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

namespace Input.Repository.Municipio
{
    public partial class MunicipioWriteRepository : IMunicipioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMunicipioQueryWrite _query; 

        public MunicipioWriteRepository(IUnitOfWork unitOfWork,IMunicipioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMunicipioEntity Municipio)
        {
            var query = _query.InserirMunicipioQuery(Municipio);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IMunicipioEntity Municipio)
        {
            var query = _query.UpdateMunicipioQuery(Municipio);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMunicipioEntity Municipio)
        {
            var query = _query.DeleteMunicipioQuery(Municipio);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_NOME(string mun_id, string value)
        {
            var query = _query.UpdateMUN_NOME(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUF_COD(string mun_id, string value)
        {
            var query = _query.UpdateUF_COD(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_CODIGO_IBGE(string mun_id, string value)
        {
            var query = _query.UpdateMUN_CODIGO_IBGE(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_LATITUDE(string mun_id, Decimal value)
        {
            var query = _query.UpdateMUN_LATITUDE(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_LONGITUDE(string mun_id, Decimal value)
        {
            var query = _query.UpdateMUN_LONGITUDE(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_ID_INTEGRACAO_ERP(string mun_id, string value)
        {
            var query = _query.UpdateMUN_ID_INTEGRACAO_ERP(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_CODIGO_SIAFI(string mun_id, string value)
        {
            var query = _query.UpdateMUN_CODIGO_SIAFI(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_CODIGO_CNPJ(string mun_id, string value)
        {
            var query = _query.UpdateMUN_CODIGO_CNPJ(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_DISTANCIA_KM(string mun_id, Decimal value)
        {
            var query = _query.UpdateMUN_DISTANCIA_KM(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string mun_id, int value)
        {
            var query = _query.UpdateTenantID(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string mun_id, bool value)
        {
            var query = _query.UpdateDeleted(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string mun_id, DateTime value)
        {
            var query = _query.UpdateChanged(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string mun_id, int value)
        {
            var query = _query.UpdateUserId(mun_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration