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

namespace Input.Repository.LaudoTesteFisico
{
    public partial class LaudoTesteFisicoWriteRepository : ILaudoTesteFisicoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ILaudoTesteFisicoQueryWrite _query; 

        public LaudoTesteFisicoWriteRepository(IUnitOfWork unitOfWork,ILaudoTesteFisicoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ILaudoTesteFisicoEntity LaudoTesteFisico)
        {
            var query = _query.InserirLaudoTesteFisicoQuery(LaudoTesteFisico);
        LaudoTesteFisico.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ILaudoTesteFisicoEntity LaudoTesteFisico)
        {
            var query = _query.UpdateLaudoTesteFisicoQuery(LaudoTesteFisico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ILaudoTesteFisicoEntity LaudoTesteFisico)
        {
            var query = _query.DeleteLaudoTesteFisicoQuery(LaudoTesteFisico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLTF_ID(int id, int value)
        {
            var query = _query.UpdateLTF_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLTF_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateLTF_EMISSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLTF_VALOR(int id, Decimal value)
        {
            var query = _query.UpdateLTF_VALOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLTF_OBS(int id, string value)
        {
            var query = _query.UpdateLTF_OBS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLTF_STATUS(int id, string value)
        {
            var query = _query.UpdateLTF_STATUS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PRO_ID(int id, string value)
        {
            var query = _query.UpdateROT_PRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int id, int value)
        {
            var query = _query.UpdateUSE_ID(id, value);
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