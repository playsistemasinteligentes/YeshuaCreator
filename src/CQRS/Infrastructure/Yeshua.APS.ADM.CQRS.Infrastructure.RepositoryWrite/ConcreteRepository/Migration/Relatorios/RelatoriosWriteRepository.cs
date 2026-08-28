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

namespace Input.Repository.Relatorios
{
    public partial class RelatoriosWriteRepository : IRelatoriosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRelatoriosQueryWrite _query; 

        public RelatoriosWriteRepository(IUnitOfWork unitOfWork,IRelatoriosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRelatoriosEntity Relatorios)
        {
            var query = _query.InserirRelatoriosQuery(Relatorios);
        Relatorios.REL_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRelatoriosEntity Relatorios)
        {
            var query = _query.UpdateRelatoriosQuery(Relatorios);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRelatoriosEntity Relatorios)
        {
            var query = _query.DeleteRelatoriosQuery(Relatorios);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREL_NOME_RELATORIO(int rel_id, string value)
        {
            var query = _query.UpdateREL_NOME_RELATORIO(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREL_NOME_CAMPO(int rel_id, string value)
        {
            var query = _query.UpdateREL_NOME_CAMPO(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREL_TIPO_CAMPO(int rel_id, string value)
        {
            var query = _query.UpdateREL_TIPO_CAMPO(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREL_POS_X(int rel_id, int value)
        {
            var query = _query.UpdateREL_POS_X(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREL_POS_Y(int rel_id, int value)
        {
            var query = _query.UpdateREL_POS_Y(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREL_TAMANHO_FONTE(int rel_id, int value)
        {
            var query = _query.UpdateREL_TAMANHO_FONTE(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int rel_id, int value)
        {
            var query = _query.UpdateTenantID(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int rel_id, bool value)
        {
            var query = _query.UpdateDeleted(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int rel_id, DateTime value)
        {
            var query = _query.UpdateChanged(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int rel_id, int value)
        {
            var query = _query.UpdateUserId(rel_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration