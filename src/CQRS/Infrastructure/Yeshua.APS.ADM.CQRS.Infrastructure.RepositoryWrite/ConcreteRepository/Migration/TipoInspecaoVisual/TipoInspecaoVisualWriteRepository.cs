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

namespace Input.Repository.TipoInspecaoVisual
{
    public partial class TipoInspecaoVisualWriteRepository : ITipoInspecaoVisualWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoInspecaoVisualQueryWrite _query; 

        public TipoInspecaoVisualWriteRepository(IUnitOfWork unitOfWork,ITipoInspecaoVisualQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoInspecaoVisualEntity TipoInspecaoVisual)
        {
            var query = _query.InserirTipoInspecaoVisualQuery(TipoInspecaoVisual);
        TipoInspecaoVisual.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoInspecaoVisualEntity TipoInspecaoVisual)
        {
            var query = _query.UpdateTipoInspecaoVisualQuery(TipoInspecaoVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoInspecaoVisualEntity TipoInspecaoVisual)
        {
            var query = _query.DeleteTipoInspecaoVisualQuery(TipoInspecaoVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_ID(int id, int value)
        {
            var query = _query.UpdateTIV_ID(id, value);
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
        public void UpdateTIV_NOME(int id, string value)
        {
            var query = _query.UpdateTIV_NOME(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateTIV_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_FECHAMENTO(int id, string value)
        {
            var query = _query.UpdateTIV_FECHAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_AMOSTRA_ALEATORIA(int id, string value)
        {
            var query = _query.UpdateTIV_AMOSTRA_ALEATORIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_N_AMOSTRAS(int id, int value)
        {
            var query = _query.UpdateTIV_N_AMOSTRAS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_MEDIDA(int id, string value)
        {
            var query = _query.UpdateTIV_MEDIDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_ESPECIFICACAO(int id, Decimal value)
        {
            var query = _query.UpdateTIV_ESPECIFICACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_TOL_MAIS(int id, Decimal value)
        {
            var query = _query.UpdateTIV_TOL_MAIS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_TOL_MENOS(int id, Decimal value)
        {
            var query = _query.UpdateTIV_TOL_MENOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration